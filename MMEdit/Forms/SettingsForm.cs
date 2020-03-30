using MMEdit.Configuration;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MMEdit.Forms
{
    internal partial class SettingsForm : Form
    {
        #region Constructor
        public SettingsForm(IEnumerable<ICustomSettings> customSettings)
        {
            if (customSettings == null)
                throw new ArgumentNullException(nameof(customSettings));
            Settings = new List<ICustomSettings>(customSettings);

            InitializeComponent();

            foreach (ICustomSettings settings in Settings)
            {
                TreeNode node = CreateNode(settings);
                if (node.Nodes.Count == 0)
                {
                    node.Nodes.Add(node.Clone() as TreeNode);
                }
                treeSettings.Nodes.Add(node);
            }

            if (treeSettings.Nodes.Count > 0)
            {
                treeSettings.SelectedNode = treeSettings.Nodes[0];
            }
        }
        #endregion

        #region Properties
        private List<ICustomSettings> Settings { get; }
        #endregion

        #region Methods
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Win32API.SetWindowTheme(treeSettings.Handle, "Explorer", null);

            if (treeSettings.SelectedNode?.Level == 0)
            {
                treeSettings.SelectedNode = treeSettings.SelectedNode.Nodes[0];
            }
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                foreach (ICustomSettings settings in Settings)
                {
                    settings.Save();
                }
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TreeSettings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            panelSettings.SuspendLayout();
            panelSettings.Controls.Clear();
            panelSettings.Controls.Add((e.Node.Tag as ICustomSettings).CreateControl());
            panelSettings.ResumeLayout();
        }

        private static TreeNode CreateNode(ICustomSettings settings)
        {
            TreeNode node = new TreeNode(settings.Text)
            {
                Tag = settings
            };

            foreach (ICustomSettings children in settings.Settings)
            {
                node.Nodes.Add(CreateNode(children));
            }
            return node;
        }
        #endregion
    }
}
