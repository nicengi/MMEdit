using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMEdit.Configuration
{
    internal class GeneralSettings : CustomSettingsBase
    {
        #region Fields
        private GeneralSettingsControl control;
        #endregion

        #region Constructor
        public GeneralSettings(Host host)
        {
            Host = host;
            Text = Properties.Resources.Settings_General;
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
                Properties.Settings.Default.HistoryMaxCount = control.HistoryMaxCount;
            }
            base.SaveSettings();
        }

        public override Control CreateControl()
        {
            if (control != null)
            {
                control.HistoryMaxCount = Properties.Settings.Default.HistoryMaxCount;
                return control;
            }
            control = new GeneralSettingsControl();
            return control;
        }
        #endregion
    }
}
