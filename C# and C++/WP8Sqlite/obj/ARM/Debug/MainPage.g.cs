﻿#pragma checksum "C:\Users\john\Downloads\Using Sqlite with WP8\C# and C++\WP8Sqlite\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6921CB35CFAB9C2E152E4F430FB8CBE1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
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


namespace WP8Sqlite {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button btnInsert;
        
        internal System.Windows.Controls.Button btnUpdate;
        
        internal System.Windows.Controls.Button GetButton;
        
        internal System.Windows.Controls.TextBlock Simplified;
        
        internal System.Windows.Controls.TextBlock Pinyin;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/WP8Sqlite;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.btnInsert = ((System.Windows.Controls.Button)(this.FindName("btnInsert")));
            this.btnUpdate = ((System.Windows.Controls.Button)(this.FindName("btnUpdate")));
            this.GetButton = ((System.Windows.Controls.Button)(this.FindName("GetButton")));
            this.Simplified = ((System.Windows.Controls.TextBlock)(this.FindName("Simplified")));
            this.Pinyin = ((System.Windows.Controls.TextBlock)(this.FindName("Pinyin")));
        }
    }
}

