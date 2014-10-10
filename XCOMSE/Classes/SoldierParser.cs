using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using XCOMSE.Enums;

namespace Xcom2012SoldierViewer
{
    public interface IDeserializable
    {
        void deSerialize(Stream file);
    }

    public class TCharacter : IDeserializable
    {
        public string strName;
        public int iType;
        public TInventory kInventory = new TInventory();
        public int[] aUpgrades = new int[Enum.GetNames(typeof(EPerkType)).Length];
        public int[] aAbilities = new int[Enum.GetNames(typeof(EAbility)).Length];
        public int[] aProperties = new int[Enum.GetNames(typeof(ECharacterProperty)).Length];
        public int[] aStats = new int[Enum.GetNames(typeof(ECharacterStat)).Length];
        public int[] aTraversals = new int[Enum.GetNames(typeof(ETraversalType)).Length];
        public ESoldierClass eClass;
        public bool bHasPsiGift;
        public float fBioElectricParticleScale;

        public void deSerialize(Stream file)
        {
            int size = Functions.readInt32FromFile(file);
            byte[] bData = new byte[size];
            file.Seek(4, SeekOrigin.Current);
            Functions.readStringFromFile(file);
            file.Seek(4, SeekOrigin.Current);
            file.Read(bData, 0, size);
            MemoryStream data = new MemoryStream(bData);
            IDeserializable Iself = this;
            while (data.Position < data.Length)
            {
                Functions.readProperty(data, Iself);
            }
        }

        public Dictionary<EPerkType, bool> getPerks()
        {
            Dictionary<EPerkType, bool> perks = new Dictionary<EPerkType, bool>();
            for (int i = 0; i < Enum.GetNames(typeof(EPerkType)).Length; i++)
            {
                if (aUpgrades[i] != 0)
                {
                    EPerkType value = (EPerkType)i;
                    bool item = aUpgrades[i] == 2;
                    perks.Add(value, item);
                }
            }
            return perks;
        }
    }

    public class TClass : IDeserializable
    {
        public string strName;
        public ESoldierClass eType;
        public int eTemplate;
        public EWeaponProperty eWeaponType;
        public int[] aAbilities = new int[16];
        public int[] aAbilityUnlocks = new int[16];

        public void deSerialize(Stream file)
        {
            int size = Functions.readInt32FromFile(file);
            byte[] bData = new byte[size];
            file.Seek(4, SeekOrigin.Current);
            Functions.readStringFromFile(file);
            file.Seek(4, SeekOrigin.Current);
            file.Read(bData, 0, size);
            MemoryStream data = new MemoryStream(bData);
            IDeserializable Iself = this;
            while (data.Position < data.Length)
            {
                Functions.readProperty(data, Iself);
            }
        }
    }

    public class TAppearance : IDeserializable
    {
        public int iHead;
        public int iGender;
        public int iRace;
        public int iHaircut;
        public int iHairColor;
        public int iFacialHair;
        public int iBody;
        public int iBodyMaterial;
        public int iSkinColor;
        public int iEyeColor;
        public int iFlag;
        public int iArmorSkin;
        public int iVoice;
        public int iLanguage;
        public int iAttitude;
        public int iArmorDeco;
        public int iArmorTint;

        public void deSerialize(Stream file)
        {
            int size = Functions.readInt32FromFile(file);
            byte[] bData = new byte[size];
            file.Seek(4, SeekOrigin.Current);
            Functions.readStringFromFile(file);
            file.Seek(4, SeekOrigin.Current);
            file.Read(bData, 0, size);
            MemoryStream data = new MemoryStream(bData);
            IDeserializable Iself = this;
            while (data.Position < data.Length)
            {
                Functions.readProperty(data, Iself);
            }
        }
    }

    public class TSoldier : IDeserializable
    {
        public int iID;
        public string strFirstName;
        public string strLastName;
        public string strNickName;
        public int iRank;
        public int iPsiRank;
        public int iCountry;
        public int iXP;
        public int iPsiXP;
        public int iNumKills;
        public TAppearance kAppearance = new TAppearance();
        public TClass kClass = new TClass();
        public bool bBlueshirt;

        public void deSerialize(Stream file)
        {
            int size = Functions.readInt32FromFile(file);
            byte[] bData = new byte[size];
            file.Seek(4, SeekOrigin.Current);
            Functions.readStringFromFile(file);
            file.Seek(4, SeekOrigin.Current);
            file.Read(bData, 0, size);
            MemoryStream data = new MemoryStream(bData);
            IDeserializable Iself = this;
            while (data.Position < data.Length)
            {
                Functions.readProperty(data, Iself);
            }
        }

