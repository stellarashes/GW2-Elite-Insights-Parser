﻿using System.Numerics;
using GW2EIEvtcParser.EIData;
using GW2EIEvtcParser.Exceptions;
using GW2EIEvtcParser.Extensions;
using GW2EIEvtcParser.ParsedData;
using GW2EIEvtcParser.ParserHelpers;
using static GW2EIEvtcParser.ArcDPSEnums;
using static GW2EIEvtcParser.EncounterLogic.EncounterLogicPhaseUtils;
using static GW2EIEvtcParser.EncounterLogic.EncounterLogicTimeUtils;
using static GW2EIEvtcParser.ParserHelper;
using static GW2EIEvtcParser.ParserHelpers.EncounterImages;
using static GW2EIEvtcParser.SkillIDs;
using static GW2EIEvtcParser.SpeciesIDs;

namespace GW2EIEvtcParser.EncounterLogic;

internal class Xera : StrongholdOfTheFaithful
{

    private long _xeraSecondPhaseStartTime = long.MaxValue;
    private bool _hasSecondPhase => _xeraSecondPhaseStartTime != long.MaxValue;
    private long _xeraFirstPhaseEndTime = long.MaxValue;
    private bool _hasSplitPhase => _xeraFirstPhaseEndTime != long.MaxValue;
    private bool _hasPreEvent = false;
    private long _xeraFirstPhaseStart = 0;

    public Xera(int triggerID) : base(triggerID)
    {
        MechanicList.Add(new MechanicGroup([
            new MechanicGroup([
                new PlayerDstHitMechanic(TemporalShredOrb, new MechanicPlotlySetting(Symbols.Circle,Colors.Red), "Orb", "Temporal Shred (Hit by Red Orb)","Red Orb", 0),
                new PlayerDstHitMechanic(TemporalShredAoE, new MechanicPlotlySetting(Symbols.CircleOpen,Colors.Red), "Orb Aoe", "Temporal Shred (Stood in Orb Aoe)","Orb AoE", 0),
            ]),
            new PlayerDstBuffApplyMechanic(BloodstoneProtection, new MechanicPlotlySetting(Symbols.HourglassOpen,Colors.DarkPurple), "In Bubble", "Bloodstone Protection (Stood in Bubble)","Inside Bubble", 0),
            new MechanicGroup([
                new EnemyCastStartMechanic(SummonFragments, new MechanicPlotlySetting(Symbols.DiamondTall,Colors.DarkTeal), "CC", "Summon Fragment (Xera Breakbar)","Breakbar", 0),
                new EnemyCastEndMechanic(SummonFragments, new MechanicPlotlySetting(Symbols.DiamondTall,Colors.Red), "CC Fail", "Summon Fragment (Failed CC)","CC Fail", 0)
                    .UsingChecker( (ce,log) => ce.ActualDuration > 11940),
                new EnemyCastEndMechanic(SummonFragments, new MechanicPlotlySetting(Symbols.DiamondTall,Colors.DarkGreen), "CCed", "Summon Fragment (Breakbar broken)","CCed", 0)
                    .UsingChecker( (ce, log) => ce.ActualDuration <= 11940),
            ]),
            new PlayerDstBuffApplyMechanic(Derangement, new MechanicPlotlySetting(Symbols.SquareOpen,Colors.LightPurple), "Stacks", "Derangement (Stacking Debuff)","Derangement", 0),
            new MechanicGroup([
                new PlayerDstBuffApplyMechanic(BendingChaos, new MechanicPlotlySetting(Symbols.TriangleDownOpen,Colors.Yellow), "Button1", "Bending Chaos (Stood on 1st Button)","Button 1", 0),
                new PlayerDstBuffApplyMechanic(ShiftingChaos, new MechanicPlotlySetting(Symbols.TriangleNEOpen,Colors.Yellow), "Button2", "Bending Chaos (Stood on 2nd Button)","Button 2", 0),
                new PlayerDstBuffApplyMechanic(TwistingChaos, new MechanicPlotlySetting(Symbols.TriangleNWOpen,Colors.Yellow), "Button3", "Bending Chaos (Stood on 3rd Button)","Button 3", 0),
            ]),
            new PlayerDstBuffApplyMechanic(InterventionSkillOwnerBuff, new MechanicPlotlySetting(Symbols.Square,Colors.Blue), "Shield", "Intervention (got Special Action Key)","Shield", 0),
            new PlayerDstBuffApplyMechanic(GravityWellXera, new MechanicPlotlySetting(Symbols.CircleXOpen,Colors.Magenta), "Gravity Half", "Half-platform Gravity Well","Gravity Well", 4000),
            new MechanicGroup([
                new PlayerDstBuffApplyMechanic(HerosDeparture, new MechanicPlotlySetting(Symbols.Circle,Colors.DarkGreen), "TP Out", "Hero's Departure (Teleport to Platform)","TP",0),
                new PlayerDstBuffApplyMechanic(HerosReturn, new MechanicPlotlySetting(Symbols.Circle,Colors.Green), "TP Back", "Hero's Return (Teleport back)","TP back", 0),
            ]),
            /*new Mechanic(Intervention, "Intervention", ParseEnum.BossIDS.Xera, new MechanicPlotlySetting(Symbols.Hourglass,"rgb(128,0,128)"), "Bubble",0),*/
            //new Mechanic(Disruption, "Disruption", ParseEnum.BossIDS.Xera, new MechanicPlotlySetting(Symbols.Square,Colors.DarkGreen), "TP",0), 
            //Not sure what this (ID 350342,"Disruption") is. Looks like it is the pulsing "orb removal" from the orange circles on the 40% platform. Would fit the name although it's weird it can hit players. 
        ]));
        Extension = "xera";
        GenericFallBackMethod = FallBackMethod.Death | FallBackMethod.CombatExit;
        Icon = EncounterIconXera;
        EncounterCategoryInformation.InSubCategoryOrder = 3;
        EncounterID |= 0x000004;
    }

