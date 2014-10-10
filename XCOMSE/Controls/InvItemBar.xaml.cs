using System.Windows;

namespace XCOMSE.Controls
{
    public partial class InvItemBar {
        public InvItemBar()
        {
            InitializeComponent();
        }

        //public long Offset;
        public string ItemName
        {
            get { return (string)InvItem.Content; }
            set { InvItem.Content = value; }
        }

        public string ButtonText
        {
            get { return MaxBtn.Content as string; }
            set
            {
                MaxBtn.Content = value;
            }
        }

        public long Offset { get; set; }

        
        public int? Value
        {
            get { return Invbox.Value; }
            set { Invbox.Value =value;}
        }

        private void MaxItem(object sender, RoutedEventArgs e)
        {
            Invbox.Value = 99999;
        }

       
    }
}