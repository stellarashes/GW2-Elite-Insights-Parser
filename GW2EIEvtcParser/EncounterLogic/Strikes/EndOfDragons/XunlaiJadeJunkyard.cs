﻿using System.Numerics;
using GW2EIEvtcParser.EIData;
using GW2EIEvtcParser.Exceptions;
using GW2EIEvtcParser.Extensions;
using GW2EIEvtcParser.ParsedData;
using GW2EIEvtcParser.ParserHelpers;
using static GW2EIEvtcParser.ArcDPSEnums;
using static GW2EIEvtcParser.EncounterLogic.EncounterLogicPhaseUtils;
using static GW2EIEvtcParser.EncounterLogic.EncounterLogicUtils;
using static GW2EIEvtcParser.ParserHelper;
using static GW2EIEvtcParser.ParserHelpers.EncounterImages;
using static GW2EIEvtcParser.SkillIDs;
using static GW2EIEvtcParser.SpeciesIDs;

namespace GW2EIEvtcParser.EncounterLogic;

internal class XunlaiJadeJunkyard : EndOfDragonsStrike
{
    public XunlaiJadeJunkyard(int triggerID) : base(triggerID)
    {
        MechanicList.Add(new MechanicGroup([  
            new PlayerDstHitMechanic(GraspingHorror, new MechanicPlotlySetting(Symbols.CircleCrossOpen, Colors.LightOrange), "Hands.H", "Hit by Hands AoE", "Hands Hit", 150),
            new MechanicGroup([
                new PlayerDstHitMechanic(DeathsEmbraceSkill, new MechanicPlotlySetting(Symbols.CircleCross, Colors.DarkRed), "AnkkaPull.H", "Hit by Death's Embrace (Ankka's Pull)", "Death's Embrace Hit", 150),
                    new EnemyCastStartMechanic(DeathsEmbraceSkill, new MechanicPlotlySetting(Symbols.CircleXOpen, Colors.Blue), "AnkkaPull.C", "Casted Death's Embrace", "Death's Embrace Cast", 150),
            ]),
            new MechanicGroup([
                new PlayerDstHitMechanic(DeathsHandInBetween, new MechanicPlotlySetting(Symbols.TriangleUp, Colors.Yellow), "Sctn.AoE.H", "Hit by in-between sections AoE", "Death's Hand Hit (transitions)", 150),
                new PlayerDstHitMechanic(DeathsHandDropped, new MechanicPlotlySetting(Symbols.TriangleDown, Colors.Green), "Sprd.AoE.H", "Hit by placeable Death's Hand AoE", "Death's Hand Hit (placeable)", 150),
                new PlayerDstBuffApplyMechanic(DeathsHandSpreadBuff, new MechanicPlotlySetting(Symbols.TriangleLeft, Colors.Green), "Sprd.AoE.B", "Received Death's Hand Spread", "Death's Hand Spread", 150),
                new MechanicGroup([
                    new PlayerDstHitMechanic(ImminentDeathSkill, new MechanicPlotlySetting(Symbols.DiamondTall, Colors.Green), "Imm.Death.H", "Hit by Imminent Death", "Imminent Death Hit", 0),
                    new PlayerDstBuffApplyMechanic(ImminentDeathBuff, new MechanicPlotlySetting(Symbols.DiamondOpen, Colors.Green), "Imm.Death.B", "Placed Death's Hand AoE and gained Imminent Death Buff", "Imminent Death Buff", 150),
                ]),
            ]),
            // Extra adds
            new MechanicGroup([
                // Kraits
                new MechanicGroup([
                    new PlayerDstHitMechanic(WallOfFear, new MechanicPlotlySetting(Symbols.TriangleRight, Colors.DarkRed), "Krait.H", "Hit by Krait AoE", "Krait Hit", 150),
                ]),
                // Quaggans
                new MechanicGroup([
                    new PlayerDstHitMechanic([WaveOfTormentNM, WaveOfTormentCM], new MechanicPlotlySetting(Symbols.Circle, Colors.DarkRed), "Quaggan.H", "Hit by Quaggan Explosion", "Quaggan Hit", 150),
                ]),
                // Lich
                new MechanicGroup([
                    new PlayerDstHitMechanic(TerrifyingApparition, new MechanicPlotlySetting(Symbols.TriangleLeft, Colors.DarkRed), "Lich.H", "Hit by Lich AoE", "Lich Hit", 150),
                    new PlayerDstBuffApplyMechanic(AnkkaLichHallucinationFixation, new MechanicPlotlySetting(Symbols.Diamond, Colors.LightBlue), "Lich.H.F", "Fixated by Lich Hallucination", "Lich Fixation", 150),
                ]),
                new PlayerDstHitMechanic([WallOfFear, WaveOfTormentNM, WaveOfTormentCM, TerrifyingApparition], new MechanicPlotlySetting(Symbols.DiamondTall, Colors.Blue), "Clarity.Achiv", "Achievement Eligibility: Clarity", "Achiv Clarity", 150)
                    .UsingAchievementEligibility(true),
                // Reaches
                new MechanicGroup([
                    new PlayerDstHitMechanic([ZhaitansReachThrashXJJ1, ZhaitansReachThrashXJJ2], new MechanicPlotlySetting(Symbols.CircleOpen, Colors.DarkGreen), "ZhtRch.Pull", "Pulled by Zhaitan's Reach", "Zhaitan's Reach Pull", 150),
                    new PlayerDstHitMechanic([ZhaitansReachGroundSlam, ZhaitansReachGroundSlamXJJ], new MechanicPlotlySetting(Symbols.CircleOpenDot, Colors.DarkGreen), "ZhtRch.Knck", "Knocked by Zhaitan's Reach", "Zhaitan's Reach Knock", 150),
                ]),
                // Hallucinations
                new MechanicGroup([
                    new PlayerDstBuffApplyMechanic(Hallucinations, new MechanicPlotlySetting(Symbols.Square, Colors.LightBlue), "Hallu", "Received Hallucinations Debuff", "Hallucinations Debuff", 150),
                ]),
                // Hatred
                new MechanicGroup([
                    new PlayerDstBuffApplyMechanic(FixatedAnkkaKainengOverlook, new MechanicPlotlySetting(Symbols.Diamond, Colors.Purple), "Fxt.Hatred", "Fixated by Reanimated Hatred", "Fixated Hatred", 150),
                ]),
            ]),
            new EnemyCastStartMechanic(InevitabilityOfDeath, new MechanicPlotlySetting(Symbols.Octagon, Colors.LightRed), "Inev.Death.C", "Casted Inevitability of Death (Enrage)", "Inevitability of Death (Enrage)", 150),
            new EnemyDstBuffApplyMechanic(PowerOfTheVoid, new MechanicPlotlySetting(Symbols.Star, Colors.Yellow), "Pwrd.Up", "Ankka has powered up", "Ankka powered up", 150),
            new MechanicGroup([
                new PlayerDstBuffApplyMechanic(DevouringVoid, new MechanicPlotlySetting(Symbols.DiamondWide, Colors.LightBlue), "DevVoid.B", "Received Devouring Void", "Devouring Void Applied", 150),
                new PlayerDstBuffApplyMechanic(DevouringVoid, new MechanicPlotlySetting(Symbols.DiamondWide, Colors.Blue), "Undev.Achiv", "Achievement Eligibility: Undevoured", "Achiv Undevoured", 150)
                    .UsingAchievementEligibility(true).UsingEnable(x => x.FightData.IsCM),
            ]),
        ])
        );
        Icon = EncounterIconXunlaiJadeJunkyard;
        Extension = "xunjadejunk";
        EncounterCategoryInformation.InSubCategoryOrder = 1;
        EncounterID |= 0x000002;
    }