    protected override CombatReplayMap GetCombatMapInternal(ParsedEvtcLog log)
    {
        return new CombatReplayMap(CombatReplayXera,
                        (1000, 897),
                        (-5992, -5992, 69, -522)/*,
                        (-12288, -27648, 12288, 27648),
                        (1920, 12160, 2944, 14464)*/);
    }

    internal override List<InstantCastFinder> GetInstantCastFinders()
    {
        return
        [
            new EffectCastFinder(InterventionSAK, EffectGUIDs.XeraIntervention1),
        ];
    }

    internal override List<BuffEvent> SpecialBuffEventProcess(CombatData combatData, SkillData skillData)
    {
        SingleActor mainTarget = GetMainTarget() ?? throw new MissingKeyActorsException("Xera not found");
        var res = new List<BuffEvent>();
        if (_hasSplitPhase)
        {
            res.Add(new BuffRemoveAllEvent(_unknownAgent, mainTarget.AgentItem, _xeraFirstPhaseEndTime, int.MaxValue, skillData.Get(Determined762), IFF.Unknown, 1, int.MaxValue));
            res.Add(new BuffRemoveManualEvent(_unknownAgent, mainTarget.AgentItem, _xeraFirstPhaseEndTime, int.MaxValue, skillData.Get(Determined762), IFF.Unknown));
        }
        return res;
    }

    internal override void CheckSuccess(CombatData combatData, AgentData agentData, FightData fightData, IReadOnlyCollection<AgentItem> playerAgents)
    {
        if (!_hasSecondPhase)
        {
            return;
        }
        base.CheckSuccess(combatData, agentData, fightData, playerAgents);
        if (fightData.Success && fightData.FightEnd < _xeraSecondPhaseStartTime)
        {
            fightData.SetSuccess(false, fightData.LogEnd);
        }
    }

