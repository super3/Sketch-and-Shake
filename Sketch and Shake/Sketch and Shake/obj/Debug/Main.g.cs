﻿#pragma checksum "C:\Users\Super3\Code\Sketch-and-Shake\Sketch and Shake\Sketch and Shake\Main.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "395D08C161528C9A8A628A43F59506DA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17379
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PhoneToolkitSample.Samples {
    
    
    public partial class LockablePivotSample : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.LockablePivot pivot;
        
        internal Microsoft.Phone.Controls.PivotItem pivotDraw;
        
        internal System.Windows.Controls.Canvas drawCanvas;
        
        internal Microsoft.Phone.Controls.PivotItem pivotSettings;
        
        internal System.Windows.Controls.Slider brushSlider;
        
        internal System.Windows.Shapes.Rectangle btnBlack;
        
        internal System.Windows.Shapes.Rectangle btnRed;
        
        internal System.Windows.Shapes.Rectangle btnBlue;
        
        internal System.Windows.Shapes.Rectangle btnGreen;
        
        internal System.Windows.Shapes.Rectangle btnWhite;
        
        internal System.Windows.Shapes.Rectangle btnYellow;
        
        internal System.Windows.Shapes.Rectangle btnPurple;
        
        internal System.Windows.Shapes.Rectangle btnOrange;
        
        internal System.Windows.Shapes.Ellipse penSample;
        
        internal Microsoft.Phone.Controls.PivotItem pivotAbout;
        
        internal System.Windows.Controls.TextBlock textBlock1;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Sketch%20and%20Shake;component/Main.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.pivot = ((Microsoft.Phone.Controls.LockablePivot)(this.FindName("pivot")));
            this.pivotDraw = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("pivotDraw")));
            this.drawCanvas = ((System.Windows.Controls.Canvas)(this.FindName("drawCanvas")));
            this.pivotSettings = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("pivotSettings")));
            this.brushSlider = ((System.Windows.Controls.Slider)(this.FindName("brushSlider")));
            this.btnBlack = ((System.Windows.Shapes.Rectangle)(this.FindName("btnBlack")));
            this.btnRed = ((System.Windows.Shapes.Rectangle)(this.FindName("btnRed")));
            this.btnBlue = ((System.Windows.Shapes.Rectangle)(this.FindName("btnBlue")));
            this.btnGreen = ((System.Windows.Shapes.Rectangle)(this.FindName("btnGreen")));
            this.btnWhite = ((System.Windows.Shapes.Rectangle)(this.FindName("btnWhite")));
            this.btnYellow = ((System.Windows.Shapes.Rectangle)(this.FindName("btnYellow")));
            this.btnPurple = ((System.Windows.Shapes.Rectangle)(this.FindName("btnPurple")));
            this.btnOrange = ((System.Windows.Shapes.Rectangle)(this.FindName("btnOrange")));
            this.penSample = ((System.Windows.Shapes.Ellipse)(this.FindName("penSample")));
            this.pivotAbout = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("pivotAbout")));
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock1")));
        }
    }
}

