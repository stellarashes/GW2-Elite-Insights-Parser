
using System;
using System.Numerics;
using GW2EIEvtcParser.EIData;
using GW2EIEvtcParser.Exceptions;
using GW2EIEvtcParser.ParsedData;
using GW2EIEvtcParser.ParserHelpers;
using static GW2EIEvtcParser.EncounterLogic.EncounterImages;
using static GW2EIEvtcParser.EncounterLogic.EncounterLogicPhaseUtils;
using static GW2EIEvtcParser.EncounterLogic.EncounterLogicUtils;
using static GW2EIEvtcParser.SkillIDs;

namespace GW2EIEvtcParser.EncounterLogic;

internal class DecimaTheStormsinger : MountBalrior
{
    public DecimaTheStormsinger(int triggerID) : base(triggerID)
    {
        MechanicList.AddRange(new List<Mechanic>()
        {
            new PlayerDstHitMechanic(Fluxlance, "Fluxlance", new MechanicPlotlySetting(Symbols.StarSquare, Colors.LightOrange), "Fluxlance.H", "Hit by Fluxlance (Single Orange Arrow)", "Fluxlance Hit", 0),
            new PlayerDstHitMechanic(FluxlanceFusillade, "Fluxlance Fusillade", new MechanicPlotlySetting(Symbols.StarDiamond, Colors.LightOrange), "FluxFusi.H", "Hit by Fluxlance Fusillade (Sequential Orange Arrows)", "Fluxlance Fusillade Hit", 0),
            new PlayerDstHitMechanic([FluxlanceSalvo1, FluxlanceSalvo2, FluxlanceSalvo3, FluxlanceSalvo4, FluxlanceSalvo5], "Fluxlance Salvo", new MechanicPlotlySetting(Symbols.StarDiamondOpen, Colors.LightOrange), "FluxSalvo.H", "Hit by Fluxlance Salvo (Simultaneous Orange Arrows)", "Fluxlance Salvo Hit", 0),
            new PlayerDstBuffApplyMechanic([TargetOrder1JW, TargetOrder2JW, TargetOrder3JW, TargetOrder4JW, TargetOrder5JW], "Target Order", new MechanicPlotlySetting(Symbols.StarTriangleDown, Colors.LightOrange), "FluxOrder.T", "Targeted by Fluxlance (Target Order)", "Fluxlance Target (Sequential)", 0),
            new PlayerDstBuffApplyMechanic(FluxlanceTargetBuff1, "Fluxlance", new MechanicPlotlySetting(Symbols.StarTriangleDown, Colors.Orange), "Fluxlance.T", "Targeted by Fluxlance", "Fluxlance Target", 0),
            new PlayerDstBuffApplyMechanic(FluxlanceRedArrowTargetBuff, "Fluxlance", new MechanicPlotlySetting(Symbols.StarTriangleDown, Colors.Red), "FluxRed.T", "Targeted by Fluxlance (Red Arrow)", "Fluxlance (Red Arrow)", 0),
        });
        Extension = "decima";
        Icon = EncounterIconDecima;
        EncounterCategoryInformation.InSubCategoryOrder = 1;
        EncounterID |= 0x000002;
    }
    protected override CombatReplayMap GetCombatMapInternal(ParsedEvtcLog log)
    {
        return new CombatReplayMap(CombatReplayDecimaTheStormsinger,
                        (1602, 1602),
                        (-12668, 10500, -7900, 15268));
    }

    protected override ReadOnlySpan<int> GetTargetsIDs()
    {
        return
        [
            (int)ArcDPSEnums.TargetID.Decima,
            //(int)ArcDPSEnums.TrashID.EnlightenedConduit,
        ];
    }

