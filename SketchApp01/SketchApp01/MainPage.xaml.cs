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
using Microsoft.Phone.Shell;


/* I basically just moved the draw code over from the previous version
 * but i made some major changes in the settings window (which i lazily left as
 * "WindowsPhoneControl1" hahaha.
 * 
 * but seriously, this should work.
 * -Eric
 */

namespace SketchApp01
{
    public partial class MainPage : PhoneApplicationPage
    {
        AppSettings settings = new AppSettings();
        
        // Private Point Data
        private Point currentPoint;
        private Point oldPoint;

        // Private Brush Data (Defaults)
        private int brushSize = 10;
        private Color brushColor = Colors.Red;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Minimized;

            ApplicationBarIconButton appBarBtnSettings = new ApplicationBarIconButton(new Uri("/Images/appbar.feature.settings.rest.png", UriKind.Relative));
            appBarBtnSettings.Text = "Settings";
            ApplicationBar.Buttons.Add(appBarBtnSettings);
            appBarBtnSettings.Click += new EventHandler(appBarBtnSettings_Click);

            ApplicationBarIconButton appBarBtnHelp = new ApplicationBarIconButton(new Uri("/Images/appbar.questionmark.rest.png", UriKind.Relative));
            appBarBtnHelp.Text = "Help";
            ApplicationBar.Buttons.Add(appBarBtnHelp);
            appBarBtnHelp.Click += new EventHandler(appBarBtnHelp_Click);
        }

        private void drawCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Drawing code
            // Nice little tutorial on that is here:
            // http://www.windowsphonegeek.com/tips/drawing-in-wp7-2-drawing-shapes-with-finger

            currentPoint = e.GetPosition(this.drawCanvas);

            Line line = new Line() { X1 = currentPoint.X, Y1 = currentPoint.Y, X2 = oldPoint.X, Y2 = oldPoint.Y };

//Made changes here!!!!!!!!!!!!!!!
            
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

        private void drawCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Drawing Code
            currentPoint = e.GetPosition(drawCanvas);
            oldPoint = currentPoint;
        }

        private void appBarBtnSettings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/WindowsPhoneControl1.xaml", UriKind.Relative));
        }

        private void appBarBtnHelp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpControl.xaml", UriKind.Relative));
        }
    }
}