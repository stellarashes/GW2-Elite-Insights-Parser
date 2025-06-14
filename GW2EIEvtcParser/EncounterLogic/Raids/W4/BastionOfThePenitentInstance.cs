﻿using GW2EIEvtcParser.EIData;
using GW2EIEvtcParser.ParsedData;
using static GW2EIEvtcParser.ArcDPSEnums;
using static GW2EIEvtcParser.EncounterLogic.EncounterLogicPhaseUtils;
using static GW2EIEvtcParser.EncounterLogic.EncounterLogicTimeUtils;
using static GW2EIEvtcParser.ParserHelpers.EncounterImages;
using static GW2EIEvtcParser.SpeciesIDs;

namespace GW2EIEvtcParser.EncounterLogic;

internal class BastionOfThePenitentInstance : BastionOfThePenitent
{
    public BastionOfThePenitentInstance(int triggerID) : base(triggerID)
    {
        EncounterID = 0;
        Icon = InstanceIconBastionOfThePenitent;
        Extension = "bstpen";
    }

    internal override string GetLogicName(CombatData combatData, AgentData agentData)
    {
        return "Bastion Of The Penitent";
    }

    protected override IReadOnlyList<TargetID> GetTargetsIDs()
    {
        return
        [
            TargetID.Cairn,
            TargetID.MursaatOverseer,
            TargetID.Samarog,
            //TargetID.Deimos,
        ];
    }
}
