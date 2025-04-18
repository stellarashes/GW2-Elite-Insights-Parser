﻿using GW2EIEvtcParser.EIData;
using GW2EIEvtcParser.Exceptions;
using GW2EIEvtcParser.Extensions;
using GW2EIEvtcParser.ParsedData;
using GW2EIEvtcParser.ParserHelpers;
using static GW2EIEvtcParser.ArcDPSEnums;
using static GW2EIEvtcParser.EncounterLogic.EncounterLogicPhaseUtils;
using static GW2EIEvtcParser.EncounterLogic.EncounterLogicUtils;
using static GW2EIEvtcParser.ParserHelpers.EncounterImages;
using static GW2EIEvtcParser.SkillIDs;
using static GW2EIEvtcParser.SpeciesIDs;

namespace GW2EIEvtcParser.EncounterLogic;

internal class Eparch : LonelyTower
{
    public Eparch(int triggerID) : base(triggerID)
    {
        MechanicList.AddRange(
        [
        ]);
        Extension = "eparch";
        Icon = EncounterIconEparch;
        EncounterCategoryInformation.InSubCategoryOrder = 1;
        EncounterID |= 0x000002;
    }

    internal override FightData.EncounterMode GetEncounterMode(CombatData combatData, AgentData agentData, FightData fightData)
    {
        ulong build = combatData.GetGW2BuildEvent().Build;
        int healthCMRelease = build >= GW2Builds.June2024Balance ? 22_833_236 : 32_618_906;
        int healthThreshold = (int)(0.95 * healthCMRelease); // fractals lose hp as their scale lowers
        SingleActor eparch = GetEparchActor();
        if (build >= GW2Builds.June2024LonelyTowerCMRelease && eparch.GetHealth(combatData) >= healthThreshold)
        {
            return FightData.EncounterMode.CM;
        }
        else
        {
            return FightData.EncounterMode.Normal;
        }
    }

    internal override string GetLogicName(CombatData combatData, AgentData agentData)
    {
        return "Eparch";
    }

    internal override void EIEvtcParse(ulong gw2Build, EvtcVersionEvent evtcVersion, FightData fightData, AgentData agentData, List<CombatItem> combatData, IReadOnlyDictionary<uint, ExtensionHandler> extensions)
    {
        var dummyEparchs = agentData.GetNPCsByID(TargetID.EparchLonelyTower).Where(eparch =>
        {
            return !combatData.Any(x => x.SrcMatchesAgent(eparch) && x.StartCasting() && x.SkillID != WeaponDraw && x.SkillID != WeaponStow);
        });
        foreach (var dummyEparch in dummyEparchs)
        {
            dummyEparch.OverrideID(IgnoredSpecies, agentData);
        }
        //
        var riftAgents = combatData.Where(x => MaxHealthUpdateEvent.GetMaxHealth(x) == 149400 && x.IsStateChange == StateChange.MaxHealthUpdate).Select(x => agentData.GetAgent(x.SrcAgent, x.Time)).Where(x => x.Type == AgentItem.AgentType.Gadget && x.FirstAware > fightData.FightStart + 5000);
        foreach (var riftAgent in riftAgents)
        {
            riftAgent.OverrideID(TargetID.KryptisRift, agentData);
            riftAgent.OverrideType(AgentItem.AgentType.NPC, agentData);
        }
        //

        base.EIEvtcParse(gw2Build, evtcVersion, fightData, agentData, combatData, extensions);
        int[] miniBossCount = [1, 1, 1, 1];
        foreach (NPC target in Targets)
        {
            switch (target.ID)
            {
                case (int)TargetID.KryptisRift:
                    target.OverrideName(target.Character + " " + miniBossCount[0]++);
                    break;
                case (int)TargetID.IncarnationOfCruelty:
                    target.OverrideName(target.Character + " " + miniBossCount[1]++);
                    break;
                case (int)TargetID.IncarnationOfJudgement:
                    target.OverrideName(target.Character + " " + miniBossCount[2]++);
                    break;
                case (int)TargetID.AvatarOfSpite:
                    target.OverrideName(target.Character + " " + miniBossCount[3]++);
                    break;
            }
        }
    }

    internal override void CheckSuccess(CombatData combatData, AgentData agentData, FightData fightData, IReadOnlyCollection<AgentItem> playerAgents)
    {
        SingleActor eparch = GetEparchActor();
        var determinedApplies = combatData.GetBuffDataByIDByDst(Determined762, eparch.AgentItem).OfType<BuffApplyEvent>().ToList();
        if (fightData.IsCM && determinedApplies.Count >= 3)
        {
            fightData.SetSuccess(true, determinedApplies[2].Time);
        } 
        else if (!fightData.IsCM && determinedApplies.Count >= 1)
        {
            fightData.SetSuccess(true, determinedApplies[0].Time);
        }
    }

