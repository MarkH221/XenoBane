using Isolib.IOPackage;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;

namespace XCOMSE.XGSoldier
{
    public static class Utilities
    {
        public static string ReadStringFromFile(ref RWStream file)
        {
            if (file.Length - file.Position < 4) return "";
            int strLength = file.ReadInt32();
            return strLength == -1 || strLength == 0 ? "" : file.ReadString(StringType.Ascii, strLength).TrimEnd(new[] { '\0' });
        }

        public static void ReadProperty(ref RWStream file, IDeserializable obj)
        {
            string propName = ReadStringFromFile(ref file);
            file.Position += 4;
            string propType = ReadStringFromFile(ref file);
            file.Position += 4;
            FieldInfo prop = obj.GetType().GetField(propName, BindingFlags.Public | BindingFlags.Instance);
            if (prop == null) return;
            switch (propType)
            {
                case "StructProperty":

                    object instanceObj = Activator.CreateInstance(prop.GetValue(obj).GetType());
                    MethodInfo parse = instanceObj.GetType().GetMethod("deSerialize");
                    parse.Invoke(instanceObj, new object[] { file });
                    prop.SetValue(obj, instanceObj);
                    break;

                case "ArrayProperty":
                    object instanceArray = Activator.CreateInstance(prop.GetValue(obj).GetType());
                    MethodInfo arrayparse = instanceArray.GetType().GetMethod("deSerialize");
                    arrayparse.Invoke(instanceArray, new object[] { file });
                    prop.SetValue(obj, instanceArray);
                    break;

                case "BoolProperty":
                    file.Position += 8; //Skip two unkown int32s
                    bool value = readBoolFromFile(ref file);
                    prop.SetValue(obj, value);
                    break;

                case "ByteProperty":
                    file.Position += 8;
                    ReadStringFromFile(ref file);
                    file.Position += 4;
                    string name = ReadStringFromFile(ref file);
                    int eIndex = file.ReadInt32();
                    object enumValue = Enum.Parse(prop.GetValue(obj).GetType(), name);
                    prop.SetValue(obj, enumValue);
                    break;

                case "FloatProperty":
                    int floatSize = file.ReadInt32();
                    file.Position += 4;
                    switch (floatSize)
                    {
                        case 4:
                            float single = readSingleFloatFromFile(ref file);
                            prop.SetValue(obj, single);
                            break;

                        case 8:
                            double dbl = readDoubleFloatFromFile(ref file);
                            prop.SetValue(obj, dbl);
                            break;

                        default:
                            throw new Exception("WTF that's not a floater");
                    }

                    break;

                case "IntProperty":
                    file.Position += 4;
                    int index = file.ReadInt32();
                    int intvalue = file.ReadInt32();
                    if (prop.GetValue(obj).GetType().IsArray)
                    {
                        var arrayVal = (int[])prop.GetValue(obj);
                        arrayVal[index] = intvalue;
                        prop.SetValue(obj, arrayVal);
                    }
                    else
                    {
                        prop.SetValue(obj, intvalue);
                    }
                    break;

                case "StrProperty":
                    file.Position += 8;
                    string strValue = ReadStringFromFile(ref file);
                    prop.SetValue(obj, strValue);
                    break;

                case "":
                    file.Position += 4;
                    break;
            }
        }

        public static bool readBoolFromFile(ref RWStream file)
        {
            return Convert.ToBoolean(file.ReadInt8());
        }

        public static float readSingleFloatFromFile(ref RWStream file)
        {
            return file.ReadSingle();
        }

        public static double readDoubleFloatFromFile(ref RWStream file)
        {
            return file.ReadDouble();
        }
    }

    public interface IDeserializable
    {
        void deSerialize(RWStream file);
    }

    public class TCharacter : IDeserializable
    {
        public int[] aAbilities = new int[Enum.GetNames(typeof(Enums.EAbility)).Length];
        public int[] aProperties = new int[Enum.GetNames(typeof(Enums.ECharacterProperty)).Length];
        public int[] aStats = new int[Enum.GetNames(typeof(Enums.ECharacterStat)).Length];
        public int[] aTraversals = new int[Enum.GetNames(typeof(Enums.ETraversalType)).Length];
        public int[] aUpgrades = new int[Enum.GetNames(typeof(Enums.EPerkType)).Length];
        public bool bHasPsiGift;
        public Enums.ESoldierClass eClass;
        public float fBioElectricParticleScale;
        public int iType;
        public TInventory kInventory = new TInventory();
        public string strName;

        public void deSerialize(RWStream file)
        {
            int size = file.ReadInt32();
            var bData = new byte[size]; file.Position += 4;
            Utilities.ReadStringFromFile(ref file);
            file.Position += 4;
            bData = file.ReadBytes(size);
            var data = new RWStream(bData);
            IDeserializable Iself = this;
            while (data.Position < data.Length)
            {
                Utilities.ReadProperty(ref data, Iself);
            }
        }

