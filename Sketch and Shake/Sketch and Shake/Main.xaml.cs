// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

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
using Microsoft.Phone.Controls;
using Microsoft.Devices.Sensors;
using ShakeGestures;
using System.Windows.Media.Imaging;
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Phone;
using System.Windows.Resources;
using System.Xml.Serialization;

namespace PhoneToolkitSample.Samples
{
    public partial class LockablePivotSample : PhoneApplicationPage
    {
       // Private Point Data
        private Point currentPoint;
        private Point oldPoint;

        // Private Brush Data
        private int brushSize = 15;
        private Color brushColor = Colors.Red;

        public LockablePivotSample()
        {
            // Start Up the Form
            InitializeComponent();

            // Register Shake Event
            ShakeGesturesHelper.Instance.ShakeGesture += new EventHandler<ShakeGestureEventArgs>(Instance_ShakeGesture);
            // Set Minimum Shakes to Prevent Accidental Clears
            ShakeGesturesHelper.Instance.MinimumRequiredMovesForShake = 3;
            // Start Shake Detection
            ShakeGesturesHelper.Instance.Active = true;
        }

        private void Instance_ShakeGesture(object sender, ShakeGestureEventArgs e)
        {
            // Because this is on a diffrent thread or something
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                // Clear Canvas
                drawCanvas.Children.Clear();
            });
        }

        private void lockButton_Click(object sender, RoutedEventArgs e)
        {
            // Intresting. This just flips the boolean control property
            // rather than having a silly if/else statement
            pivot.IsLocked = !pivot.IsLocked;
            // Another cool little boolean trick
            lockButton.Content = (pivot.IsLocked ? "Unlock" : "Lock");
        }

        private void drawCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Drawing Code
            currentPoint = e.GetPosition(this.drawCanvas);

            Line line = new Line() { X1 = currentPoint.X, Y1 = currentPoint.Y, X2 = oldPoint.X, Y2 = oldPoint.Y };
            
            line.Stroke = new SolidColorBrush(brushColor);
            line.StrokeThickness = brushSize;
            line.StrokeStartLineCap = PenLineCap.Round;
            line.StrokeEndLineCap = PenLineCap.Round;

            this.drawCanvas.Children.Add(line);
            oldPoint = currentPoint;
        }

        private void drawCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Drawing Code
            currentPoint = e.GetPosition(drawCanvas);
            oldPoint = currentPoint;
        }

        private void resetSamplePen()
        {
            try
            {
                // Set Color 
                penSample.Fill = new SolidColorBrush(brushColor);
                // Set Width and Heigh
                penSample.Width = brushSize;
                penSample.Height = brushSize;
            }
            catch
            {

            }
        }

        private void btnBlack_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushColor = Colors.Black;
            resetSamplePen();
        }

        private void btnRed_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushColor = Colors.Red;
            resetSamplePen();
        }

        private void btnBlue_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushColor = Colors.Blue;
            resetSamplePen();
        }

        private void btnGreen_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushColor = Colors.Green;
            resetSamplePen();
        }

        private void btnWhite_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushColor = Colors.White;
            resetSamplePen();
        }

        private void btnYellow_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushColor = Colors.Yellow;
            resetSamplePen();
        }

        private void btnPurple_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushColor = Colors.Purple;
            resetSamplePen();
        }

        private void btnOrange_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            brushColor = Colors.Orange;
            resetSamplePen();
        }

        private void brushSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                // Try to Set the Brush to the Slider Value
                brushSize = (int)brushSlider.Value;
            }
            catch
            {
                // Slider is Null Then Just Use Default
                brushSize = 15;
            }
            resetSamplePen();       
        }

        private void clearTextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Clear Canvas
            drawCanvas.Children.Clear();
        }
    }
}