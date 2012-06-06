using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SketchApp01
{
    public partial class WindowsPhoneControl1 : UserControl
    {
        //This is the class that handles data transfer between the pages
        DataStorage brushChanges = new DataStorage();

        public WindowsPhoneControl1()
        {
            InitializeComponent();
        }


        private void btnBlack_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushChanges.setBrushColor(Colors.Black);
            brushChanges.setResetSampleBrush(true);
        }

        private void btnRed_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushChanges.setBrushColor(Colors.Red);
            brushChanges.setResetSampleBrush(true);
        }

        private void btnBlue_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushChanges.setBrushColor(Colors.Blue);
            brushChanges.setResetSampleBrush(true);
        }

        private void btnGreen_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushChanges.setBrushColor(Colors.Green);
            brushChanges.setResetSampleBrush(true);
        }

        private void btnWhite_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushChanges.setBrushColor(Colors.White);
            brushChanges.setResetSampleBrush(true);
        }

        private void btnYellow_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushChanges.setBrushColor(Colors.Yellow);
            brushChanges.setResetSampleBrush(true);
        }

        private void btnPurple_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushChanges.setBrushColor(Colors.Purple);
            brushChanges.setResetSampleBrush(true);
        }

        private void btnOrange_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushChanges.setBrushColor(Colors.Orange);
            brushChanges.setResetSampleBrush(true);
        }

        private void brushSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                // Try to set the brush to the slider value
                brushChanges.setBrushSize((int)brushSlider.Value);
            }
            catch
            {
                // Slider is null then just use the defualt
                brushChanges.setBrushSize( 15 );
            }
        }

    }
}
