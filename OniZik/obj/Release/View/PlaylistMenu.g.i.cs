﻿#pragma checksum "..\..\..\View\PlaylistMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0D3D767F8A66E0B482EF69C2D77A60BD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using GongSolutions.Wpf.DragDrop;
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
using WpfApplication1;
using WpfApplication1.Model;


namespace WpfApplication1.View {
    
    
    /// <summary>
    /// PlaylistMenu
    /// </summary>
    public partial class PlaylistMenu : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\View\PlaylistMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid playlistDisplay;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\View\PlaylistMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitlePlaylist;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\View\PlaylistMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox playlistName;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\View\PlaylistMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createPlaylist;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\View\PlaylistMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\View\PlaylistMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainListGrid;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\PlaylistMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition myPlaylist;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\View\PlaylistMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition myList;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\View\PlaylistMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition myButtonsHere;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\View\PlaylistMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition listHere;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/view/playlistmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\PlaylistMenu.xaml"
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
            this.playlistDisplay = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.TitlePlaylist = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.playlistName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.createPlaylist = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.mainListGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.myPlaylist = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 8:
            this.myList = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 9:
            this.myButtonsHere = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 10:
            this.listHere = ((System.Windows.Controls.RowDefinition)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

