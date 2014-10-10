using System.ComponentModel;
using Ionic.Zlib;
using Isolib.Functions;
using Isolib.IOPackage;
using Isolib.STFSPackage;
using Microsoft.Win32;
using PS3FileSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.Primitives;
using XCOMSE.Classes;
using XCOMSE.Controls;
using XCOMSE.XGSoldier;
using XenoBane;
using Binding = System.Windows.Data.Binding;
using MessageBox = System.Windows.MessageBox;
using Selector = System.Windows.Controls.Primitives.Selector;

namespace XCOMSE
{
    public partial class MainWindow
    {
        #region Globals

        #region Arrays&Lists
public long[] soldieroffset;
        private static readonly List<Country> Countries = new List<Country>();

        #region Currencies

        public long cashoffset;

        public int? Cash { get { return _cash; } set { _cash = (int)value; } }

        private int _cash;

        public int Elerium { get { return Items[161]; } set { Items[161] = value; } }

        public int Alloy { get { return Items[162]; } set { Items[162] = value; } }

        public int Meld { get { return Items[164]; } set { Items[164] = value; } }

        #endregion Currencies

        public static int[] Items = new int[226]; //Item List

        //Expendables
        private static Soldier[] Soldiers;

        private List<XGStrategySoldier> Roster = new List<XGStrategySoldier>();

        private static readonly List<Staff> Team = new List<Staff>
        {
            new Staff
            {
                Name = "Engineer",
                Search = "6D5F694E756D456E67696E65657273",
                Adjustment = 0x30
            },
            new Staff
            {
                Name = "Scientist",
                Search = "6D5F694E756D536369656E7469737473",
                Adjustment = 0x31
            }
        };

        private byte[] _buffer; //Stores your decompressed data for editing.

        #region Countries

        public static Country Argentina = new Country
        {
            Name = "Argentina",
            Search = "2E5847436F756E7472795F3131" //Country 11
        };

        public static Country Australia = new Country
        {
            Name = "Australia",
            Search = "2E5847436F756E7472795F3130" //Country 10
        };

        public static Country Brazil = new Country
        {
            Name = "Brazil",
            Search = "2E5847436F756E7472795F3132"
        }; //Country 12

        public static Country Canada = new Country
        {
            Name = "Canada",
            Search = "2E5847436F756E7472795F3100"
        }; //Country 1

        public static Country China = new Country { Name = "China", Search = "2E5847436F756E7472795F37" };

        //Country 7

        public static Country Egypt = new Country { Name = "Egypt", Search = "2E5847436F756E7472795F3133" };

        //Country 13

        public static Country France = new Country { Name = "France", Search = "2E5847436F756E7472795F35" };

        //Country 5

        public static Country Germany = new Country
        {
            Name = "Germany",
            Search = "2E5847436F756E7472795F36"
        }; //Country 6

        public static Country India = new Country { Name = "India", Search = "2E5847436F756E7472795F39" };

        //Country 9

        public static Country Japan = new Country { Name = "Japan", Search = "2E5847436F756E7472795F38" };

        //Country 8

        public static Country Mexico = new Country
        {
            Name = "Mexico",
            Search = "2E5847436F756E7472795F3200"
        };

        //Country 2

        public static Country Nigeria = new Country
        {
            Name = "Nigeria",
            Search = "2E5847436F756E7472795F3135"
        }; //Country 15

        public static Country Russia = new Country { Name = "Russia", Search = "2E5847436F756E7472795F34" };

        //Country 4

        public static Country SouthAfrica = new Country
        {
            Name = "South Africa",
            Search = "2E5847436F756E7472795F3134" //Country 14
        };

        public static Country Uk = new Country
        {
            Name = "United Kingdom",
            Search = "2E5847436F756E7472795F33"
        }; //Country 3

        public static Country Us = new Country { Name = "U.S.A", Search = "2E5847436F756E7472795F3000" };

        //Country 0}

        #endregion Countries

        #region Staff

        public Staff Engineer = Team[0];

        public Staff Scientist = Team[1];

        #endregion Staff

        #endregion Arrays&Lists

        private SaveData SaveD;
        private int _soldierindex;

        //For the soldier combobox
        private bool _solsoucefired;

        private long itemoffset;
        private Enums.Platform _platform;

        #region PS3

        private bool _predecrypted = false;

        private readonly byte[] _key =
        {
            0x0A, 0x0B, 0x01, 0x07, 0x0D, 0x06, 0x01, 0x0C, 0x09, 0x05, 0x02, 0x06, 0x09,
            0x0C, 0x0A, 0x01};

        private const string PS3Name = "PAYLOAD";
        private Ps3SaveManager manager;

        #endregion PS3

        #region Xbox Only

        private Stfs _stfs; //CON file management

        #endregion Xbox Only

        private readonly string[] _spaths =
        {".e",
            ".d",
            ".e.rebuilt"};

        private string _savepath = String.Empty;

        #endregion Globals

        #region Loadup

        public MainWindow()
        {
            InitializeComponent();
            InitialiseValues();
            ranklist.SelectedIndex = 0;
            SolStatus.ItemsSource = Enum.GetNames(typeof(Enums.ESoldierStatus)).Select(i => i.Replace("eStatus_", ""));
            SolClass.ItemsSource = Enum.GetNames(typeof(Enums.ESoldierClass)).Select(i => i.Replace("eSC_", ""));
        }

