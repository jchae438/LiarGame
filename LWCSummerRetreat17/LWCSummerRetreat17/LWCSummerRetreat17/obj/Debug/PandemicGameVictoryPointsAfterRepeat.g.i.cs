﻿#pragma checksum "..\..\PandemicGameVictoryPointsAfterRepeat.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9D983BBCC63707BEDF08B46CB5D638BA36F72A5C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LWCSummerRetreat17;
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


namespace LWCSummerRetreat17 {
    
    
    /// <summary>
    /// PandemicGameVictoryPointsAfterRepeat
    /// </summary>
    public partial class PandemicGameVictoryPointsAfterRepeat : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\PandemicGameVictoryPointsAfterRepeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label pandemicGameTitle;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\PandemicGameVictoryPointsAfterRepeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label listOfWinners;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\PandemicGameVictoryPointsAfterRepeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextRoundButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\PandemicGameVictoryPointsAfterRepeat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button finishButton;
        
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
            System.Uri resourceLocater = new System.Uri("/LWCSummerRetreat17;component/pandemicgamevictorypointsafterrepeat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PandemicGameVictoryPointsAfterRepeat.xaml"
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
            this.pandemicGameTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.listOfWinners = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.nextRoundButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\PandemicGameVictoryPointsAfterRepeat.xaml"
            this.nextRoundButton.Click += new System.Windows.RoutedEventHandler(this.nextRoundButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.finishButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\PandemicGameVictoryPointsAfterRepeat.xaml"
            this.finishButton.Click += new System.Windows.RoutedEventHandler(this.endGameButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

