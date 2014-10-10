using System.Collections.Generic;

namespace XCOMSE
{
    public static class Enums
    {
        public enum ESoldierStatus : byte
        {
            eStatus_Active,
            eStatus_OnMission,
            eStatus_PsiTesting,
            eStatus_CovertOps,
            eStatus_GeneMod,
            eStatus_Augmenting,
            eStatus_Healing,
            eStatus_Dead,
            eStatus_MAX
        };

        public enum ESoldierLocation
        {
            eSoldierLoc_Barracks,
            eSoldierLoc_Dropship,
            eSoldierLoc_Infirmary,
            eSoldierLoc_Morgue,
            eSoldierLoc_PsiLabs,
            eSoldierLoc_PsiLabsCinematic,
            eSoldierLoc_Armory,
            eSoldierLoc_Gollup,
            eSoldierLoc_CyberneticsLab,
            eSoldierLoc_GeneticsLab,
            eSoldierLoc_CovertOps,
            eSoldierLoc_Outro,
            eSoldierLoc_MecCinematic,
            eSoldierLoc_GeneModCinematic,
            eSoldierLoc_GeneModNarrative,
            eSoldierLoc_MedalCeremony,
            eSoldierLoc_MAX
        };

        public enum ENameType
        {
            eNameType_First,
            eNameType_Last,
            eNameType_Nick,
            eNameType_Full,
            eNameType_Rank,
            eNameType_RankFull,
            eNameType_FullNick,
            eNameType_MAX
        };

        public enum ECharacterStat
        {
            eStat_HP,
            eStat_Offense,
            eStat_Defense,
            eStat_Mobility,
            eStat_Strength,
            eStat_ShieldHP,
            eStat_CouncilMedalAccrued,
            eStat_Will,
            eStat_AppliedSuppression,
            eStat_LowCoverBonus,
            eStat_SightRadius,
            eStat_WeaponRange,
            eStat_Damage,
            eStat_CriticalShot,
            eStat_CriticalWoundChance,
            eStat_CriticalWoundsReceived,
            eStat_CloseCombat,
            eStat_FlightFuel,
            eStat_Reaction,
            eStat_MAX
        };

        public enum EEasterEggCharacter
        {
            eEEC_None,
            eEEC_Sid,
            eEEC_Ken,
            eEEC_Otto,
            eEEC_Joe,
            eEEC_Carter,
            eEEC_Chris,
            eEEC_MAX
        };

        public enum EPerkType
        {
            ePerk_None,
            ePerk_OTS_XP,
            ePerk_PrecisionShot,
            ePerk_SquadSight,
            ePerk_GeneMod_SecondHeart,
            ePerk_LowProfile,
            ePerk_RunAndGun,
            ePerk_AutopsyRequired,
            ePerk_BattleScanner,
            ePerk_DisablingShot,
            ePerk_Opportunist,
            ePerk_Executioner,
            ePerk_OTS_Leader,
            ePerk_DoubleTap,
            ePerk_InTheZone,
            ePerk_DamnGoodGround,
            ePerk_SnapShot,
            ePerk_WillToSurvive,
            ePerk_FireRocket,
            ePerk_TracerBeams,
            ePerk_GeneMod_Adrenal,
            ePerk_FocusedSuppression,
            ePerk_ShredderRocket,
            ePerk_RapidReaction,
            ePerk_Grenadier,
            ePerk_DangerZone,
            ePerk_BulletSwarm,
            ePerk_ExtraConditioning,
            ePerk_GeneMod_BrainDamping,
            ePerk_GeneMod_BrainFeedback,
            ePerk_GeneMod_Pupils,
            ePerk_Sprinter,
            ePerk_Aggression,
            ePerk_TacticalSense,
            ePerk_CloseAndPersonal,
            ePerk_LightningReflexes,
            ePerk_RapidFire,
            ePerk_Flush,
            ePerk_GeneMod_DepthPerception,
            ePerk_BringEmOn,
            ePerk_CloseCombatSpecialist,
            ePerk_KillerInstinct,
            ePerk_GeneMod_BioelectricSkin,
            ePerk_Resilience,
            ePerk_SmokeBomb,
            ePerk_GeneMod_BoneMarrow,
            ePerk_StunImmune,
            ePerk_CoveringFire,
            ePerk_FieldMedic,
            ePerk_RifleSuppression_DEPRECATED,
            ePerk_GeneMod_MuscleFiber,
            ePerk_CombatDrugs,
            ePerk_DenseSmoke,
            ePerk_DeepPockets,
            ePerk_Sentinel,
            ePerk_Savior,
            ePerk_Revive,
            ePerk_HeightAdvantage,
            ePerk_Disabled_DEPRECATED,
            ePerk_ImmuneToDisable_DEPRECATED,
            ePerk_SuppressedActive,
            ePerk_CriticallyWounded,
            ePerk_Flying,
            ePerk_Stealth,
            ePerk_Poisoned,
            ePerk_CombatStimActive,
            ePerk_Implanted,
            ePerk_Panicked,
            ePerk_MindFray,
            ePerk_PsiPanic,
            ePerk_PsiInspiration,
            ePerk_MindControl,
            ePerk_TelekineticField,
            ePerk_Rift,
            ePerk_MindMerge,
            ePerk_MindMerger,
            ePerk_Hardened,
            ePerk_GreaterMindMerge,
            ePerk_GreaterMindMerger,
            ePerk_Evade,
            ePerk_Launch,
            ePerk_Bombard,
            ePerk_Leap,
            ePerk_Plague,
            ePerk_Poison,
            ePerk_BloodCall,
            ePerk_Intimidate,
            ePerk_FallenComrades,
            ePerk_Bloodlust,
            ePerk_BullRush,
            ePerk_HEATAmmo,
            ePerk_SmokeAndMirrors,
            ePerk_Rocketeer,
            ePerk_Mayhem,
            ePerk_Gunslinger,
            ePerk_GeneMod_MimeticSkin,
            ePerk_ClusterBomb,
            ePerk_PsiLance,
            ePerk_DeathBlossom,
            ePerk_Overload,
            ePerk_PsiControl,
            ePerk_PsiDrain,
            ePerk_Repair,
            ePerk_CannonFire,
            ePerk_Implant,
            ePerk_ChryssalidSpawn,
            ePerk_BattleFatigue,
            ePerk_OnlyForGermanModeStrings_ItemRangeBonus,
            ePerk_OnlyForGermanModeStrings_ItemRangePenalty,
            ePerk_Foundry_Scope,
            ePerk_Foundry_PistolI,
            ePerk_Foundry_PistolII,
            ePerk_Foundry_PistolIII,
            ePerk_Foundry_AmmoConservation,
            ePerk_Foundry_AdvancedFlight,
            ePerk_Foundry_ArcThrowerII,
            ePerk_Foundry_MedikitII,
            ePerk_Foundry_CaptureDrone,
            ePerk_Foundry_SHIVHeal,
            ePerk_Foundry_SHIVSuppression,
            ePerk_Foundry_EleriumFuel,
            ePerk_Foundry_MECCloseCombat,
            ePerk_Foundry_AdvancedServomotors,
            ePerk_Foundry_ShapedArmor,
            ePerk_Foundry_SentinelDrone,
            ePerk_Foundry_AlienGrenades,
            ePerk_PlasmaBarrage,
            ePerk_SeekerStealth,
            ePerk_StealthGrenade,
            ePerk_ReaperRounds,
            ePerk_Disoriented,
            ePerk_Barrage,
            ePerk_AutoThreatAssessment,
            ePerk_AdvancedFireControl,
            ePerk_DamageControl,
            ePerk_XenobiologyOverlays,
            ePerk_OneForAll,
            ePerk_JetbootModule,
            ePerk_ExpandedStorage,
            ePerk_RepairServos,
            ePerk_Overdrive,
            ePerk_PlatformStability,
            ePerk_AbsorptionFields,
            ePerk_ShockAbsorbentArmor,
            ePerk_ReactiveTargetingSensors,
            ePerk_BodyShield,
            ePerk_DistortionField,
            ePerk_GeneMod_AdrenalineSurge,
            ePerk_GeneMod_IronSkin,
            ePerk_GeneMod_RegenPheromones,
            ePerk_CovertPockets,
            ePerk_CovertHacker,
            ePerk_Medal_UrbanA,
            ePerk_Medal_UrbanB,
            ePerk_Medal_DefenderA,
            ePerk_Medal_DefenderB,
            ePerk_Medal_InternationalA,
            ePerk_Medal_InternationalB,
            ePerk_Medal_CouncilA,
            ePerk_Medal_CouncilB,
            ePerk_Medal_TerraA,
            ePerk_Medal_TerraB,
            ePerk_Dazed,
            ePerk_OnlyForGermanModeStrings_AimingAnglesBonus,
            ePerk_CatchingBreath,
            ePerk_Foundry_TacticalRigging,
            ePerk_SeekerStrangle,
            ePerk_ReinforcedArmor,
            ePerk_MindMerge_Mechtoid,
            ePerk_Electropulse,
            ePerk_OTS_Leader_Bonus,
            ePerk_OTS_Leader_TheLeader,
            ePerk_MAX
        };

