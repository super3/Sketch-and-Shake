﻿#pragma checksum "C:\Users\Super3\Code\Sketch-and-Shake\Sketch-and-Shake\Sketch-and-Shake\HelpControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "115D445582898A2C74961BFE6AEC46B3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace SketchApp01 {
    
    
    public partial class HelpControl : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock aboutBlock;
        
        internal System.Windows.Controls.HyperlinkButton sourceBtn;
        
        internal System.Windows.Controls.HyperlinkButton websiteBtn;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/SketchApp01;component/HelpControl.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.aboutBlock = ((System.Windows.Controls.TextBlock)(this.FindName("aboutBlock")));
            this.sourceBtn = ((System.Windows.Controls.HyperlinkButton)(this.FindName("sourceBtn")));
            this.websiteBtn = ((System.Windows.Controls.HyperlinkButton)(this.FindName("websiteBtn")));
        }
    }
}