        private void InitialiseValues()
        {
            //Intialise lists

            #region Bindings

            #region staff

            ScientistBar.Invbox.SetBinding(UpDownBase<int?>.ValueProperty, new Binding("Value")
            {
                Source = Scientist,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger =
                    UpdateSourceTrigger.PropertyChanged
            });
            EngineerBar.Invbox.SetBinding(UpDownBase<int?>.ValueProperty, new Binding("Value")
            {
                Source = Engineer,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger =
                    UpdateSourceTrigger.PropertyChanged
            });

            #endregion staff

            #region countries

            Countries.Add(Argentina);
            Countries.Add(Australia);
            Countries.Add(Brazil);

            RUCheck.SetBinding(ToggleButton.IsCheckedProperty, new Binding("Satellite")
            {
                Source = Russia,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger =
                    UpdateSourceTrigger.PropertyChanged
            });
            Russiapanicbar.SetBinding(RangeBase.ValueProperty, new Binding("Panic")
            {
                Source = Russia,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger =
                    UpdateSourceTrigger.PropertyChanged
            });

            FRCheck.SetBinding(ToggleButton.IsCheckedProperty, new Binding("Satellite")
            {
                Source = France,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger =
                    UpdateSourceTrigger.PropertyChanged
            });
            Francepanicbar.SetBinding(RangeBase.ValueProperty, new Binding("Panic")
            {
                Source = France,
                Mode = BindingMode.TwoWay,
                UpdateSourceTrigger =
                    UpdateSourceTrigger.PropertyChanged
            });
            /*
            CouncilCountries.Us.Satbox = USCheck;
            CouncilCountries.Us.Panicbox = uspanicbar.Progress;
            CouncilCountries.Mexico.Satbox = MexCheck;
            CouncilCountries.Mexico.Panicbox = Mexicopanicbar;
            CouncilCountries.Germany.Satbox = GerCheck;
            CouncilCountries.Germany.Panicbox = germanypanicbar;
            CouncilCountries.Japan.Satbox = JapCheck;
            CouncilCountries.Japan.Panicbox = japanpanicbar;
            CouncilCountries.India.Satbox = InCheck;
            CouncilCountries.India.Panicbox = indiapanicbar;
            CouncilCountries.Egypt.Satbox = EgCheck;
            CouncilCountries.Egypt.Panicbox = egyptpanicbar;
            CouncilCountries.SouthAfrica.Satbox = SCheck;
            CouncilCountries.SouthAfrica.Panicbox = southafricapanicbar;
            CouncilCountries.Nigeria.Satbox = NigCheck;
            CouncilCountries.Nigeria.Panicbox = nigeriapanicbar;
            CouncilCountries.Canada.Satbox = CanCheck;
            CouncilCountries.Canada.Panicbox = Canadapanicbar;
            CouncilCountries.Australia.Satbox = AusCheck;
            CouncilCountries.Australia.Panicbox = australiapanicbar;
            CouncilCountries.China.Satbox = ChiCheck;
            CouncilCountries.China.Panicbox = chinapanicbar;
            CouncilCountries.Argentina.Satbox = ArgCheck;
            CouncilCountries.Argentina.Panicbox = argentinapanicbar;
            CouncilCountries.Uk.Satbox = UKCheck;
            CouncilCountries.Uk.Panicbox = ukpanicbar.Progress;
            CouncilCountries.Brazil.Satbox = BraCheck;
            CouncilCountries.Brazil.Panicbox = brazilpanicbar;
*/

            #endregion countries

            #endregion Bindings
        }

        #endregion Loadup

        #region IO

        #region Opening

        private void Toolkit()
        {
            File.WriteAllBytes(_savepath + _spaths[0], _buffer);
            SetStatus("Saved Extracted.");
            ////Decompress
            SetStatus("Decompression Setup");
            try
            {
                if (File.Exists(_savepath + _spaths[1]))
                    File.Delete(_savepath + _spaths[1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), status.Content.ToString());
                return;
            }
            Fairchild(false);
            //await Task.Factory.StartNew(() => Fairchild(false));
            if (!File.Exists(_savepath + _spaths[1])) //Check for toolkit failure
            {
                SetStatus("Decompression Failure");
                MessageBox.Show("Decompression appears to have failed, aborting opening.");
                _savepath = "";
                return; //Safety net.
            }
            _buffer = File.ReadAllBytes(_savepath + _spaths[1]);
        }

