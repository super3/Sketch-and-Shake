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
using ShakeGestures;

namespace SketchApp01
{
    public partial class MainPage : PhoneApplicationPage
    {
        AppSettings settings = new AppSettings();
        
        // Private Point Data
        private Point currentPoint;
        private Point oldPoint;

        // Private Brush Data (Defaults)
        private int brushSize = 10; // Is this used?
        private Color brushColor = Colors.Red;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Register shake event
            ShakeGesturesHelper.Instance.ShakeGesture += new EventHandler<ShakeGestureEventArgs>(Instance_ShakeGesture);
            // Set minimum shakes to prevent accidental clears of the canvas
            // Testing on the phone showed that 3 shakes was sufficent
            ShakeGesturesHelper.Instance.MinimumRequiredMovesForShake = 3;
            // Start shake detection
            ShakeGesturesHelper.Instance.Active = true;
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

        private void drawCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Drawing code
            // Nice little tutorial on that is here:
            // http://www.windowsphonegeek.com/tips/drawing-in-wp7-2-drawing-shapes-with-finger

            // Get current point location
            currentPoint = e.GetPosition(this.drawCanvas);
            // Create a line
            Line line = new Line() { X1 = currentPoint.X, Y1 = currentPoint.Y, X2 = oldPoint.X, Y2 = oldPoint.Y };
            
            // Grab current brush settings
            line.Stroke = new SolidColorBrush(settings.getBrushColor());
            line.StrokeThickness = settings.getBrushSize();

            // Make the ends of the lines round or you will be able to 
            // see the indiviual lines as they do not merge nicly when 
            // don't have a nice round ending
            line.StrokeStartLineCap = PenLineCap.Round;
            line.StrokeEndLineCap = PenLineCap.Round;

            // Add the line to the canvas
            this.drawCanvas.Children.Add(line);
            oldPoint = currentPoint;
        }

        // Grab the the current pointer location. So we know where to draw the line later
        private void drawCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            currentPoint = e.GetPosition(drawCanvas);
            oldPoint = currentPoint;
        }

		// Launch the user control that contains all the settings for the current brush.
        private void barSettings_Click(object sender, System.EventArgs e)
        {
        	NavigationService.Navigate(new Uri("/BrushControl.xaml", UriKind.Relative));
        }

        // Launch a static user control that displays help and about
        private void barHelp_Click(object sender, System.EventArgs e)
        {
        	NavigationService.Navigate(new Uri("/HelpControl.xaml", UriKind.Relative));
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

        // Save image currently on canvas
        private void barSave_Click(object sender, System.EventArgs e)
        {
        	saveCanvas();
        }

    }
}