        public Dictionary<Enums.EPerkType, bool> GetPerks()
        {
            var perks = new Dictionary<Enums.EPerkType, bool>();
            for (int i = 0; i < Enum.GetNames(typeof(Enums.EPerkType)).Length; i++)
            {
                if (aUpgrades[i] != 0)
                {
                    var value = (Enums.EPerkType)i;
                    bool item = aUpgrades[i] == 2;
                    perks.Add(value, item);
                }
            }
            return perks;
        }
    }

    public class TClass : IDeserializable
    {
        public int[] aAbilities = new int[16];
        public int[] aAbilityUnlocks = new int[16];
        public int eTemplate;
        public Enums.ESoldierClass eType;
        public Enums.EWeaponProperty eWeaponType;
        public string strName;

        public void deSerialize(RWStream file)
        {
            int size = file.ReadInt32();
            var bData = new byte[size];
            file.Position += 4;
            Utilities.ReadStringFromFile(ref file);
            file.Position += 4;
            bData = file.ReadBytes(size);
            var data = new RWStream(bData);
            IDeserializable Iself = this;
            while (data.Position < data.Length)
            {
                Utilities.ReadProperty(ref data, Iself);
            }
        }
    }

    public class TAppearance : IDeserializable
    {
        public int iArmorDeco;
        public int iArmorSkin;
        public int iArmorTint;
        public int iAttitude;
        public int iBody;
        public int iBodyMaterial;
        public int iEyeColor;
        public int iFacialHair;
        public int iFlag;
        public int iGender;
        public int iHairColor;
        public int iHaircut;
        public int iHead;
        public int iLanguage;
        public int iRace;
        public int iSkinColor;
        public int iVoice;

        public void deSerialize(RWStream file)
        {
            int size = file.ReadInt32();
            var bData = new byte[size];
            file.Position += 4;
            Utilities.ReadStringFromFile(ref file);
            file.Position += 4; bData = file.ReadBytes(size);
            var data = new RWStream(bData);
            IDeserializable Iself = this;
            while (data.Position < data.Length)
            {
                Utilities.ReadProperty(ref data, Iself);
            }
        }
    }

    public class TSoldier : IDeserializable
    {
        public bool bBlueshirt;
        public int iCountry;
        public int iID;
        public int iNumKills;
        public int iPsiRank;
        public int iPsiXP;
        public int iRank;
        public int iXP;
        public TAppearance kAppearance = new TAppearance();
        public TClass kClass = new TClass();
        public string strFirstName;
        public string strLastName;
        public string strNickName;

        public void deSerialize(RWStream file)
        {
            var size = file.ReadInt32();
            var bData = new byte[size]; file.Position += 4;
            Utilities.ReadStringFromFile(ref file); file.Position += 4;
            bData = file.ReadBytes(size); ;
            var data = new RWStream(bData);
            IDeserializable Iself = this;
            while (data.Position < data.Length)
            {
                Utilities.ReadProperty(ref data, Iself);
            }
        }
    }

    public class UEArray<T> : List<T>, IDeserializable
    {
        public void deSerialize(RWStream file)
        {
            int size = file.ReadInt32(); file.Position += 4 + size;
        }
    }

    public class TInventory : IDeserializable
    {
        private int[] arrCustomItems = new int[16];
        private int[] arrLargeItems = new int[16];
        private int[] arrSmallItems = new int[16];
        private int iArmor;
        private int iNumCustomItems;
        private int iNumLargeItems;
        private int iNumSmallItems;
        private int iPistol;

        public void deSerialize(RWStream file)
        {
            int size = file.ReadInt32(); file.Position += 4;
            Utilities.ReadStringFromFile(ref file); file.Position += 4 + size;
        }
    }

    public class XGStrategySoldier : IDeserializable
    {
        public bool bForcePsiGift;
        public int[] m_aStatModifiers = new int[Enum.GetNames(typeof(Enums.ECharacterStat)).Length];
        public int[] m_arrMedals = new int[Enum.GetNames(typeof(Enums.EMedalType)).Length];
        public UEArray<Enums.EPerkType> m_arrRandomPerks = new UEArray<Enums.EPerkType>();
        public bool m_bAllIn;
        public bool m_bBlueShirt;
        public bool m_bMIA;
        public bool m_bPsiTested;
        public Enums.EEasterEggCharacter m_eEasterEggChar;
        public Enums.ESoldierStatus m_eStatus;
        public int m_iEnergy;
        public int m_iHQLocation;
        public int m_iNumMissions;
        public int m_iTurnsOut;
        public TInventory m_kInjuredLoadout = new TInventory();
        public TCharacter m_kChar = new TCharacter();
        public TSoldier m_kSoldier = new TSoldier();
        public string m_strCauseOfDeath;
        public string m_strKIADate;
        public string m_strKIAReport;

