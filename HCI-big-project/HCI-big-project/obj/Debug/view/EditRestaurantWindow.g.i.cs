﻿#pragma checksum "..\..\..\view\EditRestaurantWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B168E202A13B3EA55CB643B76325D41D693B3097E4B3E2D2D1841173ABE9845F"
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
    /// EditRestaurantWindow
    /// </summary>
    public partial class EditRestaurantWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\view\EditRestaurantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HCI_big_project.userControls.SideMenu Menu;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\view\EditRestaurantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GMap.NET.WindowsPresentation.GMapControl gmap;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\view\EditRestaurantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameInput;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\view\EditRestaurantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddressInput;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\view\EditRestaurantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LinkInput;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\view\EditRestaurantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CaptionInput;
        
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
            System.Uri resourceLocater = new System.Uri("/HCI_big_project;component/view/editrestaurantwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\view\EditRestaurantWindow.xaml"
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
            
            #line 13 "..\..\..\view\EditRestaurantWindow.xaml"
            ((HCI_big_project.view.EditRestaurantWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Menu = ((HCI_big_project.userControls.SideMenu)(target));
            return;
            case 3:
            this.gmap = ((GMap.NET.WindowsPresentation.GMapControl)(target));
            
            #line 32 "..\..\..\view\EditRestaurantWindow.xaml"
            this.gmap.Loaded += new System.Windows.RoutedEventHandler(this.map_load);
            
            #line default
            #line hidden
            
            #line 33 "..\..\..\view\EditRestaurantWindow.xaml"
            this.gmap.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.MapControl_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\view\EditRestaurantWindow.xaml"
            this.gmap.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Gmap_OnMouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AddressInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.LinkInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.CaptionInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 112 "..\..\..\view\EditRestaurantWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonBase_OnClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 156 "..\..\..\view\EditRestaurantWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Confirm_OnClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 160 "..\..\..\view\EditRestaurantWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