    internal override List<PhaseData> GetPhases(ParsedEvtcLog log, bool requirePhases)
    {
        long fightEnd = log.FightData.FightEnd;
        List<PhaseData> phases = GetInitialPhase(log);
        SingleActor mainTarget = GetMainTarget() ?? throw new MissingKeyActorsException("Xera not found");
        phases[0].AddTarget(mainTarget, log);
        if (requirePhases)
        {
            PhaseData? phase100to0 = null;
            if (_xeraFirstPhaseStart > 0)
            {
                var phasePreEvent = new PhaseData(0, _xeraFirstPhaseStart, "Pre Event");
                phasePreEvent.AddParentPhase(phases[0]);
                phasePreEvent.AddTargets(Targets.Where(x => x.IsSpecies(TargetID.BloodstoneShardButton) || x.IsSpecies(TargetID.BloodstoneShardRift)), log);
                phasePreEvent.AddTarget(Targets.FirstOrDefault(x => x.IsSpecies(TargetID.DummyTarget)), log);
                phases.Add(phasePreEvent);
                phase100to0 = new PhaseData(_xeraFirstPhaseStart, log.FightData.FightEnd, "Main Fight");
                phase100to0.AddParentPhase(phases[0]);
                phase100to0.AddTarget(mainTarget, log);
                phases.Add(phase100to0);
            }
            BuffEvent? invulXera = GetInvulXeraEvent(log, mainTarget);
            // split happened
            if (invulXera != null)
            {
                var phase1 = new PhaseData(_xeraFirstPhaseStart, invulXera.Time, "Phase 1");
                if (phase100to0 != null)
                {
                    phase1.AddParentPhase(phase100to0);
                } 
                else
                {
                    phase1.AddParentPhase(phases[0]);
                }
                phase1.AddTarget(mainTarget, log);
                phases.Add(phase1);

                long glidingEndTime = _hasSecondPhase ? _xeraSecondPhaseStartTime : fightEnd;
                var glidingPhase = new PhaseData(invulXera.Time, glidingEndTime, "Gliding");
                if (phase100to0 != null)
                {
                    glidingPhase.AddParentPhase(phase100to0);
                }
                else
                {
                    glidingPhase.AddParentPhase(phases[0]);
                }
                glidingPhase.AddTargets(Targets.Where(t => t.IsSpecies(TargetID.ChargedBloodstone)), log);
                phases.Add(glidingPhase);

                if (_hasSecondPhase)
                {
                    var phase2 = new PhaseData(_xeraSecondPhaseStartTime, fightEnd, "Phase 2");
                    if (phase100to0 != null)
                    {
                        phase2.AddParentPhase(phase100to0);
                    } 
                    else
                    {
                        phase2.AddParentPhase(phases[0]);
                    }
                    phase2.AddTarget(mainTarget, log);
                    phase2.AddTargets(Targets.Where(t => t.IsSpecies(TargetID.BloodstoneShardMainFight)), log);
                    //mainTarget.AddCustomCastLog(end, -5, (int)(start - end), ParseEnum.Activation.None, (int)(start - end), ParseEnum.Activation.None, log);
                    phases.Add(phase2);
                }
            }
        }
        return phases;
    }

    private SingleActor? GetMainTarget() => Targets.FirstOrDefault(x => x.IsSpecies(TargetID.Xera));

    private static BuffEvent? GetInvulXeraEvent(ParsedEvtcLog log, SingleActor xera)
    {
        BuffEvent? determined = log.CombatData.GetBuffDataByIDByDst(Determined762, xera.AgentItem).FirstOrDefault(x => x is BuffApplyEvent) ?? log.CombatData.GetBuffDataByIDByDst(SpawnProtection, xera.AgentItem).FirstOrDefault(x => x is BuffApplyEvent);
        return determined;
    }

    internal override long GetFightOffset(EvtcVersionEvent evtcVersion, FightData fightData, AgentData agentData, List<CombatItem> combatData)
    {
        if (!agentData.TryGetFirstAgentItem(TargetID.Xera, out var xera))
        {
            throw new MissingKeyActorsException("Xera not found");
        }
        // enter combat
        CombatItem? enterCombat = combatData.Find(x => x.SrcMatchesAgent(xera) && x.IsStateChange == StateChange.EnterCombat);
        if (enterCombat != null)
        {
            if (agentData.TryGetFirstAgentItem(TargetID.FakeXera, out var fakeXera))
            {
                _hasPreEvent = true;
                long encounterStart = fakeXera.LastAware;
                CombatItem ?death = combatData.LastOrDefault(x => x.IsStateChange == StateChange.ChangeDead && x.SrcMatchesAgent(fakeXera));
                if (death != null)
                {
                    encounterStart = death.Time + 1000;
                } 
                else
                {
                    CombatItem? exitCombat = combatData.LastOrDefault(x => x.IsStateChange == StateChange.ExitCombat && x.SrcMatchesAgent(fakeXera));
                    if (exitCombat != null)
                    {
                        encounterStart = exitCombat.Time + 1000;
                    }
                }
                _xeraFirstPhaseStart = enterCombat.Time - encounterStart;
                return encounterStart;
            }
            return enterCombat.Time;
        }
        return GetGenericFightOffset(fightData);
    }