        public enum EMedalType
        {
            eMedal_None,
            eMedal_UrbanCombat,
            eMedal_Defender,
            eMedal_InternationalService,
            eMedal_Council,
            eMedal_Terra,
            eMedal_MAX
        };

        public enum EAbility
        {
            eAbility_NONE,
            eAbility_Move,
            eAbility_Fly,
            eAbility_FlyUp,
            eAbility_FlyDown,
            eAbility_Launch,
            eAbility_Grapple,
            eAbility_ShotStandard,
            eAbility_RapidFire,
            eAbility_ShotStun,
            eAbility_ShotDroneHack,
            eAbility_ShotOverload,
            eAbility_ShotFlush,
            eAbility_ShotSuppress,
            eAbility_ShotDamageCover,
            eAbility_FlashBang,
            eAbility_FragGrenade,
            eAbility_SmokeGrenade,
            eAbility_AlienGrenade,
            eAbility_RocketLauncher,
            eAbility_Aim,
            eAbility_Intimidate,
            eAbility_Overwatch,
            eAbility_Torch,
            eAbility_Plague,
            eAbility_Stabilize,
            eAbility_Revive,
            eAbility_TakeCover,
            eAbility_Ghost,
            eAbility_MedikitHeal,
            eAbility_RepairSHIV,
            eAbility_CombatStim,
            eAbility_EquipWeapon,
            eAbility_Reload,
            eAbility_MindMerge,
            eAbility_PsiLance,
            eAbility_PsiBoltII,
            eAbility_PsiBomb,
            eAbility_GreaterMindMerge,
            eAbility_PsiControl,
            eAbility_PsiPanic,
            eAbility_WarCry,
            eAbility_Berserk,
            eAbility_ReanimateAlly,
            eAbility_ReanimateEnemy,
            eAbility_PsiDrain,
            eAbility_PsiBless,
            eAbility_DoubleTap,
            eAbility_PrecisionShot,
            eAbility_DisablingShot,
            eAbility_SquadSight,
            eAbility_TooCloseForComfort,
            eAbility_ShredderRocket,
            eAbility_ShotMayhem,
            eAbility_RunAndGun,
            eAbility_BullRush,
            eAbility_BattleScanner,
            eAbility_Mindfray,
            eAbility_Rift,
            eAbility_TelekineticField,
            eAbility_MindControl,
            eAbility_PsiInspiration,
            eAbility_CloseCyberdisc,
            eAbility_DeathBlossom,
            eAbility_CannonFire,
            eAbility_ClusterBomb,
            eAbility_DestroyTerrain,
            eAbility_PsiInspired,
            eAbility_Repair,
            eAbility_HeatWave,
            eAbility_CivilianCover,
            eAbility_Bloodlust,
            eAbility_BloodCall,
            eAbility_MimeticSkin,
            eAbility_AdrenalNeurosympathy,
            eAbility_MimicBeacon,
            eAbility_GasGrenade,
            eAbility_GhostGrenade,
            eAbility_GhostGrenadeStealth,
            eAbility_NeedleGrenade,
            eAbility_MEC_Flamethrower,
            eAbility_MEC_KineticStrike,
            eAbility_MEC_ProximityMine,
            eAbility_JetbootModule,
            eAbility_MEC_Barrage,
            eAbility_MEC_OneForAll,
            eAbility_MEC_GrenadeLauncher,
            eAbility_MEC_RestorativeMist,
            eAbility_MEC_ElectroPulse,
            eAbility_MEC_RestorativeMistHealing,
            eAbility_Strangle,
            eAbility_Stealth,
            eAbility_ActivateStealthMP,
            eAbility_DeactivateStealthMP,
            eAbility_PsiReflect,
            eAbility_FlashBangDaze_DEPRECATED,
            eAbility_MAX
        };

        public enum ECharacterProperty
        {
            eCP_None,
            eCP_Climb,
            eCP_Flight,
            eCP_Robotic,
            eCP_MeleeOnly,
            eCP_Hardened,
            eCP_CanGainXP,
            eCP_AirEvade,
            eCP_NoCover,
            eCP_PoisonImmunity,
            eCP_LargeUnit,
            eCP_Poisonous,
            eCP_DeathExplosion,
            eCP_DoubleOverwatch,
            eCP_MAX
        };

        public enum ETraversalType
        {
            eTraversal_None,
            eTraversal_Normal,
            eTraversal_ClimbOver,
            eTraversal_ClimbOnto,
            eTraversal_ClimbLadder,
            eTraversal_DropDown,
            eTraversal_Grapple,
            eTraversal_Landing,
            eTraversal_BreakWindow,
            eTraversal_KickDoor,
            eTraversal_WallClimb,
            eTraversal_JumpUp,
            eTraversal_Ramp,
            eTraversal_BreakWall,
            eTraversal_Unreachable,
            eTraversal_MAX
        };

