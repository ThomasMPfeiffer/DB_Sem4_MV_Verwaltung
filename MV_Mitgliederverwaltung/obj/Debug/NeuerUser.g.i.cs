﻿#pragma checksum "..\..\NeuerUser.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2B628DEA79AEB64F502030F1907ED3AA26CF2B00"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using MV_Mitgliederverwaltung;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MV_Mitgliederverwaltung {
    
    
    /// <summary>
    /// NeuerUser
    /// </summary>
    public partial class NeuerUser : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\NeuerUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Beenden;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\NeuerUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Textbox_Nutzername;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\NeuerUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBox_ersteEingabe;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\NeuerUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBox_zweiteEingabe;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\NeuerUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Erstellen;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MV_Mitgliederverwaltung;component/neueruser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NeuerUser.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Beenden = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\NeuerUser.xaml"
            this.Beenden.Click += new System.Windows.RoutedEventHandler(this.Beenden_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Textbox_Nutzername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PasswordBox_ersteEingabe = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.PasswordBox_zweiteEingabe = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.Button_Erstellen = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\NeuerUser.xaml"
            this.Button_Erstellen.Click += new System.Windows.RoutedEventHandler(this.Button_Erstellen_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

