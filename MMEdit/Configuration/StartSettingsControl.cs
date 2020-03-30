using System;
using System.Windows.Forms;

namespace MMEdit.Configuration
{
    internal partial class StartSettingsControl : UserControl
    {
        #region Constructor
        public StartSettingsControl(Host host)
        {
            InitializeComponent();
            SuspendLayout();
            Dock = DockStyle.Fill;
            ResumeLayout(true);

            Host = host;
            comboStartPlugins.Items.AddRange(host.StartPlugins.ToArray());
            StartPlugin = Properties.Settings.Default.StartPage;
        }
        #endregion

        #region Properties
        private Host Host { get; }

        /// <summary>
        /// 获取选择的启动插件 GUID。
        /// </summary>
        public Guid StartPlugin
        {
            get
            {
                if (comboStartPlugins.SelectedItem is IStartPlugin startPlugin)
                {
                    return startPlugin.Guid;
                }
                return Guid.Empty;
            }

            set
            {
                comboStartPlugins.SelectedItem = Host.GetPlugin(value) ?? comboStartPlugins.Items[0];
            }
        }
        #endregion

        #region Methods
        private void ComboStartPlugins_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is IStartPlugin plugin)
            {
                e.Value = plugin.Name;
            }
        }
        #endregion
    }
}
