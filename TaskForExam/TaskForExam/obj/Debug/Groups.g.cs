﻿#pragma checksum "..\..\Groups.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1CDFEF2CE8A03340005FB01265E8EF184DA5036516623B34D9E384A2AEA7AC73"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using System.Windows.Forms.Integration;
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
using TaskForExam;


namespace TaskForExam {
    
    
    /// <summary>
    /// Groups
    /// </summary>
    public partial class Groups : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid table;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox spec1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox number;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label a1;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label a2;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label p;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem s1;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem s2;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem s3;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Groups.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem s4;
        
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
            System.Uri resourceLocater = new System.Uri("/TaskForExam;component/groups.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Groups.xaml"
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
            this.table = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.spec1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\Groups.xaml"
            this.spec1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.spec1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.number = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\Groups.xaml"
            this.number.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.number_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 33 "..\..\Groups.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 5:
            this.a1 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.a2 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.p = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            
            #line 43 "..\..\Groups.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.s1 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 46 "..\..\Groups.xaml"
            this.s1.Click += new System.Windows.RoutedEventHandler(this.s1_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.s2 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 47 "..\..\Groups.xaml"
            this.s2.Click += new System.Windows.RoutedEventHandler(this.s2_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.s3 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 48 "..\..\Groups.xaml"
            this.s3.Click += new System.Windows.RoutedEventHandler(this.s3_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.s4 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 49 "..\..\Groups.xaml"
            this.s4.Click += new System.Windows.RoutedEventHandler(this.s4_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 50 "..\..\Groups.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