    internal override List<PhaseData> GetPhases(ParsedEvtcLog log, bool requirePhases)
    {
        List<PhaseData> phases = GetInitialPhase(log);
        SingleActor eparch = GetEparchActor();
        phases[0].AddTarget(eparch);
        phases[0].AddTargets(Targets.Where(x => x.IsSpecies(TargetID.IncarnationOfCruelty) || x.IsSpecies(TargetID.IncarnationOfJudgement)), PhaseData.TargetPriority.Blocking);
        if (!requirePhases || !log.FightData.IsCM)
        {
            return phases;
        }
        phases.AddRange(GetPhasesByInvul(log, Determined762, eparch, true, true));
        for (int i = 1; i < phases.Count; i++)
        {
            PhaseData phase = phases[i];
            phase.AddParentPhase(phases[0]);
            if (i % 2 == 0)
            {
                phase.Name = "Split " + i / 2;
                var ids = new List<TargetID>
                {
                    TargetID.IncarnationOfCruelty,
                    TargetID.IncarnationOfJudgement,
                    TargetID.KryptisRift,
                };
                AddTargetsToPhase(phase, ids);
            }
            else
            {
                phase.Name = "Phase " + (i + 1) / 2;
                phase.AddTarget(eparch);
            }
        }
        return phases;
    }

    protected override ReadOnlySpan<TargetID> GetTargetsIDs()
    {
        return
        [
            TargetID.EparchLonelyTower,
            TargetID.IncarnationOfCruelty,
            TargetID.IncarnationOfJudgement,
            TargetID.AvatarOfSpite,
            TargetID.KryptisRift,
        ];
    }

    protected override Dictionary<TargetID, int> GetTargetsSortIDs()
    {
        return new Dictionary<TargetID, int>()
        {
            {TargetID.EparchLonelyTower, 0},
            {TargetID.KryptisRift, 1},
            {TargetID.IncarnationOfCruelty, 2},
            {TargetID.IncarnationOfJudgement, 2},
            {TargetID.AvatarOfSpite, 3},
        };
    }

    protected override List<TargetID> GetTrashMobsIDs()
    {
        return
        [
            TargetID.TheTormentedLonelyTower,
            TargetID.TheCravenLonelyTower,
        ];
    }

    private SingleActor GetEparchActor()
    {
        SingleActor eparch = Targets.FirstOrDefault(x => x.IsSpecies(TargetID.EparchLonelyTower)) ?? throw new MissingKeyActorsException("Eparch not found");
        return eparch;
    }

    internal override void ComputePlayerCombatReplayActors(PlayerActor player, ParsedEvtcLog log, CombatReplay replay)
    {
        base.ComputePlayerCombatReplayActors(player, log, replay);

        // consume fixations
        var  consumes = player.GetBuffStatus(log, Consume, log.FightData.LogStart, log.FightData.LogEnd).Where(x => x.Value > 0);
        var consumeEvents = GetFilteredList(log.CombatData, [ Consume ], player, true, true);
        replay.Decorations.AddOverheadIcons(consumes, player, ParserIcons.FixationRedOverhead);
        replay.Decorations.AddTether(consumeEvents, Colors.Red, 0.5);
    }

    internal override void ComputeNPCCombatReplayActors(NPC target, ParsedEvtcLog log, CombatReplay replay)
    {
        base.ComputeNPCCombatReplayActors(target, log, replay);
        switch (target.ID)
        {
            case (int)TargetID.KryptisRift:
                {
                    var events = GetFilteredList(log.CombatData, [ KryptisRiftIncarnationTether ], target, true, true);
                    replay.Decorations.AddTether(events, Colors.Red, 0.5);
                    break;
                }
        }
    }