    internal override void EIEvtcParse(ulong gw2Build, EvtcVersionEvent evtcVersion, FightData fightData, AgentData agentData, List<CombatItem> combatData, IReadOnlyDictionary<uint, ExtensionHandler> extensions)
    {
        bool mayRequireDummy = true;
        // find target
        if (!agentData.TryGetFirstAgentItem(TargetID.Xera, out var firstXera))
        {
            throw new MissingKeyActorsException("Xera not found");
        }
        _xeraFirstPhaseEndTime = firstXera.LastAware;
        //
        var maxHPUpdates = combatData.Where(x => x.IsStateChange == StateChange.MaxHealthUpdate).Select(x => new MaxHealthUpdateEvent(x, agentData)).ToList();
        //
        var bloodstoneFragments = maxHPUpdates.Where(x => x.MaxHealth == 104580).Select(x => x.Src).Where(x => x.Type == AgentItem.AgentType.Gadget);
        foreach (AgentItem gadget in bloodstoneFragments)
        {
            gadget.OverrideType(AgentItem.AgentType.NPC, agentData);
            gadget.OverrideID(TargetID.BloodstoneFragment, agentData);
        }
        //
        var bloodstoneShardsMainFight = maxHPUpdates.Where(x => x.MaxHealth == 343620).Select(x => x.Src).Where(x => x.Type == AgentItem.AgentType.Gadget);
        foreach (AgentItem gadget in bloodstoneShardsMainFight)
        {
            gadget.OverrideType(AgentItem.AgentType.NPC, agentData);
            gadget.OverrideID(TargetID.BloodstoneShardMainFight, agentData);
        }
        //
        var bloodstoneShardsButton = maxHPUpdates.Where(x => x.MaxHealth == 597600).Select(x => x.Src).Where(x => x.Type == AgentItem.AgentType.Gadget);
        foreach (AgentItem gadget in bloodstoneShardsButton)
        {
            gadget.OverrideType(AgentItem.AgentType.NPC, agentData);
            gadget.OverrideID(TargetID.BloodstoneShardButton, agentData);
            mayRequireDummy = false;
        }
        //
        var bloodstoneShardsRift = maxHPUpdates.Where(x => x.MaxHealth == 747000).Select(x => x.Src).Where(x => x.Type == AgentItem.AgentType.Gadget);
        foreach (AgentItem gadget in bloodstoneShardsRift)
        {
            gadget.OverrideType(AgentItem.AgentType.NPC, agentData);
            gadget.OverrideID(TargetID.BloodstoneShardRift, agentData);
            mayRequireDummy = false;
        }
        //
        var chargedBloodStones = maxHPUpdates.Where(x => x.MaxHealth == 74700).Select(x => x.Src).Where(x => x.Type == AgentItem.AgentType.Gadget && x.LastAware > firstXera.LastAware);
        foreach (AgentItem gadget in chargedBloodStones)
        {
            if (!combatData.Any(x => x.IsDamage() && x.DstMatchesAgent(gadget)))
            {
                continue;
            }
            gadget.OverrideType(AgentItem.AgentType.NPC, agentData);
            gadget.OverrideID(TargetID.ChargedBloodstone, agentData);
        }
        if (_hasPreEvent && mayRequireDummy)
        {
            agentData.AddCustomNPCAgent(fightData.FightStart, _xeraFirstPhaseStart, "Xera Pre Event", Spec.NPC, TargetID.DummyTarget, true);
        }
        // find split
        if (agentData.TryGetFirstAgentItem(TargetID.Xera2, out var secondXera))
        {
            CombatItem? move = combatData.FirstOrDefault(x => x.IsStateChange == StateChange.Position && x.SrcMatchesAgent(secondXera) && x.Time >= secondXera.FirstAware + 500);
            if (move != null)
            {
                _xeraSecondPhaseStartTime = move.Time;
            }
            else
            {
                _xeraSecondPhaseStartTime = secondXera.FirstAware;
            }
            firstXera.OverrideAwareTimes(firstXera.FirstAware, secondXera.LastAware);
            RedirectAllEvents(combatData, extensions, agentData, secondXera, firstXera);
        }
        base.EIEvtcParse(gw2Build, evtcVersion, fightData, agentData, combatData, extensions);
        // Xera gains hp at 50%, total hp of the encounter is not the initial hp of Xera
        SingleActor mainTarget = GetMainTarget() ?? throw new MissingKeyActorsException("Xera not found");
        mainTarget.SetManualHealth(24085950, new List<(long hpValue, double percent)>()
        {
            (22611300, 100),
            (25560600, 50)
        });
    }

