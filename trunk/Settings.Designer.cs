﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JarrettVance.ChapterTools {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ImportDurations {
            get {
                return ((bool)(this["ImportDurations"]));
            }
            set {
                this["ImportDurations"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool IgnoreShortLastChapter {
            get {
                return ((bool)(this["IgnoreShortLastChapter"]));
            }
            set {
                this["IgnoreShortLastChapter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection RecentFiles {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["RecentFiles"]));
            }
            set {
                this["RecentFiles"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>24000/1001</string>
  <string>24</string>
  <string>25</string>
  <string>30000/1001</string>
  <string>30</string>
  <string>50</string>
  <string>60000/1001</string>
  <string>60</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection FpsValues {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["FpsValues"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("29.970029970029973")]
        public double DefaultFps {
            get {
                return ((double)(this["DefaultFps"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public int MaxRecentFiles {
            get {
                return ((int)(this["MaxRecentFiles"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public int ShortChapterSeconds {
            get {
                return ((int)(this["ShortChapterSeconds"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3.7")]
        public string ConfigVersion {
            get {
                return ((string)(this["ConfigVersion"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".txt")]
        public string LastSaveExt {
            get {
                return ((string)(this["LastSaveExt"]));
            }
            set {
                this["LastSaveExt"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("eng")]
        public string DefaultLangCode {
            get {
                return ((string)(this["DefaultLangCode"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>chi</string>
  <string>dut</string>
  <string>eng</string>
  <string>fin</string>
  <string>fre</string>
  <string>ger</string>
  <string>ita</string>
  <string>jpn</string>
  <string>nor</string>
  <string>por</string>
  <string>ita</string>
  <string>rus</string>
  <string>spa</string>
  <string>swe</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection LangValues {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["LangValues"]));
            }
            set {
                this["LangValues"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LastOpenDir {
            get {
                return ((string)(this["LastOpenDir"]));
            }
            set {
                this["LastOpenDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int LastSaveFilterIndex {
            get {
                return ((int)(this["LastSaveFilterIndex"]));
            }
            set {
                this["LastSaveFilterIndex"] = value;
            }
        }
    }
}