    internal override string GetLogicName(CombatData combatData, AgentData agentData)
    {
        return "Xunlai Jade Junkyard";
    }

    protected override CombatReplayMap GetCombatMapInternal(ParsedEvtcLog log)
    {
        return new CombatReplayMap(CombatReplayXunlaiJadeJunkyard,
                        (1485, 1292),
                        (-7090, -2785, 3647, 6556)/*,
                        (-15360, -36864, 15360, 39936),
                        (3456, 11012, 4736, 14212)*/);
    }

    internal override List<PhaseData> GetPhases(ParsedEvtcLog log, bool requirePhases)
    {
        List<PhaseData> phases = GetInitialPhase(log);
        SingleActor ankka = Targets.FirstOrDefault(x => x.IsSpecies(TargetID.Ankka)) ?? throw new MissingKeyActorsException("Ankka not found");
        phases[0].AddTarget(ankka);
        if (!requirePhases)
        {
            return phases;
        }

        // Health and Transition Phases
        List<PhaseData> subPhases = GetPhasesByInvul(log, AnkkaPlateformChanging, ankka, true, true);
        for (int i = 0; i < subPhases.Count; i++)
        {
            switch (i)
            {
                case 0:
                    subPhases[i].Name = "Phase 100-75%";
                    break;
                case 1:
                    subPhases[i].Name = "Transition 1";
                    break;
                case 2:
                    subPhases[i].Name = "Phase 75-40%";
                    break;
                case 3:
                    subPhases[i].Name = "Transition 2";
                    break;
                case 4:
                    subPhases[i].Name = "Phase 40-0%";
                    break;
                default:
                    break;
            }
            subPhases[i].AddParentPhase(phases[0]);
            subPhases[i].AddTarget(ankka);
        }
        phases.AddRange(subPhases);
        // DPS Phases
        List<PhaseData> dpsPhase = GetPhasesByInvul(log, Determined895, ankka, false, true);
        for (int i = 0; i < dpsPhase.Count; i++)
        {
            dpsPhase[i].Name = $"DPS Phase {i + 1}";
            dpsPhase[i].AddTarget(ankka);
            dpsPhase[i].AddParentPhases(subPhases);
            // We are not using the same buff between the two types of phases, the timings may slightly differ, this makes sure to put a dps phase within a fight phase
            var currentSubPhase = subPhases.FirstOrDefault(x => x.IntersectsWindow(dpsPhase[i].Start, dpsPhase[i].End));
            if (currentSubPhase != null)
            {
                dpsPhase[i].OverrideStart(Math.Max(dpsPhase[i].Start, currentSubPhase.Start));
                dpsPhase[i].OverrideEnd(Math.Min(dpsPhase[i].End, currentSubPhase.End));
            }
        }
        phases.AddRange(dpsPhase);
        // Necrotic Rituals
        List<PhaseData> rituals = GetPhasesByInvul(log, NecroticRitual, ankka, true, true);
        for (int i = 0; i < rituals.Count; i++)
        {
            if (i % 2 != 0)
            {
                rituals[i].Name = $"Necrotic Ritual {(i + 1) / 2}";
                rituals[i].AddTarget(ankka);
                rituals[i].AddParentPhases(subPhases);
            }
        }
        phases.AddRange(rituals);
        //
        return phases;
    }

