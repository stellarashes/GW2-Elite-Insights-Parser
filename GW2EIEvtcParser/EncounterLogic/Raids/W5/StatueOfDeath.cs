﻿using GW2EIEvtcParser.EIData;
using GW2EIEvtcParser.Exceptions;
using GW2EIEvtcParser.ParsedData;
using static GW2EIEvtcParser.ArcDPSEnums;
using static GW2EIEvtcParser.EncounterLogic.EncounterLogicTimeUtils;
using static GW2EIEvtcParser.ParserHelpers.EncounterImages;
using static GW2EIEvtcParser.SkillIDs;
using static GW2EIEvtcParser.SpeciesIDs;

namespace GW2EIEvtcParser.EncounterLogic;

internal class StatueOfDeath : HallOfChains
{
    
    public StatueOfDeath(int triggerID) : base(triggerID)
    {
        MechanicList.Add(new MechanicGroup([
            new PlayerDstHitMechanic(HungeringMiasma, new MechanicPlotlySetting(Symbols.TriangleLeftOpen,Colors.DarkGreen), "Vomit", "Hungering Miasma (Vomit Goo)","Vomit Dmg", 0),
            new MechanicGroup([
                new PlayerDstBuffApplyMechanic(ReclaimedEnergyBuff, new MechanicPlotlySetting(Symbols.Circle,Colors.Yellow), "Light Orb Collected", "Applied when taking a light orb","Light Orb", 0),
                new PlayerCastStartMechanic(ReclaimedEnergySkill, new MechanicPlotlySetting(Symbols.CircleOpen,Colors.Yellow), "Light Orb Thrown", "Has thrown a light orb","Light Orb Thrown", 0)
                    .UsingChecker((evt, log) => !evt.IsInterrupted),
            ]),
            new PlayerDstBuffApplyMechanic(FracturedSpirit, new MechanicPlotlySetting(Symbols.Circle,Colors.Green), "Orb CD", "Applied when taking green","Green port", 0),
        ])
        );
        Extension = "souleater";
        Icon = EncounterIconStatueOfDeath;
        EncounterCategoryInformation.InSubCategoryOrder = 2;
        EncounterID |= 0x000004;
    }

    protected override CombatReplayMap GetCombatMapInternal(ParsedEvtcLog log)
    {
        return new CombatReplayMap(CombatReplayStatueOfDeath,
                        (710, 709),
                        (1306, -9381, 4720, -5968)/*,
                        (-21504, -12288, 24576, 12288),
                        (19072, 15484, 20992, 16508)*/);
    }
    internal override List<InstantCastFinder> GetInstantCastFinders()
    {
        return
        [
            new DamageCastFinder(HungeringAura , HungeringAura ), // Hungering Aura
        ];
    }
    protected override List<TargetID> GetTrashMobsIDs()
    {
        return
        [
            TargetID.OrbSpider,
            TargetID.SpiritHorde1,
            TargetID.SpiritHorde2,
            TargetID.SpiritHorde3,
            TargetID.GreenSpirit1,
            TargetID.GreenSpirit2
        ];
    }

    internal override long GetFightOffset(EvtcVersionEvent evtcVersion, FightData fightData, AgentData agentData, List<CombatItem> combatData)
    {
        if (!agentData.TryGetFirstAgentItem(TargetID.EaterOfSouls, out var eaterOfSouls))
        {
            throw new MissingKeyActorsException("Eater of Souls not found");
        }
        long startToUse = GetGenericFightOffset(fightData);
        CombatItem? logStartNPCUpdate = combatData.FirstOrDefault(x => x.IsStateChange == StateChange.LogNPCUpdate);
        if (logStartNPCUpdate != null)
        {
            var peasants = new List<AgentItem>(agentData.GetNPCsByID(TargetID.AscalonianPeasant1));
            peasants.AddRange(agentData.GetNPCsByID(TargetID.AscalonianPeasant2));
            if (peasants.Count != 0)
            {
                startToUse = peasants.Max(x => x.LastAware);
            }
            else
            {
                startToUse = GetFirstDamageEventTime(fightData, agentData, combatData, eaterOfSouls);
            }
        }
        return startToUse;
    }

