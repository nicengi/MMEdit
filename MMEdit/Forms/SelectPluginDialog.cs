using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MMEdit.Forms
{
    public partial class SelectPluginDialog : Form
    {
        #region Fields
        List<IPlugin> pluginList;
        #endregion

        #region Constructor
        public SelectPluginDialog()
        {
            InitializeComponent();
            Text = Util.AssemblyProduct;
        }
        #endregion

        #region Properties
        public List<IPlugin> PluginList
        {
            get
            {
                return pluginList;
            }

            set
            {
                pluginList = value;

                comboPluginList.Items.Clear();
                foreach (IPlugin plugin in pluginList)
                {
                    comboPluginList.Items.Add(plugin.Name);
                }

                if (comboPluginList.Items.Count > 0)
                {
                    comboPluginList.SelectedIndex = 0;
                }
            }
        }

        public IPlugin SelectedPlugin
        {
            get
            {
                return PluginList[comboPluginList.SelectedIndex];
            }
        }

        public int SelectedIndex
        {
            get
            {
                return comboPluginList.SelectedIndex;
            }
        }
        #endregion

        #region Methods
        private void ComboPluginList_SelectedIndexChanged(object sender, EventArgs e)
        {
            IPlugin plugin = PluginList[comboPluginList.SelectedIndex];
            labelDescription.Text = plugin.Description;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
