#pragma checksum "..\..\Sparte_hinzufuegen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "312F54E8B94BBED2E1B9ABB5CD7128E7AC139A59"
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
    /// Sparte_hinzufuegen
    /// </summary>
    public partial class Sparte_hinzufuegen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\Sparte_hinzufuegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuItemBeenden;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Sparte_hinzufuegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Textbox_Spartenbezeichnung;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Sparte_hinzufuegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Textbox_AdminName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Sparte_hinzufuegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Hinzufuegen;
        
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
            System.Uri resourceLocater = new System.Uri("/MV_Mitgliederverwaltung;component/sparte_hinzufuegen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Sparte_hinzufuegen.xaml"
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
            this.MenuItemBeenden = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\Sparte_hinzufuegen.xaml"
            this.MenuItemBeenden.Click += new System.Windows.RoutedEventHandler(this.MenuItemBeenden_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Textbox_Spartenbezeichnung = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Textbox_AdminName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Button_Hinzufuegen = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\Sparte_hinzufuegen.xaml"
            this.Button_Hinzufuegen.Click += new System.Windows.RoutedEventHandler(this.Button_Hinzufuegen_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

