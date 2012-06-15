using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SketchApp01
{
    public partial class WindowsPhoneControl1 : UserControl
    {
        //This is the class that handles data transfer between the pages
        AppSettings settings = new AppSettings();

        public WindowsPhoneControl1()
        {
            InitializeComponent();
            brushSlider.Value = settings.getBrushSize();
        }

        private void btnBlack_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            settings.setBrushColor(Colors.Black);
            resetSampleBrush();
        }

        private void btnRed_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            settings.setBrushColor(Colors.Red);
            resetSampleBrush();
        }

        private void btnBlue_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            settings.setBrushColor(Colors.Blue);
            resetSampleBrush();
        }

        private void btnGreen_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            settings.setBrushColor(Colors.Green);
            resetSampleBrush();
        }

        private void btnWhite_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            settings.setBrushColor(Colors.White);
            resetSampleBrush();
        }

        private void btnYellow_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            settings.setBrushColor(Colors.Yellow);
            resetSampleBrush();
        }

        private void btnPurple_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            settings.setBrushColor(Colors.Purple);
            resetSampleBrush();
        }

        private void btnOrange_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            settings.setBrushColor(Colors.Orange);
            resetSampleBrush();
        }

        private void brushSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                // Try to set the brush to the slider value
                settings.setBrushSize((int)brushSlider.Value);
            }
            catch
            {
                // Slider is null then just use the defualt
                settings.setBrushSize( 15 );
            }
            resetSampleBrush();
        }

        private void resetSampleBrush()
        {
            try
            {
                sampleBrush.Fill = new SolidColorBrush(settings.getBrushColor());
                sampleBrush.Width = settings.getBrushSize();
                sampleBrush.Height = settings.getBrushSize();
            }
            catch
            {
                // Failed. Do Nothing.
            }
        }
    }
}
