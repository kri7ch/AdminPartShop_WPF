﻿#pragma checksum "..\..\..\..\Windows\TwoFactorActivation_Window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9FCB6DA0DCD6AAC56E160698228052A9963B46B0"
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
    /// TwoFactorActivation_Window
    /// </summary>
    public partial class TwoFactorActivation_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Windows\TwoFactorActivation_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_code;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\Windows\TwoFactorActivation_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_enter;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Windows\TwoFactorActivation_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Hyperlink changedMyMind;
        
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
            System.Uri resourceLocater = new System.Uri("/AdminPartShop;component/windows/twofactoractivation_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\TwoFactorActivation_Window.xaml"
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
            this.textbox_code = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\..\Windows\TwoFactorActivation_Window.xaml"
            this.textbox_code.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.textBox_PreviewExecuted));
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\..\Windows\TwoFactorActivation_Window.xaml"
            this.textbox_code.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.textbox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_enter = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\Windows\TwoFactorActivation_Window.xaml"
            this.btn_enter.Click += new System.Windows.RoutedEventHandler(this.btn_enter_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.changedMyMind = ((System.Windows.Documents.Hyperlink)(target));
            
            #line 26 "..\..\..\..\Windows\TwoFactorActivation_Window.xaml"
            this.changedMyMind.Click += new System.Windows.RoutedEventHandler(this.changedMyMind_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