    protected override List<ArcDPSEnums.TrashID> GetTrashMobsIDs()
    {
        return
        [
            ArcDPSEnums.TrashID.GreenOrb1Person,
            ArcDPSEnums.TrashID.GreenOrb2Persons,
            ArcDPSEnums.TrashID.GreenOrb3Persons,
            ArcDPSEnums.TrashID.EnlightenedConduit,
        ];
    }

    internal override List<InstantCastFinder> GetInstantCastFinders()
    {
        return
        [
            new DamageCastFinder(ThrummingPresenceBuff, ThrummingPresenceDamage),
        ];
    }

    internal override List<PhaseData> GetPhases(ParsedEvtcLog log, bool requirePhases)
    {
        List<PhaseData> phases = GetInitialPhase(log);
        SingleActor Decima = Targets.FirstOrDefault(x => x.IsSpecies(ArcDPSEnums.TargetID.Decima)) ?? throw new MissingKeyActorsException("Decima not found");
        phases[0].AddTarget(Decima);
        if (!requirePhases)
        {
            return phases;
        }
        // Invul check
        phases.AddRange(GetPhasesByInvul(log, NovaShield, Decima, true, true));
        for (int i = 1; i < phases.Count; i++)
        {
            PhaseData phase = phases[i];
            if (i % 2 == 0)
            {
                phase.Name = "Split " + (i) / 2;
                phase.AddTarget(Decima);
            }
            else
            {
                phase.Name = "Phase " + (i + 1) / 2;
                phase.AddTarget(Decima);
            }
        }
        return phases;
    }

