﻿#pragma checksum "..\..\..\Sales.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1594D5D42C81DA9640554B5AC8E182530D552806"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Assignment2;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Assignment2 {
    
    
    /// <summary>
    /// Sales
    /// </summary>
    public partial class Sales : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button goBackToAdmin;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid cartGrid;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button okToPay;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label cart;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label totalSales1;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox totalSales;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Sales.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button connectCart;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Assignment2;component/sales.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Sales.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.goBackToAdmin = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\Sales.xaml"
            this.goBackToAdmin.Click += new System.Windows.RoutedEventHandler(this.goBackToAdmin_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cartGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.okToPay = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Sales.xaml"
            this.okToPay.Click += new System.Windows.RoutedEventHandler(this.OkToPay_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cart = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.totalSales1 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.totalSales = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.connectCart = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Sales.xaml"
            this.connectCart.Click += new System.Windows.RoutedEventHandler(this.connectCart_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

