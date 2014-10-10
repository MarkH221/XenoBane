using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace XCOMSE.Controls
{
    /// <summary>
    /// Interaction logic for PanicProgressBar.xaml
    /// </summary>
    public partial class PanicProgressBar : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        [Description("Progressbar ProgValue")]
        public double Value
        {
            get { return Progress.Value; }
            set { Progress.Value = value; OnPropertyChanged("Value"); }
        }

        [Description("Control FlowDirection")]
        public bool FlowLeft
        {
            get { return Progress.FlowDirection == FlowDirection.RightToLeft; }
            set
            {
                Progress.FlowDirection = value ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
                //Check.FlowDirection = value ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            }
        }

        public long Offset;

        public PanicProgressBar()
        {
            InitializeComponent();
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "LeftBtn":
                    if (FlowLeft) Progress.Value++;
                    else Progress.Value -= 1;
                    break;

                case "RightBtn":
                    if (FlowLeft) Progress.Value -= 1;
                    else Progress.Value++;
                    break;
            }
        }

        private void PanicShift(object sender, EventArgs e)
        {
            var Sender = ((ProgressBar)sender);
            var value = Sender.Value < 3 ? 0 : Convert.ToInt32(Sender.Value);
            string colour;
            Enums.PanicColours.TryGetValue(value, out colour);
            Sender.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(colour);
        }
    }
}