    internal override void CheckSuccess(CombatData combatData, AgentData agentData, FightData fightData, IReadOnlyCollection<AgentItem> playerAgents)
    {
        base.CheckSuccess(combatData, agentData, fightData, playerAgents);
        if (!fightData.Success)
        {
            SingleActor ankka = Targets.FirstOrDefault(x => x.IsSpecies(TargetID.Ankka)) ?? throw new MissingKeyActorsException("Ankka not found");
            var buffApplies = combatData.GetBuffDataByIDByDst(Determined895, ankka.AgentItem).OfType<BuffApplyEvent>().Where(x => !x.Initial && x.AppliedDuration > int.MaxValue / 2 && x.Time >= fightData.FightStart + 5000);
            if (buffApplies.Count() == 3)
            {
                fightData.SetSuccess(true, buffApplies.Last().Time);
            }
        }
    }

    protected override ReadOnlySpan<TargetID> GetUniqueNPCIDs()
    {
        return
        [
            TargetID.Ankka,
        ];
    }

    protected override ReadOnlySpan<TargetID> GetTargetsIDs()
    {
        return
        [
            TargetID.Ankka,
            TargetID.ReanimatedAntipathy,
            TargetID.ReanimatedSpite,
        ];
    }

    protected override Dictionary<TargetID, int> GetTargetsSortIDs()
    {
        return new Dictionary<TargetID, int>()
        {
            {TargetID.Ankka, 0 },
            {TargetID.ReanimatedAntipathy, 1 },
            {TargetID.ReanimatedSpite, 1 },
        };
    }

    protected override List<TargetID> GetTrashMobsIDs()
    {
        return
        [
            TargetID.Ankka2,
            TargetID.ReanimatedMalice1,
            TargetID.ReanimatedMalice2,
            TargetID.ReanimatedHatred,
            TargetID.ZhaitansReach,
            TargetID.KraitsHallucination,
            TargetID.LichHallucination,
            TargetID.QuaggansHallucinationNM,
            TargetID.QuaggansHallucinationCM,
            TargetID.SanctuaryPrism,
        ];
    }

