﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dental_Management_System.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class PaymentSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static PaymentSettings defaultInstance = ((PaymentSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new PaymentSettings())));
        
        public static PaymentSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("12")]
        public int VATTax {
            get {
                return ((int)(this["VATTax"]));
            }
            set {
                this["VATTax"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("222-222-222-222")]
        public string BIRnumber {
            get {
                return ((string)(this["BIRnumber"]));
            }
            set {
                this["BIRnumber"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("222-222-222-222")]
        public string TINnumber {
            get {
                return ((string)(this["TINnumber"]));
            }
            set {
                this["TINnumber"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string TAXpermitIssueDate {
            get {
                return ((string)(this["TAXpermitIssueDate"]));
            }
            set {
                this["TAXpermitIssueDate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string TAXpermitExpireDate {
            get {
                return ((string)(this["TAXpermitExpireDate"]));
            }
            set {
                this["TAXpermitExpireDate"] = value;
            }
        }
    }
}
