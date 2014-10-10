using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace XCOMSE.Controls
{
    /// <summary>
    /// Interaction logic for BaseSlot.xaml
    /// </summary>
    public partial class BaseSlot : UserControl
    {
        public enum ComboSide
        {
            Left,
            Up,
            Down,
            Right
        }

        public bool ComboVisible { get { return Comb.IsVisible; } set { Comb.Visibility = value ? Visibility.Visible : Visibility.Hidden; } }

        private enum BaseCodes
        {
            Satellite,
            AlienContainment,
            GallopChamber,
            Workshop,
            PowerGenerator,
            ThermalGenerator,
            EleriumGenerator,
            OTS,
            Lab,
            GeneLab,
            Foundry,
            Cybernetics,
            PsiChamber,
            AccessLift,
            SatNexus,
            Steam
        }

        private void ChangeSlot(int slot)
        {
        }

        // public int Foreground { get{return Enum.Parse(typeof(BaseCodes),FG.Source)}}

        public BaseSlot()
        {
            InitializeComponent();
            BitmapFrame frame1 = BitmapDecoder.Create(new Uri("/XCOMSE;component/Resources/Images/Base/FacilityCard_Empty.png"), BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
            BitmapFrame frame2 = BitmapDecoder.Create(new Uri("/XCOMSE;component/Resources/Images/Base/Facility_Steam.png"), BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();

            // Gets the size of the images (I assume each image has the same size)
            int imageWidth = 64;
            int imageHeight = 32;

            // Draws the images into a DrawingVisual component
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(frame1, new Rect(0, 0, imageWidth, imageHeight));
                drawingContext.DrawImage(frame2, new Rect(0, 0, imageWidth, imageHeight));
            }

            // Converts the Visual (DrawingVisual) into a BitmapSource
            RenderTargetBitmap bmp = new RenderTargetBitmap(imageWidth * 2, imageHeight * 2, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);

            // Creates a PngBitmapEncoder and adds the BitmapSource to the frames of the encoder
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
        }
    }
}