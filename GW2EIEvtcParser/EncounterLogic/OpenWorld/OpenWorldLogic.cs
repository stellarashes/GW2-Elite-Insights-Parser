﻿using static GW2EIEvtcParser.SpeciesIDs;

namespace GW2EIEvtcParser.EncounterLogic;

internal abstract class OpenWorldLogic : FightLogic
{
    public OpenWorldLogic(int triggerID) : base(triggerID)
    {
        ParseMode = ParseModeEnum.OpenWorld;
        SkillMode = SkillModeEnum.PvE;
        EncounterCategoryInformation.Category = EncounterCategory.FightCategory.OpenWorld;
        EncounterCategoryInformation.SubCategory = EncounterCategory.SubFightCategory.OpenWorld;
        EncounterID |= EncounterIDs.EncounterMasks.OpenWorldMask;
    }
    protected override IReadOnlyList<TargetID>  GetTargetsIDs()
    {
        return new[] { GetTargetID(GenericTriggerID) };
    }
}
