﻿#pragma checksum "C:\Users\val\Documents\FloK2\FloK\MenuPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CA971ECA758D411E814A79144631E6E1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18444
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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


namespace FloK {
    
    
    public partial class MenuPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Button bt_find;
        
        internal System.Windows.Controls.Button bt_give;
        
        internal System.Windows.Controls.Button bt_info;
        
        internal System.Windows.Controls.Button bt_alarm;
        
        internal System.Windows.Controls.Image im_logo;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/FloK;component/MenuPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.bt_find = ((System.Windows.Controls.Button)(this.FindName("bt_find")));
            this.bt_give = ((System.Windows.Controls.Button)(this.FindName("bt_give")));
            this.bt_info = ((System.Windows.Controls.Button)(this.FindName("bt_info")));
            this.bt_alarm = ((System.Windows.Controls.Button)(this.FindName("bt_alarm")));
            this.im_logo = ((System.Windows.Controls.Image)(this.FindName("im_logo")));
        }
    }
}

