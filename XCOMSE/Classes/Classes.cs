using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace XCOMSE
{
    #region Classes

  public class CoreClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }
        public long Adjustment;
        public string Name;
        public string Search;
        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;OnPropertyChanged("Value");}
        }

        public long Offset;

        public override string ToString()
        {
            return Name;
        }
    }

    public class Country : CoreClass
    {
        private long _panic;
        private bool _satellite;
        public long Panic{
            get { return _panic; }
            set
            {
                _panic = value;OnPropertyChanged("Panic");}
        }
        public long SOffset;
        public long POffset;
        public bool Satellite{
            get { return _satellite; }
            set
            {
                _satellite = value;OnPropertyChanged("Satellite");}
        }
    }

    public class Item : CoreClass
    {
        public bool EW;
    }

    public class Soldier : INotifyPropertyChanged
    {
        public int Aim; //+0x2B from HP
        public long AimOffset;
        public string Class;

        //0954536F6C64696572 = .TSoldier
        public int Defense;

        public long DefenseOffset;
        //public int Energy;
        //public long EnergyOffset;

        public string FName = "";

        public bool Gifted;
        public long Giftedoffset;
        public uint Hp; //-0x76C from .TSoldier
        public long HpOffset;
        public uint ID;
        public string LName = "";
        public string Nickname = "";
        public uint PsiRank;
        public long PsiRankOffset;
        public uint PsiXP;
        public long PsiXPOffset;
        public uint SRank;
        public long SRankOffset;
        public string Status = ""; //45536F6C6469657253746174757300 SoldierStatus + 16, read8 = length

        public long StatusOffset;
        public bool Tested;
        public long Testedoffset;
        public uint Will;
        public long WillOffset;
        public uint XP;
        public long XPOffset;

        public string DisplayName
        {
            get
            {
                return Nickname != ""
                    ? String.Format("{0} {1} {2}", FName, Nickname, LName)
                    : String.Format("{0} {1}", FName, LName);
            }
        }

        public override string ToString()
        {
            return DisplayName;
        }

public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
    }

    public class Staff : CoreClass
    {
    }

    #endregion Classes
}