    internal override void ComputeNPCCombatReplayActors(NPC target, ParsedEvtcLog log, CombatReplay replay)
    {
        int start = (int)replay.TimeOffsets.start;
        int end = (int)replay.TimeOffsets.end;
        switch (target.ID)
        {
            case (int)TargetID.EaterOfSouls: {
                var cls = target.GetCastEvents(log, log.FightData.FightStart, log.FightData.FightEnd);
                var breakbar = cls.Where(x => x.SkillId == Imbibe);
                foreach (CastEvent c in breakbar)
                {
                    replay.Decorations.Add(new OverheadProgressBarDecoration(ParserHelper.CombatReplayOverheadProgressBarMajorSizeInPixel, (c.Time, c.EndTime), Colors.Red, 0.6, Colors.Black, 0.2, [(c.Time, 0), (c.ExpectedEndTime, 100)], new AgentConnector(target))
                        .UsingRotationConnector(new AngleConnector(180)));
                }
                var vomit = cls.Where(x => x.SkillId == HungeringMiasma);
                foreach (CastEvent c in vomit)
                {
                    start = (int)c.Time + 2100;
                    int cascading = 1500;
                    int duration = 15000 + cascading;
                    end = start + duration;
                    uint radius = 900;
                    if (target.TryGetCurrentFacingDirection(log, start, out var facing) && target.TryGetCurrentPosition(log, start, out var position))
                    {
                        replay.Decorations.Add(new PieDecoration(radius, 60, (start, end), Colors.GreenishYellow, 0.5, new PositionConnector(position)).UsingGrowingEnd(start + cascading).UsingRotationConnector(new AngleConnector(facing)));
                    }
                }
                var pseudoDeath = cls.Where(x => x.SkillId == PseudoDeathEaterOfSouls);
                foreach (CastEvent c in pseudoDeath)
                {
                    start = (int)c.Time;
                    //int duration = 900;
                    end = (int)c.EndTime; //duration;
                    //replay.Actors.Add(new CircleActor(true, 0, 180, (start, end), "rgba(255, 150, 255, 0.35)", new AgentConnector(target)));
                    replay.Decorations.Add(new CircleDecoration(180, (start, end), "rgba(255, 180, 220, 0.7)", new AgentConnector(target)).UsingGrowingEnd(end));
                }
            } break;
            case (int)TargetID.GreenSpirit1:
            case (int)TargetID.GreenSpirit2: {
                var cls = target.GetCastEvents(log, log.FightData.FightStart, log.FightData.FightEnd);
                var green = cls.Where(x => x.SkillId == GreensEaterofSouls);
                foreach (CastEvent c in green)
                {
                    int gstart = (int)c.Time + 667;
                    int gend = gstart + 5000;
                    var circle = new CircleDecoration(240, (gstart, gend), Colors.Green, 0.2, new AgentConnector(target));
                    replay.Decorations.AddWithGrowing(circle, gend);
                }
            } break;
            case (int)TargetID.SpiritHorde1:
            case (int)TargetID.SpiritHorde2:
            case (int)TargetID.SpiritHorde3:
            case (int)TargetID.OrbSpider:
                break;
            default:
                break;
        }

    }

