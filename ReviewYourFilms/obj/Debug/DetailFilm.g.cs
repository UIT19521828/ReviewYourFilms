﻿#pragma checksum "..\..\DetailFilm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8EEFEC40FD0A380A831835A1570A4AE253128A320DC6882E45A9D360CDB03B6F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
using LibVLCSharp.WPF;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using ReviewYourFilms;
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


namespace ReviewYourFilms {
    
    
    /// <summary>
    /// DetailFilm
    /// </summary>
    public partial class DetailFilm : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTitle;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbAvgRate;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbMyRate;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush imgPoster;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border vlcBorder;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LibVLCSharp.WPF.VideoView trailerPlayer;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon iconPlay;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTime;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtYear;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGenre;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDir;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescript;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel panelButtonG;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel panelReview;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\DetailFilm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTempReview;
        
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
            System.Uri resourceLocater = new System.Uri("/ReviewYourFilms;component/detailfilm.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DetailFilm.xaml"
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
            
            #line 34 "..\..\DetailFilm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NavBack_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.lbAvgRate = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lbMyRate = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.imgPoster = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 6:
            this.vlcBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.trailerPlayer = ((LibVLCSharp.WPF.VideoView)(target));
            return;
            case 8:
            
            #line 103 "..\..\DetailFilm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Play_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.iconPlay = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 10:
            this.txtTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.txtYear = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.txtGenre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.txtDir = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.txtDescript = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.panelButtonG = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 16:
            
            #line 197 "..\..\DetailFilm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenReview_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.panelReview = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 18:
            this.lbTempReview = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

