﻿#pragma checksum "..\..\..\view\TripDetailsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B810281EA90509CFCD92DD61B23754FDC60BB1DF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
    /// TripDetailsWindow
    /// </summary>
    public partial class TripDetailsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\view\TripDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HCI_big_project.userControls.SideMenu Menu;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\view\TripDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GMap.NET.WindowsPresentation.GMapControl gmap;
        
        #line default
        #line hidden
        
        
        #line 210 "..\..\..\view\TripDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridAdmin;
        
        #line default
        #line hidden
        
        
        #line 228 "..\..\..\view\TripDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridUser;
        
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
            System.Uri resourceLocater = new System.Uri("/HCI_big_project;component/view/tripdetailswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\view\TripDetailsWindow.xaml"
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
            
            #line 13 "..\..\..\view\TripDetailsWindow.xaml"
            ((HCI_big_project.view.TripDetailsWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Menu = ((HCI_big_project.userControls.SideMenu)(target));
            return;
            case 3:
            this.gmap = ((GMap.NET.WindowsPresentation.GMapControl)(target));
            
            #line 37 "..\..\..\view\TripDetailsWindow.xaml"
            this.gmap.Loaded += new System.Windows.RoutedEventHandler(this.map_load);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\view\TripDetailsWindow.xaml"
            this.gmap.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.MapControl_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 115 "..\..\..\view\TripDetailsWindow.xaml"
            ((System.Windows.Controls.ListBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 150 "..\..\..\view\TripDetailsWindow.xaml"
            ((System.Windows.Controls.ListBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 184 "..\..\..\view\TripDetailsWindow.xaml"
            ((System.Windows.Controls.ListBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.GridAdmin = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.GridUser = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            
            #line 237 "..\..\..\view\TripDetailsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.purchase_OnClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 241 "..\..\..\view\TripDetailsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.reserve_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