        private async void Open(object sender, RoutedEventArgs e)
        {
            SetStatus("Opening gamesave...");
            try
            {
                var open = new OpenFileDialog
                {
                    Filter = "XCOM Save|save*;*PAYLOAD*",
                    Title = "Select a XCOM:EW Gamesave",
                    CheckFileExists = true,
                    Multiselect = false
                };

                if ((bool)!open.ShowDialog())
                {
                    //User cancels
                    SetStatus("Idle");
                    return;
                }
                //End Generic Open Sequence

                _savepath = open.FileName;
                _platform = open.SafeFileName == "PAYLOAD" ? Enums.Platform.PS3 : Enums.Platform.Xbox360;
                //Ask about backup
                if (File.Exists(_savepath + ".backup"))
                {
                    if (!CompareMd5((_savepath), GenMD5(_savepath + ".backup")))
                        BackupManager(true); //Backup exists but is outdated
                }
                else
                {
                    BackupManager(false); //There is no backup, see if user wants to make one.
                }

                //Begin Platform based analysis
                SetStatus("Analysing Save");
                switch (_platform)
                {
                    case Enums.Platform.PC:
                        //TODO Endian Swap
                        //LZO with additional checksums.
                        _buffer = File.ReadAllBytes(_savepath);
                        Toolkit();
                        break;

                    case Enums.Platform.PS3:
                        //ZLIB
                        var path = Directory.GetParent(_savepath).ToString();
                        //Thanks Jappi
                        //Check if user already decrypted using BSD or something, probably did.
                        if (Directory.GetFiles(path).Any(i => i.Contains("~files_decrypted_by_pfdtool")) || Directory.GetFiles(path).Any(i => !i.Contains("PARAM.PFD")))
                        {
                            _predecrypted = true;
                            _buffer = File.ReadAllBytes(_savepath);
                        }
                        else
                        {
                            _predecrypted = false;
                            manager = new Ps3SaveManager(path, _key);
                            var file = manager.Files.FirstOrDefault(t => t.PFDEntry.file_name == PS3Name);
                            if (file == null)
                            {
                                MessageBox.Show("Could not find PAYLOAD in save folder!", "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                                SetStatus("Load Error - PAYLOAD Missing");
                                return;
                            }
                            _buffer = file.DecryptToBytes();
                        }
                        await Task.Run(() => SaveD = new SaveData(_buffer));
                        //TODO stop using _buffer and complete transition to savedata class.
                        _buffer = SaveD.Buffer;
                        break;

                    case Enums.Platform.iOS:
                        //ZLIB
                        byte[] buffer = File.ReadAllBytes(_savepath);
                        await Task.Run(() => SaveD = new SaveData(buffer));
                        //TODO stop using _buffer and complete transition to savedata class.
                        _buffer = SaveD.Buffer;
                        break;

                    case Enums.Platform.Xbox360:
                        //LZW - I don't fully understand how this can work for a binary file yet.
                        _stfs = new Stfs(_savepath); //Load the file as an STFS file.
                        if (_stfs.HeaderData.SignatureHeaderType != SignatureType.Con ||
                            !_stfs.HeaderData.TitleID.Contains("545408AE"))//.TitleName.Contains("XCOM: Enemy Within"))
                        //Checks CON to make sure it's the right game's save
                        {
                            SetStatus("XCOM:EW Not Detected");
                            //It's not
                            MessageBox.Show("This doesn't seem to be an 'XCOM: Enemy Within' Gamesave!", "Error",
                                MessageBoxButton.OK);
                            _stfs.Close();
                            _savepath = null;
                            return; //abort open
                        }
                        SetStatus("XCOM Detected");
                        ////Extraction
                        SetStatus("Extracting...");
                        _buffer = _stfs.Extract(0); //Extract save from CON into buffer.
                        SetStatus("Extracted.");
                        Toolkit();
                        break;
                }
                SetStatus("Decompressed.");

                await Task.Run(() => Read());
            }
            catch (Exception ex) //generic error catcher.
            {
                MessageBox.Show(ex.Message, status.Content.ToString());
            }
        }

        #endregion Opening

        #region Reading

        private void Read()
        {
            using (var reader = new RWStream(_buffer, true))
            {
                #region Cash

                try
                {
                    SetStatus("Reading Cash");
                    reader.Position =
                            (reader.SearchHexString(
                                "6D5F6943617368", 0,
                                true))[0] +
                            0x28;
                    cashoffset = reader.Position;
                    _cash = reader.ReadInt32(true);
                    CashBar.Dispatcher.Invoke(delegate
                    {
                        CashBar.Invbox.SetBinding(UpDownBase<int?>.ValueProperty, new Binding("Cash")
                            {
                                Source = this,
                                Mode = BindingMode.TwoWay,
                                UpdateSourceTrigger =
                                    UpdateSourceTrigger.PropertyChanged
                            });
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                #endregion Cash

                #region Items

                try
                {
                    SetStatus("Reading Items");
                    reader.Position = (reader.SearchHexString("0B6D5F6172724974656D7300", 0, true)[0]) + 0x2E;
                    Items = new int[reader.ReadInt32()];
                    itemoffset = reader.Position;
                    var rows = Items.Count() / 2;

                    InvGrid.Dispatcher.Invoke(delegate
                    {
                        for (int i = 1; i < rows; i++)
                        {
                            InvGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                        }
                    });

                    var col = false;
                    int row = 0;
                    for (int i = 0; i < Items.Length; i++)
                    {
                        Items[i] = reader.ReadInt32(true);
                        string s;
                        if (!Enums.ItemNames.TryGetValue(i, out s)) continue;
                        SetStatus("Reading " + s);

                        InvGrid.Dispatcher.Invoke(delegate
                        {
                            var bar = new InvItemBar() { ItemName = s, Value = Items[i] };
                            bar.SetValue(Grid.ColumnProperty, Convert.ToInt32(col));
                            bar.SetValue(Grid.RowProperty, row);
                            InvGrid.Children.Add(bar);
                            if (col) row++;
                        });
                        col = !col;
                    }
                    CurrencyPanel.Dispatcher.Invoke(delegate
                    {
                        EleriumBar.Invbox.SetBinding(UpDownBase<int?>.ValueProperty, new Binding("Elerium")
                        {
                            Source = this,
                            Mode = BindingMode.TwoWay,
                            UpdateSourceTrigger =
                                UpdateSourceTrigger.PropertyChanged
                        });
                        MeldBar.Invbox.SetBinding(UpDownBase<int?>.ValueProperty, new Binding("Meld")
                        {
                            Source = this,
                            Mode = BindingMode.TwoWay,
                            UpdateSourceTrigger =
                                UpdateSourceTrigger.PropertyChanged
                        });
                        AlloyBar.Invbox.SetBinding(UpDownBase<int?>.ValueProperty, new Binding("Alloy")
                        {
                            Source = this,
                            Mode = BindingMode.TwoWay,
                            UpdateSourceTrigger =
                                UpdateSourceTrigger.PropertyChanged
                        });
                    });
                    //_Items = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Item Error");
                    SetStatus("Item Error");
                    return;
                }

                #endregion Items

                #region Staff

                try
                {
                    SetStatus("Reading Staff");
                    foreach (Staff staff in Team)
                    {
                        SetStatus("Reading " + staff.Name + "s");
                        reader.Position =
                            (reader.SearchHexString(
                                staff.Search, 0, true))[0] +
                            staff.Adjustment;
                        staff.Offset = reader.Position;
                        staff.Value = reader.ReadInt32(true);
                    }
                    //_Staff = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Staff Error");
                }

                #endregion Staff

                #region EXALT

                try
                {
                    SetStatus("Reading EXALT");
                    //reader.Position = 0;
                    reader.Position = reader.SearchHexString("106D5F654578616C74436F756E747279", 0, true)[0] + 0x46;
                    //.m_eExaltCountry
                    sbyte length = reader.ReadInt8();
                    string exalt = (reader.ReadString(StringType.Ascii, length - 1));
                    //var traitorCountry = (int) Enum.Parse(typeof (ECountry), exalt, false);
                    Exaltcountrylabel.Dispatcher.Invoke(delegate
                    {
                        Exaltcountrylabel.Content = "EXALT Location: " +
                                                    exalt.Replace("eCountry_",
                                                        string.Empty);
                    }); // Countries[traitorCountry].Name; });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "EXALT Error");
                }

                #endregion EXALT

                #region Countries

                /*
                try
                {
                    long[] countrylist = reader.SearchHexString("0954436F756E747279", 0, false);

                    foreach (Country country in Countries)
                    {
                        SetStatus("Reading " +
                                  country.Name);
                        int index = Countries.FindIndex(0, item => item == country);
                        reader.Position = countrylist[index];
                        country.Panic = reader.Position;
                        //country.Offset = reader.Position;
                        //Panic
                        SetStatus("Reading " +
                                  country.Name +
                                  " Panic");
                        country.POffset =
                            (reader.SearchHexString(
                                "096D5F6950616E6963",
                                true))[0] + 0x2A;
                        reader.Position = country.POffset;
                        country.Panic = (reader.ReadInt32(true));

                        //Write panic state

                        //Satellite
                        SetStatus("Reading " +
                                  country.Name +
                                  " Satellite");
                        reader.Position =
                            (reader.SearchHexString(
                                "0D6D5F62536174656C6C697465",
                                true))[0] + 0x2F;
                        country.SOffset = reader.Position;
                        //var satval = reader.ReadInt8();
                        country.Satellite = (Convert.ToBoolean(reader.ReadInt8()));
                    }
                    //_Countries = true;
                }
                catch (Exception)
                {
                    // _Countries = false;
                }
*/

                #endregion Countries

                #region NewSoldier

                SetStatus("Initiating Soldier Parse.");
                var sols = reader.SearchHexString("58436F6D537472617465677947616D652E58475374726174656779536F6C64696572", false);
                soldieroffset = sols;
                for (int i = 0; i < sols.Count(); i++)
                {
                    reader.Position = sols[i] + 0x23;
                    var test = new XGStrategySoldier();
                    test.deSerialize(reader);
                    reader.Position += 4;
                    Roster.Add(test);
                    SetStatus(String.Format("Added: {0}", test));
                }
                SetStatus("Soldier Parse Complete.");

                #endregion NewSoldier

                #region Soldier

                /*
                SetStatus("Reading Soldiers");
                long[] soldiercount = reader.SearchHexString("2E58475374726174656779536F6C646965725F", 0, false);
                //Scans for soldiers
                SetStatus("Soldier Count:" + soldiercount.Length); //Shows counted soldiers.
                int counter = 0;
                Soldiers = new Soldier[soldiercount.Length]; //Initialise the soldier array.

                foreach (long l in soldiercount)
                {
                    Soldiers[counter] = new Soldier();
                    // Intialise index slot
                    reader.Position = l;
                    //First Name
                    reader.Position =
                        reader.SearchHexString(
                            "73747246697273744E616D6500", true)
                            [0] + 0x30;
                    if (reader.PeekInt8() != 0)
                        Soldiers[counter].FName =
                            reader.ReadString(
                                StringType.Ascii,
                                reader.ReadInt8() - 1);

                    //Last Name
                    reader.Position =
                        reader.SearchHexString(
                            "7374724C6173744E616D6500", true)[0
                            ] + 0x2F;
                    if (reader.PeekInt8() != 0)
                        Soldiers[counter].LName =
                            reader.ReadString(
                                StringType.Ascii,
                                reader.ReadInt8() - 1);

                    //NickName
                    reader.Position =
                        reader.SearchHexString(
                            "7374724E69636B4E616D6500", true)[0
                            ] + 0x2F;
                    if (reader.PeekInt8() != 0)
                    {
                        Soldiers[counter].Nickname = "'" + reader.ReadString(StringType.Ascii, reader.ReadInt8() - 1) +
                                                     "'";
                    }
                    //Rank
                    reader.Position =
                        reader.SearchHexString(
                            "066952616E6B00", true)[0] + 0x27;
                    Soldiers[counter].SRankOffset =
                        reader.Position;
                    Soldiers[counter].SRank = reader.ReadUInt32(true);

                    SetStatus("Reading " +
                              Enum.GetName(typeof(Enums.Rank), Soldiers[counter].SRank) + " " +
                              Soldiers[counter].DisplayName); //Shows user current read, looks good.

                    reader.Position = soldiercount[counter];
                    reader.Position =
                        reader.SearchHexString(
                            "07615374617473", true)[0];
                    //astats alignment search
                    //HP
                    Soldiers[counter].HpOffset =
                        reader.Position + 0x28;
                    reader.Position =
                        Soldiers[counter].HpOffset;
                    Soldiers[counter].Hp = reader.ReadUInt32(true);
                    //Aim
                    Soldiers[counter].AimOffset =
                        reader.Position + 0x2B;
                    reader.Position =
                        Soldiers[counter].AimOffset;
                    Soldiers[counter].Aim =
                        reader.ReadInt32(true);
                    //Defense
                    Soldiers[counter].DefenseOffset =
                        reader.Position + 0x2B;
                    reader.Position =
                        Soldiers[counter].DefenseOffset;
                    Soldiers[counter].Defense =
                        reader.ReadInt32(true);
                    //Will
                    Soldiers[counter].WillOffset =
                        reader.Position + 0xE7;
                    reader.Position =
                        Soldiers[counter].WillOffset;
                    Soldiers[counter].Will = reader.ReadUInt32(true);

                    //Class
                    reader.Position = reader.SearchHexString("0765436C61737300", true)[0] + 0x42;
                    sbyte classlength = reader.ReadInt8();
                    Soldiers[counter].Class = (reader.ReadString(StringType.Ascii, classlength - 1).Substring(4));

                    //Psi Gift
                    reader.Position =
                        reader.SearchHexString(
                            "0C6248617350736947696674", true)[0
                            ] + 0x2E;
                    Soldiers[counter].Giftedoffset =
                        reader.Position;
                    Soldiers[counter].Gifted =
                        Convert.ToBoolean(reader.ReadInt8());

                    //Soldier ID
                    reader.Position =
                        reader.SearchHexString(
                            "0954536F6C64696572", true)[0] +
                        0x36; //Exact location of ID

                    Soldiers[counter].ID = reader.ReadUInt32(true);

                    //PsiRank
                    reader.Position =
                        reader.SearchHexString(
                            "096950736952616E6B", true)[0] +
                        0x2A;
                    Soldiers[counter].PsiRankOffset =
                        reader.Position;
                    Soldiers[counter].PsiRank = reader.ReadUInt32(true);

                    //XP
                    reader.Position =
                        reader.SearchHexString("04695850", true)
                            [0] + 0x25;
                    Soldiers[counter].XPOffset =
                        reader.Position;
                    Soldiers[counter].XP = reader.ReadUInt32(true);

                    //PsiXP
                    reader.Position =
                        reader.SearchHexString(
                            "07695073695850", true)[0] + 0x28;
                    Soldiers[counter].PsiXPOffset =
                        reader.Position;
                    Soldiers[counter].PsiXP = reader.ReadUInt32(true);

                    //Status
                    reader.Position =
                        reader.SearchHexString(
                            "0F45536F6C64696572537461747573",
                            true)[0] + 0x17;
                    Soldiers[counter].StatusOffset =
                        reader.Position + 1;
                    sbyte dlength = reader.ReadInt8();
                    Soldiers[counter].Status =
                        (reader.ReadString(StringType.Ascii,
                            dlength - 1).Substring(8, dlength - 9));

                    //PsiTested
                    reader.Position =
                        reader.SearchHexString(
                            "0D6D5F62507369546573746564", true)
                            [0] + 0x2F;
                    Soldiers[counter].Testedoffset =
                        reader.Position;
                    Soldiers[counter].Tested =
                        Convert.ToBoolean(reader.ReadInt8());

                    counter++;
                }
                ;
                //ToString Override was for this.
                //_Soldiers = true;
                SetStatus("Soldiers Loaded.");
                */

                #endregion Soldier

                soldierlist.Dispatcher.Invoke(delegate
                {
                    soldierlist.ItemsSource = Roster;
                    soldierlist.SelectedIndex = 0;
                    Soldiershift(null, null);
                });
            }
            SetStatus("Read Complete. Ready to edit.");
        }

        #endregion Reading

        #region Saving

        private void FinaliseXbox()
        {
            Fairchild(true); //Signal for compression
            SetStatus("Compression Complete");
            _stfs.Replace(File.ReadAllBytes(_savepath + _spaths[2]), 0); //Replace old copy with rebuilt save inside CON
            _stfs.Finish(); //Rehash & Resign
            _stfs.Close(); //Release CON so user can manipulate it.
            SetStatus("Save Successful. Ready for return to your xbox360!");
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            using (var writer = new RWStream(_buffer, true,true))
            {
                #region Cash

                SetStatus("Writing Cash");
                writer.Position = cashoffset;
                writer.WriteInt32((int)Cash, true);

                #endregion Cash

                #region Staff

                //foreach (var staff in Team)
                //{
                //    SetStatus("Writing " + staff.Name);
                //    writer.Position = staff.Offset;
                //    writer.WriteInt32(staff.Value, true);
                //}

                #endregion Staff

                #region Countries

                /*
                            foreach (var country in Countries)
                            {
                                SetStatus("Writing " + country.Name + "Panic");
                                writer.Position = country.POffset;
                                writer.WriteInt32(country.Value, true);
                                SetStatus("Writing " + country.Name + "Satellite");
                                writer.Position = country.SOffset;
                                writer.WriteInt8(Convert.ToSByte(country.Satellite));
                            }
                */

                #endregion Countries

                #region Items

                writer.Position = itemoffset;
                SetStatus("Writing Items");
                for (int i = 0; i < Items.Count(); i++)
                {
                    writer.WriteInt32(Items[i], true);
                }

                #endregion Items
                #region NewSoldiers
                //Perks
                for (int i = 0; i < soldieroffset.Length; i++)
                {
                    writer.Position =soldieroffset[i];
                    writer.Position = writer.SearchHexString("615570677261646573") + 0x2A;
                    for (int index = 0; index < Roster[i].m_kChar.aUpgrades.Length; index++)
                    {
                        writer.WriteInt32(Roster[i].m_kChar.aUpgrades[index]);
                        writer.Position += 0x2E;
                    }
                }

                #endregion
                #region Soldiers

                //foreach (var sol in Soldiers)
                //{
                //    SetStatus("Writing " + sol.DisplayName);
                //    //Hp
                //    SetStatus("Writing " + sol.DisplayName + " HP");
                //    writer.Position = sol.HpOffset;
                //    writer.WriteInt32((int)sol.Hp, true);
                //    //Aim
                //    SetStatus("Writing " + sol.DisplayName + " Aim");
                //    writer.Position = sol.AimOffset;
                //    writer.WriteInt32(sol.Aim, true);
                //    //Defense
                //    SetStatus("Writing " + sol.DisplayName + " Defense");
                //    writer.Position = sol.DefenseOffset;
                //    writer.WriteInt32(sol.Defense, true);
                //    //Will
                //    SetStatus("Writing " + sol.DisplayName + " Will");
                //    writer.Position = sol.WillOffset;
                //    writer.WriteInt32((int)sol.Will, true);
                //    //Psionic Rank
                //    SetStatus("Writing " + sol.DisplayName + " PsiRank");
                //    writer.Position = sol.PsiRankOffset;
                //    writer.WriteInt32((int)sol.PsiRank, true);
                //    //Psionic Gifted
                //    writer.Position = sol.Giftedoffset;
                //    writer.WriteInt8(Convert.ToSByte(sol.Gifted));
                //    //Psionic Tested
                //    writer.Position = sol.Testedoffset;
                //    writer.WriteInt8(Convert.ToSByte(sol.Tested));
                //    //Rank
                //    SetStatus("Writing " + sol.DisplayName + " Rank");
                //    writer.Position = sol.SRankOffset;
                //    writer.WriteInt32((int)sol.SRank, true);
                //}

                #endregion Soldiers

                ////Finish
                writer.Flush();
            }

            SetStatus("Writing complete. Preparing to compress. ");
            switch (_platform)
            {
                case Enums.Platform.PC:
                    //LZO with additional checksums
                    break;

                case Enums.Platform.PS3:
                case Enums.Platform.iOS:
                    SetStatus("Beginning ZLIB Compression.");

                    using (var b = new Reader(_buffer, true))
                    {
                        SetStatus("Writing Blocks.");

                        //Compress all 'Full sized' blocks
                        while (_buffer.Length - b.Position >= 0x00020000)
                        {
                            SaveD.Block.AddRange(new[] { ZlibStream.CompressBuffer(b.ReadBytes(0x00020000, true)) });
                        }
                        //Compress the remainder (if any)
                        if (b.Position != _buffer.Length)
                        {
                            SetStatus("Writing final block.");

                            SaveD.LastBlockLength = Convert.ToUInt32(_buffer.Length - b.Position);
                            SaveD.Block.AddRange(new[]
                            {
                                ZlibStream.CompressBuffer(
                                    b.ReadBytes((int) (_buffer.Length - b.Position), true))
                            });
                        }
                        SetStatus("Rebuilding save.");
                        //Build save
                        var FinalBuffer = new List<byte>();
                        FinalBuffer.AddRange(SaveD.Header);
                        int c = 0;
                        var g = new byte[] { 0, 2, 0, 0 };
                        foreach (var bl in SaveD.Block)
                        {
                            FinalBuffer.AddRange(IsoFunctions.ReverseByteArray(BitConverter.GetBytes(SaveD.Magic)));
                            FinalBuffer.AddRange(g);
                            FinalBuffer.AddRange(IsoFunctions.Int32ToBytesArray(bl.Length));
                            FinalBuffer.AddRange((c == SaveD.Block.Count - 1)
                                ? IsoFunctions.UInt32ToBytesArray(SaveD.LastBlockLength)
                                : g);
                            FinalBuffer.AddRange(IsoFunctions.Int32ToBytesArray(bl.Length));
                            FinalBuffer.AddRange((c == SaveD.Block.Count - 1)
                                ? IsoFunctions.UInt32ToBytesArray(SaveD.LastBlockLength)
                                : g);
                            FinalBuffer.AddRange(bl);
                            c++;
                        }
                        SetStatus("Rebuild Complete.");

                        var s = new SaveFileDialog { Title = "Select location for rebuilt save" };
                        if (s.ShowDialog() == true)
                            SetStatus("Saving.");
                        File.WriteAllBytes(s.FileName, FinalBuffer.ToArray());
                        SetStatus("Save Complete.");
                    }
                    break;

                case Enums.Platform.Xbox360:
                    File.WriteAllBytes(_savepath + _spaths[1], _buffer);
                    //Writes buffer to decompressed file so we can compress.
                    FinaliseXbox(); //Endgame
                    break;
            }
        }

        #endregion Saving

        #endregion IO

        #region Utilities

        private void AddPerk(object sender, RoutedEventArgs e)
        {
            
            if (PerksList.SelectedItems[0] == null) return;
            var r = Roster[soldierlist.SelectedIndex];
            foreach (ListBoxItem d in PerksList.SelectedItems)
            {r.m_kChar.aUpgrades[(int)d.Tag] = 1;}
            PerksList.Items.Clear();
            foreach (var l in r.GetUnusedPerks())
            {PerksList.Items.Add(l);}
            SolPerks.Items.Clear();
            foreach (var l in r.GetPerks())
            {SolPerks.Items.Add(l);}
            PerksList.Items.Refresh();
            SolPerks.Items.Refresh();
        }
        private void RemovePerk(object sender, RoutedEventArgs e)
        {
            if (SolPerks.SelectedItems[0] == null) return;
            var r = Roster[soldierlist.SelectedIndex];
            foreach (ListBoxItem d in SolPerks.SelectedItems)
            { r.m_kChar.aUpgrades[(int)d.Tag] = 0; }
            PerksList.Items.Clear();
            foreach (var l in r.GetUnusedPerks())
            { PerksList.Items.Add(l); }
            SolPerks.Items.Clear();
            foreach (var l in r.GetPerks())
            { SolPerks.Items.Add(l); }
        }

        private void AboutShow(object sender, RoutedEventArgs e)
        {
            var aboot = new About
            {
                Owner = Application.Current.MainWindow,
                Margin = Margin,
                Height = ActualHeight,
                Width = ActualWidth
            };
            MasterTabControl.Visibility = Visibility.Hidden;
            IOStack.Visibility = Visibility.Hidden;
            AboutButton.Visibility = Visibility.Hidden;
            aboot.ShowDialog();
            MasterTabControl.Visibility = Visibility.Visible;
            IOStack.Visibility = Visibility.Visible;
            AboutButton.Visibility = Visibility.Visible;
            aboot = null;
        }

        private void SetStatus(string text)
        {
            if (status.CheckAccess())
                status.Content = String.Format("Status: {0}", text);
            else
            {
                status.Dispatcher.Invoke(delegate { status.Content = String.Format("Status: {0}", text); });
            }
        }

        private void Soldiershift(object sender, SelectionChangedEventArgs e)
        {
            if (Roster.Count == 0) return;
            if (_solsoucefired)
            {
                try
                {
                    int chosen = soldierlist.SelectedIndex; //Get new soldier selection
                    var sol = Roster[chosen];
                    aimbox.InputBindings.Clear();
                    aimbox.SetBinding(UpDownBase<int?>.ValueProperty, new Binding("Aim")
                    {
                        Source = sol,
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger =
                            UpdateSourceTrigger.PropertyChanged
                    });
                    defensebox.InputBindings.Clear();
                    defensebox.SetBinding(UpDownBase<int?>.ValueProperty, new Binding("Defense")
                    {
                        Source = sol,
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger =
                            UpdateSourceTrigger.PropertyChanged
                    });
                    Willbox.InputBindings.Clear();
                    Willbox.SetBinding(UpDownBase<int?>.ValueProperty, new Binding("Will")
                    {
                        Source = sol,
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger =
                            UpdateSourceTrigger.PropertyChanged
                    });
                    Hpbox.InputBindings.Clear();
                    Hpbox.SetBinding(UpDownBase<int?>.ValueProperty, new Binding("HP")
                    {
                        Source = sol,
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger =
                            UpdateSourceTrigger.PropertyChanged
                    });
                    ranklist.InputBindings.Clear();
                    ranklist.SetBinding(Selector.SelectedIndexProperty, new Binding("Rank")
                    {
                        Source = sol,
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger =
                            UpdateSourceTrigger.PropertyChanged
                    });
                    xpbox.InputBindings.Clear();
                    xpbox.SetBinding(UpDownBase<int?>.ValueProperty, new Binding("XP")
                    {
                        Source = sol,
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger =
                            UpdateSourceTrigger.PropertyChanged
                    });
                    Psirankbox.InputBindings.Clear();
                    Psirankbox.SetBinding(UpDownBase<int?>.ValueProperty, new Binding("PsiRank")
                    {
                        Source = sol,
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger =
                            UpdateSourceTrigger.PropertyChanged
                    });
                    psixpbox.InputBindings.Clear();
                    psixpbox.SetBinding(UpDownBase<int?>.ValueProperty, new Binding("PsiXP")
                    {
                        Source = sol,
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger =
                            UpdateSourceTrigger.PropertyChanged
                    });
                    Psitestcheck.InputBindings.Clear();
                    Psitestcheck.SetBinding(ToggleButton.IsCheckedProperty, new Binding("PsiTest")
                    {
                        Source = sol,
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger =
                            UpdateSourceTrigger.PropertyChanged
                    });
                    Psigiftcheck.InputBindings.Clear();
                    Psigiftcheck.SetBinding(ToggleButton.IsCheckedProperty, new Binding("PsiGift")
                    {
                        Source = sol,
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger =
                            UpdateSourceTrigger.PropertyChanged
                    });
                    SolStatus.InputBindings.Clear();
                    SolStatus.SetBinding(Selector.SelectedIndexProperty, new Binding("Status")
                    {
                        Source = sol,
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger =
                            UpdateSourceTrigger.PropertyChanged
                    });
                    SolClass.InputBindings.Clear();
                    SolClass.SetBinding(Selector.SelectedIndexProperty, new Binding("Class")
                    {
                        Source = sol,
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger =
                            UpdateSourceTrigger.PropertyChanged
                    });
                    PerksList.Items.Clear();
                    foreach (var l in sol.GetUnusedPerks())
                    {
                        PerksList.Items.Add(l);
                    }
                    SolPerks.Items.Clear();
                    foreach (var l in sol.GetPerks())
                    {
                        SolPerks.Items.Add(l);
                    }
                    PerksList.Items.SortDescriptions.Add(new SortDescription("Content", ListSortDirection.Ascending));
                    SolPerks.Items.SortDescriptions.Add(new SortDescription("Content", ListSortDirection.Ascending));
       
                    _soldierindex = chosen; //Set as current selected soldier.
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            _solsoucefired = true;
        }

        private void SolShow(object sender, RoutedEventArgs e)
        {
            var Sender = ((Button)sender);
            foreach (var a in Soldierpanel.Children.OfType<Grid>())
            {
                a.Visibility = Visibility.Hidden;
            }
            switch (Sender.Name)
            {
                case "SolGeneralButton":
                  SoldierGeneral.Visibility = Visibility.Visible;
                  break;

                case "AbilityButton":
                   PerkGrid.Visibility = Visibility.Visible;
                   break;

                case "PsiAbilityButton":
                    break;

                case "GeneButton":
                    break;

                case "LoadoutButton":
                    break;

                case "CustomiseButton":
                    break;
            }
        }

        private void BackupManager(bool caller)
        {
            MessageBoxResult dresult = MessageBox.Show("Would you like to backup the save first?",
                caller ? "No Backup Detected" : "Backup Outdated", MessageBoxButton.YesNo);
            if (dresult.ToString().Equals("Yes")) File.Copy(_savepath, _savepath + ".backup", true);
        }

        private void UpdateAllPanicBars(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            foreach (PanicProgressBar bar in PanicGrid.Children.OfType<PanicProgressBar>())
            {
                bar.Value = PanicSlider.Value;
            }
        }

        #region MD5 Tools

        private bool CompareMd5(string exePath, string hash)
        {
            SetStatus("Checking Toolkit...");
            using (MD5 md5 = MD5.Create())
            {
                try
                {
                    using (FileStream stream = File.OpenRead(exePath))
                    {
                        return md5.ComputeHash(stream).ToString() == hash;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }

        private string GenMD5(string filepath)
        {
            using (MD5 md5 = MD5.Create())
            {
                try
                {
                    using (FileStream stream = File.OpenRead(filepath))
                    {
                        return md5.ComputeHash(stream).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return "";
                }
            }
        }

        #endregion MD5 Tools

        #region Compression

        private void Fairchild(bool compress)
        {
            string exePath = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\xcom-fix.exe");
            //Fairchilds Toolkit location
            SetStatus("Checking toolkit...");
            if (!File.Exists(exePath) || !CompareMd5(exePath, "C21C5538217224A85A8C8BCA76D1B71B"))
            {
                SetStatus("Extracting Toolkit...");
                using (
                    Stream stream =
                        Assembly.GetExecutingAssembly().GetManifestResourceStream("XCOMSE.Resources.xcom-fix.exe")
                    )
                {
                    var bytes = new byte[stream.Length]; //initialize buffer
                    stream.Read(bytes, 0, (int)stream.Length); // streams the exe to buffer
                    File.WriteAllBytes(exePath, bytes);
                }
                SetStatus("Toolkit Extracted.");
            }
            var toolkit = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    RedirectStandardInput = false,
                    FileName = exePath,
                    CreateNoWindow = true,
                    //Verb = "runas",
                    Arguments =
                        (compress
                            ? "-c " + "\"" + _savepath + _spaths[1] + "\"" + " " + "\"" +
                              _savepath + _spaths[0] + "\""
                            : "-d " + "\"" + _savepath + _spaths[0] + "\"" + " " + "\"" +
                              _savepath + _spaths[1] + "\"")
                }
            };
            SetStatus("Commencing " + (compress ? "Compression" : "Decompression") + "...");
            try
            {
                toolkit.Start();
                toolkit.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), status.Content.ToString());
            }
        }

        #endregion Compression

        private void Output(object sender, RoutedEventArgs e)
        {
            var s = new SaveFileDialog();
            if ((bool)s.ShowDialog()) File.WriteAllBytes(s.FileName, _buffer);
        }

        private void Input(object sender, RoutedEventArgs e)
        {
            var o = new OpenFileDialog();
            if ((bool)o.ShowDialog())
            {
                _buffer = File.ReadAllBytes(o.FileName);
                SaveD.Buffer = _buffer;
            }
        }

        #endregion Utilities
    }
}