        public enum ESoldierClass
        {
            eSC_None,
            eSC_Sniper,
            eSC_HeavyWeapons,
            eSC_Support,
            eSC_Assault,
            eSC_Psi,
            eSC_Mec,
            eSC_MAX
        };

        public enum EWeaponProperty
        {
            eWP_None,
            eWP_Secondary,
            eWP_Pistol,
            eWP_AnyClass,
            eWP_Support,
            eWP_Rifle,
            eWP_Assault,
            eWP_Sniper,
            eWP_Heavy,
            eWP_Explosive,
            eWP_UnlimitedAmmo,
            eWP_Overheats,
            eWP_Psionic,
            eWP_Melee,
            eWP_Integrated,
            eWP_Encumber,
            eWP_MoveLimited,
            eWP_Backpack,
            eWP_NoReload,
            eWP_CantReact,
            eWP_Mec,
            eWP_MAX
        };

        public enum eChosenPower
        {
        }

        public enum ECountry
        {
            //This is to ID the traitor nation and general country stuff
            eCountry_USA = 0,

            eCountry_Canada = 1,
            eCountry_Mexico,
            eCountry_UK,
            eCountry_Brazil,
            eCountry_China,
            eCountry_India,
            eCountry_Russia,
            eCountry_Argentina,
            eCountry_Japan,
            eCountry_Australia,
            eCountry_France,
            eCountry_Germany,
            eCountry_Egypt,
            eCountry_SouthAfrica,
            eCountry_Nigeria
        }

        public enum ECountries
        {
            USA = 0x0,
            Canada = 0x0F,
            Mexico = 0x15,
            UK = 0x03,
            Brazil = 0x13,
            China = 0x02,
            India = 0x07,
            Russia = 0x01,
            Argentina = 0x14,
            Japan = 0x06,
            Australia = 0x08,
            France = 0x05,
            Germany = 0x04,
            Egypt = 0x12,
            SouthAfrica = 0x16,
            Nigeria = 0x19
        }

        public enum eTemplate
        {
        }

        public enum Rank
        {
            Rookie = 0,
            Squaddie = 1,
            Corporal,
            Sergeant,
            Lieutenant,
            Captain,
            Major,
            Colonel
        }

        public static readonly Dictionary<int, string> PanicColours = new Dictionary<int, string>()
        {
            {0,"LightBlue"},
            {3,"Yellow"},
            {4,"DarkOrange"},
            {5,"DarkRed"}
    };

        //public enum PanicColours
        //        {
        //            LightBlue = 0,
        //            Yellow = 3,
        //            DarkOrange = 4,
        //            DarkRed = 5
        //        }

        public enum GameMode
        {
            Geo = 0x6,
            Tactical = 0x4
        }

        public enum GameVersion
        {
            Unknown,
            Within
        }

        public enum Platform
        {
            Xbox360,
            PS3,
            PC,
            iOS
        }

        public enum EContinent
        {
            eContinent_NorthAmerica,
            eContinent_SouthAmerica,
            eContinent_Europe,
            eContinent_Asia,
            eContinent_Africa
        }

        public enum EContinentBonus
        {
            eCB_AirAndSpace,
            eCB_WeHaveWays,
            eCB_Experts,
            eCB_FutureCombat,
            eCB_Funding
        }

        public enum EAlienObjective
        {
            eObjective_Scout,
            eObjective_Hunt,
            eObjective_Abduct,
            eObjective_Terrorize,
            eObjective_Infiltrate,
            eObjective_Flyby,
            eObjective_Harvest
        }

