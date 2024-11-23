﻿namespace GW2EIEvtcParser;

public static class EffectGUIDs
{
    #region Generic
    // Generic
    // blue circles indicating radius of boons etc.
    public static readonly GUID Generic240UnitRadius = new("E7C50E0E148CBE44BB2770AF2D6750A4"); // e.g. speed of synergy, bypass coating
    public static readonly GUID Generic360UnitRadius = new("10873BDE22D87845AAF004B0A60FA546"); // e.g. crisis zone
    public static readonly GUID Generic360UnitRadius2 = new("0B3A5E8DDBB43447815547D96E7CA146"); // e.g. over shield, deathly haste, mechanical genius, barrier burst
    public static readonly GUID Generic360Or600UnitRadius = new("4C7A5E148F7FD642B34EE4996DDCBBAB"); // somehow both? e.g. chaos vortex, medical dispersion field, reconstruction enclosure, barrier engine
    public static readonly GUID Generic600UnitRadius = new("9C7C1B2379CCDD4990001A38030E4495"); // e.g. ranger spirits, protect me
    public static readonly GUID Generic900UnitRadius = new("EB9EBC2CB610B448BB00B7FBCB191F28"); // e.g. call of the wild
    public static readonly GUID GenericTrapInactive = new("D9F9B146BC2B914B874EA980B2FF0C00");
    public static readonly GUID RuneOfNightmare = new("149E616EB45B1E4982305B99A7952EA8");
    public static readonly GUID StealthApply = new("B44BAD999BEB2D4DB284745895B42BDD");
    public static readonly GUID StealthReveal = new("A37F8E2B550B254DA89F933BDF654B41"); // also used with e.g. infiltrators strike, infiltrators arrow, shadowstep, shadow return, infiltrators signet
    public static readonly GUID WhiteMantlePortalInactive = new("D43373FEFA19A54DA2A2B6BB7834A338");
    public static readonly GUID WhiteMantlePortalActive = new("388CF9246218A34DB2F8107E19FCA471");
    #endregion
      
    #region Mounts
    // Skyscale
    public static readonly GUID SkyscaleLaunch = new("F6A06D8222280F40B17A6984F9B5894F");
    public static readonly GUID SkyscaleFireball = new("0325D55E6A772047981F4EEAA5CAE537");
    public static readonly GUID SkyscaleFireballExplosion = new("BA8C9DDEAC761A48ACC53777F1D68C34");
    public static readonly GUID SkyscaleBlast1 = new("4D30A7F374E56E4F806420A81EAEA03F");
    public static readonly GUID SkyscaleBlast2 = new("E15FF7FD742AA24BB6C2BE38087CFC22");
    #endregion
      
    #region Gear
    // Relics
    public static readonly GUID RelicWhiteCircle = new("866307A6A0E34242BDC3067AB24A549D"); // Appears for Nightmare, Citadel, Krait
    public static readonly GUID RelicOfCerusEye = new("1066BEACB107C743908D860DA2D59796");
    public static readonly GUID RelicOfCerusEye2 = new("521B6C72BF291E4E8A895A0827AF1727");
    public static readonly GUID RelicOfCerusBeam = new("513AEEF08C217942A798831BD9F4903E"); // 1 second delayed
    public static readonly GUID RelicOfCerusBeam2 = new("43F06D75DF774C4DBB1383B8621B1047"); // 1 second delayed
    public static readonly GUID RelicOfIce = new("54F2B4920F7E2D4FAA56CED739BA2C41");
    public static readonly GUID RelicOfTheCitadelExplosion = new("DE4373D3B08DE04E903B99B6F9194F74"); // 2.5 seconds delayed
    public static readonly GUID RelicOfFireworks = new("2BC033D40C0AEB40A77EEF28D51AE263");
    public static readonly GUID RelicOfTheNightmare = new("0FCF4B1F75575949AA4997365FAE0288");
    public static readonly GUID RelicOfTheKrait = new("0685880038B8F441B191439DB678A5F8");
    public static readonly GUID RelicOfTheSunless = new("B1FFFAEFC0A3C74D96851E07C75B3FC7"); // Target Src
    public static readonly GUID RelicOfTheWizardsTower = new("2A1D0C23F448C348A83E9A4F2669B73F");
    public static readonly GUID RelicOfPeitha = new("0CBFB70434661647B68003ECD77207E6"); // Projectile
    public static readonly GUID RelicOfAkeem = new("8181E21A43EAFB42BC8FFB001F02CF44"); // Target Src
    public static readonly GUID RelicOfTheTwinGenerals = new("40ECD58F39B30041B3E6C7CEDB7C4D8C");
    public static readonly GUID RelicOfSorrow1 = new("DB02EB39ABBEE241859DC9662AD49FA5"); // Duration 0, No Src
    public static readonly GUID RelicOfSorrow2 = new("FEEA4632BAF0B1438D83F6C8B71AEA15"); // Duration 0, No Src
    public static readonly GUID RelicOfSorrow3 = new("3D981397D9C6A44B888212CE4E3F6F9A"); // Duration 4000
    public static readonly GUID RelicOfTheStormsinger = new("E8EB2CDF97F34C42A8AAC0D3BA6551D0"); // Effect appears up to 4 times. Collides with Overload Air but OA does not multi trigger
    #endregion
      
    #region Mesmer
    public static readonly GUID MesmerThePrestigeDisappear1 = new("48B69FBC3090E144BFC067D6C0208878");
    public static readonly GUID MesmerThePrestigeDisappear2 = new("5FA6527231BB8041AC783396142C6200"); // also used with elementalist cleansing fire
    public static readonly GUID MesmerSignetOfMidnight = new("02154B72900B5740A73CD0ADECED27BF");
    public static readonly GUID MesmerFeedback = new("D6C8F406E4DEE04AB16A215BE068E910");
    public static readonly GUID MesmerVeil = new("6B29E895E2EB9341B560FFD3A78F78F2");
    public static readonly GUID MesmerNullField = new("D8E8B086ACCF7549B8F50CF1AF177039");
    public static readonly GUID MesmerTeleport = new("C34E250B01FF534292EE6AB36D768337"); // used by blink, phase retreat, swap (illusionary leap)
    public static readonly GUID MesmerPortalInactive = new("F3CD4D9BFC8EAD45AAA1EA7A3AB148BF");
    public static readonly GUID MesmerPortalActive = new("3C346BE32EFB9E40BE39E379B061C803");
    public static readonly GUID MesmerCryOfFrustration = new("52F65A4D9970954BA849CB57A46A65A8");
    public static readonly GUID MesmerDiversion = new("916D8385083F144EBAA5BEEDE21FD47A");
    public static readonly GUID MesmerDistortionOrMindWrack = new("3D29ABD39CB5BD458C4D50A22FCC0E4B");
    public static readonly GUID MesmerMantraOfResolveAndPowerCleanse = new("593E668A006AB24D84999AED68F2E4C4");
    public static readonly GUID MesmerMantraOfResolveAndPowerCleanse2 = new("ABF2332D28C7D6449A5B822E5714ADA4");
    public static readonly GUID MesmerMantraOfConcentrationAndPowerBreak = new("5B488D552E316045AD99C4A98EEDDB1E");
    public static readonly GUID MesmerPowerReturn = new("F53E2CE3B06B934085D46FA59468477B");
    public static readonly GUID MesmerDimensionalAperturePortal = new("9246D82C91B5274396DBAB561DC8EFAF");
    public static readonly GUID MesmerIllusionOfLife1 = new("F7D8B60F91335741AB6CDCC9B7CEF2C5");
    public static readonly GUID MesmerIllusionOfLife2 = new("40818C8E9CC6EF4388C2821FCC26A9EC"); // Collides with other fields
    public static readonly GUID MesmerMentalCollapse120Radius = new("15C98898B2E33A49A7BAE3DFE99A2584");
    public static readonly GUID MesmerMentalCollapse240Radius = new("4590C8949239AE419CEC0F9053548A6F");
    public static readonly GUID MesmerMentalCollapse360Radius = new("674B586AEBEACC419A1EA44FE112F027");
    public static readonly GUID ChronomancerSeizeTheMomentShatter = new("4C7A5E148F7FD642B34EE4996DDCBBAB"); // This seems to happen everytime split second, rewinder, time sink or continuum split are cast under SeizeTheMoment
    public static readonly GUID ChronomancerSplitSecond = new("C035166E3E4C414ABE640F47797D9B4A"); // this is also triggered by the clones while being sourced to the chrono
    public static readonly GUID ChronomancerRewinder = new("DC1C8A043ADCD24B9458688A792B04BA"); // this is also triggered by the clones while being sourced to the chrono
    public static readonly GUID ChronomancerTimeSink = new("AB2E22E7EE74DA4C87DA777C62E475EA");
    public static readonly GUID ChronomancerWellGeneric = new("643B0B821F470748BC877B089ACD0C18");
    public static readonly GUID ChronomancerWellOfEternity = new("F574310CA199DF4488AFFA0216BA1454");
    public static readonly GUID ChronomancerWellOfEternityPulse = new("AB9D0AC13EEBE7459CFA914542567F40"); // 1 pulse every second, 3 total
    public static readonly GUID ChronomancerWellOfEternityExplosion = new("E35E0D4F892AAD4BB76B2A5C6F9DE8C1"); // 1 second after final pulse
    public static readonly GUID ChronomancerWellOfAction = new("6CB76B96F4242C468BFE5FA5FA038D73");
    public static readonly GUID ChronomancerWellOfActionPulse = new("FD2802E2DC92124F940DDDD998B8B57B"); // 1 pulse every second, 3 total
    public static readonly GUID ChronomancerWellOfActionExplosion = new("F57C7DD4E9BDE348BF8583F97E1C01C1"); // 1 second after final pulse
    public static readonly GUID ChronomancerWellOfCalamity = new("4C7071BBE735D843B12893898A4C2688");
    public static readonly GUID ChronomancerWellOfCalamityPulse = new("D49238E0B3A365489A5B601EDB68F942"); // 1 pulse every second, 3 total
    public static readonly GUID ChronomancerWellOfCalamityExplosion = new("CEB6C2416CF40C44B0C156BCBF247E24"); // 1 second after final pulse
    public static readonly GUID ChronomancerWellOfPrecognition = new("AB99EA6C6534B74597277998C301866B");
    public static readonly GUID ChronomancerWellOfPrecognitionPulse = new("E5F4B6BC7A9F084CAB5FD548163DF7CF"); // 1 pulse every second, 3 total
    public static readonly GUID ChronomancerWellOfPrecognitionExplosion = new("9DDFE99A09A8FA45810B1ED41B310B74"); // 1 second after final pulse
    public static readonly GUID ChronomancerWellOfSenility = new("9ED7EC5CDA3A7D4DB44998CE40C8CF31");
    public static readonly GUID ChronomancerWellOfSenilityPulse = new("DF910E4C6F75DB4CB345889EA68808B2"); // 1 pulse every second, 3 total
    public static readonly GUID ChronomancerWellOfSenilityExplosion = new("8799483A7E93AB4385451033145B3345"); // 1 second after final pulse
    public static readonly GUID ChronomancerGravityWell = new("42B42983DA2E2D45876D201F1DCECE73");
    public static readonly GUID ChronomancerGravityWellPulse = new("60A74BCA1ECF974FB31CE28ABDF6D8AE"); // 1 pulse every second, 3 total
    public static readonly GUID ChronomancerGravityWellExplosion = new("E0D03976A4BC034E8ABFBBECCC828932"); // 1 second after final pulse
    public static readonly GUID MirageCloak = new("4C7A5E148F7FD642B34EE4996DDCBBAB");
    public static readonly GUID MirageMirror = new("1370CDF5F2061445A656A1D77C37A55C");
    public static readonly GUID MirageJaunt = new("3A5A38C26A1FFB438EAD734F3ED42E5E"); // may have collisions! not known which
    public static readonly GUID VirtuosoUnstableBladestorm = new("DEF12997FAEA6847A8786CD2920ACA91"); // has effect end
    public static readonly GUID VirtuosoUnstableBladestorm2 = new("242B1513FCF07842B658A56CDE4851C8");
    public static readonly GUID VirtuosoBladeturnRequiem = new("87B761200637AC48B71469F553BA6F60");
    public static readonly GUID VirtuosoRainOfSwords = new("83834EDBA8E79946A6D5665E3519B72C");
    public static readonly GUID VirtuosoThousandCuts = new("E4002B7AD7DF024394D0184B47A316E7");
    public static readonly GUID MesmerRifleAbstraction = new("90A4ECA144416A4790FC0D68EB0C1A8C");
    // public static readonly GUID MirageJauntConflict1                    = new("B6557C336041B24FA7CC198B6EBDAD9A"); // used with e.g. jaunt & axes of symmetry
    // public static readonly GUID MirageJauntConflict2                    = new("D7A05478BA0E164396EB90C037DCCF42"); // used with e.g. jaunt, axes of symmetry, illusionary ambush
    // public static readonly GUID MesmerTrail                             = new("73414BA39AFCF540A90CF91DE961CCEF"); // used with e.g. mirror images, phase retreat, illusionary ambush - likely the trail left behind
    #endregion
      
