﻿#pragma checksum "..\..\..\Pages\PasswordRecovery_Page.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0388FC2583D3189A3DF6CB62A73E3DD146DC403F9B1A1DE399C1E74C939A3493"
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


namespace AdminPartShop.Pages {
    
    
    /// <summary>
    /// PasswordRecovery_Page
    /// </summary>
    public partial class PasswordRecovery_Page : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Pages\PasswordRecovery_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_pass;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Pages\PasswordRecovery_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_pass_2;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Pages\PasswordRecovery_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_enter;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\PasswordRecovery_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Hyperlink remembered_password;
        
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
            System.Uri resourceLocater = new System.Uri("/AdminPartShop;component/pages/passwordrecovery_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PasswordRecovery_Page.xaml"
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
            this.textbox_pass = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\Pages\PasswordRecovery_Page.xaml"
            this.textbox_pass.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.textBox_PreviewExecuted));
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\Pages\PasswordRecovery_Page.xaml"
            this.textbox_pass.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.textbox_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\Pages\PasswordRecovery_Page.xaml"
            this.textbox_pass.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textbox_pass_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textbox_pass_2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\Pages\PasswordRecovery_Page.xaml"
            this.textbox_pass_2.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.textBox_PreviewExecuted));
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\Pages\PasswordRecovery_Page.xaml"
            this.textbox_pass_2.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.textbox_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\Pages\PasswordRecovery_Page.xaml"
            this.textbox_pass_2.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textbox_pass_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_enter = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Pages\PasswordRecovery_Page.xaml"
            this.btn_enter.Click += new System.Windows.RoutedEventHandler(this.btn_enter_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.remembered_password = ((System.Windows.Documents.Hyperlink)(target));
            
            #line 34 "..\..\..\Pages\PasswordRecovery_Page.xaml"
            this.remembered_password.Click += new System.Windows.RoutedEventHandler(this.remembered_password_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