        public enum ePerk
        {
            ePerk_None,
            ePerk_OTS_XP,
            ePerk_PrecisionShot,
            ePerk_SquadSight,
            ePerk_GeneMod_SecondHeart,
            ePerk_LowProfile,
            ePerk_RunAndGun,
            ePerk_AutopsyRequired,
            ePerk_BattleScanner,
            ePerk_DisablingShot,
            ePerk_Opportunist,
            ePerk_Executioner,
            ePerk_OTS_Leader,
            ePerk_DoubleTap,
            ePerk_InTheZone,
            ePerk_DamnGoodGround,
            ePerk_SnapShot,
            ePerk_WillToSurvive,
            ePerk_FireRocket,
            ePerk_TracerBeams,
            ePerk_GeneMod_Adrenal,
            ePerk_FocusedSuppression,
            ePerk_ShredderRocket,
            ePerk_RapidReaction,
            ePerk_Grenadier,
            ePerk_DangerZone,
            ePerk_BulletSwarm,
            ePerk_ExtraConditioning,
            ePerk_GeneMod_BrainDamping,
            ePerk_GeneMod_BrainFeedback,
            ePerk_GeneMod_Pupils,
            ePerk_Sprinter,
            ePerk_Aggression,
            ePerk_TacticalSense,
            ePerk_CloseAndPersonal,
            ePerk_LightningReflexes,
            ePerk_RapidFire,
            ePerk_Flush,
            ePerk_GeneMod_DepthPerception,
            ePerk_BringEmOn,
            ePerk_CloseCombatSpecialist,
            ePerk_KillerInstinct,
            ePerk_GeneMod_BioelectricSkin,
            ePerk_Resilience,
            ePerk_SmokeBomb,
            ePerk_GeneMod_BoneMarrow,
            ePerk_StunImmune,
            ePerk_CoveringFire,
            ePerk_FieldMedic,
            ePerk_RifleSuppression_DEPRECATED,
            ePerk_GeneMod_MuscleFiber,
            ePerk_CombatDrugs,
            ePerk_DenseSmoke,
            ePerk_DeepPockets,
            ePerk_Sentinel,
            ePerk_Savior,
            ePerk_Revive,
            ePerk_HeightAdvantage,
            ePerk_Disabled_DEPRECATED,
            ePerk_ImmuneToDisable_DEPRECATED,
            ePerk_SuppressedActive,
            ePerk_CriticallyWounded,
            ePerk_Flying,
            ePerk_Stealth,
            ePerk_Poisoned,
            ePerk_CombatStimActive,
            ePerk_Implanted,
            ePerk_Panicked,
            ePerk_MindFray,
            ePerk_PsiPanic,
            ePerk_PsiInspiration,
            ePerk_MindControl,
            ePerk_TelekineticField,
            ePerk_Rift,
            ePerk_MindMerge,
            ePerk_MindMerger,
            ePerk_Hardened,
            ePerk_GreaterMindMerge,
            ePerk_GreaterMindMerger,
            ePerk_Evade,
            ePerk_Launch,
            ePerk_Bombard,
            ePerk_Leap,
            ePerk_Plague,
            ePerk_Poison,
            ePerk_BloodCall,
            ePerk_Intimidate,
            ePerk_FallenComrades,
            ePerk_Bloodlust,
            ePerk_BullRush,
            ePerk_HEATAmmo,
            ePerk_SmokeAndMirrors,
            ePerk_Rocketeer,
            ePerk_Mayhem,
            ePerk_Gunslinger,
            ePerk_GeneMod_MimeticSkin,
            ePerk_ClusterBomb,
            ePerk_PsiLance,
            ePerk_DeathBlossom,
            ePerk_Overload,
            ePerk_PsiControl,
            ePerk_PsiDrain,
            ePerk_Repair,
            ePerk_CannonFire,
            ePerk_Implant,
            ePerk_ChryssalidSpawn,
            ePerk_BattleFatigue,
            ePerk_OnlyForGermanModeStrings_ItemRangeBonus,
            ePerk_OnlyForGermanModeStrings_ItemRangePenalty,
            ePerk_Foundry_Scope,
            ePerk_Foundry_PistolI,
            ePerk_Foundry_PistolII,
            ePerk_Foundry_PistolIII,
            ePerk_Foundry_AmmoConservation,
            ePerk_Foundry_AdvancedFlight,
            ePerk_Foundry_ArcThrowerII,
            ePerk_Foundry_MedikitII,
            ePerk_Foundry_CaptureDrone,
            ePerk_Foundry_SHIVHeal,
            ePerk_Foundry_SHIVSuppression,
            ePerk_Foundry_EleriumFuel,
            ePerk_Foundry_MECCloseCombat,
            ePerk_Foundry_AdvancedServomotors,
            ePerk_Foundry_ShapedArmor,
            ePerk_Foundry_SentinelDrone,
            ePerk_Foundry_AlienGrenades,
            ePerk_PlasmaBarrage,
            ePerk_SeekerStealth,
            ePerk_StealthGrenade,
            ePerk_ReaperRounds,
            ePerk_Disoriented,
            ePerk_Barrage,
            ePerk_AutoThreatAssessment,
            ePerk_AdvancedFireControl,
            ePerk_DamageControl,
            ePerk_XenobiologyOverlays,
            ePerk_OneForAll,
            ePerk_JetbootModule,
            ePerk_ExpandedStorage,
            ePerk_RepairServos,
            ePerk_Overdrive,
            ePerk_PlatformStability,
            ePerk_AbsorptionFields,
            ePerk_ShockAbsorbentArmor,
            ePerk_ReactiveTargetingSensors,
            ePerk_BodyShield,
            ePerk_DistortionField,
            ePerk_GeneMod_AdrenalineSurge,
            ePerk_GeneMod_IronSkin,
            ePerk_GeneMod_RegenPheromones,
            ePerk_CovertPockets,
            ePerk_CovertHacker,
            ePerk_Medal_UrbanA,
            ePerk_Medal_UrbanB,
            ePerk_Medal_DefenderA,
            ePerk_Medal_DefenderB,
            ePerk_Medal_InternationalA,
            ePerk_Medal_InternationalB,
            ePerk_Medal_CouncilA,
            ePerk_Medal_CouncilB,
            ePerk_Medal_TerraA,
            ePerk_Medal_TerraB,
            ePerk_Dazed,
            ePerk_OnlyForGermanModeStrings_AimingAnglesBonus,
            ePerk_CatchingBreath,
            ePerk_Foundry_TacticalRigging,
            ePerk_SeekerStrangle,
            ePerk_ReinforcedArmor,
            ePerk_MindMerge_Mechtoid,
            ePerk_Electropulse,
            ePerk_OTS_Leader_Bonus,
            ePerk_OTS_Leader_TheLeader,
            ePerk_MAX
        }

