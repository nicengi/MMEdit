using System.Windows.Forms;

namespace MMEdit.Configuration
{
    internal class StartSettings : CustomSettingsBase
    {
        #region Fields
        private StartSettingsControl control;
        #endregion

        #region Constructor
        public StartSettings(Host host)
        {
            Host = host;
            Text = Properties.Resources.Settings_Start;
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
                Properties.Settings.Default.StartPage = control.StartPlugin;
            }
            base.SaveSettings();
        }

        public override Control CreateControl()
        {
            if (control != null)
            {
                control.StartPlugin = Properties.Settings.Default.StartPage;
                return control;
            }
            control = new StartSettingsControl(Host);
            return control;
        }
        #endregion
    }
}
