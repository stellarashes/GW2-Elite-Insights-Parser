﻿using GW2EIEvtcParser.ParserHelpers;
using static GW2EIEvtcParser.ArcDPSEnums;
using static GW2EIEvtcParser.DamageModifierIDs;
using static GW2EIEvtcParser.EIData.Buff;
using static GW2EIEvtcParser.EIData.DamageModifiersUtils;
using static GW2EIEvtcParser.ParserHelper;
using static GW2EIEvtcParser.SkillIDs;

namespace GW2EIEvtcParser.EIData;

internal static class BerserkerHelper
{
    internal static readonly List<InstantCastFinder> InstantCastFinder =
    [
        new DamageCastFinder(KingOfFires, KingOfFires)
            .WithBuilds(GW2Builds.July2019Balance)
            .UsingOrigin(EIData.InstantCastFinder.InstantCastOrigin.Trait),
        new EffectCastFinder(Outrage, EffectGUIDs.BerserkerOutrage)
            .UsingSrcSpecChecker(Spec.Berserker),
        new BuffLossCastFinder(BerserkEndSkill, BerserkBuff),
        new BuffGainCastFinder(BerserkSkill, BerserkBuff)
            .WithBuilds(GW2Builds.October2022Balance),
    ];

    internal static readonly IReadOnlyList<DamageModifierDescriptor> OutgoingDamageModifiers =
    [
        // Always Angry
        new BuffOnActorDamageModifier(Mod_AlwaysAngry, AlwaysAngry, "Always Angry", "7% per stack", DamageSource.NoPets, 7.0, DamageType.StrikeAndCondition, DamageType.All, Source.Berserker, ByPresence, TraitImages.AlwaysAngry, DamageModifierMode.PvE)
            .WithBuilds(GW2Builds.StartOfLife, GW2Builds.April2019Balance),
        // Bloody Roar
        new BuffOnActorDamageModifier(Mod_BloodyRoar, BerserkBuff, "Bloody Roar", "10% while in berserk", DamageSource.NoPets, 10.0, DamageType.Strike, DamageType.All, Source.Berserker, ByPresence, TraitImages.BloodyRoar, DamageModifierMode.All)
            .WithBuilds(GW2Builds.StartOfLife, GW2Builds.April2019Balance),
        new BuffOnActorDamageModifier(Mod_BloodyRoar, BerserkBuff, "Bloody Roar", "20% while in berserk", DamageSource.NoPets, 20.0, DamageType.Strike, DamageType.All, Source.Berserker, ByPresence, TraitImages.BloodyRoar, DamageModifierMode.All)
            .WithBuilds(GW2Builds.April2019Balance, GW2Builds.July2019Balance),
        new BuffOnActorDamageModifier(Mod_BloodyRoar, BerserkBuff, "Bloody Roar", "20% while in berserk", DamageSource.NoPets, 20.0, DamageType.Strike, DamageType.All, Source.Berserker, ByPresence, TraitImages.BloodyRoar, DamageModifierMode.PvE)
            .WithBuilds(GW2Builds.July2019Balance, GW2Builds.August2022Balance),
        new BuffOnActorDamageModifier(Mod_BloodyRoar, BerserkBuff, "Bloody Roar", "25% while in berserk", DamageSource.NoPets, 25.0, DamageType.Strike, DamageType.All, Source.Berserker, ByPresence, TraitImages.BloodyRoar, DamageModifierMode.PvE)
            .WithBuilds(GW2Builds.August2022Balance, GW2Builds.June2023BalanceAndSOTOBetaAndSilentSurfNM),
        new BuffOnActorDamageModifier(Mod_BloodyRoar, BerserkBuff, "Bloody Roar", "20% while in berserk", DamageSource.NoPets, 20.0, DamageType.Strike, DamageType.All, Source.Berserker, ByPresence, TraitImages.BloodyRoar, DamageModifierMode.PvE)
            .WithBuilds(GW2Builds.June2023BalanceAndSOTOBetaAndSilentSurfNM, GW2Builds.January2024Balance),
        new BuffOnActorDamageModifier(Mod_BloodyRoar, BerserkBuff, "Bloody Roar", "15% while in berserk", DamageSource.NoPets, 15.0, DamageType.Strike, DamageType.All, Source.Berserker, ByPresence, TraitImages.BloodyRoar, DamageModifierMode.PvE)
            .WithBuilds(GW2Builds.January2024Balance),
        new BuffOnActorDamageModifier(Mod_BloodyRoar, BerserkBuff, "Bloody Roar", "15% while in berserk", DamageSource.NoPets, 15.0, DamageType.Strike, DamageType.All, Source.Berserker, ByPresence, TraitImages.BloodyRoar, DamageModifierMode.sPvPWvW)
            .WithBuilds(GW2Builds.July2019Balance, GW2Builds.October2022Balance),
        new BuffOnActorDamageModifier(Mod_BloodyRoar, BerserkBuff, "Bloody Roar", "10% while in berserk", DamageSource.NoPets, 10.0, DamageType.Strike, DamageType.All, Source.Berserker, ByPresence, TraitImages.BloodyRoar, DamageModifierMode.sPvPWvW)
            .WithBuilds(GW2Builds.October2022Balance),

    ];

    internal static readonly IReadOnlyList<DamageModifierDescriptor> IncomingDamageModifiers =
    [
        // Fell No Pain
        new CounterOnActorDamageModifier(Mod_FeelNoPain, FeelNoPainSavageInstinct, "Feel No Pain", "-100%", DamageSource.Incoming, DamageType.StrikeAndCondition, DamageType.All, Source.Berserker, TraitImages.SavageInstinct, DamageModifierMode.All)
    ];

    internal static readonly IReadOnlyList<Buff> Buffs =
    [
        new Buff("Berserk", BerserkBuff, Source.Berserker, BuffClassification.Other, SkillImages.Berserk),
        new Buff("Flames of War", FlamesOfWar, Source.Berserker, BuffClassification.Other, SkillImages.FlamesOfWarWarrior)
            .WithBuilds(GW2Builds.StartOfLife, GW2Builds.June2023BalanceAndSOTOBetaAndSilentSurfNM),
        new Buff("Blood Reckoning", BloodReckoning , Source.Berserker, BuffClassification.Other, SkillImages.BloodReckoning)
            .WithBuilds(GW2Builds.StartOfLife, GW2Builds.October2022Balance),
        new Buff("Blood Reckoning", BloodReckoning , Source.Berserker, BuffStackType.Queue, 9, BuffClassification.Other, SkillImages.BloodReckoning)
            .WithBuilds(GW2Builds.October2022Balance),
        new Buff("Rock Guard", RockGuard , Source.Berserker, BuffClassification.Other, SkillImages.ShatteringBlow),
        new Buff("Feel No Pain (Savage Instinct)", FeelNoPainSavageInstinct, Source.Berserker, BuffClassification.Other, TraitImages.SavageInstinct)
            .WithBuilds(GW2Builds.April2019Balance),
        new Buff("Always Angry", AlwaysAngry, Source.Berserker, BuffClassification.Other, TraitImages.AlwaysAngry)
            .WithBuilds(GW2Builds.StartOfLife, GW2Builds.April2019Balance),
        new Buff("Heat the Soul", HeatTheSoulBuff, Source.Berserker, BuffClassification.Other, TraitImages.HeatTheSoul),
    ];

}
