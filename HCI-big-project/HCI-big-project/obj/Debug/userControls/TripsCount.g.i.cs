﻿#pragma checksum "..\..\..\userControls\TripsCount.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F999266BC69C63C84EECC878036543EF620DD139"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using HCI_big_project.userControls;
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


namespace HCI_big_project.userControls {
    
    
    /// <summary>
    /// TripsCount
    /// </summary>
    public partial class TripsCount : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\userControls\TripsCount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Border;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\userControls\TripsCount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NameLabel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\userControls\TripsCount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DescriptionLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/HCI_big_project;component/usercontrols/tripscount.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\userControls\TripsCount.xaml"
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
            
            #line 9 "..\..\..\userControls\TripsCount.xaml"
            ((HCI_big_project.userControls.TripsCount)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Card_OnLoaded);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\userControls\TripsCount.xaml"
            ((HCI_big_project.userControls.TripsCount)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.TripsOverviewCard_OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\userControls\TripsCount.xaml"
            ((HCI_big_project.userControls.TripsCount)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.TripsOverviewCard_OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Border = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.NameLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.DescriptionLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

