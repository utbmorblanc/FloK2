﻿#pragma checksum "C:\Users\chris\Documents\Visual Studio 2010\Projects\FloK\FloK\LoginPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9B1199E0775A99483BC80673ED53D63B"
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
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock FloK;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox tb_login;
        
        internal System.Windows.Controls.TextBox tb_pwd;
        
        internal System.Windows.Controls.TextBlock lb_login;
        
        internal System.Windows.Controls.TextBlock lb_pwd;
        
        internal System.Windows.Controls.Button btn_login;
        
        internal System.Windows.Controls.TextBlock tb_error;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/FloK;component/LoginPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.FloK = ((System.Windows.Controls.TextBlock)(this.FindName("FloK")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.tb_login = ((System.Windows.Controls.TextBox)(this.FindName("tb_login")));
            this.tb_pwd = ((System.Windows.Controls.TextBox)(this.FindName("tb_pwd")));
            this.lb_login = ((System.Windows.Controls.TextBlock)(this.FindName("lb_login")));
            this.lb_pwd = ((System.Windows.Controls.TextBlock)(this.FindName("lb_pwd")));
            this.btn_login = ((System.Windows.Controls.Button)(this.FindName("btn_login")));
            this.tb_error = ((System.Windows.Controls.TextBlock)(this.FindName("tb_error")));
        }
    }
}

