﻿#pragma checksum "..\..\..\Components\ComReview.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B81F478D4F50204A3BF76A6A6D7D26D198F0CE677BA8A9008C453CFD04BCEA08"
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
using ReviewYourFilms.Components;
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


namespace ReviewYourFilms.Components {
    
    
    /// <summary>
    /// ComReview
    /// </summary>
    public partial class ComReview : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Components\ComReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderComment;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Components\ComReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush imgReviewer;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Components\ComReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTitle;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Components\ComReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtScore;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Components\ComReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rtbContent;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Components\ComReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLike;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Components\ComReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLike;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Components\ComReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDis;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Components\ComReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDis;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Components\ComReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtReviewer;
        
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
            System.Uri resourceLocater = new System.Uri("/ReviewYourFilms;component/components/comreview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Components\ComReview.xaml"
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
            this.borderComment = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.imgReviewer = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 3:
            this.txtTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtScore = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.rtbContent = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 6:
            this.btnLike = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\Components\ComReview.xaml"
            this.btnLike.Click += new System.Windows.RoutedEventHandler(this.btnLike_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtLike = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnDis = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\Components\ComReview.xaml"
            this.btnDis.Click += new System.Windows.RoutedEventHandler(this.btnDis_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txtDis = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.txtReviewer = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