        public string getShtRank()
        {
            switch (iRank)
            {
                case 0:
                    return "PFC";

                case 1:
                    return "SPEC";

                case 2:
                    return "LCPL";

                case 3:
                    return "CPL";

                case 4:
                    return "SGT";

                case 5:
                    return "TSGT";

                case 6:
                    return "GSGT";

                case 7:
                    return "MSGT";

                default:
                    return "Unknown";
            }
        }

        public string getLngRank()
        {
            switch (iRank)
            {
                case 0:
                    return "Private First Class";

                case 1:
                    return "Specialist";

                case 2:
                    return "Lance Corporal";

                case 3:
                    return "Corporal";

                case 4:
                    return "Sergeant";

                case 5:
                    return "Tech Sergeant";

                case 6:
                    return "Gunnery Sergeant";

                case 7:
                    return "Master Sergeant";

                default:
                    return "Unknown";
            }
        }
    }

    public class UEArray<T> : List<T>, IDeserializable
    {
        public void deSerialize(Stream file)
        {
            int size = Functions.readInt32FromFile(file);
            file.Seek(4 + size, SeekOrigin.Current);
        }
    }

    public class TInventory : IDeserializable
    {
        private int iArmor;
        private int iPistol;
        private int[] arrLargeItems = new int[16];
        private int iNumLargeItems;
        private int[] arrSmallItems = new int[16];
        private int iNumSmallItems;
        private int[] arrCustomItems = new int[16];
        private int iNumCustomItems;

        public void deSerialize(Stream file)
        {
            int size = Functions.readInt32FromFile(file);
            file.Seek(4, SeekOrigin.Current);
            Functions.readStringFromFile(file);
            file.Seek(size + 4, SeekOrigin.Current);
        }
    }

    public class XGStrategySoldier : IDeserializable
    {
        public TCharacter m_kChar = new TCharacter();
        public TSoldier m_kSoldier = new TSoldier();
        public int[] m_aStatModifiers = new int[Enum.GetNames(typeof(ECharacterStat)).Length];
        public ESoldierStatus m_eStatus;
        public int m_iHQLocation;
        public int m_iEnergy;
        public int m_iTurnsOut;
        public int m_iNumMissions;
        public string m_strKIAReport;
        public string m_strKIADate;
        public string m_strCauseOfDeath;
        public bool m_bPsiTested;
        public bool bForcePsiGift;
        public bool m_bMIA;
        public bool m_bAllIn;
        public TInventory m_kBackedUpLoadout = new TInventory();
        public EEasterEggCharacter m_eEasterEggChar;
        public UEArray<EPerkType> m_arrRandomPerks = new UEArray<EPerkType>();
        public int[] m_arrMedals = new int[Enum.GetNames(typeof(EMedalType)).Length];
        public bool m_bBlueShirt;

        public void deSerialize(Stream file)
        {
            int size = Functions.readInt32FromFile(file);
            byte[] bData = new byte[size];
            file.Read(bData, 0, size);
            MemoryStream data = new MemoryStream(bData);
            IDeserializable Iself = this;
            while (data.Position < data.Length)
            {
                Functions.readProperty(data, Iself);
            }
        }

        public string getStatus()
        {
            return Enum.GetName(typeof(ESoldierStatus), (object)m_eStatus);
        }
    }

    public static class Functions
    {
        public static List<XGStrategySoldier> parseSoldiers(MemoryStream file)
        {
            List<XGStrategySoldier> ret = new List<XGStrategySoldier>();
            int numElements = readInt32FromFile(file);
            // Skip the header
            for (int index = 0; index < numElements; index++)
            {
                readStringFromFile(file);
                file.Seek(4, SeekOrigin.Current); //skip unknown 4 bytes.
            }
            //Skip the first object list
            //First skip the header.
            file.Seek(4, SeekOrigin.Current); //Skip the unknown 4 bytes.
            readStringFromFile(file); //Skip header string.
            readStringFromFile(file); //skip "none" string.
            file.Seek(4, SeekOrigin.Current); //Skip the other unknown 4 bytes.
            numElements = readInt32FromFile(file); //get number of elements in this list.
            //Skip this list.
            for (int index = 0; index < numElements; index++)
            {
                readStringFromFile(file); //skip fully qualified instance name.
                string instanceName = readStringFromFile(file); //get instance name name.
                file.Seek(24, SeekOrigin.Current); //skip unkown bytes
                string className = readStringFromFile(file); //get fully qualified class name.
                if (className == "XComStrategyGame.XGStrategySoldier")
                {
                    XGStrategySoldier test = new XGStrategySoldier();
                    test.deSerialize(file);
                    file.Seek(4, SeekOrigin.Current);
                    ret.Add(test);
                }
                else
                {
                    int dataLength = readInt32FromFile(file) + 4; //skip data block + the unknown byte at the end.
                    file.Seek((long)dataLength, SeekOrigin.Current);
                }
            }
            file.Close();
            return ret;
        }