    #region Necromancer
    public static readonly GUID NecromancerNecroticTraversal = new("47C48881C5AC214388F6253197A7F11A");
    public static readonly GUID NecromancerUnholyBurst = new("C4E8DD3234E0C647993857940ED79AC1"); // also used for spiteful spirit
    public static readonly GUID NecromancerPlagueSignet = new("E78ED095E97F1D4A8BEB901796449E2F"); // might be pov only?
    public static readonly GUID NecromancerWellOfBlood = new("159515DADB2DFB46A980A2A661BD881B");
    public static readonly GUID NecromancerWellOfSuffering = new("E24BA6F2CCB8374CB7F5BE829BC7228E");
    public static readonly GUID NecromancerWellOfDarkness = new("824EF999A0B6D14D9AC2EC843C6984D5");
    public static readonly GUID NecromancerWellOfCorruption = new("FF96BAE8EC4D5A4CBF6E13C15649F3DA");
    public static readonly GUID NecromancerCorrosivePoisonCloud = new("68D13E0EBB247A40B2F131B2C729443E");
    public static readonly GUID NecromancerPlaguelands = new("883D5C97F3673843A8423D01B97ED78F");
    public static readonly GUID NecromancerPlaguelandsPulse1 = new("7E12B3B1896BC748AE50333267CDBFB9");
    public static readonly GUID NecromancerPlaguelandsPulse2 = new("A442AE5DFE73D04BBC19B050540E000A");
    public static readonly GUID NecromancerPlaguelandsPulse3 = new("253ADDAEC2009A499FA29C44E1D73F05");
    public static readonly GUID NecromancerMarkOfBloodOrChillblains = new("A859FDB2593E2C4ABEFB51907393BBAA");
    public static readonly GUID NecromancerPutridMark = new("651695CA0DB15E4F88E30BF58630B891");
    public static readonly GUID NecromancerReapersMark = new("074AFD46220642429D67BF645CA81D65");
    public static readonly GUID NecromancerMarkOfBloodActivated1 = new("31D543A5DCEF9643A59EF9498A55ACDE");
    public static readonly GUID NecromancerMarkOfBloodActivated2 = new("5FA6527231BB8041AC783396142C6200");
    public static readonly GUID NecromancerChillblainsActivated = new("831159227814DF4FA354CAD7E0755FEE");
    public static readonly GUID NecromancerPutridMarkActivated1 = new("E52F2D6DBABA934882BBBB8F0832C777");
    public static readonly GUID NecromancerPutridMarkActivated2 = new("EFB9CDA30AEBC744B9D377A99BEBC0B2");
    public static readonly GUID NecromancerPutridMarkActivated3 = new("CAF4E62C2C5CC04499657C2A6A78087B"); // No src or dst
    public static readonly GUID NecromancerReapersMarkActivated = new("255FBE1C15D0C6488BD018748184624F");
    public static readonly GUID NecromancerSignetOfUndeathOverhead = new("1FEB5ECC28F92245A04646869B4A8169");
    public static readonly GUID NecromancerSignetOfUndeathGroundMark = new("28FE26F58FB0534BAF091C2D9D2261EA");
    public static readonly GUID NecromancerSpectralRing = new("99D0D6FC6817E24396180B07711013EE"); // infinite duration, has effect end
    public static readonly GUID NecromancerSpearDistress = new("239BF9EA9B747B44ACC63B86DC49B0D0");
    public static readonly GUID ReaperSuffer = new("6C8C388BCD26F04CA6618D2916B8D796");
    public static readonly GUID ReaperYouAreAllWeaklings1 = new("37242DF51D238A409E822E7A1936D7A6"); // 3 potential candidates, 4th effect has collisions
    public static readonly GUID ReaperYouAreAllWeaklings2 = new("FEE4F26C2866E34C9D75506A8ED94F5E");
    public static readonly GUID ReaperYouAreAllWeaklings3 = new("ED6A8440CB49B248A352B2073FAF1F5F");
    public static readonly GUID ScourgeTrailOfAnguish = new("1DAE3CAEF2228845867AAF419BF31E8C");
    public static readonly GUID ScourgeShade = new("78408C6DA08C2746BEABEB995187271A");
    public static readonly GUID ScourgeShadeStrike = new("C8B109540159AA429E83D0AA98EF3E90");
    public static readonly GUID ScourgeSandSwellPortal = new("086CF7823EB13047B2187E7933639703");
    public static readonly GUID HarbingerCascadingCorruption = new("EEDCAB61CD35E840909B03D398878B1C");
    public static readonly GUID HarbingerDeathlyHaste = new("9C06D9D9B0E22247A1752C426808CD80");
    public static readonly GUID HarbingerDoomApproaches = new("88C0010F0B7148469B88E2A1B4500DCC");
    public static readonly GUID HarbingerVitalDrawSelfDst = new("667EAEE89766E14E883E6ECA5D3D267B"); // Target self
    public static readonly GUID HarbingerVitalDrawAoE = new("859611F71893924989B056F6A011C160"); // Ground effect
    #endregion
      
    #region Elementalist
    public static readonly GUID ElementalistArmorOfEarth1 = new("D43DC34DEF81B746BC130F7A0393AAC7");
    public static readonly GUID ElementalistArmorOfEarth2 = new("D0C072102FAA6A4EA8A16CB73F3B96DD"); // happens at the same time as the other, could be relevant to check should collisions appear
    //public static readonly GUID ElementalistCleansingFire              = new("5FA6527231BB8041AC783396142C6200"); // also used with mesmer the prestige, collides with some air traits
    public static readonly GUID ElementalistSignetOfAir = new("30A96C0E559DBD489FEE36DA96CC374A");
    //public static readonly GUID ElementalistLightningFlash             = new("40818C8E9CC6EF4388C2821FCC26A9EC"); // Conflicts with certain field combos, thief teleport skills, guardian judges/merciful intervention
    public static readonly GUID ElementalistMeteorShowerCircle = new("0F42F49776A5F74E8A0CADC4BCF53904");
    public static readonly GUID ElementalistMeteorShowerMeteor = new("F3DD685A8E52124A9FCC653C90EA789A");
    public static readonly GUID ElementalistStaticFieldStaff = new("1ED1C9E57048CF419AFB9C31329FF51E");
    public static readonly GUID ElementalistStaticFieldLightningHammer = new("E32640807FA71947BE21177E2C75043C");
    public static readonly GUID ElementalistUpdraft = new("DFFD3374FA23D644A6D0BE37216938C5");
    public static readonly GUID ElementalistUpdraft2 = new("0FA8EF1CE419504A9D03004D6CF5F073");
    public static readonly GUID ElementalistUpdraftWind = new("DE8C1CE6E3AC3445911B214CA8021BDD");
    public static readonly GUID ElementalistFirestorm = new("172F43AB94CB214D95A6EA7F7DFCE520"); // Same for Glyph of Storms and Conjured Fiery Greatsword
    public static readonly GUID ElementalistGeyserSplash = new("C0FAFED39AEDD948B025AA1272B80A8B");
    public static readonly GUID ElementalistGeyser = new("3A15A72D28971D4D8CE5C24DB66C5595");
    public static readonly GUID ElementalistEtchingVolcanoTier0 = new("CD585E149DBA7B48B849A6770A13CA5E"); // duration 7000
    public static readonly GUID ElementalistEtchingVolcanoTier1 = new("B3F5CE63080B5843A2210868723D1DC5"); // duration left of above
    public static readonly GUID ElementalistEtchingVolcanoTier2 = new("3A0470359182F1419386663A1B4B96A5"); // duration left of above
    public static readonly GUID ElementalistEtchingVolcanoTier3 = new("8FE807E76BFB7E4094C15370C609F967"); // duration left of above
    public static readonly GUID ElementalistEtchingVolcanoPerfect = new("B484C8F2096A4947A40ADF273B9E54FD"); // duration left of above
    public static readonly GUID ElementalistVolcano = new("C448637F92482941A56674014635FD57"); // duration 4500
    public static readonly GUID ElementalistLesserVolcano = new("0F232E502BBD2549A09E21F12FECBEE0"); // duration 3000
    public static readonly GUID ElementalistVolcanoHits = new("F9DC96357BF47A4C8ACAD172B3E62C5C"); // duration 0
    public static readonly GUID ElementalistEtchingJokulhlaupTier0 = new("A732034ABC8F664DA6FB2ABD14471DA9"); // duration 7000
    public static readonly GUID ElementalistEtchingJokulhlaupTier1 = new("1141327798AEA04480325DEB5BF09C80"); // duration left of above
    public static readonly GUID ElementalistEtchingJokulhlaupTier2 = new("A5AC5BC6A81B5E498DAACA0043DA3C27"); // duration left of above
    public static readonly GUID ElementalistEtchingJokulhlaupTier3 = new("5E7DBE302DB3694A9FB86B241E0686EE"); // duration left of above
    public static readonly GUID ElementalistEtchingJokulhlaupPerfect = new("C496AAC50143C240905ADBD54960D069"); // duration left of above
    public static readonly GUID ElementalistEtchingDerechoTier0 = new("D6B06696239539409E2DB26EA0CD0BD6"); // duration 7000
    public static readonly GUID ElementalistEtchingDerechoTier1 = new("D95670A51AE01E43B5F682AB368FCA5C"); // duration left of above
    public static readonly GUID ElementalistEtchingDerechoTier2 = new("9D30874E9EA1964EA5D2406A42F9403D"); // duration left of above
    public static readonly GUID ElementalistEtchingDerechoTier3 = new("D185C50D7A39C24399A8B9A1DE90D801"); // duration left of above
    public static readonly GUID ElementalistEtchingDerechoPerfect = new("0581AA26A9FEBF4CBFAC956CB7E00346"); // duration left of above
    public static readonly GUID ElementalistEtchingHaboobTier0 = new("B9AAEECDACA062468CEF0CF586A8FCE8"); // duration 7000
    public static readonly GUID ElementalistEtchingHaboobTier1 = new("FD3A19911F77344FADFC31A570DA568F"); // duration left of above
    public static readonly GUID ElementalistEtchingHaboobTier2 = new("C6F123F7EFBF364AADAC22E050DFBCA0"); // duration left of above
    public static readonly GUID ElementalistEtchingHaboobTier3 = new("E769B58D51A3954E8909A944B6198611"); // duration left of above
    public static readonly GUID ElementalistEtchingHaboobPerfect = new("11BA980FA8B2314C85BAC45D7EA82D9B"); // duration left of above
    public static readonly GUID ElementalistMeteor = new("BF54809B0B97D44EA1B9C97A43A4B37B"); // duration 1000
    public static readonly GUID ElementalistFulgor = new("BE073ED273CB184CAF38622E030F11B9"); // duration 4000
    public static readonly GUID ElementalistTwister = new("F95B8A4617519245989E5A35784A7032"); // duration 1000 - has end event
    public static readonly GUID ElementalistUndertow = new("7DBF028669B4984FB849F76E1550FECC"); // duration 0 - doesn't have end event
    public static readonly GUID ElementalistFissure = new("89D8A6B9E9F1E644A4C553235DC7DDBE"); // duration 0 - doesn't have end event
    public static readonly GUID TempestOverloadFire1 = new("675AE0297C86764ABC4A5988CE76A20E");
    public static readonly GUID TempestOverloadFire2 = new("977D44CE34F6B9438BCDCFA074BBDCA8");
    public static readonly GUID TempestOverloadAir1 = new("3CE58ECAB1EE9C4E96F70E3A64967F55");
    public static readonly GUID TempestOverloadAir2 = new("E8EB2CDF97F34C42A8AAC0D3BA6551D0");
    public static readonly GUID TempestFeelTheBurn = new("C668B5DB6220D9448817B3E5F7DE6E46");
    public static readonly GUID TempestEyeOfTheStorm1 = new("52FEF389CF7D014BAA375EACF1826BB6");
    public static readonly GUID TempestEyeOfTheStorm2 = new("31FE88E9CCF82047895FD0EF19C9BBA0"); // happens at the same time as the other, could be relevant to check should collisions appear 
    public static readonly GUID TempestLightningOrb1 = new("DE4C727C58DA0A4EB87D5433B2B64EAB");
    public static readonly GUID TempestLightningOrb2 = new("AF5462A3F3500A4B8C91D6BEAFA62B62");
    public static readonly GUID CatalystDeployFireJadeSphere = new("AFC5D5C7DA63D64BAAD55F787205B64F");
    public static readonly GUID CatalystDeployWaterJadeSphere = new("6D7EB5747873484DAF29C01FA51FE175");
    public static readonly GUID CatalystDeployAirJadeSphere = new("A3C8A55C3E530140A7F99AAA1CBB4E09");
    public static readonly GUID CatalystDeployEarthJadeSphere = new("A674D3E7BC0C4342BC7A4EF0EE8FF8F0");
    #endregion
      
    #region Warrior
    public static readonly GUID WarriorSignetOfMight = new("75EF160EAFC0394CACC436CF89819148");
    public static readonly GUID WarriorSignetOfStamina = new("1E720C4D42448D45BDCB6307869D3D66"); // not actually instant cast, just for reference
    public static readonly GUID WarriorDolyakSignet = new("D7F8FA5695F8714B99A51EE72EF6E178");
    public static readonly GUID SpellbreakerWindsOfDisenchantment = new("926917599B6B6E498AD62B812001B823");
    public static readonly GUID BladeswornDragonspikeMine = new("B5BE541DBF290E4AA381E1E52A2A3525");
    public static readonly GUID BerserkerOutrage = new("AC32B7F7BB281B4D94713F180C44F322");
    #endregion
      
