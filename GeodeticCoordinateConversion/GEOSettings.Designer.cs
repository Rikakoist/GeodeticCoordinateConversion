﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeodeticCoordinateConversion {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class GEOSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static GEOSettings defaultInstance = ((GEOSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new GEOSettings())));
        
        public static GEOSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool GEOZoneType3 {
            get {
                return ((bool)(this["GEOZoneType3"]));
            }
            set {
                this["GEOZoneType3"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string WorkFolder {
            get {
                return ((string)(this["WorkFolder"]));
            }
            set {
                this["WorkFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public uint EllipseType {
            get {
                return ((uint)(this["EllipseType"]));
            }
            set {
                this["EllipseType"] = value;
            }
        }
    }
}
