using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MMEdit;

namespace MMEdit.Configuration
{
    internal sealed class PreferencesSettings : CustomSettingsBase
    {
        #region Fields
        private GeneralSettings generalSettings;
        private ExtensionRulesSettings extensionRulesSettings;
        private StartSettings startSettings;
        #endregion

        #region Constructor
        public PreferencesSettings(Host host)
        {
            Text = Properties.Resources.Settings_Preferences;

            generalSettings = new GeneralSettings(host);
            extensionRulesSettings = new ExtensionRulesSettings(host);
            startSettings = new StartSettings(host);

            Settings.AddRange(new CustomSettingsBase[]
            {
                generalSettings,
                extensionRulesSettings,
                startSettings,
            });
        }
        #endregion

        #region Methods
        public override void Save()
        {
            SaveSettings();
            Properties.Settings.Default.Save();
        }

        public override Control CreateControl()
        {
            return generalSettings.CreateControl();
        }
        #endregion
    }
}