    #region Revenant
    public static readonly GUID RevenantTabletAutoHeal = new("C715D15450E56E4998F9EB90B91C5668");
    public static readonly GUID RevenantTabletVentarisWill = new("D3FD740370D6B747B2DA4F8F065A0177");
    public static readonly GUID RevenantProtectiveSolace = new("63683ECFD27DA746BF0B16404D817978");
    public static readonly GUID RevenantNaturalHarmony = new("390487E4E5DFEA4C922AE3156A86D9DB");
    public static readonly GUID RevenantNaturalHarmonyEnergyRelease = new("E239BA17214B4943A4EC2D6B43F6175F");
    public static readonly GUID RevenantPurifyingEssence = new("D2B388E8DB721544A110979C3A384977");
    public static readonly GUID RevenantEnergyExpulsion = new("BE191381B1BC984A989D94D215DDEA1F");
    public static readonly GUID RevenantInspiringReinforcement = new("09171204F3936841813E518123E2F867");
    public static readonly GUID RevenantInspiringReinforcementPart = new("E6D6CD56B9A61E40A86F982C60421625");
    public static readonly GUID RevenantEternitysRequiemOnPlayer = new("40240467597E2746A5CCFA31FAC22FAB");
    public static readonly GUID RevenantEternitysRequiemHit = new("9BFCBED9DE8A6E4E8AB5F480629AE244");
    public static readonly GUID RevenantCoalescenceOfRuin = new("D37B86D576586B489A951153B598CDE6");
    public static readonly GUID RevenantCoalescenceOfRuinLast = new("D66761A11B8FF344B3CEBE31F458896C");
    public static readonly GUID RevenantDropTheHammer = new("A4311C8684668348B427FA0162992E6C");
    public static readonly GUID RevenantSpearAbyssalBlitz1 = new("25908EB455863D43AE70FB3F4A22D6E4"); // Duration 500 - Black smoke
    public static readonly GUID RevenantSpearAbyssalBlitz2 = new("EA6D96295971F34094FB70A765204A02"); // Duration 0
    public static readonly GUID RevenantSpearBlitzMines1 = new("0E5D42F70AF65E4ABBB7EE94C3D5BD1C"); // Infinite duration - Mine spawn
    public static readonly GUID RevenantSpearBlitzMines2 = new("834EE816C77EFD4C99C001D9BAE6DDD7"); // Infinite duration - Mine
    public static readonly GUID RevenantSpearBlitzMinesDetonation1 = new("40C9F5FE5BD3BD449B5E48DF1E5FD348"); // Duration 0 - Mine detonation
    public static readonly GUID RevenantSpearBlitzMinesDetonation2 = new("1B3ACEE36F61DE42AB1C24BD33B5B5AD"); // Duration 0 - Mine detonation
    public static readonly GUID RevenantSpearAbyssalBlot = new("7F47C082E2C27C4D88102DCFE36C8FAF"); // Duration 3000
    public static readonly GUID RevenantSpearAbyssalRaze = new("E759557D9CE535459D964ED7AAB5034A"); // Duration 5100 (seems wrong)
    public static readonly GUID RevenantSpearAbyssalRazeHit = new("A7BF07C94A2AB54FA6BD1E46B945D4BA"); // Duration 5100 (seems wrong)
    public static readonly GUID RenegadeOrdersFromAboveRighteousRebel = new("F53F05F041957A47AD62B522FE030408");
    public static readonly GUID RenegadeOrdersFromAbove = new("B63D192DED78B1489DDB6E742D603CE5");
    public static readonly GUID RenegadeCitadelBombardmentPortal = new("145B288ECA42CF43A40DFD759419C904");
    public static readonly GUID RenegadeCitadelBombardment1 = new("5BBF59761E6B9D49A91E79D5474CC61C");
    public static readonly GUID RenegadeCitadelBombardment2 = new("6C8201B551CF274C9C1AF51C33AA062A"); // duration 0
    public static readonly GUID RenegadeBreakrazorsBastion = new("72FC15613B4B2C44A1906617998859F9");
    public static readonly GUID RenegadeRazorclawsRage = new("71B04F91F9B3DF4A8954059FCFAD630E");
    public static readonly GUID RenegadeDarkrazorsDaring = new("C8FDB04E59C1034CABEFBECE470AA1BC");
    public static readonly GUID RenegadeIcerazorsIre = new("E725FC2FD486A84EBEAC403DB4DA30DE");
    #endregion
      
    #region Guardian
    public static readonly GUID GuardianGenericFlames = new("EA98C3533AA46E4A9B550929356B7277"); // used e.g. with judges intervention, signet of judgment
    public static readonly GUID GuardianGenericTeleport = new("61C193EBA6526143BE01B80FF7C52217"); // usd e.g. with judges intervention, merciful intervention
    public static readonly GUID GuardianGenericTeleport2 = new("5E1717FB11CE1D44B59B36B6AD83B9CC"); // delayed, when reaching target? used with e.g. judges intervention, symbol of blades
    public static readonly GUID GuardianGenericLightEffect = new("61ED02C4AA44C0429790A79E8EFCA7CC"); // Duration 0 - Used by Signet of Mercy, Empower
    public static readonly GUID GuardianRingOfWarding = new("5A54592448836A46B30BC93A544A0E47");
    public static readonly GUID GuardianLineOfWarding = new("F8BE013B34366E458640B47BF43F257D");
    public static readonly GUID GuardianWallOfReflection = new("70FABE08FFCFEE48A7160A4D479E3F8B");
    public static readonly GUID GuardianSanctuary = new("A96093E9CB3D7F468C5235C81537301E");
    public static readonly GUID GuardianShout = new("122BA55CCDF2B643929F6C4A97226DC9"); // used with all shouts
    public static readonly GUID GuardianSaveYourselves = new("68F2C378E6C80548B5A3C89870C5DD86");
    public static readonly GUID GuardianSmiteCondition = new("8CBE6348BB8C9646B210AEE4BA9BCCA3"); // also lesser smite condition
    public static readonly GUID GuardianContemplationOfPurity1 = new("75D72E2DA47ECF47A6BD009B49B7C708");
    public static readonly GUID GuardianContemplationOfPurity2 = new("D0C072102FAA6A4EA8A16CB73F3B96DD"); // same as elementalist armor of earth
    public static readonly GUID GuardianMercifulIntervention = new("B45E7BD66E424A4CA695DE63DC13E93F"); // delayed, when reaching target?
    public static readonly GUID GuardianSignetOfJudgement1 = new("0AFA3936BD4D70458925660B54D47A90"); // happens twice?
    public static readonly GUID GuardianSignetOfJudgement2 = new("5EAC13DB0953EF4C9C5BCC10DB13C9C8");
    public static readonly GUID GuardianShieldOfTheAvenger = new("0885D553A0A0A341B4C31B7964243407");
    public static readonly GUID GuardianSignetOfMercyLightTray = new("E9D10435E997D846B736B62EDCC6B4BD"); // Duration 2000 - light ray at the start of the cast
    public static readonly GUID GuardianSignetOfMercyEnd = new("61ED02C4AA44C0429790A79E8EFCA7CC"); // Duration 0 - end cast
    public static readonly GUID GuardianSymbolOfPunishment1 = new("D20225BED809BE4D86FFE87D6C5AD2B0"); // duration 5000
    public static readonly GUID GuardianSymbolOfPunishment2 = new("5F56361FEE7463448CA988CE773F4F63"); // duration 6000 - has effect end after 5000
    public static readonly GUID GuardianSymbolOfPunishmentOrb = new("A8C650860481DD48B1B41F76B3054576"); // duration 500
    public static readonly GUID GuardianSymbolOfResolution = new("98C9834C6381204A85DC67C375D135E4"); // duration 4000
    public static readonly GUID GuardianSymbolOfBlades = new("FA37E0B77272314AA1ADCFF824F24C27"); // duration 5000
    public static readonly GUID GuardianDetonateJurisdictionLevel1 = new("6646D48A2446884998EFADB3EFEF0483");
    public static readonly GUID GuardianDetonateJurisdictionLevel2 = new("3E33C9645D62CF4DBC208511BB3D12F1");
    public static readonly GUID GuardianDetonateJurisdictionLevel3 = new("29F6AADDF5E75348854123B956E4BF0E");
    public static readonly GUID GuardianSymbolOfLuminance1 = new("F5E8E3DC7B2F2B4DB8451F3D68FD298D"); // duration 0 - no src - player dst
    public static readonly GUID GuardianSymbolOfLuminance2 = new("951D9581F5B0D64685A2C77E25246E7A"); // duration 4000 - player src
    public static readonly GUID GuardianSymbolOfLuminance3 = new("E37AD3E0D6DA364999D987D9DDFC9707"); // duration 4000 - player src
    public static readonly GUID GuardianSymbolOfLuminance4 = new("0B22F631EBB04341A17FDC57431385EB"); // duration 4000 - player src - CONFLICT Symbol of Vengeance
    public static readonly GUID GuardianSymbolOfLuminance5 = new("0D459F62A5A4FB41A94AD7B7174A4BBC"); // duration 0 - no src - player dst
    public static readonly GUID GuardianSolarStormSpearProjectile = new("7ACBDCFF4A1FAC4E9D3221D946E49658"); // duration 0 - player src
    public static readonly GUID GuardianSolarStormAerealEffect = new("23D4642E4DC66548A7FC8214C73FA3CD"); // duration 0 - player src
    public static readonly GUID GuardianSolarStormSpearImpact = new("928509D0D350234EA86589063083FEB0"); // duration 0 - player src
    public static readonly GUID GuardianEmpower1 = new("124CBEBD2272D04999CEACBA67FD9A6B"); // Duration 5000 - Around Dst - Starts on cast time
    public static readonly GUID GuardianEmpower2 = new("44CFDE741F85CB47A88529C0F547400E"); // Duration 0 - Around Dst - Pulsing effect
    public static readonly GUID FirebrandValiantBulwark = new("1430A107F74F164387668DE2744A1528");
    public static readonly GUID FirebrandStalwartStand1 = new("E20B6672FDCE57409B229DB152BF2286"); // duration 4000
    public static readonly GUID FirebrandStalwartStand2 = new("CA4F198982BFD44180D63EB043F9F710"); // duration 4000
    public static readonly GUID FirebrandShiningRiver1 = new("D2803F97338434488CD789E22E797CE2"); // duration 4000
    public static readonly GUID FirebrandShiningRiver2 = new("AEBF45AEDFF2CC48A64ED01441241288"); // duration 4000
    public static readonly GUID FirebrandScorchedAftermath1 = new("3B0AF49A77811F4EA3CFD1BF671BDDE5"); // duration 4000
    public static readonly GUID FirebrandScorchedAftermath2 = new("4CC8C2BAB89D1C488CD69D4F711D49B3"); // duration 0
    public static readonly GUID FirebrandMantraOfLiberationCone = new("86CC98C9D9D2B64689F8993AB02B09E5");
    public static readonly GUID FirebrandMantraOfLiberationSymbol = new("A8E0E4C48848424D85503B674015D247");
    public static readonly GUID FirebrandMantraOfLoreCone = new("C2B55AE44B295849A2983745203D19A1");
    public static readonly GUID FirebrandMantraOfLoreSymbol = new("3D01B04C5700904BA279E9F135A3FAB3");
    public static readonly GUID FirebrandMantraOfPotenceCone = new("FB70E37EB3915F4BAB6E06E328832D1D");
    public static readonly GUID FirebrandMantraOfPotenceSymbol = new("95B52793B838524AB237EB9FED7834BF");
    public static readonly GUID FirebrandMantraOfSolaceCone = new("D2C28FC5AB651746914FC595D1591623");
    public static readonly GUID FirebrandMantraOfSolaceSymbol = new("8F0C77784AFD7F40B27446617DC05CDC");
    public static readonly GUID FirebrandMantraOfTruthCone = new("C2F283E74AC9024DBB865BA0F98AF20B");
    public static readonly GUID FirebrandMantraOfTruthSymbol = new("E33EA0A63898CA469F864EDA1336FCD0");
    public static readonly GUID FirebrandMantraOfFlameCone = new("9C2F9434C5827943A7F175EFF245D39F");
    public static readonly GUID FirebrandMantraOfFlameSymbol = new("AF2B09AC1145AA4880B967C32A11E81C");
    public static readonly GUID FirebrandTomeOfJusticeOpen = new("D573910FDB59434ABF6E7433061995BD");
    public static readonly GUID FirebrandTomeOfResolveOpen = new("39C1BD24ADA04C4788A99C7B0FD9B53F");
    public static readonly GUID FirebrandTomeOfCourageOpen = new("9EE3EAFEF333BE44AD8A7D234A1C3899");
    public static readonly GUID FirebrandSymbolOfVengeance1 = new("9E41C2BEFD43D64299C41FD6EFB9ECBE");
    public static readonly GUID FirebrandSymbolOfVengeance2 = new("0B22F631EBB04341A17FDC57431385EB"); // CONFLICT Symbol of Luminance
    public static readonly GUID FirebrandSymbolOfVengeance3 = new("60C2DD0478450F4B81BAA6486227872A");
    public static readonly GUID DragonhunterTrapEffect = new("CCF55B3EAA4D514BBB8340E01B6A1DEC");
    public static readonly GUID DragonhunterTestOfFaith = new("D7006AC247BBE74BA54E912188EF6B12");
    public static readonly GUID DragonhunterFragmentsOfFaith = new("C84644DDAA59E542989FDB98CD69134C");
    public static readonly GUID DragonhunterHuntersWardCage = new("F70A6157503537478331C8F82C0AB76E");
    public static readonly GUID DragonhunterSymbolOfEnergy = new("8493CB203B40E04BAE5DC6F141B40743");
    #endregion
      