        public int? Aim
        {
            get { return m_kChar.aStats[(int)Enums.ECharacterStat.eStat_Offense]; }
            set { m_kChar.aStats[(int)Enums.ECharacterStat.eStat_Offense] = (int)value; }
        }

        public int HP
        {
            get { return m_kChar.aStats[(int)Enums.ECharacterStat.eStat_HP]; }
            set { m_kChar.aStats[(int)Enums.ECharacterStat.eStat_HP] = value; }
        }

        public int? Defense
        {
            get { return m_kChar.aStats[(int)Enums.ECharacterStat.eStat_Defense]; }
            set { m_kChar.aStats[(int)Enums.ECharacterStat.eStat_Defense] = (int)value; }
        }

        public int? Will
        {
            get { return m_kChar.aStats[(int)Enums.ECharacterStat.eStat_Will]; }
            set { m_kChar.aStats[(int)Enums.ECharacterStat.eStat_Will] = (int)value; }
        }

        public bool PsiGift
        {
            get { return m_kChar.bHasPsiGift; }
            set { m_kChar.bHasPsiGift = value; }
        }

        public bool PsiTest
        {
            get { return m_bPsiTested; }
            set { m_bPsiTested = value; }
        }

        public int Class
        {
            get { return (int)m_kSoldier.kClass.eType; }
            set { m_kSoldier.kClass.eType = (Enums.ESoldierClass)value; }
        }

        public int Rank
        {
            get { return m_kSoldier.iRank; }
            set { m_kSoldier.iRank = value; }
        }

        public int XP
        {
            get { return m_kSoldier.iXP; }
            set { m_kSoldier.iXP = value; }
        }

        public int PsiRank
        {
            get { return m_kSoldier.iPsiRank; }
            set { m_kSoldier.iPsiRank = value; }
        }

        public int PsiXP
        {
            get { return m_kSoldier.iPsiXP; }
            set { m_kSoldier.iPsiXP = value; }
        }

        public IEnumerable<ListBoxItem> GetPerks()
        {
            var list = new List<ListBoxItem>();
            for (int index = 0; index < m_kChar.aUpgrades.Length; index++)
            {
                int a = m_kChar.aUpgrades[index];
                string b = (Enum.GetName(typeof(Enums.EPerkType), index)).Replace("ePerk_", "").Replace("_", " ");
                if (b.Contains("DEPRECATED") || b.Contains("None") || b.Contains("GermanMode") || b.Contains("MAX")) continue;
                String tip;
                Enums.PerkTips.TryGetValue((Enums.EPerkType)(index), out tip);
                ListBoxItem c = new ListBoxItem() { Tag = index, Content = b, ToolTip = tip };
                if (a != 0) list.Add(c);
            }
            return list;//.OrderBy(o=>o.Content);
        }

        public IEnumerable<ListBoxItem> GetUnusedPerks()
        {
            var list = new List<ListBoxItem>();
            for (int index = 0; index < m_kChar.aUpgrades.Length; index++)
            {
                int a = m_kChar.aUpgrades[index];
                string b = (Enum.GetName(typeof(Enums.EPerkType), index)).Replace("ePerk_", "").Replace("_", " ");
                if (b.Contains("DEPRECATED") || b.Contains("None") || b.Contains("GermanMode") || b.Contains("MAX")) continue;
                String tip;
                Enums.PerkTips.TryGetValue((Enums.EPerkType)index, out tip);
                var c = new ListBoxItem() { Tag = index, Content = b, ToolTip = tip };
                if (a == 0) list.Add(c);
            }
            return list;//.OrderBy(o => o.Content);
        }

        public override string ToString()
        {
            return String.Format("{0}{1} {2}", m_kSoldier.strFirstName, (m_kSoldier.strNickName == "") ? String.Empty : " \"" + m_kSoldier.strLastName + "\"", m_kSoldier.strLastName);
        }

        public void deSerialize(RWStream file)
        {
            int size = file.ReadInt32();
            var bData = file.ReadBytes(size);
            RWStream data = new RWStream(bData);
            IDeserializable Iself = this;
            while (data.Position < data.Length)
            {
                Utilities.ReadProperty(ref data, Iself);
            }
        }

        public string GetStatus()
        {
            return Enum.GetName(typeof(Enums.ESoldierStatus), m_eStatus);
        }

        public int Status { get { return (int)m_eStatus; } set { m_eStatus = (Enums.ESoldierStatus)value; } }
    }
}