    internal override FightData.EncounterStartStatus GetEncounterStartStatus(CombatData combatData, AgentData agentData, FightData fightData)
    {
        // We expect pre event with logs with LogStartNPCUpdate events
        if (!_hasPreEvent && combatData.GetLogNPCUpdateEvents().Any())
        {
            return FightData.EncounterStartStatus.NoPreEvent;
        }
        else
        {
            return FightData.EncounterStartStatus.Normal;
        }
    }

    protected override IReadOnlyList<TargetID>  GetTargetsIDs()
    {
        return [
            TargetID.Xera,
            TargetID.DummyTarget,
            TargetID.BloodstoneShardMainFight,
            TargetID.BloodstoneShardRift,
            TargetID.BloodstoneShardButton,
            TargetID.ChargedBloodstone,
        ];
    }

    protected override IReadOnlyList<TargetID> GetTrashMobsIDs()
    {
        return
        [
            TargetID.WhiteMantleSeeker1,
            TargetID.WhiteMantleSeeker2,
            TargetID.WhiteMantleKnight1,
            TargetID.WhiteMantleKnight2,
            TargetID.WhiteMantleBattleMage1,
            TargetID.WhiteMantleBattleMage2,
            TargetID.BloodstoneFragment,
            TargetID.ExquisiteConjunction,
            TargetID.XerasPhantasm,
        ];
    }

    internal override void ComputeNPCCombatReplayActors(NPC target, ParsedEvtcLog log, CombatReplay replay)
    {
        switch (target.ID)
        {
            case (int)TargetID.Xera:
                foreach (CastEvent cast in target.GetAnimatedCastEvents(log, log.FightData.FightStart, log.FightData.FightEnd))
                {
                    switch (cast.SkillId)
                    {
                        case SummonFragments:
                            replay.Decorations.Add(new CircleDecoration(180, (cast.Time, cast.EndTime), Colors.LightBlue, 0.3, new AgentConnector(target)));
                            break;
                        default:
                            break;
                    }
                }
                if (_hasSplitPhase)
                {
                    replay.Hidden.Add(new(_xeraFirstPhaseEndTime, _hasSecondPhase ? _xeraSecondPhaseStartTime - 500 : log.FightData.LogEnd));
                }
                break;
            case (int)TargetID.ChargedBloodstone:
                if (_hasSplitPhase)
                {
                    long end = replay.TimeOffsets.end;
                    HealthDamageEvent? lastDamage = target.GetDamageTakenEvents(null, log, 0, log.FightData.FightEnd).LastOrDefault();
                    if (lastDamage != null)
                    {
                        end = lastDamage.Time;
                    }
                    replay.Trim(_xeraFirstPhaseEndTime + 12000, end);
                }
                break;
            case (int)TargetID.BloodstoneFragment:
                replay.Decorations.Add(new CircleDecoration(760, (replay.TimeOffsets.start, replay.TimeOffsets.end), Colors.LightOrange, 0.2, new AgentConnector(target)));
                break;
            default:
                break;
        }
    }