    internal override FightData.EncounterMode GetEncounterMode(CombatData combatData, AgentData agentData, FightData fightData)
    {
        SingleActor ankka = Targets.FirstOrDefault(x => x.IsSpecies(TargetID.Ankka)) ?? throw new MissingKeyActorsException("Ankka not found");
        MapIDEvent? map = combatData.GetMapIDEvents().FirstOrDefault();
        if (map != null && map.MapID == 1434)
        {
            return FightData.EncounterMode.Story;
        }
        return ankka.GetHealth(combatData) > 50e6 ? FightData.EncounterMode.CM : FightData.EncounterMode.Normal;
    }

    internal override void EIEvtcParse(ulong gw2Build, EvtcVersionEvent evtcVersion, FightData fightData, AgentData agentData, List<CombatItem> combatData, IReadOnlyDictionary<uint, ExtensionHandler> extensions)
    {
        var sanctuaryPrism = combatData.Where(x => MaxHealthUpdateEvent.GetMaxHealth(x) == 14940 && x.IsStateChange == StateChange.MaxHealthUpdate).Select(x => agentData.GetAgent(x.SrcAgent, x.Time)).Where(x => x.Type == AgentItem.AgentType.Gadget && x.HitboxWidth == 16);
        foreach (AgentItem sanctuary in sanctuaryPrism)
        {
            IEnumerable<CombatItem> items = combatData.Where(x => x.SrcMatchesAgent(sanctuary) && x.IsStateChange == StateChange.HealthUpdate && HealthUpdateEvent.GetHealthPercent(x) == 0);
            sanctuary.OverrideType(AgentItem.AgentType.NPC, agentData);
            sanctuary.OverrideID(TargetID.SanctuaryPrism, agentData);
            sanctuary.OverrideAwareTimes(fightData.LogStart, items.Any() ? items.First().Time : fightData.LogEnd);
        }
        base.EIEvtcParse(gw2Build, evtcVersion, fightData, agentData, combatData, extensions);
    }

    protected override void SetInstanceBuffs(ParsedEvtcLog log)
    {
        base.SetInstanceBuffs(log);

        if (log.FightData.Success && log.FightData.IsCM && CustomCheckGazeIntoTheVoidEligibility(log))
        {
            InstanceBuffs.Add((log.Buffs.BuffsByIds[AchievementEligibilityGazeIntoTheVoid], 1));
        }
    }

    private static bool CustomCheckGazeIntoTheVoidEligibility(ParsedEvtcLog log)
    {
        IReadOnlyList<AgentItem> agents = log.AgentData.GetNPCsByID((int)TargetID.Ankka);

        foreach (AgentItem agent in agents)
        {
            IReadOnlyDictionary<long, BuffGraph> bgms = log.FindActor(agent).GetBuffGraphs(log);
            if (bgms != null && bgms.TryGetValue(PowerOfTheVoid, out var bgm))
            {
                if (bgm.Values.Any(x => x.Value == 6)) { return true; }
            }
        }
        return false;
    }

