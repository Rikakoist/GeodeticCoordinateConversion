﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeodeticCoordinateConversion.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
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
        [global::System.Configuration.DefaultSettingValueAttribute("GeoConversion.xml")]
        public string DataFileName {
            get {
                return ((string)(this["DataFileName"]));
            }
            set {
                this["DataFileName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("GeoConvertDB.mdb")]
        public string DBName {
            get {
                return ((string)(this["DBName"]));
            }
            set {
                this["DBName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public uint DefaultEllipseType {
            get {
                return ((uint)(this["DefaultEllipseType"]));
            }
            set {
                this["DefaultEllipseType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("6")]
        public uint DefaultZoneType {
            get {
                return ((uint)(this["DefaultZoneType"]));
            }
            set {
                this["DefaultZoneType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool SwitchAfterGaussTransfer {
            get {
                return ((bool)(this["SwitchAfterGaussTransfer"]));
            }
            set {
                this["SwitchAfterGaussTransfer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ClearExistingRecordData2File {
            get {
                return ((bool)(this["ClearExistingRecordData2File"]));
            }
            set {
                this["ClearExistingRecordData2File"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ClearExistingRecordData2DB {
            get {
                return ((bool)(this["ClearExistingRecordData2DB"]));
            }
            set {
                this["ClearExistingRecordData2DB"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ClearExistingRecordDB2File {
            get {
                return ((bool)(this["ClearExistingRecordDB2File"]));
            }
            set {
                this["ClearExistingRecordDB2File"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ClearExistingRecordFile2DB {
            get {
                return ((bool)(this["ClearExistingRecordFile2DB"]));
            }
            set {
                this["ClearExistingRecordFile2DB"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Green")]
        public global::System.Drawing.Color SelectedColor {
            get {
                return ((global::System.Drawing.Color)(this["SelectedColor"]));
            }
            set {
                this["SelectedColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Red")]
        public global::System.Drawing.Color ErrorColor {
            get {
                return ((global::System.Drawing.Color)(this["ErrorColor"]));
            }
            set {
                this["ErrorColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Green")]
        public global::System.Drawing.Color CorrectColor {
            get {
                return ((global::System.Drawing.Color)(this["CorrectColor"]));
            }
            set {
                this["CorrectColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Crimson")]
        public global::System.Drawing.Color DirtyColor {
            get {
                return ((global::System.Drawing.Color)(this["DirtyColor"]));
            }
            set {
                this["DirtyColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DarkGreen")]
        public global::System.Drawing.Color CalculatedColor {
            get {
                return ((global::System.Drawing.Color)(this["CalculatedColor"]));
            }
            set {
                this["CalculatedColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("White")]
        public global::System.Drawing.Color DefaultCellColor {
            get {
                return ((global::System.Drawing.Color)(this["DefaultCellColor"]));
            }
            set {
                this["DefaultCellColor"] = value;
            }
        }
    }
}
