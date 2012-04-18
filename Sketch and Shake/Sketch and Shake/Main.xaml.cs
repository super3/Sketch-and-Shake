﻿// Author: Shawn Wilkinson
// Date: April 13, 2012
// Website: http://super3.org
// Note this XAML page was made from a lockable pivot sample. 

// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone.Shell;
using ShakeGestures;

namespace PhoneToolkitSample.Samples
{
    public partial class LockablePivotSample : PhoneApplicationPage
    {
       // Private Point Data
        private Point currentPoint;
        private Point oldPoint;

        // Private Brush Data (Defaults)
        private int brushSize = 15;
        private Color brushColor = Colors.Red;

        public LockablePivotSample()
        {
            // Start Up the Form
            InitializeComponent();

            // Register shake event
            ShakeGesturesHelper.Instance.ShakeGesture += new EventHandler<ShakeGestureEventArgs>(Instance_ShakeGesture);
            // Set minimum shakes to prevent accidental clears of the canvas
            // Testing on the phone showed that 3 shakes was sufficent
            ShakeGesturesHelper.Instance.MinimumRequiredMovesForShake = 3;
            // Start shake detection
            ShakeGesturesHelper.Instance.Active = true;

            // Application Bar
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Minimized;

            // Application Bar Save Button
            ApplicationBarIconButton saveBtnBar = new ApplicationBarIconButton(new Uri("/Images/appbar.save.rest.png", UriKind.Relative));
            saveBtnBar.Text = "Save";
            ApplicationBar.Buttons.Add(saveBtnBar);
            saveBtnBar.Click += new EventHandler(saveBtnBar_Click);

            // Application Bar Settings Button
            ApplicationBarIconButton settingBtnBar = new ApplicationBarIconButton(new Uri("/Images/appbar.feature.settings.rest.png", UriKind.Relative));
            settingBtnBar.Text = "Settings";
            ApplicationBar.Buttons.Add(settingBtnBar);

            // Application Bar Help Button
            ApplicationBarIconButton helpBtnBar = new ApplicationBarIconButton(new Uri("/Images/appbar.questionmark.rest.png", UriKind.Relative));
            helpBtnBar.Text = "Help";
            ApplicationBar.Buttons.Add(helpBtnBar);
        }

        void saveBtnBar_Click(object sender, EventArgs e)
        {
            saveCanvas();
        }

        private void Instance_ShakeGesture(object sender, ShakeGestureEventArgs e)
        {
            // Because this is on a diffrent thread (or something), you can't 
            // call the canvas control directly
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                // Clear Canvas
                drawCanvas.Children.Clear();
            });
        }

        //private void lockButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Intresting. This just flips the boolean control property
        //    // rather than having a silly if/else statement
        //    pivot.IsLocked = !pivot.IsLocked;
        //    // Another cool little boolean trick
        //    lockButton.Content = (pivot.IsLocked ? "Unlock" : "Lock");
        //}

        private void drawCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Drawing code
            // Nice little tutorial on that is here:
            // http://www.windowsphonegeek.com/tips/drawing-in-wp7-2-drawing-shapes-with-finger

            currentPoint = e.GetPosition(this.drawCanvas);

            Line line = new Line() { X1 = currentPoint.X, Y1 = currentPoint.Y, X2 = oldPoint.X, Y2 = oldPoint.Y };
            
            // Grab current brush settingss
            line.Stroke = new SolidColorBrush(brushColor);
            line.StrokeThickness = brushSize;
            // Make the ends of the lines round or you will be able to 
            // see the indiviual lines as they do not merge nicly when 
            // don't have a nice round ending
            line.StrokeStartLineCap = PenLineCap.Round;
            line.StrokeEndLineCap = PenLineCap.Round;

            // Add the line to the canvas
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
                // Failed. Do Nothing.
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
                // Try to set the brush to the slider value
                brushSize = (int)brushSlider.Value;
            }
            catch
            {
                // Slider is null then just use the defualt
                brushSize = 15;
            }
            resetSamplePen();       
        }

        private void clearTextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Clear Canvas
            drawCanvas.Children.Clear();
        }

        private void saveCanvas()
        {
            // Article on saving
            // http://msdn.microsoft.com/en-us/library/ff769549(v=vs.92).aspx

            // Create an incrementing name 
            int jpegNameCounter = 1;
            String jpegName = "Sketch" + jpegNameCounter.ToString();
            jpegNameCounter++;

            // Create isolated storage file and check if it exsists 
            var myStore = IsolatedStorageFile.GetUserStoreForApplication();
            if (myStore.FileExists(jpegName))
            {
                myStore.DeleteFile(jpegName);
            }

            // Create isolated storage file steam
            IsolatedStorageFileStream myFileStream = myStore.CreateFile(jpegName);

            // Create a stream out of the sample JPEG file.
            // For [Application Name] in the URI, use the project name that you entered 
            // in the previous steps. Also, TestImage.jpg is an example;
            // you must enter your JPEG file name if it is different.
            StreamResourceInfo sri = null;
            Uri uri = new Uri("Sketch and Shake;component/" + jpegName + ".jpg", UriKind.Relative);
            sri = Application.GetResourceStream(uri);

            // Get bitmap from canvas
            WriteableBitmap wb = new WriteableBitmap(drawCanvas, null);

            // Encode the WriteableBitmap object to a JPEG stream.
            wb.SaveJpeg(myFileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
            myFileStream.Close();

            // Create a new stream from isolated storage, and save the JPEG file to the media library on Windows Phone.
            myFileStream = myStore.OpenFile(jpegName, FileMode.Open, FileAccess.Read);

            // Save the image to the camera roll or saved pictures album.
            MediaLibrary library = new MediaLibrary();

            //// Save the image to the camera roll album.
            //Picture pic = library.SavePictureToCameraRoll("SavedPicture.jpg", myFileStream);
            //MessageBox.Show("Image saved to camera roll album");

            // Save the image to the saved pictures album.
            Picture pic = library.SavePicture(jpegName + ".jpg", myFileStream);
            MessageBox.Show("Sketch Saved to Saved Pictures Album");

            // Clean up
            myFileStream.Close();
        }

        /// <summary>
        ///  Application Bar Save Button
        /// </summary>
        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            saveCanvas();
        }
    }
}