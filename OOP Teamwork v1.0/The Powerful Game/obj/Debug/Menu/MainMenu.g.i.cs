﻿#pragma checksum "..\..\..\Menu\MainMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C8A44819B8C34C2EA809566505A7B64A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace The_Powerful_Game.Menu {
    
    
    /// <summary>
    /// MainMenu
    /// </summary>
    public partial class MainMenu : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Menu\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainMenuLayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Menu\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newGameButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Menu\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button optionButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Menu\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button creditsGameButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Menu\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button quitButton;
        
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
            System.Uri resourceLocater = new System.Uri("/The Powerful Game;component/menu/mainmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Menu\MainMenu.xaml"
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
            this.mainMenuLayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.newGameButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Menu\MainMenu.xaml"
            this.newGameButton.Click += new System.Windows.RoutedEventHandler(this.newGameButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.optionButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Menu\MainMenu.xaml"
            this.optionButton.Click += new System.Windows.RoutedEventHandler(this.optionButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.creditsGameButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Menu\MainMenu.xaml"
            this.creditsGameButton.Click += new System.Windows.RoutedEventHandler(this.creditsButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.quitButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Menu\MainMenu.xaml"
            this.quitButton.Click += new System.Windows.RoutedEventHandler(this.quitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