    internal override void ComputeEnvironmentCombatReplayDecorations(ParsedEvtcLog log)
    {
        base.ComputeEnvironmentCombatReplayDecorations(log);
        // TODO check sizes
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.EaterOfSoulsSpiritOrbs, out var orbEffectEvents))
        {
            foreach (EffectEvent effectEvent in orbEffectEvents)
            {
                (long start, long end) lifespan = effectEvent.ComputeDynamicLifespan(log, 0);
                EnvironmentDecorations.Add(new CircleDecoration(20, lifespan, Colors.Pink, 0.8, new PositionConnector(effectEvent.Position)));
            }
        }
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.EaterOfSoulsSpiderWeb, out var webEffectEvents))
        {
            foreach (EffectEvent effectEvent in webEffectEvents)
            {
                (long start, long end) lifespan = effectEvent.ComputeLifespan(log, effectEvent.Duration);
                uint webRadius = 320;
                var webIndicator = new CircleDecoration(webRadius, lifespan, Colors.Orange, 0.1, new PositionConnector(effectEvent.Position));
                var web = new CircleDecoration(webRadius, (lifespan.end, lifespan.end + 750), Colors.Orange, 0.3, new PositionConnector(effectEvent.Position));
                EnvironmentDecorations.Add(webIndicator);
                EnvironmentDecorations.Add(webIndicator.GetBorderDecoration(Colors.Orange, 0.3));
                EnvironmentDecorations.Add(webIndicator.Copy().UsingGrowingEnd(lifespan.end));
                EnvironmentDecorations.Add(web);
            }
        }
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.EaterOfSoulsLightOrbOnGround, out var orbOnGroundEffectEvents))
        {
            foreach (EffectEvent effectEvent in orbOnGroundEffectEvents)
            {
                (long start, long end) lifespan = effectEvent.ComputeDynamicLifespan(log, 0);
                EnvironmentDecorations.Add(new CircleDecoration(80, lifespan, Colors.Yellow, 0.6, new PositionConnector(effectEvent.Position)));
            }
        }
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.EaterOfSoulsLightOrbThrowHitGround, out var orbThrowEffectEvents))
        {
            foreach (EffectEvent effectEvent in orbThrowEffectEvents)
            {
                (long start, long end) lifespan = (effectEvent.Time, effectEvent.Time + 500);
                EnvironmentDecorations.Add(new CircleDecoration(40, lifespan, Colors.Yellow, 0.6, new PositionConnector(effectEvent.Position)));
            }
        }
        if (log.CombatData.TryGetEffectEventsByGUID(EffectGUIDs.EaterOfSoulsSpiritShockwave2, out var shockwaveEffectEvents))
        {
            foreach (EffectEvent effectEvent in shockwaveEffectEvents)
            {
                (long start, long end) lifespan = effectEvent.ComputeLifespan(log, 3600);
                EnvironmentDecorations.Add(new CircleDecoration(1400, lifespan, Colors.Red, 0.3, new PositionConnector(effectEvent.Position)).UsingFilled(false).UsingGrowingEnd(lifespan.end));
            }
        }
    }

    internal override void ComputePlayerCombatReplayActors(PlayerActor p, ParsedEvtcLog log, CombatReplay replay)
    {
        base.ComputePlayerCombatReplayActors(p, log, replay);
        var spiritTransform = log.CombatData.GetBuffDataByIDByDst(FracturedSpirit, p.AgentItem).Where(x => x is BuffApplyEvent);
        foreach (BuffEvent c in spiritTransform)
        {
            int duration = 30000;
            BuffEvent? removedBuff = log.CombatData.GetBuffRemoveAllData(MortalCoilStatueOfDeath).FirstOrDefault(x => x.To == p.AgentItem && x.Time > c.Time && x.Time < c.Time + duration);
            int start = (int)c.Time;
            int end = start + duration;
            if (removedBuff != null)
            {
                end = (int)removedBuff.Time;
            }
            var circle = new CircleDecoration(100, (start, end), "rgba(0, 50, 200, 0.3)", new AgentConnector(p));
            replay.Decorations.AddWithGrowing(circle, start + duration);
        }
    }

    internal override void CheckSuccess(CombatData combatData, AgentData agentData, FightData fightData, IReadOnlyCollection<AgentItem> playerAgents)
    {
        NoBouncyChestGenericCheckSucess(combatData, agentData, fightData, playerAgents);
    }

    internal override string GetLogicName(CombatData combatData, AgentData agentData)
    {
        return "Statue of Death";
    }
}