    internal override void ComputeNPCCombatReplayActors(NPC target, ParsedEvtcLog log, CombatReplay replay)
    {

        switch (target.ID)
        {
            case (int)TargetID.Ankka:
                {
                    var casts = target.GetCastEvents(log, log.FightData.FightStart, log.FightData.FightEnd);
                    var deathsEmbraces = casts.Where(x => x.SkillId == DeathsEmbraceSkill);
                    int deathsEmbraceCastDuration = 10143;
                    foreach (CastEvent deathEmbrace in deathsEmbraces)
                    {
                        int endTime = (int)deathEmbrace.Time + deathsEmbraceCastDuration;

                        if (target.TryGetCurrentPosition(log, deathEmbrace.Time, out var ankkaPosition))
                        {
                            if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.DeathsEmbrace, out var deathsEmbraceEffects))
                            {
                                uint radius = 500; // Zone 1
                                                   // Zone 2
                                if (ankkaPosition.X > 0 && ankkaPosition.X < 4000)
                                {
                                    radius = 340;
                                }

                                // Zone 3
                                if (ankkaPosition.Y > 4000 && ankkaPosition.Y < 6000)
                                {
                                    radius = 380;
                                }

                                var effects = deathsEmbraceEffects.Where(x => x.Time >= deathEmbrace.Time && x.Time <= deathEmbrace.EndTime);
                                foreach (EffectEvent effectEvt in effects)
                                {
                                    AddDeathEmbraceDecoration(replay, (int)deathEmbrace.Time, deathsEmbraceCastDuration, radius, (int)(effectEvt.Time - deathEmbrace.Time), effectEvt.Position);
                                }
                            }
                            else
                            {
                                // logs without effects
                                int delay = 1833 * 2;
                                // Zone 1
                                if (ankkaPosition.X > -6000 && ankkaPosition.X < -2500 && ankkaPosition.Y < 1000 && ankkaPosition.Y > -1000)
                                {
                                    AddDeathEmbraceDecoration(replay, (int)deathEmbrace.Time, deathsEmbraceCastDuration, 500, delay, new(-3941.78f, 66.76819f, -3611.2f)); // CENTER
                                }

                                // Zone 2
                                if (ankkaPosition.X > 0 && ankkaPosition.X < 4000)
                                {
                                    AddDeathEmbraceDecoration(replay, (int)deathEmbrace.Time, deathsEmbraceCastDuration, 340, delay, new(1663.69f, 1739.87f, -4639.695f)); // NW
                                    AddDeathEmbraceDecoration(replay, (int)deathEmbrace.Time, deathsEmbraceCastDuration, 340, delay, new(2563.689f, 1739.87f, -4664.611f)); // NE
                                    AddDeathEmbraceDecoration(replay, (int)deathEmbrace.Time, deathsEmbraceCastDuration, 340, delay, new(1663.69f, 839.8699f, -4640.633f)); // SW
                                    AddDeathEmbraceDecoration(replay, (int)deathEmbrace.Time, deathsEmbraceCastDuration, 340, delay, new(2563.689f, 839.8699f, -4636.368f)); // SE
                                }

                                // Zone 3
                                if (ankkaPosition.Y > 4000 && ankkaPosition.Y < 6000)
                                {
                                    AddDeathEmbraceDecoration(replay, (int)deathEmbrace.Time, deathsEmbraceCastDuration, 380, delay, new(-2547.61f, 5466.439f, -6257.504f)); // NW
                                    AddDeathEmbraceDecoration(replay, (int)deathEmbrace.Time, deathsEmbraceCastDuration, 380, delay, new(-1647.61f, 5466.439f, -6256.795f)); // NE
                                    AddDeathEmbraceDecoration(replay, (int)deathEmbrace.Time, deathsEmbraceCastDuration, 380, delay, new(-2547.61f, 4566.439f, -6256.799f)); // SW
                                    AddDeathEmbraceDecoration(replay, (int)deathEmbrace.Time, deathsEmbraceCastDuration, 380, delay, new(-1647.61f, 4566.439f, -6257.402f)); // SE
                                }
                            }
                        }
                    }

                    if (log.CombatData.TryGetEffectEventsBySrcWithGUID(target.AgentItem, EffectGUIDs.DeathsHandByAnkkaRadius300, out var deathsHandOnPlayerNM))
                    {
                        foreach (EffectEvent deathsHandEffect in deathsHandOnPlayerNM)
                        {
                            if (log.CombatData.GetBuffRemoveAllData(DeathsHandSpreadBuff).Any(x => Math.Abs(x.Time - deathsHandEffect.Time) < ServerDelayConstant))
                            {
                                AddDeathsHandDecoration(replay, deathsHandEffect.Position, (int)deathsHandEffect.Time, 3000, 300, 13000);
                            }
                        }
                    }

                    if (log.CombatData.TryGetEffectEventsBySrcWithGUID(target.AgentItem, EffectGUIDs.DeathsHandByAnkkaRadius380, out var deathsHandOnPlayerCMOrInBetween))
                    {
                        foreach (EffectEvent deathsHandEffect in deathsHandOnPlayerCMOrInBetween)
                        {
                            if (!log.CombatData.GetBuffRemoveAllData(DeathsHandSpreadBuff).Any(x => Math.Abs(x.Time - deathsHandEffect.Time) < ServerDelayConstant))
                            {
                                // One also happens during death's embrace so we filter that one out
                                if (!deathsEmbraces.Any(x => x.Time <= deathsHandEffect.Time && x.Time + deathsEmbraceCastDuration >= deathsHandEffect.Time))
                                {
                                    AddDeathsHandDecoration(replay, deathsHandEffect.Position, (int)deathsHandEffect.Time, 3000, 380, 1000);
                                }
                            }
                            else if (log.FightData.IsCM)
                            {
                                AddDeathsHandDecoration(replay, deathsHandEffect.Position, (int)deathsHandEffect.Time, 3000, 380, 33000);
                            }
                        }
                    }

                    // Power of the Void
                    IEnumerable<Segment> potvSegments = target.GetBuffStatus(log, PowerOfTheVoid, log.FightData.LogStart, log.FightData.LogEnd).Where(x => x.Value > 0);
                    replay.Decorations.AddOverheadIcons(potvSegments, target, ParserIcons.PowerOfTheVoidOverhead);
                }
                break;