        public static readonly Dictionary<EPerkType,string> PerkTips = new Dictionary<EPerkType, string>()
        {
            
{EPerkType.ePerk_Sprinter,"Allows the soldier to move <XGAbility:SprinterBonusDistanceInTiles/> additional tiles."
},{EPerkType.ePerk_HeightAdvantage,"Elevated Ground"
},{EPerkType.ePerk_Sentinel,"Allows two reaction shots during Overwatch, instead of only one."
},{EPerkType.ePerk_Rocketeer,"Allows <XGAbility:RocketeerExtraRockets/> additional standard rocket to be fired per battle."
},{EPerkType.ePerk_Mayhem,"Confers additional damage based on weapon tech level to Suppression and all area-effect abilities."
},{EPerkType.ePerk_SmokeAndMirrors,"Allows <XGAbility:SmokeAndMirrorsExtraSmokeBombs/> additional uses of Smoke Grenade each mission."
},{EPerkType.ePerk_DisablingShot,"Allows the Sniper to fire a shot that causes the target's main weapon to malfunction. The target may use Reload to fix the weapon. The shot cannot inflict a critical hit. <XGAbility:DisablingShotCooldown/> turn cooldown."
},{EPerkType.ePerk_SuppressedActive,"Suppressed"
},{EPerkType.ePerk_CriticallyWounded,"Critically Wounded"
},{EPerkType.ePerk_Flying,"Airborne"
},{EPerkType.ePerk_Stealth,"The Ghost Armor's stealth systems can be activated up to 4 times per battle. Activating Ghost Mode does not cost an action or end the wearer's turn. The wearer becomes invisible to enemies, but must re-activate Ghost Mode each turn to remain so. Firing from stealth confers a large bonus to critical hit chance."
},{EPerkType.ePerk_GreaterMindMerge,"Merge minds with all lesser allies of the same species nearby, granting them +<XGAbility:MindMergeCritBonus/>% critical chance and +<XGAbility:MindMergeHealthBonus/> health."
},{EPerkType.ePerk_ClusterBomb,"Mark a large area, and after one turn, saturate it with a barrage of explosive mini-bombs."
},{EPerkType.ePerk_PsiLance,"Project a bolt of pure psi force at an enemy."
},{EPerkType.ePerk_Overload,"Overload the unit's own power source, destroying the unit but causing explosive damage similar to a grenade's."
},{EPerkType.ePerk_PsiControl,"Very difficult psi technique that, if successful, grants control of the target for 3 turns. Does not work on robotic enemies."
},{EPerkType.ePerk_PsiDrain,"Drain health from an ally."
},{EPerkType.ePerk_Repair,"Repairs robotic units."
},{EPerkType.ePerk_CannonFire,"Beam attack that causes high damage and grants free Overwatch. If the Sectopod does not move, Cannon Fire can be used twice (against different enemies)."
},{EPerkType.ePerk_Implant,"Victims are implanted with a Chryssalid egg if they are killed by a Chryssalid's attack (not from poison caused by Poisonous Claws)."
},{EPerkType.ePerk_StunImmune,"This unit cannot be stunned with the Arc Thrower; taking a live specimen is not possible."
},{EPerkType.ePerk_ChryssalidSpawn,"Implanted Chryssalid eggs hatch into Chryssalids after 3 turns if the Zombie host is not killed."
},{EPerkType.ePerk_MindMerge,"Merge minds with the target, granting the target +<XGAbility:MindMergeCritBonus/>% critical chance and +<XGAbility:MindMergeHealthBonus/> health."
},{EPerkType.ePerk_Hardened,"Confers extra protection against critical hits. Enemies suffer a -<XGAbility:HardenedCritPenalty/>% chance to inflict critical hits."
},{EPerkType.ePerk_CombatStimActive,"Combat Stimmed"
},{EPerkType.ePerk_Panicked,"Panicked"
},{EPerkType.ePerk_PrecisionShot,"Fire a shot with +<XGAbility:HeadshotCritBonus/>% critical chance and extra damage on critical hits, based on the sniper's rank. <XGAbility:HeadshotCooldown/> turn cooldown."
},{EPerkType.ePerk_SquadSight,"Allows firing at targets in any ally's sight radius, but these targets cannot be critically hit unless using Headshot."
},{EPerkType.ePerk_Gunslinger,"Confers <XGAbility:GunslingerPistolDamageBonus/> bonus damage with pistols."
},{EPerkType.ePerk_DamnGoodGround,"Confers +<XGAbility:DamnGoodGroundAimBonus/> Aim and +<XGAbility:DamnGoodGroundDefenseBonus/> Defense against enemies at lower elevation, in addition to the usual elevation bonuses."
},{EPerkType.ePerk_SnapShot,"Removes the sniper rifle's restriction on firing and Overwatch after moving. Any shots taken suffer a -<XGAbility:SnapShotAimPenalty/> Aim penalty."
},{EPerkType.ePerk_Opportunist,"Eliminates the Aim penalty on reaction shots, and allows reaction shots to cause critical hits."
},{EPerkType.ePerk_Executioner,"Confers +<XGAbility:ExecutionerAimBonus/> Aim against targets with less than <XGAbility:ExecutionerHealthThreshold/>% health."
},{EPerkType.ePerk_LowProfile,"Makes partial cover count as full."
},{EPerkType.ePerk_DoubleTap,"Allows both actions to be used for Standard Shot, Headshot, or Disabling Shot, provided no moves were made. <XGAbility:DoubleTapCooldown/> turn cooldown."
},{EPerkType.ePerk_BattleScanner,"Scanning device that, when thrown, creates a new source of vision for <XGAbility:BattleScannerDuration/> turns. Can only be used <XGAbility:BattleScannerCharges/> times per battle."
},{EPerkType.ePerk_InTheZone,"Killing a flanked or uncovered target with the sniper rifle does not cost an action."
},{EPerkType.ePerk_RunAndGun,"Allows firing or Overwatch after Dashing on the turn Run and Gun is activated. <XGAbility:RunAndGunCooldown/> turn cooldown."
},{EPerkType.ePerk_Aggression,"Confers +<XGAbility:AggressionCritBonusPerEnemy/>% critical chance per enemy in sight (max +<XGAbility:AggressionCritBonusMax/>%)."
},{EPerkType.ePerk_TacticalSense,"Confers +<XGAbility:TacticalSenseDefenseBonusPerEnemy/> Defense per enemy in sight (max +<XGAbility:TacticalSenseDefenseBonusMax/>)."
},{EPerkType.ePerk_CloseAndPersonal,"The first standard shot made within <XGAbility:CloseAndPersonalDist/> tiles of the target does not cost an action. Cannot combine with Run and Gun."
},{EPerkType.ePerk_LightningReflexes,"Forces the first reaction shot against this unit each turn to miss."
},{EPerkType.ePerk_BringEmOn,"Adds <XGAbility:BringEmOnCritDamageBonus/> damage on critical hits for each enemy the squad can see (up to <XGAbility:BringEmOnMaxCritDamageBonus/>)."
},{EPerkType.ePerk_Flush,"Fire a shot that causes enemies to run out of cover. The shot is easy to hit with, but does reduced damage."
},{EPerkType.ePerk_Evade,"Enemies targeting this unit when it is airborne suffer a -<XGAbility:EvasionDefenseBonus/> Aim penalty."
},{EPerkType.ePerk_BloodCall,"Unleash a bestial roar that inspires nearby allies of the same species to greater speed, focus, and resolve for <XGAbility:BloodCallDuration/> turns. <XGAbility:BloodCallCooldown/> turn cooldown."
},{EPerkType.ePerk_Intimidate,"Reacts unpredictably when wounded, provoking panic in enemies."
},{EPerkType.ePerk_BullRush,"Charge towards an enemy to unleash a devastating melee attack."
},{EPerkType.ePerk_Bloodlust,"Allows the Berserker to charge an enemy that wounds it."
},{EPerkType.ePerk_DeathBlossom,"Project an intense energy field from Closed position, damaging all nearby enemies. <XGAbility:DeathBlossomCooldown/> turn cooldown."
},{EPerkType.ePerk_Launch,"Move anywhere on the battlefield in a single turn. Launch cannot be used indoors."
},{EPerkType.ePerk_Bombard,"Throw or launch grenades over exceptionally long distances."
},{EPerkType.ePerk_Poison,"Poison enemies wounded with melee attacks."
},{EPerkType.ePerk_Leap,"Allows vertical leaps onto elevated surfaces during movement."
},{EPerkType.ePerk_Plague,"Spit poison at long range, causing a noxious cloud to remain briefly on the battlefield."
},{EPerkType.ePerk_RapidFire,"Take two shots against a single target in quick succession. Each shot carries a -<XGAbility:RapidFireAimPenalty/> penalty to Aim."
},{EPerkType.ePerk_CloseCombatSpecialist,"Confers a reaction shot against any enemy who closes to within 4 tiles. Does not require overwatch."
},{EPerkType.ePerk_WillToSurvive,"Reduces all normal damage taken by <XGAbility:WillToSurviveProtection/> if in cover and not flanked."
},{EPerkType.ePerk_KillerInstinct,"Activating Run and Gun now also grants +<XGAbility:KillerInstinctCritDamageBonus/>% critical damage for the rest of the turn."
},{EPerkType.ePerk_Resilience,"Confers immunity to critical hits."
},{EPerkType.ePerk_FireRocket,"Fire a rocket using an equipped launcher. This ability cannot be used after moving, nor more than once per mission."
},{EPerkType.ePerk_TracerBeams,"Shooting at or suppressing enemies also confers +<XGAbility:TracerBeamsAimBonus/> Aim to any allies' attacks on those enemies."
},{EPerkType.ePerk_HEATAmmo,"Confers +<XGAbility:HEATAmmoDamageBonusVsRobots/>% damage against robotic enemies."
},{EPerkType.ePerk_FocusedSuppression,"Fire a barrage that pins down a target, granting reaction fire against it and imposing a <XGAbility:CalcSuppression/> penalty to Aim."
},{EPerkType.ePerk_ShredderRocket,"Fire a rocket that causes all enemies hit to take +<XGAbility:ShredderRocketDamageEffect/>% damage from all sources for the next <XGAbility:ShredderRocketDamageEffectDuration/> turns. The rocket's blast is weaker than a standard rocket's."
},{EPerkType.ePerk_RapidReaction,"Confers a second reaction shot, if on Overwatch and the first reaction shot is a hit."
},{EPerkType.ePerk_Grenadier,"Allows <XGAbility:GrenadierCharges/> grenades in a single inventory slot. Frag, Alien, and Needle Grenades receive a +<XGAbility:GrenadierDmgBonus/> damage bonus."
},{EPerkType.ePerk_DangerZone,"Increases area of effect on Suppression and all rocket attacks by <XGAbility:DangerZoneAOEIncrease/> tiles."
},{EPerkType.ePerk_BulletSwarm,"Standard shots with the primary weapon no longer end the turn, if taken as the first action."
},{EPerkType.ePerk_ExtraConditioning,"Confers bonus health based on which type of armor is equipped. Heavier armor increases the bonus."
},{EPerkType.ePerk_SmokeBomb,"Deploy a smoke grenade once per mission. The smoke confers +<XGAbility:SmokeBombDefenseBonus/> defense to all units, not just allies, and lasts through the enemy turn."
},{EPerkType.ePerk_CoveringFire,"Allows reaction shots to trigger on enemy attacks, not just movement."
},{EPerkType.ePerk_FieldMedic,"Allows medikits to be used <XGAbility:FieldMedicCharges/> times per battle instead of once."
},{EPerkType.ePerk_CombatDrugs,"Smoke Grenades now contain powerful stimulants that grant +<XGAbility:CombatDrugsWillBonus/> Will and +<XGAbility:CombatDrugsCritBonus/>% critical chance for all units in the cloud."
},{EPerkType.ePerk_DenseSmoke,"Smoke Grenades have increased area of effect and further increase units' Defense by <XGAbility:DenseSmokeDefenseBonus/>."
},{EPerkType.ePerk_DeepPockets,"All limited-use items in your inventory receive one extra use."
},{EPerkType.ePerk_Revive,"Allows Medikits to revive critically wounded soldiers at <XGAbility:ReviveHealthPercent/>% of maximum health, instead of just stabilizing them."
},{EPerkType.ePerk_Savior,"Medikits restore <XGAbility:SaviorMedikitHealIncrease/> more health per use."
},{EPerkType.ePerk_MindFray,"Use psi abilities in combat to unlock further psi training. Causes the target to lose grip on reality, inflicting penalties to Aim, Will, and mobility, and doing <XGAbility:MindfrayDamage/> base damage. Robotic units are immune. Lasts <XGAbility:MindfrayDuration/> turns. <XGAbility:MindfrayCooldown/> turn cooldown."
},{EPerkType.ePerk_TelekineticField,"Create an immobile telekinetic field that lasts through the enemy turn. The field distorts and deflects incoming attacks, granting +<XGAbility:TKFieldDefenseBonus/> Defense to both allies and enemies within the field. <XGAbility:TelekineticFieldCooldown/> turn cooldown."
},{EPerkType.ePerk_PsiInspiration,"Removes Mindfray and panic from all allies within 3 tiles, and strengthen their Will by +<XGAbility:PsiInspirationWillBonus/> for <XGAbility:PsiInspirationDuration/> turns. <XGAbility:PsiInspirationCooldown/> turn cooldown."
},{EPerkType.ePerk_MindControl,"Very difficult psi technique that, if successful, grants control of the target for <XGAbility:MindControlDuration/> turns. Robotic enemies are immune. <XGAbility:MindControlCooldown/> turn cooldown."
},{EPerkType.ePerk_PsiPanic,"Cause target to panic on its following turn, if the target's Will is overcome. Robotic enemies are immune. <XGAbility:PsiPanicCooldown/> turn cooldown."
},{EPerkType.ePerk_Rift,"Devastate an area with a storm of psi energy. The rift does more damage against targets with low Will, and reduced damage against targets with high Will. <XGAbility:RiftCooldown/> turn cooldown."
},{EPerkType.ePerk_GeneMod_SecondHeart,"Causes soldiers to bleed out instead of dying the first time they go to zero health in a mission. The bleed-out timer is extended by <XGAbility:SecondaryHeartBleedTimerBonus/> turns. Prevents loss of Will from critical wounds."
},{EPerkType.ePerk_GeneMod_Adrenal,"Overloads the soldier's adrenal glands; when a kill is confirmed, the soldier emits pheromones that grant offensive benefits to all nearby squadmates. Cannot occur more than once every 5 turns."
},{EPerkType.ePerk_GeneMod_BrainDamping,"Confers +<XGAbility:GeneModBrainDampingWill/> Will when defending against psi attacks, and immunity to panic. If the soldier is Mind Controlled, the control is cancelled, and the soldier is stunned for 1 turn instead."
},{EPerkType.ePerk_GeneMod_BrainFeedback,"Causes damage to psi attackers and puts all of their psi attacks on cooldown. Does not reduce the attacks' chance of success."
},{EPerkType.ePerk_GeneMod_Pupils,"Confers +<XGAbility:GeneModPupilsBonus/> Aim on any shot after a miss."
},{EPerkType.ePerk_GeneMod_DepthPerception,"Height Advantage confers an additional +<XGAbility:GeneModDepthPerceptionAim/> Aim and +<XGAbility:GeneModDepthPerceptionCrit/>% critical chance."
},{EPerkType.ePerk_GeneMod_BioelectricSkin,"The soldier projects an electric field from his or her skin, revealing but not alerting nearby enemies, and is immune to strangulation."
},{EPerkType.ePerk_GeneMod_BoneMarrow,"Wound recovery time is reduced by 66% (stacks with Rapid Recovery). Soldier regenerates 2 HP per turn up to the HP max without armor."
},{EPerkType.ePerk_GeneMod_MuscleFiber,"Confers superhuman leg strength, enabling the soldier to reach high positions without the need for ladders or other climbing aids."
},{EPerkType.ePerk_GeneMod_MimeticSkin,"Confers the ability to change skin pattern to match cover. When the soldier moves to high cover, enemies without special capabilities will not target the soldier. Does not work if any enemies have line of sight to the soldier's starting position. Leaving cover or firing will break this concealment."
},{EPerkType.ePerk_PlasmaBarrage,"Twin-linked plasma mini-cannons allow the Mechtoid two shots in the same turn."
},{EPerkType.ePerk_SeekerStealth,"The Seeker becomes invisible to enemies. It can use its tentacles to attack from stealth mode, but must deactivate stealth mode to use its ranged attack."
},{EPerkType.ePerk_AutoThreatAssessment,"Confers +<XGAbility:AutoThreatAssessBonus/> Defense when in Overwatch."
},{EPerkType.ePerk_AdvancedFireControl,"Shots from Overwatch no longer suffer any Aim penalty."
},{EPerkType.ePerk_XenobiologyOverlays,"Confers 2 bonus damage against targets that have been autopsied."
},{EPerkType.ePerk_Overdrive,"Firing the MEC's primary weapon as the first action no longer ends the turn."
},{EPerkType.ePerk_PlatformStability,"Any shots taken without moving have +<XGAbility:PlatformStabilityAim/> Aim and +<XGAbility:PlatformStabilityCrit/>% critical chance."
},{EPerkType.ePerk_ShockAbsorbentArmor,"Damage received from enemies within <XGAbility:ShockAbsorbentArmorTiles/> tiles is reduced by <XGAbility:ShockAbsorbentArmorDmgReduction/>%."
},{EPerkType.ePerk_ExpandedStorage,"Allows additional uses of Restorative Mist, Grenade Launcher, and Proximity Mine Launcher in each mission, and increases primary weapon base ammo by 50%."
},{EPerkType.ePerk_RepairServos,"Confers <XGAbility:RepairServosRegen/> health recovery at the start of each turn. A total of <XGAbility:RepairServosMax/> health can be regenerated per battle."
},{EPerkType.ePerk_AbsorptionFields,"Any hit that does more damage than <XGAbility:AbsorptionFieldsDmgLimit/>% of the MEC's maximum health is reduced to that number."
},{EPerkType.ePerk_JetbootModule,"When activated, confers the ability to jump to normally inaccessible heights for the rest of the turn."
},{EPerkType.ePerk_OneForAll,"When activated, the MEC becomes a high cover element. Moving or using an arm-based weapon will return the MEC to standard posture."
},{EPerkType.ePerk_DamageControl,"When the MEC takes damage, all further damage will be reduced by <XGAbility:DamageControlDmg/> for the next <XGAbility:DamageControlTurns/> turns."
},{EPerkType.ePerk_ReactiveTargetingSensors,"MEC gets a free shot back at the first enemy who attacks the MEC each turn, provided there's enough ammo to do so."
},{EPerkType.ePerk_BodyShield,"The nearest visible enemy suffers -<XGAbility:BodyShieldDefense/> Aim and cannot critically hit this unit."
},{EPerkType.ePerk_DistortionField,"Nearby allies in cover receive +<XGAbility:DistortionFieldDefense/> Defense."
},{EPerkType.ePerk_GeneMod_AdrenalineSurge,"Confers +<XGAbility:AdrenalineSurgeAimBonus/> Aim and +<XGAbility:AdrenalineSurgeCritBonus/>% critical chance."
},{EPerkType.ePerk_GeneMod_IronSkin,"All damage taken is reduced by <XGAbility:IronSkinDamage/>%."
},{EPerkType.ePerk_GeneMod_RegenPheromones,"This unit and all nearby allies are healed for <XGAbility:RegenPheromoneRegen/> health each turn."
},{EPerkType.ePerk_Barrage,"Area of effect attack that destroys most cover and hits all eligible targets for <XGAbility:CollateralDamageReduction/>% damage. This attack cannot cause critical hits."
},{EPerkType.ePerk_CovertPockets,"Covert operatives carry one extra grenade of the same type they have equipped in their item slot."
},{EPerkType.ePerk_CovertHacker,"Covert operatives can disable EXALT communications arrays, sowing confusion and disorder among EXALT's forces."
},{EPerkType.ePerk_Medal_UrbanA,"+<XGAbility:UrbanDefense/> Defense when in cover."
},{EPerkType.ePerk_Medal_UrbanB,"+<XGAbility:UrbanAim/> Aim against enemies in full cover."
},{EPerkType.ePerk_Medal_DefenderA,"Never panic as a result of allies getting wounded or killed."
},{EPerkType.ePerk_Medal_DefenderB,"Medikits and Restorative Mist heal <XGAbility:DefenderMedikit/> HP more when used on the soldier."
},{EPerkType.ePerk_Medal_InternationalA,"+<XGAbility:InternationalWill/> Will per different nationality in the squad."
},{EPerkType.ePerk_Medal_InternationalB,"+<XGAbility:InternationalAim/> Aim per continent bonus XCOM has earned."
},{EPerkType.ePerk_Medal_CouncilA,"+<XGAbility:CouncilMedalStatBonus/> Aim and Will for each mission completed with no soldier deaths, up to a maximum of +<XGAbility:CouncilMedalStatMax/>."
},{EPerkType.ePerk_Medal_CouncilB,"+<XGAbility:CouncilMedalFightBonus/> Aim and Critical Chance if not within <XGAbility:CouncilMedalFightTiles/> tiles of an allied unit."
},{EPerkType.ePerk_Medal_TerraA,"Entire squad receives +<XGAbility:TerraWill/> Will and +<XGAbility:TerraDefense/> Defense in battle. Robotic units receive only the Defense bonus."
},{EPerkType.ePerk_Medal_TerraB,"All soldiers in the squad at Lieutenant rank or lower gain +25% XP for completing missions."
},{EPerkType.ePerk_Foundry_SentinelDrone,"Integrated circuitry will repair the SHIV for <XGAbility:SentinelHP/> HP/turn and provides automated reaction fire against enemies at close engagement range."
},{EPerkType.ePerk_OTS_Leader_TheLeader,"This squad leader substitutes his or her Will for that of all nearby lower-Will squadmates."
},{EPerkType.ePerk_SeekerStrangle,"Strangle can be used against adjacent humans unprotected by strangle-resistant armor, items, or abilities."
},{EPerkType.ePerk_ReinforcedArmor,"All damage taken is reduced by <XGAbility:ReinforcedArmorDamage/>%."
},{EPerkType.ePerk_MindMerge_Mechtoid,"This unit generates a psionic force shield when targeted by an ally's Mind Merge ability."
},{EPerkType.ePerk_Foundry_SHIVSuppression,"Reduce the target's Aim by <XGAbility:CalcSuppression/> and take a free shot if the target moves."
},{EPerkType.ePerk_Foundry_MECCloseCombat,"Kinetic Strike no longer ends the MEC's turn, although it still costs an action. It also deals <XGAbility:CloseCombatKineticDamage/>% more damage."
}
        }; 
        public static readonly Dictionary<int, string> ItemNames = new Dictionary<int, string>()
    {
        //{2,"Pistol"},
        //{3,"Assault Rifle"},
   //{ 4,"Shotgun"},
    //{5,"LMG"},
   // {6,"Sniper Rifle"},
   // {7,"Rocket Launcher"},
    {8,"Laser Pistol"},
    {9,"Laser Rifle"},
    {10,"Scatter Laser"},
    {11,"Heavy Laser"},
    {12,"Laser Sniper Rifle"},
    {13,"Plasma Pistol"},
    {14,"Light Plasma Rifle"},
    {15,"Plasma Rifle"},
    {16,"Alloy Cannon"},
    {17,"Heavy Plasma"},
    {18,"Plasma Sniper Rifle"},
    {19,"Blaster Launcher"},
    //{20,"Mechtoid Plasma Mini-Cannon"},
    //{21,"Seeker Plasma Pistol"},
    {22,"Kinetic Strike Module"},
    {23,"Flamethrower"},
    {24,"Grenade Launcher"},
    {25,"Restorative Mist"},
    {26,"Electro Pulse"},
    {27,"Proximity Mine Launcher"},
  // {28,"Minigun"},
    {29,"Railgun"},
    {30,"Particle Cannon"},
    //{32,"Sectopod Arm"},
    //{33,"Sectopod Turret"},
   // {34,"Sectopod Heat Ray"},
    //{35,"Chryssalid Claw"},
   // {36,"Drone Beam"},
    //{37,"Psi Amp"},
    //{38,"Grapple"},
    //{39,"Cyberdisc Cannon"},
    //{41,"Sectoid Plasma Pistol"},
    //{42,"Thin Man Plasma Rifle"},
    //{43,"Floater Plasma Rifle"},
    //{44,"Muton Light Plasma Rifle"},
    //{45,"Muton Plasma Rifle"},
    //{46,"Floater Heavy Plasma Rifle"},
    //{47,"Muton Heavy Plasma Rifle"},
    //{49,"Zombie Fist"},
    //{50,"Psi Locus"},
   // {51,"Muton Blade"},
    //{52,"Outsider Light Plasma Rifle"},
    //{53,"No Weapon"},
   // {54,"Poison Spit"},
    //{55,"Sectopod Cluster Bomb"},
    //{56,"Seeker Tentacles"},
    //{59,"Body Armor"},
    {60,"Carapace Armor"},
    {61,"Skeleton Suit"},
    {62,"Titan Armor"},
    {63,"Archangel Armor"},
    {64,"Ghost Armor"},
    {65,"Psi Armor"},
    //{66,"Covert Ops Armor"},
   // {69,"Medikit"},
    {70,"Combat Stims"},
    {71,"Mind Shield"},
    {72,"Chitin Plating"},
    {73,"Arc Thrower"},
    {74,"S.C.O.P.E."},
    {75,"Nano-fiber Vest"},
    {76,"Respirator Implant"},
    {78,"Reaper Rounds"},
   // {81,"Frag Grenade"},
   // {82,"Smoke Grenade"},
    {83,"Flashbang Grenade"},
    {84,"Alien Grenade"},
    {85,"Ghost Grenade"},
    {86,"Gas Grenade"},
    {87,"Needle Grenade"},
    {88,"Mimic Beacon"},
   // {90,"Sectoid Grenade"},
   // {91,"Floater Grenade"},
    //{92,"Muton Grenade"},
   // {93,"Cyberdisc Grenade"},
   // {94,"Thin Man Grenade"},
    {96,"Psi Grenade"},
    {97,"Battle Scanner"},
    {100,"S.H.I.V."},
    {101,"Alloy S.H.I.V."},
    {102,"Hover S.H.I.V."},
   // {103,"Interceptor"},
   // {104,"Firestorm"},
   // {105,"Skyranger"},
    {106,"Satellite"},
    {109,"Minigun"},
    {110,"Sentry"},
    {111,"Laser Cannon"},
    {112,"Plasma Cannon"},
   // {113,"Tread Deck"},
   // {114,"Heavy Alloy Deck"},
   // {115,"Hover Deck"},
    {117,"Phoenix Cannon"},
    //{118,"Avalanche Missiles"},
    {119,"Laser Cannon"},
    {120,"Plasma Cannon"},
    {121,"EMP Cannon"},
    {122,"Fusion Lance"},
    {125,"Defense Matrix (Dodge)"},
    {126,"UFO Tracking (Boost)"},
    {127,"Uplink Targeting (Aim)"},
    //{131,"Civilian Corpse"},
    //{132,"S.H.I.V. Wreck"},
    //{133,"Soldier Corpse"},
    {134,"Sectoid Corpse"},
    {135,"Sectoid Commander Corpse"},
    {136,"Floater Corpse"},
    {137,"Heavy Floater Corpse"},
    {138,"Thin Man Corpse"},
    {139,"Muton Corpse"},
    {140,"Muton Elite Corpse"},
    {141,"Berserker Corpse"},
    {142,"Cyberdisc Wreck"},
    {143,"Ethereal Corpse"},
    {144,"Chryssalid Corpse"},
    //{145,"Zombie Corpse"},
    {146,"Sectopod Wreck"},
    {147,"Drone Wreck"},
    {150,"Sectoid Captive"},
    {151,"Sectoid Commander Captive"},
    {152,"Floater Captive"},
    {153,"Heavy Floater Captive"},
    {154,"Thin Man Captive"},
    {155,"Muton Captive"},
    {156,"Muton Elite Captive"},
    {157,"Berserker Captive"},
    {158,"Ethereal Captive"},
    {161,"Elerium"},
    {162,"Alien Alloys"},
    {163,"Weapon Fragment"},
    {164,"Meld"},
    {165,"Alien Entertainment"},
    {166,"Alien Food"},
    {167,"Alien Stasis Tank"},
    {168,"UFO Flight Computer"},
    {169,"Alien Surgery"},
    {170,"UFO Power Source"},
    {171,"Hyperwave Beacon"},
    {172,"Alien Entertainment (Damaged)"},
    {173,"Alien Food (Damaged)"},
    {174,"Alien Stasis Tank (Damaged)"},
    {175,"UFO Flight Computer (Damaged)"},
    {176,"Alien Surgery (Damaged)"},
    {177,"UFO Power Source (Damaged)"},
    //{178,"Hyperwave Beacon (Damaged)"},
    {179,"Fusion Core"},
    {180,"Ethereal Device"},
    {181,"EXALT Intelligence"},
    {183,"Outsider Shard"},
    {184,"Skeleton Key"},
    //{185,"Sectopod Chest Cannon"},
    {187,"Mechtoid Core"},
    {188,"Seeker Wreck"},
    //{192,"Base Augments"},
    {193,"MEC-1 Warden"},
    {194,"MEC-2 Sentinel"},
    {195,"MEC-3 Paladin"},
    {196,"Mk1-Kinetic"},
    {197,"Mk1-Flamethrower"},
    {198,"Mk2-Kinetic-Grenade"},
    {199,"Mk2-Kinetic-Mist"},
    {200,"Mk2-Flame-Grenade"},
    {201,"Mk2-Flame-Mist"},
    {202,"Mk3-Kinetic-Grenade-Electro"},
    {203,"Mk3-Kinetic-Grenade-Mine"},
    {204,"Mk3-Kinetic-Mist-Electro"},
    {205,"Mk3-Kinetic-Mist-Mine"},
    {206,"Mk3-Flame-Grenade-Electro"},
    {207,"Mk3-Flame-Grenade-Mine"},
    {208,"Mk3-Flame-Mist-Electro"},
    {209,"Mk3-Flame-Mist-Mine"},
    {212,"EXALT Assault Rifle"},
    {213,"EXALT Sniper Rifle"},
    {214,"EXALT LMG"},
    {215,"EXALT Laser Assault Rifle"},
    {216,"EXALT Laser Sniper Rifle"},
    {217,"EXALT Heavy Laser"},
    {218,"EXALT Rocket Launcher"},
    {222,"Recovered Art"},
    {223,"EXALT Artifact"},
    {224,"EXALT Technology"},
    };
    }
}