﻿#pragma checksum "..\..\..\Menu\FightField.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ED35FB2D8EBB1A698918E5EBD0341906"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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
    /// FightField
    /// </summary>
    public partial class FightField : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\Menu\FightField.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid fight;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Menu\FightField.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PlayerImage;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\Menu\FightField.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CombatLog;
        
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
            System.Uri resourceLocater = new System.Uri("/The Powerful Game;component/menu/fightfield.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Menu\FightField.xaml"
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
            this.fight = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.PlayerImage = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            
            #line 96 "..\..\..\Menu\FightField.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAttackOnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 105 "..\..\..\Menu\FightField.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonOffensiveSpellOnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 114 "..\..\..\Menu\FightField.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDeffensiveSpellOnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 123 "..\..\..\Menu\FightField.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDrinkHealthPotionOnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 132 "..\..\..\Menu\FightField.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDrinkResourcePotionOnClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 144 "..\..\..\Menu\FightField.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonFleeOnClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CombatLog = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