            case (int)TargetID.KraitsHallucination:
                // Wall of Fear
                long firstMovementTime = target.FirstAware + 2550;
                uint kraitsRadius = 420;

                replay.Decorations.Add(new CircleDecoration(kraitsRadius, (target.FirstAware, firstMovementTime), Colors.Orange, 0.2, new AgentConnector(target)).UsingGrowingEnd(firstMovementTime));
                replay.Decorations.Add(new CircleDecoration(kraitsRadius, (firstMovementTime, target.LastAware), Colors.Red, 0.2, new AgentConnector(target)));
                break;

            case (int)TargetID.LichHallucination:
                // Terrifying Apparition
                long awareTime = target.FirstAware + 1000;
                uint lichRadius = 280;

                replay.Decorations.Add(new CircleDecoration(lichRadius, (target.FirstAware, awareTime), Colors.Orange, 0.2, new AgentConnector(target)).UsingGrowingEnd(awareTime));
                replay.Decorations.Add(new CircleDecoration(lichRadius, (awareTime, target.LastAware), Colors.Red, 0.2, new AgentConnector(target)));
                break;

            case (int)TargetID.QuaggansHallucinationNM:
                {
                    var casts = target.GetCastEvents(log, log.FightData.FightStart, log.FightData.FightEnd);
                    var waveOfTormentNM = casts.Where(x => x.SkillId == WaveOfTormentNM);
                    foreach (CastEvent c in waveOfTormentNM)
                    {
                        int castTime = 2800;
                        uint radius = 300;
                        int endTime = (int)c.Time + castTime;
                        replay.Decorations.AddWithGrowing(new CircleDecoration(radius, (c.Time, endTime), Colors.Orange, 0.2, new AgentConnector(target)), endTime);
                    }
                }
                break;

            case (int)TargetID.QuaggansHallucinationCM:
                {
                    var casts = target.GetCastEvents(log, log.FightData.FightStart, log.FightData.FightEnd);
                    var waveOfTormentCM = casts.Where(x => x.SkillId == WaveOfTormentCM);
                    foreach (CastEvent c in waveOfTormentCM)
                    {
                        int castTime = 5600;
                        uint radius = 450;
                        int endTime = (int)c.Time + castTime;
                        replay.Decorations.AddWithGrowing(new CircleDecoration(radius, (c.Time, endTime), Colors.Orange, 0.2, new AgentConnector(target)), endTime);
                    }
                }
                break;

            case (int)TargetID.ZhaitansReach:
                {
                    var casts = target.GetCastEvents(log, log.FightData.FightStart, log.FightData.FightEnd);
                    // Thrash - Circle that pulls in
                    var thrash = casts.Where(x => x.SkillId == ZhaitansReachThrashXJJ1 || x.SkillId == ZhaitansReachThrashXJJ2);
                    foreach (CastEvent c in thrash)
                    {
                        int castTime = 1900;
                        int endTime = (int)c.Time + castTime;
                        replay.Decorations.AddWithGrowing(new DoughnutDecoration(300, 500, (c.Time, endTime), Colors.Orange, 0.2, new AgentConnector(target)), endTime);
                    }
                    // Ground Slam - AoE that knocks out
                    var groundSlam = casts.Where(x => x.SkillId == ZhaitansReachGroundSlam || x.SkillId == ZhaitansReachGroundSlamXJJ);
                    foreach (CastEvent c in groundSlam)
                    {
                        int castTime = 0;
                        uint radius = 400;
                        int endTime = 0;
                        // 66534 -> Fast AoE -- 66397 -> Slow AoE
                        if (c.SkillId == ZhaitansReachGroundSlam) { castTime = 800; } else if (c.SkillId == ZhaitansReachGroundSlamXJJ) { castTime = 2500; }
                        endTime = (int)c.Time + castTime;
                        replay.Decorations.AddWithGrowing(new CircleDecoration(radius, (c.Time, endTime), Colors.Orange, 0.2, new AgentConnector(target)), endTime);
                    }
                }
                break;

