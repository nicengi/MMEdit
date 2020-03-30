using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMEdit.Configuration
{
    internal partial class GeneralSettingsControl : UserControl
    {
        #region Constructor
        public GeneralSettingsControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            comboHistoryMaxCount.Items.AddRange(new object[] { 5, 10, 15, 20, 25, 30 });
            comboHistoryMaxCount.SelectedItem = Properties.Settings.Default.HistoryMaxCount;
        }
        #endregion

        #region Properties
        public int HistoryMaxCount
        {
            get
            {
                return (int)comboHistoryMaxCount.SelectedItem;
            }

            set
            {
                comboHistoryMaxCount.SelectedItem = value;
            }
        }
        #endregion
    }
}