    #region Engineer
    public static readonly GUID EngineerHealingMist = new("B02D3D0FF0A4FC47B23B1478D8E770AE"); // used with healing mist, soothing detonation
    public static readonly GUID EngineerMagneticInversion = new("F8BD502E5B0D9444AA6DC5B5918801EE");
    public static readonly GUID EngineerThrowMineInactive1 = new("2EE26B8656BD424B9BF9A7EA4CB0AA06"); // infinite duration
    public static readonly GUID EngineerThrowMineInactive2 = new("67649A4CB18C5C4A8D48ACFCF50B21CE"); // 0 duration
    public static readonly GUID EngineerMineField = new("997750CA2636154E9FFBFEE4AA51A970"); // 0 duration and infinite duration, both logged at the same time
    public static readonly GUID EngineerMineExplosion1 = new("885B7AAA68F09E48A926BFFE488DB5AD"); // 0 duration - Throw Mine and Mine Field use this effect
    public static readonly GUID EngineerMineExplosion2 = new("1B3ACEE36F61DE42AB1C24BD33B5B5AD"); // 0 duration - Throw Mine and Mine Field use this effect
    public static readonly GUID EngineerSpearDevastator1 = new("EFB9CDA30AEBC744B9D377A99BEBC0B2"); // Happens at the end of the cast
    public static readonly GUID EngineerSpearDevastator2 = new("AA5B8BF4646103469C1846D51AA9E010"); // Happens at the end of the cast
    public static readonly GUID ScrapperThunderclap = new("8C8E0AB8328CC1418F9A815E022E20B6"); // has owner, 5s duration
    public static readonly GUID ScrapperThunderclapSpawn = new("039F8B46E5595C4E9C2D52AA58FDD8B0"); // has owner, 1s duration
    public static readonly GUID ScrapperFunctionGyro = new("B4CA602E8A849F47BFC105C740005162"); // has owner, 5s duration
    public static readonly GUID ScrapperFunctionGyroSpawn = new("AC9C3749A245D741BC012CCAB224E37C"); // has owner, 1s duration
    public static readonly GUID ScrapperBulwarkGyroTraited = new("611D90C69ECF8142BEEE84139F333388");
    public static readonly GUID ScrapperBulwarkGyro = new("C6A40B12F9E6E046A98223F30E717633");
    public static readonly GUID ScrapperPurgeGyroTraited = new("0DBE4F7115EADC4889F1E00232B2398B");
    public static readonly GUID ScrapperPurgeGyro = new("86DC533FBB84BC43BBA03EC3B3E13034");
    public static readonly GUID ScrapperDefenseField = new("9E2D190A92E2B5498A88722910A9DECD");
    public static readonly GUID ScrapperBypassCoating = new("D2307A69B227BE4B831C2AA1DAAE646A"); // player is owner
    public static readonly GUID HolosmithFlashSpark = new("418A090D719AB44AAF1C4AD1473068C4");
    public static readonly GUID HolosmitBladeBurstParticleAccelerator1 = new("9D2A5C8FF1E67547A41B72D91F4355E7");
    public static readonly GUID HolosmitBladeBurstParticleAccelerator2 = new("5635C8217573C449905554A1BE38044B"); // happens at the same time as the other on Dst
    public static readonly GUID MechanistCrashDownImpact = new("80E1A21E07C03A43A21E470B95075A5A"); // happens at spawn location, no owner, no target, ~800ms after spawn
    public static readonly GUID MechanistMechEyeGlow = new("CDF749672C01964BAEF64CCB3D431DEE"); // used with e.g. crash down (delayed), crisis zone
    public static readonly GUID MechanistDischargeArray = new("5AAD58AD0259604AADA18AFD3AE0DDFD"); // likely the white radius indicator
    public static readonly GUID MechanistCrisisZone = new("956450E1260FB94B8691BC1378086250");
    public static readonly GUID MechanistShiftSignet1 = new("E1C1DD7F866B4149A1BADD216C9AA69D"); // happens twice, without owner at destination, with owner at origin?
    public static readonly GUID MechanistShiftSignet2 = new("DB22850AE209B34BBD11372F56D42D43");
    public static readonly GUID MechanistOverclockSignet = new("734834E7EB7CD74EB129ACBCE5C64C1D");
    #endregion
      
    #region Ranger
    public static readonly GUID RangerLightningReflexes = new("3CF1D1228CBC3740AA33EDA357EABED4");
    public static readonly GUID RangerQuickeningZephyr = new("B23157C515072E46B5514419B0F923B7");
    public static readonly GUID RangerSignetOfRenewal = new("EA9896A81DDF4843B18DBF6EE4F25E18");
    public static readonly GUID RangerSignetOfTheHunt = new("1A38CAE72C2F164BA3815441CA643A20");
    public static readonly GUID RangerHunkerDown = new("FAE87ED17A43E54AA3ABB3EAA2FDB754");
    public static readonly GUID RangerBarrage1 = new("A982C451890E704BA918B6959175D2A4"); // has owner, repeating, has duration
    public static readonly GUID RangerBarrage2 = new("90A4BD30E723C749A4E161C177F723A0"); // has owner, repeating
    public static readonly GUID RangerBonfire = new("E68388DE0702F44BB3F7E457EE9410AF"); // has owner
    public static readonly GUID RangerFlameTrap = new("371DA8262E27304BB1142A39FAED0731"); // has owner
    public static readonly GUID RangerFrostTrap = new("B2A5125C3FDDFB448F130488D32568C2"); // has owner, has duration
    public static readonly GUID RangerFrostTrapTrigger = new("A86A024FE2DDD147829551764894D716"); // has owner, no duration
    public static readonly GUID RangerVipersNest = new("1964816830EF7B47827298789EF7227B"); // has owner
    public static readonly GUID RangerSpikeTrap = new("E0223550EAC46A4C8CEC277CFC2B7927"); // has owner
    public static readonly GUID RangerPoisonousCloud = new("FDD0241186BAFE4AA451767D082D0BA9"); // has owner
    public static readonly GUID RangerHealingSpringInactive1 = new("D9F9B146BC2B914B874EA980B2FF0C00"); // has owner, duration 1000
    public static readonly GUID RangerHealingSpringInactive2 = new("A531836FD73C5B44B48AC22A928EAED9"); // has owner, infinite duration
    public static readonly GUID RangerHealingSpringActive = new("4B67AD5794D7824EABB0C6BDBB90FFB5"); // has owner, duration 5000
    public static readonly GUID DruidGlyphOfEquality = new("9B8A1BE554450B4899B64F7579DF0A8C");
    public static readonly GUID DruidGlyphOfEqualityCA = new("74870558C43E4747955C573CAAC630A7");
    public static readonly GUID DruidSeedOfLife = new("19C4FA17A38E7E4780722799B48BF2BE"); // has owner
    public static readonly GUID DruidSeedOfLifeBlossom = new("666BCBD61F72E042B08EFE1C62555245"); // has owner, ~720ms delayed
    public static readonly GUID DruidSublimeConversion1 = new("5707A4A2BFFAD048BBDEC9CA0F2A61E1");
    public static readonly GUID DruidSublimeConversion2 = new("2F74AC468871444BB66AF5D8B25EC870");
    public static readonly GUID DruidGlyphOfTheStars = new("84BD2B25ADE2E34C8E8B508283BE8077");
    public static readonly GUID DruidGlyphOfTheStarsCA = new("6AFF7DBF27F63D45940FEC1CB837475D");
    public static readonly GUID SoulbeastEternalBond = new("BF0A5B11A4076A4F98C6E1D655D507B1"); // has owner & target
    public static readonly GUID UntamedMutateConditions = new("D7DCD4ABF9E4A749950AF0175E02EA06");
    public static readonly GUID UntamedUnnaturalTraversal = new("8D36806A690A5442A983308EDCECB018");
    public static readonly GUID UntamedVenomousOutburst = new("60BE4692A455B140A05AD794BF4753F6");
    public static readonly GUID UntamedRendingVines = new("2C40B0741111444F98895A658A7F978F");
    public static readonly GUID UntamedEnvelopingHaze = new("F2B1B61970FC59418AC049BF3A07FFD4");
    #endregion
      
    #region Thief
    public static readonly GUID ThiefTeleportTrail = new("03A8D8B8F81FE94FB52FFE5F74F31C9E"); // likely the trail, used with infiltrators arrow, shadow step, infiltrators signet, measured shot
    // public static readonly GUID ThiefTeleport                      = new("1DEF5F2ECCF6CA4683ECC2DAED54726C"); // used with e.g. shadow shot, shadow strike
    public static readonly GUID ThiefShadowstep = new("2C40AE26C91BEE468E245D0009B590F9");
    public static readonly GUID ThiefInfiltratorsSignet1 = new("23284B87C26C9A41A887F410F930E1A2");
    public static readonly GUID ThiefInfiltratorsSignet2 = new("2C89A39F7B88614ABED16D4B5A5BD2EB");
    // public static readonly GUID ThiefInfiltratorsSignetCollision   = new("70CFE546FA6A9B4E93BCAAF1ED1CD326"); // collision with shadow shot, shadow strike
    public static readonly GUID ThiefSignetOfAgility = new("BB5488951B60B546BB1BD5626DAE83E1");
    public static readonly GUID ThiefSignetOfShadows = new("14A5982DB277744CB928A4935555F563");
    public static readonly GUID ThiefPitfallAoE = new("7325E9B0DD2E914F9837E5FCFC740A95");
    // public static readonly GUID ThiefThousandNeedlesAoECollision   = new("2125A13079C1C5479C150926EB60A15D"); // collision with shadow flare & other
    public static readonly GUID ThiefThousandNeedlesAoE1 = new("9AF103E33FC235498190448A9496C98A"); // ~280ms delayed
    public static readonly GUID ThiefThousandNeedlesAoE2 = new("B8DC8C6736C8E0439295A9DBBADC6296"); // ~280ms delayed
    public static readonly GUID ThiefSealAreaAoE = new("92A7634C2C7F2746AFDA88E1AD9AE886");
    public static readonly GUID ThiefShadowRefuge = new("1708CD9EDF419E41B40822C52E487E1E");
    public static readonly GUID ThiefShadowPortalArmedInactive = new("97AF46D347914E4FBDB37BFEC91C4711"); // unarmed portal has no effect, is this pov only?
    public static readonly GUID ThiefShadowPortalActiveEntrance = new("8535B486C1BCD24A87B7AC895FB26BB0");
    public static readonly GUID ThiefShadowPortalActiveExit = new("97AF46D347914E4FBDB37BFEC91C4711");
    public static readonly GUID DeadeyeMercy = new("B59FCEFCF1D5D84B9FDB17F11E9B52E6");
    public static readonly GUID SpecterWellOfGloom1 = new("F4260FA8B35EFC40B6990F5015E486A3"); // These 3 effects happen before the AoE, the placement can be moved with skill retargetting
    public static readonly GUID SpecterWellOfGloom2 = new("F5BD1268C23E0C4C85E7DFC927360EFE");
    public static readonly GUID SpecterWellOfGloom3 = new("1B9672DFA1F1D74DB11ADF3F0956FCF0");
    public static readonly GUID SpecterWellOfGloom4 = new("0FA258E85B5B2B4CBCF504F478558D3C"); // ~715ms delay - Using these two effects for the AoE placement (they happen after retargetting)
    public static readonly GUID SpecterWellOfGloom5 = new("63B5CB22E35C094E948DA101CA247B25"); // ~715ms delay
    public static readonly GUID SpecterWellOfGloom6 = new("D4CD6FCC1BABB042AA7E1779FF166F4B"); // ~960ms delay
    public static readonly GUID SpecterWellOfBounty1 = new("E452C4E8FD6B9A4F9C3659782ECEDEA3");
    public static readonly GUID SpecterWellOfBounty2 = new("704FF2761D3CA74AB7C12060F1D3D872"); // ~880ms delay
    public static readonly GUID SpecterWellOfTears1 = new("AEB43693461D1846BB70C2AEAB47EE2B");
    public static readonly GUID SpecterWellOfTears2 = new("21BF83968804A54DBF795C7A0AD385A5"); // ~1240ms delay
    public static readonly GUID SpecterWellOfTears3 = new("5CBC62CDE1F5204E8E63EA785CF81D59"); // ~1240ms delay
    public static readonly GUID SpecterWellOfSilence1 = new("51FCBBE627637D4C9EB9AC8A4CD216AC");
    public static readonly GUID SpecterWellOfSilence2 = new("15A73155534B204D8C9F97F5C8ED6DA1"); // ~440ms delay
    public static readonly GUID SpecterWellOfSorrow1 = new("036B9D5F24402C4A9ED923A0391E61C3");
    public static readonly GUID SpecterWellOfSorrow2 = new("5A74A8FADB71B249BD245E2FBE1D8952"); // ~1240ms delay
    public static readonly GUID SpecterWellOfSorrow3 = new("1B56F702912BE7428182CA57036AEE99"); // ~1240ms delay
    public static readonly GUID SpecterShadowfall1 = new("FB21A6E213C240459BD8E9524088FA66");
    public static readonly GUID SpecterShadowfall2 = new("D8E380E80E843A4092C8DD53C5A51F0F"); // ~880ms delay
    #endregion
      