    internal static Dictionary<long, string> fluxlanceBuffToOverheadMap = new Dictionary<long, string>
    {
        {TargetOrder1JW, ParserIcons.TargetOrder1Overhead},
        {TargetOrder2JW, ParserIcons.TargetOrder2Overhead},
        {TargetOrder3JW, ParserIcons.TargetOrder3Overhead},
        {TargetOrder4JW, ParserIcons.TargetOrder4Overhead},
        {TargetOrder5JW, ParserIcons.TargetOrder5Overhead},
    };
    internal override void ComputeNPCCombatReplayActors(NPC target, ParsedEvtcLog log, CombatReplay replay)
    {
        var lifespan = ((int)replay.TimeOffsets.start, (int)replay.TimeOffsets.end);
        switch (target.ID)
        {
            case (int)ArcDPSEnums.TargetID.Decima:
                if (log.CombatData.TryGetEffectEventsBySrcWithGUID(target.AgentItem, EffectGUIDs.DecimaMainshockIndicator, out var mainshockSlices))
                {
                    foreach (EffectEvent effect in mainshockSlices)
                    {
                        long duration = 2300;
                        long growing = effect.Time + duration;
                        (long start, long end) lifespan2 = effect.ComputeLifespan(log, duration);
                        var rotation = new AngleConnector(effect.Rotation.Z + 90);
                        var slice = (PieDecoration)new PieDecoration(1200, 32, lifespan2, Colors.LightOrange, 0.4, new PositionConnector(effect.Position)).UsingRotationConnector(rotation);
                        replay.AddDecorationWithBorder(slice, Colors.LightOrange, 0.6);
                    }
                }

                var cls = target.GetCastEvents(log, log.FightData.FightStart, log.FightData.FightEnd).ToArray();
                var fluxlances = cls.Where(x => x.SkillId == Fluxlance);
                int start;
                int end;
                var length = 3000U;
                var width = 50U;

                foreach (var c in fluxlances)
                {

                    start = (int)c.Time;
                    end = (int)c.EndTime;
                    if (replay.Rotations.Count != 0)
                    {
                        var connector = new AgentConnector(target).WithOffset(new(length / 2, 0, 0), true);
                        var rotationConnector = new AgentFacingConnector(target);
                        replay.Decorations.Add(
                            new RectangleDecoration(length, width, (start, end), Colors.Red, 0.7, connector)
                                .UsingRotationConnector(rotationConnector)
                        );
                        if (end > start + c.ExpectedDuration)
                        {
                            replay.Decorations.Add(new RectangleDecoration(length, width, (start + c.ExpectedDuration, end), Colors.LightGrey, 0.7, connector).UsingRotationConnector(rotationConnector));
                        }
                    }
                }

                var multipleLances = cls.Where(x => x.SkillId == FluxlanceFusilladeCast);
                var keys = fluxlanceBuffToOverheadMap.Keys;
                foreach (var c in multipleLances)
                {
                    var playerBuffStatuses = log.PlayerList.Select(p =>
                        (p, keys.Select(k => p.GetBuffStatus(log, k, c.Time))
                            .Where(buff => buff.Value > 0))
                    );

                    foreach (var tuple in playerBuffStatuses)
                    {
                        if (!tuple.Item2.Any())
                        {
                            continue;
                        }

                        var buff = tuple.Item2.First();
                        var connector = new AgentConnector(target).WithOffset(new(length / 2, 0, 0), true);
                        var toPlayerConnector = new AgentFacingAgentConnector(target, tuple.p);
                        var decoration = new RectangleDecoration(length, width, (c.Time, buff.End), Colors.Orange, 0.3, connector)
                                .UsingRotationConnector(toPlayerConnector);
                        replay.Decorations.Add(decoration);
                    }
                }
                break;
            // TODO: find all greens and their proper sizes
            case (int)ArcDPSEnums.TrashID.GreenOrb1Person:
                replay.AddOverheadIcon(lifespan, target, ParserIcons.TargetOrder1Overhead);
                //replay.Decorations.Add(new CircleDecoration(100, lifespan, Colors.Green, 0.3, new AgentConnector(target)));
                break;
            case (int)ArcDPSEnums.TrashID.GreenOrb2Persons:
                replay.AddOverheadIcon(lifespan, target, ParserIcons.TargetOrder2Overhead);
                //replay.Decorations.Add(new CircleDecoration(200, lifespan, Colors.Green, 0.3, new AgentConnector(target)));
                break;
            case (int)ArcDPSEnums.TrashID.GreenOrb3Persons:
                replay.AddOverheadIcon(lifespan, target, ParserIcons.TargetOrder3Overhead);
                //replay.Decorations.Add(new CircleDecoration(200, lifespan, Colors.Green, 0.3, new AgentConnector(target)));
                break;
            case (int)ArcDPSEnums.TrashID.EnlightenedConduit:
                if (log.CombatData.TryGetEffectEventsBySrcWithGUID(target.AgentItem, EffectGUIDs.DecimaEnlightenedConduitPurpleAoE, out var effects))
                {
                    // TODO: We need to find a way to handle sizing
                    foreach (var effect in effects)
                    {
                        var aoeLifeSpan = effect.ComputeDynamicLifespan(log, 1200000);
                        // Placeholder to indicate activated conduits, until we can find proper sizes
                        replay.AddOverheadIcon(aoeLifeSpan, target, BuffImages.InvokeLightning);
                        //replay.Decorations.Add(new CircleDecoration(150, aoeLifeSpan, Colors.DarkPurple, 0.3, new PositionConnector(effect.Position)));
                    }
                }
                var walls = GetFilteredList(log.CombatData, DecimaConduitWallBuff, target, true, true);
                replay.AddTether(walls, Colors.Purple, 0.4, 60, true);
                break;
            default:
                break;
        }
    }


    internal override void ComputePlayerCombatReplayActors(PlayerActor player, ParsedEvtcLog log, CombatReplay replay)
    {
        base.ComputePlayerCombatReplayActors(player, log, replay);

        foreach (var kvp in fluxlanceBuffToOverheadMap)
        {
            replay.AddOverheadIcons(
                player.GetBuffStatus(log, kvp.Key, log.FightData.LogStart, log.FightData.LogEnd).Where(x => x.Value > 0),
                player,
                kvp.Value
            );
        }
    }
}
