﻿#pragma checksum "..\..\..\view\EditAccomodationWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4F90F0AD8388AA165FEE7D4180C35050FFB4C6B2DBF158BDA75F929104265D09"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GMap.NET.WindowsPresentation;
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


namespace HCI_big_project.view {
    
    
    /// <summary>
    /// EditAccomodationWindow
    /// </summary>
    public partial class EditAccomodationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\view\EditAccomodationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HCI_big_project.userControls.SideMenu Menu;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\view\EditAccomodationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GMap.NET.WindowsPresentation.GMapControl gmap;
        
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
            System.Uri resourceLocater = new System.Uri("/HCI_big_project;component/view/editaccomodationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\view\EditAccomodationWindow.xaml"
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
            
            #line 13 "..\..\..\view\EditAccomodationWindow.xaml"
            ((HCI_big_project.view.EditAccomodationWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Menu = ((HCI_big_project.userControls.SideMenu)(target));
            return;
            case 3:
            this.gmap = ((GMap.NET.WindowsPresentation.GMapControl)(target));
            
            #line 32 "..\..\..\view\EditAccomodationWindow.xaml"
            this.gmap.Loaded += new System.Windows.RoutedEventHandler(this.map_load);
            
            #line default
            #line hidden
            
            #line 33 "..\..\..\view\EditAccomodationWindow.xaml"
            this.gmap.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.MapControl_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\view\EditAccomodationWindow.xaml"
            this.gmap.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Gmap_OnMouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 113 "..\..\..\view\EditAccomodationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonBase_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 156 "..\..\..\view\EditAccomodationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Confirm_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 159 "..\..\..\view\EditAccomodationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