    #region Fractals
    // Nightmare Fractal
    public static readonly GUID SmallFluxBomb = new("B9CB27D38747A94F817208835C41BB35");
    public static readonly GUID ToxicSicknessIndicator = new("3C98B00B9E795F4B8744E186EEEA7DF7");
    public static readonly GUID ToxicSicknessOldIndicator = new("B7DFF8C2A8DABD4C9C7F1D4CFC31FC8C");
    public static readonly GUID ToxicSicknessNewIndicator = new("71469269D3A1F9469D74CC96153264C0");
    public static readonly GUID ToxicSicknessPuke = new("E09CD66E417B59409401192201CE4B6E");
    public static readonly GUID MAMAGrenadeBarrageIndicator = new("8DDED161CE26964FA5952D821AD852F7");
    public static readonly GUID NightmareMiasmaIndicator = new("41883B3BD532124DACF93F7C2584E63C");
    public static readonly GUID NightmareMiasmaDamage = new("8A882A495793044D8C4A9AD9080283A7");
    public static readonly GUID ArkkShieldIndicator = new("5B1B9D29D6242F47A82743330AE4225B"); // Duration 7400
    public static readonly GUID ArkkShieldIndicator2 = new("1E267990C5098E49AFD5CFD5CA4E2B82"); // Duration 6400
    public static readonly GUID SiaxNightmareHallucinationsSpawnIndicator = new("0C284B1C201D1846B4D9F249AD01A5C6"); // siax src
    public static readonly GUID SiaxVileSpitIndicator = new("BC17A48E8DD2FF44864AA48A732BDC36");
    public static readonly GUID SiaxVileSpitPoison = new("6589BB8F4EE227428CC3DDDE84A67015");
    public static readonly GUID CausticBarrageIndicator = new("C910F1B11A21014AA99F24DBDFBF13FB");
    public static readonly GUID CausticBarrageHitEffect = new("CAF4E62C2C5CC04499657C2A6A78087B"); // 1000 duration - green explosion effect when orb lands - conflicts with player effects
    public static readonly GUID VolatileExpulsionIndicator = new("DCA047DBD6E90A41B46CDDCE5405E4BC"); // 300 - 400 duration
    public static readonly GUID VolatileExpulsion2 = new("F22E201EAF24DD42A43D297B2E83CC66"); // 0 duration
    public static readonly GUID CascadeOfTormentRing0 = new("EFF32973C7921F41AA3FD65745E06506");
    public static readonly GUID CascadeOfTormentRing1 = new("D919AC7D1B2ABD438F809B3B9DCE9226");
    public static readonly GUID CascadeOfTormentRing2 = new("A5D958EDAD66D7469CA40059915843CC");
    public static readonly GUID CascadeOfTormentRing3 = new("55FC7E1387EA2241B6538CAAB6017497");
    public static readonly GUID CascadeOfTormentRing4 = new("8CFFD69B25B7E844856A7D06D11332D5");
    public static readonly GUID CascadeOfTormentRing5 = new("D427C86A0E120F4A860F4570B354396D");
    public static readonly GUID EnsolyssMiasmaDoughnut100_66 = new("16B9D11838F68A4C8E477ED62F956226");
    public static readonly GUID EnsolyssMiasmaDoughnut66_15 = new("3AE042F82A10B84DB7487B0C0F4D2AB1");
    public static readonly GUID EnsolyssMiasmaDoughnut15_0 = new("AB294EC140644E48BC739B8E303D2762");
    public static readonly GUID EnsolyssNightmareAltarShockwave = new("AA31A20BDC52324B945FD660D60429EB");
    public static readonly GUID EnsolyssNightmareAltarLightOrangeAoE = new("66C6DEE334653342BDC578817254F7C8");
    public static readonly GUID EnsolyssNightmareAltarOrangeAoE = new("FA097ABEFB8CEF4B89EB12825EEE1FB9"); // same effect as Skorvald's Solar Bolt
    public static readonly GUID EnsolyssArrow = new("3D85505CEBCF0E4D8993625957405977");
    // Shattered Observatory Fractal
    public static readonly GUID SolarBoltIndicators = new("FA097ABEFB8CEF4B89EB12825EEE1FB9");
    public static readonly GUID SkorvaldSolarBoltDamage = new("49813989C508464B81FC45E6D24EA8C3");
    public static readonly GUID KickGroundEffect = new("47FE87414A88484AB05A84E1440F5FDD");
    public static readonly GUID AoeIndicator130Radius = new("8DDED161CE26964FA5952D821AD852F7");
    public static readonly GUID MistBomb = new("03FB41386DD2A54FA093795DF2870B7A");
    public static readonly GUID ArtsariivBeamingSmileIndicator = new("C047F635A01A4441945CD0EB85AD3D2C"); // no owner
    public static readonly GUID ArtsariivBeamingSmile = new("F01DC8CB8C6ACF4891BAE252FB950A24"); // no owner
    public static readonly GUID ArtsariivAoeIndicator = new("7948A94F5DB40D45B947F82804598027"); // no owner
    public static readonly GUID ArtsariivAoeExplosion = new("A09474AB8EBD2146B1A4299F3C918DB6"); // no owner
    public static readonly GUID ArtsariivObliterateIndicator = new("8938C846962EA045B5726F53C3ECF6AF"); // no owner
    public static readonly GUID ArtsariivObliterateExplosion = new("F2D51BED8214F1419A5D1684D2087093"); // no owner
    public static readonly GUID ArtsariivBlackSmoke = new("172355593E35D6479A742472E29CA150");
    public static readonly GUID CorporealReassignmentDome = new("1607FB8A58554A4E96E5AD04AF8E247A"); // owned by unknown agent
    public static readonly GUID CorporealReassignmentExplosionDome = new("5B8F0DCE941DF544AD0966F6158A5127");
    public static readonly GUID CorporealReassignmentExplosion1 = new("C93D2CA54BC7F84BBFA31B40DE056D21"); // owned by exploding player
    public static readonly GUID CorporealReassignmentExplosion2 = new("DAD653E8823274409610A732BE8FA188"); // owned by exploding player
    public static readonly GUID HorizonStrikeArkk = new("C5E4632E8131D342AA4F18222C68D8EB"); // owned by arkk
    // Sunqua Peak Fractal
    public static readonly GUID AiArrowAttackIndicator = new("88E9C3112BF6DA4486845A0433782E9C"); // GENERIC, no owner, rotated towards direction, used for lines & dash
    public static readonly GUID AiCircleAoEIndicator = new("171A7BD24B5D0B4BA3770FF8A6A37EC0"); // GENERIC, no owner, no rotation, used for air & fire lines, pulsing circles
    public static readonly GUID AiConeIndicator = new("CB877C57D1423240BACDF8D6B52A440F"); // GENERIC, owned by ai, rotation weird
    public static readonly GUID AiAoEAroundIndicator = new("D11320204E28E643A48469AA8E4845BA"); // GENERIC, owned by ai
    public static readonly GUID AiGreenCircleIndicator = new("BFFF308926A8B647A729197D364C1095"); // GENERIC, owned by player, 6.250s duration
    public static readonly GUID AiSpreadCircle = new("DD3870359E8FFA41BE69D612E05C972E"); // owned by ai, 5s duration
    public static readonly GUID AiRedPointblankIndicator = new("46DCBA8A1BF48A46BDD5B533FFF20659"); // owned by ai, 4s duration
    public static readonly GUID AiAirLine1 = new("EFB7EF07C1CCD4479A73B34C56B53D7C"); // owned by ai, oriented towards ai
    public static readonly GUID AiAirOrbFloat = new("06E1712B62940C4CB8CEB23F06893370"); // owned by ai, 5s duration, higher up
    public static readonly GUID AiAirOrbGround = new("014DCBC1E960094C84CE145C2F813169"); // owned by ai, 5s duration
    public static readonly GUID AiAirOrbZap = new("014DCBC1E960094C84CE145C2F813169"); // played on spawn and on despawn?
    public static readonly GUID AiAirCircleDetonate = new("A419E2904C80914C9F15991B3810B79A"); // no owner, no duration
    public static readonly GUID AiAirCirclePulsing = new("AD2951EF56887941BC2001EC14C484E4"); // owned by ai, 8s duration
    public static readonly GUID AiAirDetonate = new("84EB1D03AD685647BB815B4601C81B46"); // no owner, no duration
    public static readonly GUID AiAirIntermissionRedCircleIndicator = new("A1B63679B1042C4ABB88491CD126249A"); // owner by ai, 1.5s duration
    public static readonly GUID AiAirLightningStrike = new("06A1D3F77B651C4F87AE2EBA7EDE852F"); // no owner, no duration, lightning strikes in intermission
    public static readonly GUID AiAirIntermissionUnknown1 = new("46DCBA8A1BF48A46BDD5B533FFF20659"); // owned by ai, 1.5s duration
    public static readonly GUID AiAirIntermissionUnknown2 = new("1370664D1C79DF48AE3BC58B8EFCC81B"); // no owner, no duration, maybe growing indicator?
    public static readonly GUID AiMeteorIndicatorBeam = new("EEAFAFB527630D44A232A335841CAE20"); // 5s duration
    public static readonly GUID AiMeteorIndicatorGround = new("82F44EDA9D427D48B051FA9419ACB8F1"); // 6s duration, owned by ai, same for fixed position & on players
    public static readonly GUID AiMeteorDrop = new("1B0ACDDD402CA0459F6B3ECD78E7F292");
    public static readonly GUID AiMeteorImpact = new("ADE797298A7138408F4D27560EE26608");
    public static readonly GUID AiFireOrbFloat = new("936AA38E65815647A9E005DD9D7E9238"); // owned by ai, 5s duration, higher up
    public static readonly GUID AiFireOrbGround = new("3C8ECB429FAF8C43A22CC90DC8BACA8B"); // owned by ai, 5s duration
    public static readonly GUID AiFireCircleDetonate = new("8CAF14D6FC78B9459652C6C5DF160539"); // no owner, 1.6s duration
    public static readonly GUID AiFireCirclePulsing = new("70324046B99FA14D9D3B2F903CEEE6A7"); // owned by ai, 8s duration
    public static readonly GUID AiFireDetonate = new("77258AA889B529419A71DB25F71C009F"); // no owner, no duration
    public static readonly GUID AiWaterTornadoIndicator1 = new("EFB7EF07C1CCD4479A73B34C56B53D7C"); // owned by ai, 1.5s duration, oriented towards ai
    public static readonly GUID AiWaterTornadoIndicator2 = new("4467407024CFA749B71274BE38E587E9"); // no owner, 1.8s duration, oriented in tornado direction
    public static readonly GUID AiWaterOrbFloat = new("2B63C3FF719EF044BFB6D8D95DF8E0E8"); // owned by ai, 5s duration
    public static readonly GUID AiWaterOrbGround = new("FC86E1F5291AE84D9B35400941BDAC30"); // owned by ai, no duration
    public static readonly GUID AiWaterDetonate = new("97884C8935277A44AE284E65FC9A57C2"); // no owner, no duration, REUSED for circles, spawning orbs, spreads
    public static readonly GUID AiDarkLine1 = new("7F54007357160B42A5445AB2533DB131"); // owned by ai, ~2s duration for lines pattern, 5s for lines towards ai
    public static readonly GUID AiDarkOrbRedIndicator = new("4E379E5BB319134D8E2DCF15D92D9E8E"); // owned by ai, 1761ms duration
    public static readonly GUID AiDarkOrbFloat = new("B8EED8719B64FC4DB0159097C5D00602"); // owned by ai, 5s duration, NOT used for line attack version
    public static readonly GUID AiDarkOrbGround = new("A244911C6EDC9C4F8F97AB7BB298B937"); // owned by ai, no duration, used for both versions
    public static readonly GUID AiDarkDetonate = new("FD02022B7D29BB40B991E1E1C25E46BE"); // no owner, no duration, used for spreads & orb detonate
    public static readonly GUID AiDarkCirclePulsing = new("4BBF32BC8008C74282E7F6FD8DC459E3"); // owned by ai, no duration
    public static readonly GUID AiDarkCircleDetonate = new("F9CBDC860F82E14C8C06A90CE1674FCB"); // owned by ai, 500ms duration, REUSED for end of dash with duration 0ms
    public static readonly GUID AiSorrowIndicator = new("2A4BE7D8CB917A45B3BCA8AE696BA55C"); // owned by sorrow, 9.5s duration
    public static readonly GUID AiSorrowDetonate = new("F7C16B270D67E54F8E849B0FD579D23E"); // owned by sorrow, no duration
    // Silent Surf Fractal
    public static readonly GUID FrighteningSpeedRedAoE = new("96E8C6EA0D2FAF4C8F62B5C6CA4B611C");
    public static readonly GUID AxeGroundAoE = new("234949DB5ECD52409F6EDD601BBC0C19");
    public static readonly GUID AxeGroundAoE2 = new("CE91D2D4CD6C4141B3977FA70FFE05BB");
    public static readonly GUID HarrowshotAoE = new("3AE17719B3D7374BAC4899DA0A3E7DF9");
    // Lonely Tower Fractal
    public static readonly GUID EparchRedCircle = new("0D2192849D53B4469F56B1C74542DBE9"); // owned by eparch, 2s duration, REUSED
    public static readonly GUID EparchDespairPool = new("FF359460D95C96478CE2A4415EACD312"); // owned by eparch, 15s duration
    public static readonly GUID EparchRageImpact = new("968B7C89FEF01C4298294E86800B9BA9"); // owned by eparch, no duration
    public static readonly GUID EparchRageFissure = new("797210B1B11C984AACBD2AFC80D02BC7"); // no owner, 24s duration
    public static readonly GUID EparchArrowIndicator = new("27563132F8532847B4DD2CA7AB5B9CE8"); // owned by eparch, 1.5s duration, REUSED for envy, incarnation of judgement
    public static readonly GUID EparchInhale = new("FADE0B1FF0CAC146950DB6B69DBAFEDF"); // owned by eparch, 5s duration
    public static readonly GUID EparchCircleIndicator = new("B90A382180F3BD478F59D3DE7AA305B6"); // owned by eparch, 1s duration, REUSED for malice
    public static readonly GUID EparchSpikeOfMalice = new("4550118E2A59DB459CB8AFA3AB3F16A4"); // owned by eparch, no duration
    #endregion
      
