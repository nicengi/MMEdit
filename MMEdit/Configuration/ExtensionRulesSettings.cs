using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MMEdit.Configuration
{
    internal class ExtensionRulesSettings : CustomSettingsBase
    {
        #region Fields
        private ExtensionRulesSettingsControl control;
        #endregion

        #region Constructor
        public ExtensionRulesSettings(Host host)
        {
            Host = host;
            Text = Properties.Resources.Settings_ExtensionRules;
        }
        #endregion

        #region Properties
        private Host Host { get; }
        #endregion

        #region Methods
        public override void Save()
        {
            if (control != null)
            {
                Host.ImportConfig.ExtensionRules = control.ExtensionRules;
                Util.XmlSerialize(ImportConfig.ImageConfigPath, Host.ImportConfig);
            }
        }

        public override Control CreateControl()
        {
            if (control != null)
            {
                control.ExtensionRules = new List<ExtensionRule>(Host.ImportConfig.ExtensionRules);
                return control;
            }
            control = new ExtensionRulesSettingsControl(Host)
            {
                ExtensionRules = new List<ExtensionRule>(Host.ImportConfig.ExtensionRules),
            };
            return control;
        }
        #endregion
    }

}