    internal override void ComputeEnvironmentCombatReplayDecorations(ParsedEvtcLog log)
    {
        base.ComputeEnvironmentCombatReplayDecorations(log);

        AddGlobuleDecorations(log);

        // rain of despair pools
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.EparchDespairPool, out var pools))
        {
            foreach (EffectEvent effect in pools)
            {
                // TODO: pools are differently sized?
                (long, long) lifespan = effect.ComputeDynamicLifespan(log, 15000);
                var position = new PositionConnector(effect.Position);
                var circle = new CircleDecoration(110, lifespan, Colors.RedSkin, 0.2, position);
                EnvironmentDecorations.Add(circle);
                EnvironmentDecorations.Add(circle.GetBorderDecoration(Colors.Red, 0.2));
            }
        }

        // rage wave
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.EparchRageImpact, out var rageWaves))
        {
            const float velocity = 450.0f; // units per second
            const uint maxRange = 1300;
            const long duration = (long)(1000.0f * maxRange / velocity);
            foreach (EffectEvent effect in rageWaves)
            {
                var start = effect.Time;
                var end = start + duration;
                var position = new PositionConnector(effect.Position);
                EnvironmentDecorations.Add(new CircleDecoration(maxRange, (start, end), Colors.Orange, 0.3, position).UsingFilled(false).UsingGrowingEnd(end));
            }
        }

        // rage fissures
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.EparchRageFissure, out var fissures))
        {
            const uint width = 40;
            const uint length = 220;
            foreach (EffectEvent effect in fissures)
            {
                (long, long) lifespan = effect.ComputeDynamicLifespan(log, 24000);
                GeographicalConnector position = new PositionConnector(effect.Position).WithOffset(new(0.0f, 0.5f * length, 0), true);
                var rotation = new AngleConnector(effect.Rotation.Z);
                EnvironmentDecorations.Add(new RectangleDecoration(width, length, lifespan, Colors.Red, 0.2, position).UsingRotationConnector(rotation));
            }
        }

        // envy arrow indicators
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.EparchArrowIndicator, out var envyArrows))
        {
            const uint width = 60;
            const uint length = 800;
            foreach (EffectEvent effect in envyArrows)
            {
                (long start, long end)= effect.ComputeLifespan(log, 1500);
                var rotation = new AngleConnector(effect.Rotation.Z);
                GeographicalConnector position = new PositionConnector(effect.Position).WithOffset(new(0.0f, 0.5f * length, 0), true);
                EnvironmentDecorations.Add(new RectangleDecoration(width, length, (start, end), Colors.Orange, 0.2, position).UsingRotationConnector(rotation));
                EnvironmentDecorations.Add(new RectangleDecoration(width, length, (end, end + 300), Colors.Red, 0.2, position).UsingRotationConnector(rotation));
            }
        }

        // inhale indicator
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.EparchInhale, out var inhales))
        {
            foreach (EffectEvent effect in inhales)
            {
                (long, long) lifespan = effect.ComputeDynamicLifespan(log, 5000);
                GeographicalConnector position = new PositionConnector(effect.Position);
                EnvironmentDecorations.Add(new CircleDecoration(400, lifespan, Colors.Red, 0.2, position));
            }
        }

        // spike of malice
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.EparchCircleIndicator, out var spikeIndicators))
        {
            foreach (EffectEvent effect in spikeIndicators)
            {
                (long start, long end) = effect.ComputeDynamicLifespan(log, 1000);
                GeographicalConnector position = new PositionConnector(effect.Position);
                var circle = new CircleDecoration(100, (start, end), Colors.Orange, 0.2, position);
                FormDecoration circleBorder = circle.Copy().UsingFilled(false);
                FormDecoration circleFiller = circle.UsingGrowingEnd(end);
                EnvironmentDecorations.Add(circleBorder);
                EnvironmentDecorations.Add(circleFiller);
            }
        }
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.EparchSpikeOfMalice, out var spikes))
        {
            foreach (EffectEvent effect in spikes)
            {
                (long, long) lifespan = effect.ComputeDynamicLifespan(log, 300);
                GeographicalConnector position = new PositionConnector(effect.Position);
                EnvironmentDecorations.Add(new CircleDecoration(100, lifespan, Colors.Red, 0.2, position));
            }
        }
    }

    private void AddGlobuleDecorations(ParsedEvtcLog log)
    {
        SingleActor eparch = GetEparchActor();
        IReadOnlyList<AnimatedCastEvent> eparchCasts = log.CombatData.GetAnimatedCastData(eparch.AgentItem);

        // globule gadgets as decorations
        var globuleColors = new Dictionary<long, Color> {
            { RainOfDespair, Colors.Blue },
            { WaveOfEnvy, Colors.Green },
            { Inhale, Colors.Orange },
            { SpikeOfMalice, Colors.Purple },
            { EnragedSmashEparch, Colors.Red },
            { RegretSkillEparch, Colors.Yellow },
        };
        foreach (AgentItem gadget in log.AgentData.GetAgentByType(AgentItem.AgentType.Gadget))
        {
            const int globuleHealth = 14_940;
            const uint globuleWidth = 16;
            const uint globuleHeight = 160;
            MaxHealthUpdateEvent? health = log.CombatData.GetMaxHealthUpdateEvents(gadget).LastOrDefault(); // may have max health 0 initially
            if (gadget.HitboxWidth == globuleWidth && gadget.HitboxHeight == globuleHeight && health?.MaxHealth == globuleHealth)
            {
                SpawnEvent? spawn = log.CombatData.GetSpawnEvents(gadget).FirstOrDefault();
                DespawnEvent? despawn = log.CombatData.GetDespawnEvents(gadget).FirstOrDefault();
                if (spawn != null && despawn != null)
                {
                    const long globuleDelay = 700;
                    AnimatedCastEvent? lastCast = eparchCasts.LastOrDefault(x => x.Time < spawn.Time - globuleDelay);
                    if (lastCast != null && globuleColors.TryGetValue(lastCast.SkillId, out var color))
                    {
                        if (gadget.TryGetCurrentPosition(log, gadget.LastAware, out var position))
                        {
                            (long, long) lifespan = (spawn.Time, despawn.Time);
                            EnvironmentDecorations.Add(new CircleDecoration(globuleWidth, lifespan, color, 0.7, new PositionConnector(position)));
                        }
                    }
                }
            }
        }
    }
}