    #region Raids
    // Vale Guardian
    public static readonly GUID ValeGuardianDistributedMagic = new("43FD739499BB6040BBF9EEF37781B2CE");
    public static readonly GUID ValeGuardianMagicSpike = new("55364633145D264A934935C3F026B19F");
    // Escort Glenna
    public static readonly GUID EscortOverHere = new("64CD79C1A121EC42B1278DEF9280ED35");
    // Xera
    public static readonly GUID XeraIntervention1 = new("63C34770B4EFF64B8EAA21BB835BB560"); // 4294967295 duration - Src Player - Usable with ComputeDynamicEffectLifespan
    public static readonly GUID XeraIntervention2 = new("79EA3F01274B4F418B2C571BAE1B9E17"); // 0 duration - Src Player
    public static readonly GUID XeraIntervention3 = new("5FA6527231BB8041AC783396142C6200"); // 0 duration - No Src No Dst
    // Cairn
    public static readonly GUID CairnDisplacement = new("7798B97ED6B6EB489F7E33DF9FE6BD99");
    public static readonly GUID CairnDashGreen = new("D2E6D55CC94F79418BB907F063CBDD81");
    // Mursaat Overseen
    public static readonly GUID MursaarOverseerDispelProjectile = new("DE71A86A0867764BB5789265E8C0CF6A"); // No Src - Dst Jade Scout
    public static readonly GUID MursaarOverseerProtectBubble = new("17BC358A51ED2D43BF2ABE8AB642B86B"); // Src player
    public static readonly GUID MursaarOverseerClaimMarker = new("94F3501D777FAC439E78E143CE756B0A"); // No Src - No Dst
    public static readonly GUID MursaarOverseerShockwave = new("0F62A1315A00FC438B2F1273E6BC4054");
    // Broken King
    public static readonly GUID BrokenKingNumbingBreachIndicator = new("5341E83B29B534408E90DBE7BE6F452D");
    public static readonly GUID BrokenKingNumbingBreachDamage = new("1BF014091BFD1E40A11ED36B92601342");
    public static readonly GUID BrokenKingHailstormGreen = new("C97A7665B2AA6C4482026D4F2562E25E");
    public static readonly GUID BrokenKingIceBreakerGreenExplosion = new("957ADB83D139704F8CB865E86E389228");
    public static readonly GUID BrokenKingKingsWrathConeAoEIndicator = new("FA4B726574C96E489D73529CFE390D3D"); // Currently unused, we don't know how to determinate the aoe size
    public static readonly GUID BrokenKingKingsWrathConeAoEDamage = new("22AC6BFC0B06C1459DFEF1E380F50165"); // Currently unused, we don't know how to determinate the aoe size
    // Eater of Souls
    public static readonly GUID EaterOfSoulsLightOrbOnGround = new("0ABBB74207F2D0419A49CE951321166D");
    public static readonly GUID EaterOfSoulsLightOrbThrowHitGround = new("D44445C5713E9D47B0D653EB5A939A2B");
    public static readonly GUID EaterOfSoulsVomitFragment = new("A52D0864063A8A489E5FB7690D9B5C9A");
    public static readonly GUID EaterOfSoulsSpiderWeb = new("084A4E29CD66A04C9ECDB8033EFFE6A1");
    public static readonly GUID EaterOfSoulsSpiritOrbs = new("D8FD90C7854D0B4CBE4B301DE17D7AEB");
    public static readonly GUID EaterOfSoulsSpiritShockwave1 = new("1E318AEAA483F346B85DCD243FDC0204");
    public static readonly GUID EaterOfSoulsSpiritShockwave2 = new("E3551E82FB4F0B4EB7A73C51CB73C664");
    // Dhuum
    public static readonly GUID DhuumScytheSwingIndicator = new("91A23D51294E80458BE9C3C89A2ED138"); // 1200 duration
    public static readonly GUID DhuumScytheSwingDamage = new("C79F5D95E11070448A39ACD7F6C5D0D3"); // 0 duration
    public static readonly GUID DhuumCullAoEIndicator = new("1BB71ED45AF4354AB65BBEB976E8CFEE"); // 0 duration
    public static readonly GUID DhuumCullCracksIndicator = new("F28528CBE08E0D43B3227A157CD1CCF2"); // dynamic duration, earlier cracks have longer duration than last ones.
    public static readonly GUID DhuumCullCracksDamage = new("13B5022FBF7D884C9AA9ED667FEEC22F"); // 0 duration
    public static readonly GUID DhuumDeathMarkFirstIndicator = new("6A0D725CD03D8D48BEA939CD1BBA7A9A"); // 2000 duration - Soul split warning indicator
    public static readonly GUID DhuumDeathMarkSecondIndicator = new("4BA74BA044B7BD4BB1E3392641078D97"); // 1000 duration - Hit indicator (black smoke)
    public static readonly GUID DhuumDeathMarkDeathZone = new("B8F90FE6AF4F2A4C84D349861A098392"); // 120000 duration
    public static readonly GUID DhuumSuperspeedOrb = new("8F89945581099142B598977188BAC8E1"); // max duration - has end effect
    public static readonly GUID DhuumConeSlash = new("21BA95CC014CC944A71E2A6FB28D9A86");
    // CA
    public static readonly GUID CAArmSmash = new("B1AAD873DB07E04E9D69627156CA8918");
    // Qadim
    public static readonly GUID QadimCMIncinerationOrbs = new("F0EC05F2019BD3429E7F8349BEB5A1DF"); // 2600 duration - 180 corner orb - 540 central orb
    public static readonly GUID QadimPyresIncinerationOrbs = new("D3D9E94418D8094BAE0E0C510DDF2A91"); // 2300 duration - 240 radius
    public static readonly GUID QadimInfernoAoEs = new("37DF91103EC45240AA7910575F1FC55F"); // On non static platform - 3000 duration - 150 radius
    public static readonly GUID QadimJumpingBlueOrbs = new("9FE9CEE3B3B1A743B769D16B196AD45D");
    public static readonly GUID QadimPlatformStartsOrEndsMoving = new("98891680AFB80A4E9CAFCCBD1662DF88");
    // Sabir
    public static readonly GUID SabirFlashDischarge = new("40818C8E9CC6EF4388C2821FCC26A9EC");
    // Qadim the Peerless
    public static readonly GUID QadimPeerlessRainOfChaos = new("D8259BFD4E6B8348AF15D862F7DBC8FA");
    public static readonly GUID QadimPeerlessResidualImpactFireAoE = new("EFAC2FC0F661404D84F0291CAB76FF0E");
    public static readonly GUID QadimPeerlessChaosCalledElectricShark = new("7A5A2002C855A440BCC22E2C76B0C405");
    public static readonly GUID QadimPeerlessForceOfHavoc1 = new("5F3B01764915FD41A02B2FBAD788651B"); // 2000 duration
    public static readonly GUID QadimPeerlessForceOfHavoc2 = new("B2396CC1F4A73B4EAEA86F66978DC895"); // 1000 duration
    public static readonly GUID QadimPeerlessForceOfHavoc3 = new("A2E91B50829AB64097D217E468189F52"); // 22400 duration
    public static readonly GUID QadimPeerlessEtherStrikesOrbs = new("625838F1175E25459A5293CA6C911290"); // 1500 duration
    public static readonly GUID QadimPeerlessEtherStrikesAoEs = new("A89E436B20CFC142B159F3D2195F75AE"); // 0 duration
    public static readonly GUID QadimPeerlessShowerOfChaosAoE = new("845D252D05631740B3B2309457FB4338"); // 5000 duration
    public static readonly GUID QadimPeerlessShowerOfChaosExplosion = new("3AAEF82C63C4424FAA0F55CD02256E00");
    public static readonly GUID QadimPeerlessShowerOfChaosOnPlayer1 = new("27B83B9DF241F94DB16414852EA68354");
    public static readonly GUID QadimPeerlessShowerOfChaosOnPlayer2 = new("0BA57434DC93604096B870FB98B3C4F1"); // Src Qadim
    public static readonly GUID QadimPeerlessMeteorIllusion1 = new("00C4F7C59E4D8449B565CC00FC30D9DD"); // 5000 duration
    public static readonly GUID QadimPeerlessMeteorIllusion2 = new("ED04DA4F2B31D74CBEF501CAFFDAFAAD"); // 4294967295 duration - Usable with ComputeDynamicEffectLifespan
    public static readonly GUID QadimPeerlessBrandstormLightning1 = new("C5B4846F6A548D47B0856AA8A2CE283C"); // 0 duration
    public static readonly GUID QadimPeerlessBrandstormLightning2 = new("995E6709BB16B44DBABCC707F10E5345"); // 3000 duration
    public static readonly GUID QadimPeerlessMagmaWarningAoE = new("E269977C2FC9474EAAD1051CDAFAD653"); // 4000 duration - Src player
    public static readonly GUID QadimPeerlessMagmaLandingExplosion = new("6617FA23565EE646ADAA7A646C895927"); // 1000 duration - No Src
    public static readonly GUID QadimPeerlessMagmaDamagingAoE = new("BABE69EC5AC7AF48A2F14A9FB8920C7F"); // 600000 duration - Src Qadim
    // Greer
    public static readonly GUID GreerNoxiousBlightGreen = new("C4E12D8CDDAA904CB4E7B52E6CEF1287"); // 10000 duration - Src NPC
    // Decima
    public static readonly GUID DecimaEnlightenedConduitPurpleAoE = new("1A81CC24D58C3046AEF30AAA35D6D854"); // 1200000 duration - Src Conduit
    public static readonly GUID DecimaEnlightenedConduitPurpleAoE2 = new("8771719DDCA8654BA06B928509595BB1"); // 0 duration - Src Conduit
    public static readonly GUID DecimaMainshockIndicator = new("E9196E3A25E11F4FB66EFC47CE3593D1"); // 2300 duration - Src Decima
    public static readonly GUID DecimaMainshockDamage = new("8079A224EB97804EBD2B19963BF21F6F"); // 1000 duration - Src Decima
    // Ura
    public static readonly GUID UraToxicGeyserSpawn = new("6B95E7A99147644A990ACF34D04A98F1");
    public static readonly GUID UraSulfuricGeyserSpawn = new("413AF4D44B924B4399481047CBB2820C");
    public static readonly GUID UraSlamCone = new("BBA33A70B7D2A94589DE81B1F35D3D69");
    public static readonly GUID UraSteamPrisonIndicator = new("093D22A7DBFB0D4ABA9424225954DB68"); // 3000 duration - Src Ura - Dst Player
    #endregion