            case (int)TargetID.ReanimatedSpite:
                break;

            case (int)TargetID.SanctuaryPrism:
                if (!log.FightData.IsCM)
                {
                    replay.Trim(log.FightData.LogStart, log.FightData.LogStart);
                }
                break;

            default:
                break;
        }
    }

    internal override void ComputePlayerCombatReplayActors(PlayerActor p, ParsedEvtcLog log, CombatReplay replay)
    {
        base.ComputePlayerCombatReplayActors(p, log, replay);
        if (p.GetBuffGraphs(log).TryGetValue(DeathsHandSpreadBuff, out var value))
        {
            foreach (Segment segment in value.Values)
            {
                //TODO(Rennorb) @correctnes: there was a null check here, i have no clue why.
                if (!segment.IsEmpty() && segment.Value == 1)
                {
                    uint deathsHandRadius = (uint)(log.FightData.IsCM ? 380 : 300);
                    int deathsHandDuration = log.FightData.IsCM ? 33000 : 13000;
                    // AoE on player
                    replay.Decorations.AddWithGrowing(new CircleDecoration(deathsHandRadius, segment, Colors.Orange, 0.2, new AgentConnector(p)), segment.End);
                    // Logs without effects, we add the dropped AoE manually
                    if (!log.CombatData.HasEffectData)
                    {
                        if (p.TryGetCurrentPosition(log, segment.End, out var playerPosition))
                        {
                            AddDeathsHandDecoration(replay, playerPosition, (int)segment.End, 3000, deathsHandRadius, deathsHandDuration);
                        }
                    }
                }
            }
        }
        // Tethering Players to Lich
        var lichTethers = GetFilteredList(log.CombatData, AnkkaLichHallucinationFixation, p, true, true);
        replay.Decorations.AddTether(lichTethers, Colors.Teal, 0.5);

        // Reanimated Hatred Fixation
        IEnumerable<Segment> hatredFixations = p.GetBuffStatus(log, FixatedAnkkaKainengOverlook, log.FightData.LogStart, log.FightData.LogEnd).Where(x => x.Value > 0);
        replay.Decorations.AddOverheadIcons(hatredFixations, p, ParserIcons.FixationPurpleOverhead);
        // Reanimated Hatred Tether to player - The buff is applied by Ankka to the player - The Reanimated Hatred spawns before the buff application
        replay.Decorations.AddTetherByThirdPartySrcBuff(log, p, FixatedAnkkaKainengOverlook, (int)TargetID.Ankka, (int)TargetID.ReanimatedHatred, Colors.Magenta, 0.5);
    }

    private static void AddDeathsHandDecoration(CombatReplay replay, Vector3 position, int start, int delay, uint radius, int duration)
    {
        int deathHandGrowStart = start;
        int deathHandGrowEnd = deathHandGrowStart + delay;
        // Growing AoE
        replay.Decorations.AddWithGrowing(new CircleDecoration(radius, (deathHandGrowStart, deathHandGrowEnd), Colors.Orange, 0.2, new PositionConnector(position)), deathHandGrowEnd);
        // Damaging AoE
        int AoEStart = deathHandGrowEnd;
        int AoEEnd = AoEStart + duration;
        replay.Decorations.AddWithBorder(new CircleDecoration(radius, (AoEStart, AoEEnd), "rgba(0, 100, 0, 0.3)", new PositionConnector(position)), Colors.Red, 0.4);
    }

    private static void AddDeathEmbraceDecoration(CombatReplay replay, int startCast, int durationCast, uint radius, int delay, Vector3 position)
    {
        int endTime = startCast + durationCast;
        var connector = new PositionConnector(position);
        replay.Decorations.Add(new CircleDecoration(radius, (startCast, startCast + delay), Colors.Orange, 0.2, connector).UsingGrowingEnd(startCast + delay));
        replay.Decorations.Add(new CircleDecoration(radius, (startCast + delay, endTime), Colors.Red, 0.2, connector));
    }
}