        public static string readStringFromFile(Stream file)
        {
            int strLength = readInt32FromFile(file);
            byte[] strBuffer = new byte[strLength];
            file.Read(strBuffer, 0, strLength);
            return Encoding.ASCII.GetString(strBuffer).TrimEnd(new char[1] { '\0' });
        }

        public static int readInt32FromFile(Stream file)
        {
            byte[] bInteger = new byte[4];
            file.Read(bInteger, 0, 4);
            int integer = BitConverter.ToInt32(bInteger, 0);
            return integer;
        }

        public static bool readBoolFromFile(Stream file)
        {
            return Convert.ToBoolean(file.ReadByte());
        }

        public static float readSingleFloatFromFile(Stream file)
        {
            byte[] bFloat = new byte[4];
            file.Read(bFloat, 0, 4);
            return BitConverter.ToSingle(bFloat, 0);
        }

        public static double readDoubleFloatFromFile(Stream file)
        {
            byte[] bFloat = new byte[8];
            file.Read(bFloat, 0, 8);
            return BitConverter.ToDouble(bFloat, 0);
        }

        public static void readProperty(Stream file, IDeserializable obj)
        {
            string propName = readStringFromFile(file);
            file.Seek(4, SeekOrigin.Current);
            string propType = readStringFromFile(file);
            file.Seek(4, SeekOrigin.Current);
            FieldInfo prop = obj.GetType().GetField(propName, BindingFlags.Public | BindingFlags.Instance);
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
                    MethodInfo Arrayparse = instanceArray.GetType().GetMethod("deSerialize");
                    Arrayparse.Invoke(instanceArray, new object[] { file });
                    prop.SetValue(obj, instanceArray);
                    break;

                case "BoolProperty":
                    file.Seek(8, SeekOrigin.Current); //Skip two unkown int32s
                    bool value = readBoolFromFile(file);
                    prop.SetValue(obj, (object)value);
                    break;

                case "ByteProperty":
                    file.Seek(8, SeekOrigin.Current);
                    readStringFromFile(file);
                    file.Seek(4, SeekOrigin.Current);
                    string name = readStringFromFile(file);
                    int eIndex = readInt32FromFile(file);
                    //if (name == "eStatus_Healing" && eIndex == 1)
                    //    name = "eStatus_Fatigued";
                    object enumValue = Enum.Parse(prop.GetValue(obj).GetType(), name);
                    prop.SetValue(obj, enumValue);
                    break;

                case "FloatProperty":
                    int floatSize = readInt32FromFile(file);
                    file.Seek(4, SeekOrigin.Current);
                    switch (floatSize)
                    {
                        case 4:
                            float single = readSingleFloatFromFile(file);
                            prop.SetValue(obj, single);
                            break;

                        case 8:
                            double dbl = readDoubleFloatFromFile(file);
                            prop.SetValue(obj, dbl);
                            break;

                        default:
                            throw new Exception("WTF that's not a floater");
                    }

                    break;

                case "IntProperty":
                    file.Seek(4, SeekOrigin.Current);
                    int index = readInt32FromFile(file);
                    int Intvalue = readInt32FromFile(file);
                    if (prop.GetValue(obj).GetType().IsArray)
                    {
                        int[] arrayVal = (int[])prop.GetValue(obj);
                        arrayVal[index] = Intvalue;
                        prop.SetValue(obj, (object)arrayVal);
                    }
                    else
                    {
                        prop.SetValue(obj, (object)Intvalue);
                    }
                    break;

                case "StrProperty":
                    file.Seek(8, SeekOrigin.Current);
                    string strValue = readStringFromFile(file);
                    prop.SetValue(obj, strValue);
                    break;

                case "":
                    file.Seek(4, SeekOrigin.Current);
                    break;
            }
        }
    }
}