    #region Strikes
    // Freezie
    public static readonly GUID FreezieFrozenPatch = new("2CE301ED692ACA4E964BFDFEED9D055E"); // 30000 duration
    public static readonly GUID FreezieOrangeAoE120 = new("0760BCD6779C0248B480E59D41E785B4"); // Has multiple durations
    public static readonly GUID FreezieDoughnutRing = new("3627917E07E3344EB97B795BE437DDF0"); // 10000 duration
    // Boneskinner
    public static readonly GUID GraspAoeIndicator = new("B9B32815D670DC4E8B8CF71E92A9FFD5"); // Orange aoe indicator
    public static readonly GUID GraspClaws1 = new("75B096EF78F3AB4CB1D05BAE9CA3235C"); // One is the claw, the other the red aoe indicator
    public static readonly GUID GraspClaws2 = new("4C290CBF719C0E448391E9415EF307A7");
    public static readonly GUID CascadeBonesEffect = new("3E370A8629BB134F83902A8F14B99CCE");
    public static readonly GUID CascadeAoEIndicator1 = new("4692619BBBFE6346B409C4A2B93B9BA6");
    public static readonly GUID CascadeAoEIndicator2 = new("8E8592D62B48834180C66FE806278C86");
    public static readonly GUID CascadeAoEIndicator3 = new("89CB4BCA7B012244B0864DFAD7E9F3AC");
    public static readonly GUID CascadeAoEIndicator4 = new("965355FD1C53F24085A9C422B8333780");
    public static readonly GUID CascadeAoEIndicator5 = new("F26A2240C0F1E24E81EAEFDE64EFA3BF");
    // Aetherblade Hideout
    public static readonly GUID AetherbladeHideoutKaleidoscopicChaosNM = new("C660211FCC31A54397A8F73BEC25EB73"); // Duration 5000 - Can have End Event
    public static readonly GUID AetherbladeHideoutKaleidoscopicChaosCM = new("BDF708225224C64183BA3CE2A609D37F"); // Duration 5000 - Can have End Event
    public static readonly GUID AetherbladeHideoutFocusedDestructionGreen = new("3EEDE16455C8C8449237BCC77F107548"); // Duration 6250 - Can have End Event
    public static readonly GUID AetherbladeHideoutTormentingWaveIndicator1 = new("E273E005F90E3041939C6235FF9CADBA"); // Duration 3000
    public static readonly GUID AetherbladeHideoutTormentingWaveIndicator2 = new("BA8AD38816F84246BB6F24203D3843FC"); // Duration 3000
    public static readonly GUID AetherbladeHideoutElectricBlastIndicator = new("1177BFB7901625428E749D8923ADA1A4"); // Duration 0
    public static readonly GUID AetherbladeHideoutElectricBlastDetonation = new("5DCCEF82D98807429081E3C647B6E5EE"); // Duration 0
    public static readonly GUID AetherbladeHideoutPuzzleCirclesDetonation = new("9417F62F39B64C4897B53B53008611B8"); // Duration 0
    public static readonly GUID AetherbladeHideoutPuzzleNormalMode = new("D4E5ED06119B5B40B74C09240498AF0A"); // Duration 12000 - Has End Event
    public static readonly GUID AetherbladeHideoutFissureOfTormentIndicator = new("67B2D706779AAB48A01962388DCA2ADB"); // Duration 1300
    public static readonly GUID AetherbladeHideoutFissureOfTormentDamage = new("2DCB402ABABAD34E87B0A8A8957C8E13"); // Duration 0
    public static readonly GUID AetherbladeHideoutLeyBreachIndicator1 = new("D4089DD8E0040146B3899EB2955AAE87"); // Duration 2000 - Conflicts with Kaineng Overlook effect
    public static readonly GUID AetherbladeHideoutLeyBreachIndicator2 = new("27E4543F5DD04844B5D98BC3EAFF9348"); // Duration 2000
    public static readonly GUID AetherbladeHideoutLeyBreachRedPuddle = new("4B62321544A6314ABEEECA3FF2D96116"); // Duration 30000 - Has End Event
    public static readonly GUID AetherbladeHideoutHeartpiercer = new("06EA9504DA08A0468E9CAFAA97CD9A36"); // Duration 2000
    // Ankka
    public static readonly GUID DeathsEmbrace = new("4AC57C4159E0804D8DBEB6F0F39F5EF3");
    public static readonly GUID DeathsHandOnPlayerCM = new("9A64DC8F21EEC046BA1D4412863F2940");
    public static readonly GUID DeathsHandByAnkkaRadius380 = new("651CA3631083EF4A81159989AB58F787");
    public static readonly GUID DeathsHandByAnkkaRadius300 = new("805E3CE2A313584797C614082C44197D");
    // Kaineng Overlook
    public static readonly GUID KainengOverlookSharedDestructionGreen = new("BFFF308926A8B647A729197D364C1095"); // 6250 duration
    public static readonly GUID KainengOverlookSharedDestructionGreenSuccess = new("F2D28874FE961C40837B97DA1159A541");
    public static readonly GUID KainengOverlookSharedDestructionGreenFailure = new("C460400C2CADAA4880CD74F95D011A36");
    public static readonly GUID KainengOverlookDragonSlashBurstRedAoE1 = new("4BE73D3E16294149A1829230F9E1F363"); // 208000 duration
    public static readonly GUID KainengOverlookDragonSlashBurstRedAoE2 = new("E9DDC9F070B9514F8B4C6F5D428356E4"); // 0 duration - probably the explosion effect on player hit
    public static readonly GUID KainengOverlookJadeMine1 = new("DE7F3CF2B6C1794F97F5DC6F6B1C5F7C"); // 4294967295 duration
    public static readonly GUID KainengOverlookJadeMine2 = new("FAAC4919C404C945ACEF2ABE3C8CCF08"); // 2000 duration
    public static readonly GUID KainengOverlookSniperRicochetBeamCM = new("A5C623040E6810468F2C9E518DB09D83"); // 10000 duration
    public static readonly GUID KainengOverlookSmallOrangeAoE = new("34724E94CD4E974C95A8D9D1D1162658");
    public static readonly GUID KainengOverlookTargetedExpulsion = new("67C0C333F91A5443BA894BEE5E88E202"); // 5000 duration
    public static readonly GUID KainengOverlookJadeLobPulsingGreen = new("D5CD93218B9CBE4B93B6B5D54ED71273");
    public static readonly GUID KainengOverlookJadeLobSomething = new("D36F4CE327D701449358B19E23C8AED0");
    public static readonly GUID KainengOverlookEnforcerRushingJusticeFlames = new("0E5D42F70AF65E4ABBB7EE94C3D5BD1C"); // 4294967295 duration
    public static readonly GUID KainengOverlookEnforcerMiddleAoE = new("BA8654BD3D252C4B9A170EE404FBEA15"); // 1500 duration
    public static readonly GUID KainengOverlookEnforcerMiddleRedAoE = new("C0F88EBEA179344092D4BB193A741F1D"); // 0 duration
    public static readonly GUID KainengOverlookEnforcerOrbsAoE = new("766B7DACFC18974B8F6AA46BCD779563"); // 2708 duration
    public static readonly GUID KainengOverlookMindbladeRainOfBladesFirstOrangeAoEOnPlayer = new("D7FB6DB480A6D14DB4561E03172B705D"); // 8000 duration
    public static readonly GUID KainengOverlookMindbladeRainOfBladesConsecutiveOrangeAoEOnPlayer = new("D4089DD8E0040146B3899EB2955AAE87"); // 2000 duration
    public static readonly GUID KainengOverlookMindbladeRainOfBladesRedAoECM = new("6814DF4DB1EB4541996056FF4E805AC4");
    public static readonly GUID KainengOverlookVolatileExpulsionAoE = new("A673F658E9B67C41AD469BAD8E7ACEA7");
    public static readonly GUID KainengOverlookVolatileBurstAoE = new("6C2F5A0A632627419B77D52D8CC9E4DB");
    public static readonly GUID KainengOverlookJadeBusterCannonWarning = new("C047F635A01A4441945CD0EB85AD3D2C");
    public static readonly GUID KainengOverlookEnforcerHeavensPalmAoE = new("BDF708225224C64183BA3CE2A609D37F"); // 5000 duration
    public static readonly GUID KainengOverlookEnforcerHeavensPalmAnimation = new("92F0566A1A0A9E4B919C796DB434052C"); // Should be the actual palm
    public static readonly GUID KainengOverlookRitualistSpiritualLightningAoE = new("3AEC5A729A1D624B80CABCFDA11D82C6");
    public static readonly GUID KainengOverlookDragonSlashWaveIndicator = new("CB877C57D1423240BACDF8D6B52A440F");
    public static readonly GUID KainengOverlookStormOfSwordsIndicator = new("F019EA6ADC183B4599FDF7E67071E181");
    // Harvest Temple
    public static readonly GUID HarvestTemplePurificationLightningOfJormag = new("ADDDB6E725094240845270262E59F2BD");
    public static readonly GUID HarvestTemplePurificationStormfall = new("F5A9E487E2B3A64A83661D87DE1CAF1F");
    public static readonly GUID HarvestTemplePurificationZones = new("D5B07DF36991DD48B64AC403EFAA6F9F");
    public static readonly GUID HarvestTemplePurificationFlamesOfPrimordus = new("D49EB86EB17A0D4793768B19978C1B2C");
    public static readonly GUID HarvestTemplePurificationBeeLaunch = new("73FE43AEE78ADC4B9527DF683481984F");
    public static readonly GUID HarvestTemplePurificationPoolOfUndeath = new("CCBA0AD77B52774DA48EE37AED9108F4"); // duration 21000
    public static readonly GUID HarvestTemplePurificationWaterProjectiles = new("F8F9628F58DA09438574D66424399151");
    public static readonly GUID HarvestTempleJormagFrostMeteorIceField = new("40C38381C43B184A885960714F9388D5");
    public static readonly GUID HarvestTempleJormagGraspOfJormagIndicator = new("3A39297503D1C542AFC16CB5C1D2D3F7"); // duration 2000
    public static readonly GUID HarvestTemplePrimordusLavaSlamIndicator = new("EDA1C033B296404BA403E106F6F258C0");
    public static readonly GUID HarvestTemplePrimordusGeneralJawAttack = new("160CBAE34F4A2941885EB3F3CD6BB0C3");
    public static readonly GUID HarvestTemplePrimordusJawsOfDestructionIndicator = new("4D8CA1836969BD4BBF345719576ACAAF");
    public static readonly GUID HarvestTemplePrimordusJawsOfDestructionDamage = new("363F831AD54DB7489DFDC31F659B222E");
    public static readonly GUID HarvestTempleKralkatorrikBeamIndicator = new("4ACBA11BFAC6B940BF6FD11CB332FFB8"); // This is the effect for the AoE indicator, the actual puddles are a different effect
    public static readonly GUID HarvestTempleKralkatorrikBeamAoe = new("8B55EBC6025EB3429D464EDA5710E419"); // This is the effect for the actual circular puddles
    public static readonly GUID HarvestTempleKralkatorrikCrystalBarrageImpact = new("32B9E497929F054E8633EF013583E20C");
    public static readonly GUID HarvestTempleMordremothPoisonRoarIndicator = new("171A7BD24B5D0B4BA3770FF8A6A37EC0");
    public static readonly GUID HarvestTempleMordremothPoisonRoarImpact = new("E500544171F13643899C178EC3FB38A9");
    public static readonly GUID HarvestTempleMordremothShockwave1 = new("3DFB20FECCAF794EA194E1F93CB0146A"); // duration 0
    public static readonly GUID HarvestTempleMordremothShockwave2 = new("17E4CA4ED7CAF843895AD75F2D45D9A6"); // duration 0
    public static readonly GUID HarvestTempleZhaitanPutridDelugeImpact = new("FE8B96A200376B4BA75297FF2367C5C4");
    public static readonly GUID HarvestTempleZhaitanPutridDelugeAoE = new("82A8BC954DD69E4DBBF526EE1C6A3E74");
    public static readonly GUID HarvestTempleZhaitanTailSlamImpact = new("7D0FBDEC2B1DEF4B8BC0FD6A5BFD3705");
    public static readonly GUID HarvestTempleZhaitanScreamIndicator = new("12B49E1A9D034F45A3BD754331418F9B");
    public static readonly GUID HarvestTempleTargetedExpulsionSpreadNM = new("F39933B190100B4C87E808EF8E6C654A"); // Duration 5000
    public static readonly GUID HarvestTempleTargetedExpulsionSpreadCM = new("BDF708225224C64183BA3CE2A609D37F"); // Duration 5000
    public static readonly GUID HarvestTempleVoidPoolRedPuddleSelectionNM = new("0CD6F76C1BF9C049A2FCE4D86CB46475"); // Duration 7936
    public static readonly GUID HarvestTempleVoidPoolRedPuddleAoENM = new("60EE2CA1A95C514F8A325B654E0D9478"); // Duration 24000
    public static readonly GUID HarvestTempleVoidPoolRedPuddleSelectionCM = new("61C1CD7E89346843B04FCE613EC487AA"); // Duration 7936
    public static readonly GUID HarvestTempleVoidPoolRedPuddleAoECM = new("FF0A7D32AD894E45993BE5ED748BF484"); // Duration 240000 (4 minutes)
    public static readonly GUID HarvestTempleGreen = new("3EEDE16455C8C8449237BCC77F107548");
    public static readonly GUID HarvestTempleSuccessGreen = new("72EE47DE4F63D3438E193578011FBCBF");
    public static readonly GUID HarvestTempleFailedGreen = new("F4F80E9AF2B6AF49AFE46D8CF797B604");
    public static readonly GUID HarvestTempleOrbExplosion = new("B329CFB6B354C148A537E114DC14CED6");
    public static readonly GUID HarvestTemplePurificationOrbSpawns = new("4F982CD060507C44A25844BF0ADFCB54");
    public static readonly GUID HarvestTempleVoidPoolOrbGettingReadyToBeDangerous = new("D11320204E28E643A48469AA8E4845BA");
    public static readonly GUID HarvestTempleInfluenceOfTheVoidPool = new("912F68E45158C14E9A30D6011B7B0C7F");
    public static readonly GUID HarvestTempleSooWonClaw = new("CB877C57D1423240BACDF8D6B52A440F");
    public static readonly GUID HarvestTempleSooWonVoidOrbs1 = new("F6964A4DE51DF04CA7E0F011BEE7D854"); // 2080 duration - these are the orbs spawning just before the claw swipe
    public static readonly GUID HarvestTempleSooWonVoidOrbs2 = new("88E9C3112BF6DA4486845A0433782E9C"); // 2080 duration - these are the orbs spawning just before the claw swipe
    public static readonly GUID HarvestTempleTormentOfTheVoidClawIndicator = new("3F24896D3EF8D5459B399DAC8D0AD150"); // AoE indicator for bouncing orbs after Soo-Won's Claw Slap attack
    public static readonly GUID HarvestTempleScalableOrangeAoE = new("C1A523D71A841048897211B1020B8D95"); // Generic orange aoe - variable radius - variable duration
    public static readonly GUID HarvestTempleTsunamiIndicator = new("8B0EBA3241E1ED469DAC7AFD4E385FF2");
    public static readonly GUID HarvestTempleTsunami1 = new("8F96447526A09B4F8545CBEA1B0046D4"); // There are multiple effects when the Tsunami goes off
    public static readonly GUID HarvestTempleTsunami2 = new("C2CF236673BC0141B6EE5A918869728A"); // There are multiple effects when the Tsunami goes off
    public static readonly GUID HarvestTempleTsunami3 = new("E4700E828E058649B9B94F170DEF8659"); // There are multiple effects when the Tsunami goes off
    public static readonly GUID HarvestTempleSooWonTsunamiSlamIndicator = new("0D594F550B0BF043B0B299FC26A8463B");
    public static readonly GUID HarvestTempleTailSlamIndicator = new("49BD7FF8309E4047B4D17C83E660A461");
    public static readonly GUID HarvestTempleVoidBrandbomberBrandedArtillery = new("3ED61C8A1C2E594A8AD2E2E69AF16322"); // duration 2310
    public static readonly GUID HarvestTempleVoidExplosion = new("A478BD35F568974091FC99670B5A9700"); // Last Laugh AoE - Same effect for all sizes - 2050 duration
    public static readonly GUID HarvestTempleVoidStormseerIceSpike = new("2B9395E6BDE51E4C90AD3A9CA78FBCE7"); // duration 5000
    public static readonly GUID HarvestTempleVoidStormseerIceSpikeIndicator = new("BFF48E3A55F94E48ACE3820EEB4B0E71"); // duration 1750
    public static readonly GUID HarvestTempleVoidGiantRottingBileIndicator = new("912F68E45158C14E9A30D6011B7B0C7F"); // duration 1400
    public static readonly GUID HarvestTempleVoidGiantRottingBileDamage = new("73931DCBD7D25E4FAE930BA1B896D07E"); // duration 10000
    public static readonly GUID HarvestTempleVoidTimecasterGravityCrushIndicator = new("1344E9C82608BB47AADA2B850DB7DEF7"); // duration 1600
    public static readonly GUID HarvestTempleVoidTimecasterNightmareEpoch = new("7D94F6283F23FC4A839D0F8EEE0549C5"); // duration 10000
    public static readonly GUID HarvestTempleVoidSaltsprayDragonHydroBurstWhirlpools = new("8198E9B46FF7AB438927745B76759A7F"); // duration 3000
    public static readonly GUID HarvestTempleVoidSaltsprayDragonCallLightning = new("6724030E0E64CA4E8D947A5CCFA8188E"); // duration 0 - using this for mechanic instead of orange aoe effect
    public static readonly GUID HarvestTempleVoidSaltsprayDragonFrozenFuryCone = new("ECD550A176BD9249A6925E8C2DD0CA30");
    public static readonly GUID HarvestTempleVoidSaltsprayDragonFrozenFuryRectangle = new("56E2F67D3D550442A7BE11E85FDDE65D");
    public static readonly GUID HarvestTempleVoidSaltsprayDragonRollingFlames = new("084A4E29CD66A04C9ECDB8033EFFE6A1");
    public static readonly GUID HarvestTempleVoidSaltsprayDragonShatterEarth = new("5978C1D3AE4BCD4BAB286BF4FD8B24E9");
    public static readonly GUID HarvestTempleVoidGoliathGlacialSlam = new("B28E156F3C93ED4B842B4479ABF5F5C1"); // duration 5000
    public static readonly GUID HarvestTempleVoidObliteratorChargeIndicator = new("8F65EC18AC385342982BCB28F9742B37"); // duration 1000
    public static readonly GUID HarvestTempleVoidObliteratorWyvernBreathIndicator = new("8A1D085CA69E8A42A52196C99AE86CAF"); // duration 3400
    public static readonly GUID HarvestTempleVoidObliteratorWyvernBreathFire = new("453283E51FF9EF489980B6F0208F5F43"); // duration 30000
    public static readonly GUID HarvestTempleVoidObliteratorFirebomb = new("D2E7228A6225FB44911507A45EF2CCEC"); // duration 21000
    public static readonly GUID HarvestTempleVoidObliteratorShockwave = new("4254DCF4AF72FF4A83847908DA98E427"); // duration 0, should probably be 2900
    // Old Lion's Court
    public static readonly GUID OldLionsCourtExhaustPlumeAoE = new("E273E005F90E3041939C6235FF9CADBA"); // All Knights Src - Duration 5000 - AoE
    public static readonly GUID OldLionsCourtBoilingAetherExpanding = new("CBD8C6AE14B69A43A9596B94C402B9F3"); // All Knights Src - Duration 10000
    public static readonly GUID OldLionsCourtBoilingAetherFullyExpanded1 = new("77D73A835CEE5446ACD9D8C5BDF99BB0"); // All Knights Src - Duration 590000 - Has End Event
    public static readonly GUID OldLionsCourtBoilingAetherFullyExpanded2 = new("6BA3A84984190042A31400D52637B141"); // All Knights Src - Duration 590000 - Has End Event
    public static readonly GUID OldLionsCourtSpaghettificationDoughnutStart = new("40A9EFF40B532140A615020A6419EBE4"); // Red Knight Src - Duration 1500 or 30000 - Doughnut AoE - Has End Event if 30000
    public static readonly GUID OldLionsCourtSpaghettificationCircleFlipped = new("9306700A06F4B14EBC91318C24535280"); // Red Knight Src - Duration 1500 or 30000 - Circle AoE - Has End Event if 30000
    public static readonly GUID OldLionsCourtSpaghettificationCircleDetonation = new("549A02C94E642B45BF35EBEE84CF72CC"); // Red Knight Src - Duration 1500 - Circle AoE - Has End Event
    public static readonly GUID OldLionsCourtSpaghettificationDoughnutDetonation = new("B7FB4A5607D3284EBAA649A39861EE5C"); // Red Knight Src - Duration 0 - Doughnut AoE
    public static readonly GUID OldLionsCourtSpaghettificationSafeZoneSemiCircle = new("A9544AB8A84EED468817138BAFB79551"); // Red Knight Src - Duration 30000 - Safe Zone Semi Circle AoE - Has End Event
    public static readonly GUID OldLionsCourtSpaghettificationSafeZoneFullCircle = new("5718748DF0A13B438ACBBD156BADCFEE"); // Red Knight Src - Duration 30000 - Safe Zone FUll Circle AoE - Has End Event
    public static readonly GUID OldLionsCourtDualHorizonOrange = new("533D8FC0542C2F41ADC6515141E38501"); // Red Knight Src - Duration 4100 - AoE Doughnut
    public static readonly GUID OldLionsCourtDualHorizonWhiteInner = new("182666D5B4B6E64AAE8423D76012E9B0"); // Red Knight Src - Duration 4000 - White Outer
    public static readonly GUID OldLionsCourtDualHorizonWhiteOuter = new("F51B10029E0537488BAE346558A22F02"); // Red Knight Src - Duration 4000 - White Inner
    public static readonly GUID OldLionsCourtThunderingUltimatumFrontalCone = new("687C781108ED664DB17B7B501C942ADC"); // Blue Knight Src - Duration 1500 or 30000 - Frontal Cone AoE - Has End Event if 30000
    public static readonly GUID OldLionsCourtThunderingUltimatumFlipCone = new("DFD5DF9B331D9C45A5E592EA2E39695D"); // Blue Knight Src - Duration 1500 or 30000 - Flip Cone AoE - Has End Event if 30000
    public static readonly GUID OldLionsCourtThunderingUltimatumDetonation = new("676C0B284588FC40829C2F09F07BCDFD"); // Blue Knight Src - Duration 0 - Detonation AoE
    public static readonly GUID OldLionsCourtThunderingUltimatumSafeZone = new("8119770118A16243BAE86724E575753A"); // Blue Knight Src - Duration 30000 - Safe Zone AoE - Has End Event
    public static readonly GUID OldLionsCourtDysapoptosisIndicator = new("49BD1C09B29DEC49AFE85E15D070108F"); // Green Knight Src - Duration 1500 or 30000 - Incorrect logged position - Has End Event if 30000
    public static readonly GUID OldLionsCourtDysapoptosisDetonation = new("909CBB96C7FA0A47A7AFB7764457786F"); // Green Knight Src - Duration 0 - Semi Circle AoE
    public static readonly GUID OldLionsCourtTriBoltSpread = new("740D0839AD1AD749A92B06E40765BBF2"); // Blue Knight Src - Player Dst - Duration 2000 - Triple Spread AoE
    public static readonly GUID OldLionsCourtTribocharge = new("CB4C61AE8EF4FC468B185E126FD42C81"); // Tribocharge Src - No Dst - Duration 5000
    public static readonly GUID OldLionsCourtGravitationalWave = new("B329CFB6B354C148A537E114DC14CED6"); // Red Knight Src - No Dst - Duration 0 - Safe effect as Harvest Temple Orb Explosion
    public static readonly GUID OldLionsCourtGravityHammer = new("D11320204E28E643A48469AA8E4845BA"); // Red Knight Src - Duration 1000 - Third Autoattack Indicator AoE
    public static readonly GUID OldLionsCourtBoilingAetherSpawnIndicator = new("34724E94CD4E974C95A8D9D1D1162658"); // Red Knight Src - Duration 1190
    public static readonly GUID OldLionsCourtPerniciousVortexWarning1 = new("6BDC9DB69C2BD643828419CB58957901"); // Green Knight Src - Duration 4000
    public static readonly GUID OldLionsCourtPerniciousVortexWarning2 = new("E10DD1D759499749B880B99945C823B5"); // Green Knight Src - Duration 4000
    public static readonly GUID OldLionsCourtPerniciousVortexActive = new("A4F4B2C3DA211040B9BFAAA8DA801807"); // Green Knight Src - Duration 5000
    public static readonly GUID OldLionsCourtCracklingWindIndicator = new("4B569B684D489B4592AF8285A3A4B401"); // Blue Knight Src - Duration 4000
    public static readonly GUID OldLionsCourtRuptureIndicator = new("2A42D5E57617DF46A22B34485D6F3831"); // Green Knight Src - Duration 2000
    // Cosmic Observatory
    public static readonly GUID CosmicObservatoryDemonicBlastSliceIndicator = new("A21A92783688A847963B86E96B8CC9BE");
    public static readonly GUID CosmicObservatoryDemonicBlastDagdaEffect1 = new("D03CDF37E0AC8246ABD4E741ADD61427"); // 0 duration no effect end
    public static readonly GUID CosmicObservatoryDemonicBlastDagdaEffect2 = new("3A19BC0143715C419504C25EA0B7ADFE"); // 0 duration no effect end
    public static readonly GUID CosmicObservatoryDemonicFever = new("BDF708225224C64183BA3CE2A609D37F");
    public static readonly GUID CosmicObservatorySharedDestructionCosmicMeteorGreen = new("3EEDE16455C8C8449237BCC77F107548");
    public static readonly GUID CosmicObservatorySharedDestructionCosmicMeteorGreenEnd = new("FED0256743CC534695F30EB3655933AD");
    public static readonly GUID CosmicObservatorySpinningNebula = new("8196855C5F76874CAF1DB683BD163811");
    public static readonly GUID CosmicObservatoryShootingStarsGreenArrow = new("046AFA0B20E07447BDBB94A03FCA2662"); // 9000 duration
    public static readonly GUID CosmicObservatoryDemonicPoolsIndicator = new("52C0855CB838424D91343DD5C176EC2E"); // 3000 duration
    public static readonly GUID CosmicObservatoryDemonicPoolsDamage = new("F9020791BEE9BC41B6A17955120EDD32"); // 20000 duration - can end early
    public static readonly GUID CosmicObservatoryRainOfComets = new("43A9C4FBF0628A4C9D38084854653547");
    public static readonly GUID CosmicObservatoryPlanetCrash = new("B4529A29DF12BA4D913973FFAAE22926");
    // Temple of Febe
    public static readonly GUID TempleOfFebeCerusGreen = new("0651E35503F642419A21378FBD29F777"); // Owner Cerus Target Player
    public static readonly GUID TempleOfFebeCerusGreen2 = new("E7E95B11D4AAD2469DD2FD0AF9631ED5"); // Owner Cerus Target Player
    public static readonly GUID TempleOfFebeRegretGreen = new("015E5CF598A13D4F8D6CCFD66643525F"); // Owner Embodiment of Regret Target Player
    public static readonly GUID TempleOfFebeGreenFailure = new("217289F02841EE498070E653723A3991"); // Owner Cerus/Embodiment Target None
    public static readonly GUID TempleOfFebeGreenSuccess = new("D7C64FEAB21040428D14CC3B2B4018F0"); // Owner Cerus/Embodiment Target None
    public static readonly GUID TempleOfFebeWailOfDespair = new("9EDCB6E2E3C11448B37F7D07B6B2D4F5"); // Owner Cerus/Embodiment Target Player Duration 5000
    public static readonly GUID TempleOfFebeWailOfDespair2 = new("00E0C7FC6A454B43B0FB93A6CA7BE83F"); // No Owner Target Player Duration 0
    public static readonly GUID TempleOfFebeWailOfDespairEmpowered = new("246326728CB3704C93FEA75C402D65CA"); // Owner Cerus/Embodiment Target Player Duration 5000
    public static readonly GUID TempleOfFebePoolOfDespair = new("3CF93AB93143B64A879D1D63FBA9282A"); // Owner Cerus/Embodiment Duration 60000
    public static readonly GUID TempleOfFebePoolOfDespair2 = new("4F982CD060507C44A25844BF0ADFCB54"); // No Owner Target Player Duration 0
    public static readonly GUID TempleOfFebePoolOfDespairEmpowered = new("24E40E1F15BE2142B61F3568D23AE799"); // Owner Cerus/Embodiment Duration 999000
    public static readonly GUID TempleOfFebeEnviousGazeIndicator = new("62B3766CDF54BD4EA964DAA462954A4A"); // Duration 1500
    public static readonly GUID TempleOfFebeEnviousGaze1 = new("246ECEBC28173B498B9A6886D7937D59"); // Duration 12500
    public static readonly GUID TempleOfFebeEnviousGaze2 = new("DA42718917F2304FBA10AF6898217788"); // Duration 12500
    public static readonly GUID TempleOfFebeEnviousGaze3 = new("B77A06C842511949889877EDC1448D49"); // Duration 11000
    public static readonly GUID TempleOfFebeEnviousGaze4 = new("0D2192849D53B4469F56B1C74542DBE9"); // Duration 11000
    public static readonly GUID TempleOfFebeMaliciousIntentTether = new("518369328A12B74EAC49702A785FBA19"); // Duration 0
    #endregion
}
