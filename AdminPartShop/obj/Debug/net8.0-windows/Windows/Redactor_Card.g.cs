﻿#pragma checksum "..\..\..\..\Windows\Redactor_Card.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D98C85A20AFF9CD6772623992A682AED98DBCD38"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AdminPartShop;
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


namespace AdminPartShop.Windows {
    
    
    /// <summary>
    /// Redactor_Card
    /// </summary>
    public partial class Redactor_Card : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Windows\Redactor_Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ProductImage;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Windows\Redactor_Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_redact;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Windows\Redactor_Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_delete;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Windows\Redactor_Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_name;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Windows\Redactor_Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_description;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Windows\Redactor_Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_count;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Windows\Redactor_Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_price;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Windows\Redactor_Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_exit;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Windows\Redactor_Card.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_category_id;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AdminPartShop;component/windows/redactor_card.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\Redactor_Card.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ProductImage = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.btn_redact = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.btn_delete = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Windows\Redactor_Card.xaml"
            this.btn_delete.Click += new System.Windows.RoutedEventHandler(this.btn_delete_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textbox_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.textbox_description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.textbox_count = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\..\Windows\Redactor_Card.xaml"
            this.textbox_count.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textbox_number_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.textbox_price = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\..\..\Windows\Redactor_Card.xaml"
            this.textbox_price.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textbox_number_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_exit = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\Windows\Redactor_Card.xaml"
            this.btn_exit.Click += new System.Windows.RoutedEventHandler(this.btn_exit_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.textbox_category_id = ((System.Windows.Controls.TextBox)(target));
            
            #line 66 "..\..\..\..\Windows\Redactor_Card.xaml"
            this.textbox_category_id.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textbox_number_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