    internal override void ComputePlayerCombatReplayActors(PlayerActor player, ParsedEvtcLog log, CombatReplay replay)
    {
        base.ComputePlayerCombatReplayActors(player, log, replay);
        // Derangement - 0 to 29 nothing, 30 to 59 Silver, 60 to 89 Gold, 90 to 99 Red
        var derangements = player.GetBuffStatus(log, Derangement, log.FightData.LogStart, log.FightData.LogEnd).Where(x => x.Value > 0);
        foreach (var segment in derangements)
        {
            if (segment.Value >= 90)
            {
                replay.Decorations.AddOverheadIcon(segment, player, ParserIcons.DerangementRedOverhead);
            }
            else if (segment.Value >= 60)
            {
                replay.Decorations.AddOverheadIcon(segment, player, ParserIcons.DerangementGoldOverhead);
            }
            else if (segment.Value >= 30)
            {
                replay.Decorations.AddOverheadIcon(segment, player, ParserIcons.DerangementSilverOverhead);
            }
        }
    }

    internal override void ComputeEnvironmentCombatReplayDecorations(ParsedEvtcLog log)
    {
        base.ComputeEnvironmentCombatReplayDecorations(log);

        // Intervention Bubble
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.XeraIntervention1, out var intervention))
        {
            foreach (EffectEvent effect in intervention)
            {
                // Effect has duration of 4294967295 but the skill lasts only 6000
                (long, long) lifespan = effect.ComputeDynamicLifespan(log, 6000);
                var circle = new CircleDecoration(240, lifespan, Colors.Yellow, 0.3, new PositionConnector(effect.Position));
                EnvironmentDecorations.Add(circle);
                EnvironmentDecorations.Add(circle.GetBorderDecoration(Colors.LightBlue, 0.4));
            }
        }

        // Gravity Well
        // TODO: Find the correct effect, this is wrong
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.XeraHalfArenaGravityWell, out var halfGravityWells))
        {
            var cur = 0;
            var pos = new PositionConnector(new Vector3(-3020.77f, -3153.32f, -20338.6f));
            bool resetCurForSecondPhase = true;
            foreach (var halfGravityWell in halfGravityWells)
            {
                // Float happens after 7000 ms, extra 500ms to display the hit
                float angle = 0;
                (long start, long end) lifespan = (halfGravityWell.Time, halfGravityWell.Time + 7500);
                (long start, long end) lifespanIndicator = (halfGravityWell.Time, halfGravityWell.Time + 7000);
                bool hasFired = true;
                if (halfGravityWell.Time < _xeraFirstPhaseEndTime)
                {
                    angle = -30 + (cur++) * 90;
                    if (lifespanIndicator.end > _xeraFirstPhaseEndTime)
                    {
                        hasFired = false;
                    }
                    lifespan.end = Math.Min(lifespan.end, _xeraFirstPhaseEndTime);
                }
                else
                {
                    if (cur > 0 && resetCurForSecondPhase)
                    {
                        cur = 0;
                        resetCurForSecondPhase = false;
                    }
                    angle = -210 - (cur++) * 90;
                }
                var angleConnector = new AngleConnector(angle);
                EnvironmentDecorations.AddWithFilledWithGrowing(
                        (PieDecoration)new PieDecoration(1150, 180, lifespan, Colors.Purple, 0.15, pos)
                            .UsingRotationConnector(angleConnector),
                        true,
                        lifespanIndicator.end
                );
                if (hasFired)
                {
                    EnvironmentDecorations.Add((PieDecoration)new PieDecoration(1150, 180, (lifespanIndicator.end, lifespanIndicator.end + 500), Colors.Purple, 0.2, pos)
                            .UsingRotationConnector(angleConnector));
                }
            }
        }

        // Temporal Shred Projectiles
        var temporalShred = log.CombatData.GetMissileEventsBySkillID(TemporalShredOrb);
        EnvironmentDecorations.AddNonHomingMissiles(log, temporalShred, Colors.Red, 0.3, 25);

        // Temporal Shred AoE
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.XeraTemporalShredAoE, out var temporalShredAoEs))
        {
            foreach (EffectEvent effect in temporalShredAoEs)
            {
                (long start, long end) lifespan = effect.ComputeLifespan(log, 1500);
                EnvironmentDecorations.AddWithBorder(new CircleDecoration(120, lifespan, Colors.LightPurple, 0.2, new PositionConnector(effect.Position)), Colors.Red, 0.2);
            }
        }
    }
}
