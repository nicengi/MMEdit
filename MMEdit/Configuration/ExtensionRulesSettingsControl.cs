using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MMEdit.Configuration
{
    internal partial class ExtensionRulesSettingsControl : UserControl
    {
        #region Fields
        private bool isSelected;
        private List<ExtensionRule> extensionRules;
        ComponentResourceManager resources = new ComponentResourceManager(typeof(ExtensionRulesSettingsControl));
        #endregion

        #region Constructor
        public ExtensionRulesSettingsControl(Host host)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            textExtension.AutoSize = false;
            listExtensionRules.Columns[1].Width = 400;
            Host = host;
        }
        #endregion

        #region Properties
        private Host Host { get; }

        public List<ExtensionRule> ExtensionRules
        {
            get
            {
                return extensionRules;
            }

            set
            {
                extensionRules = value;

                textExtension.Text = null;
                comboImpoetPlugins.Items.Clear();
                comboImpoetPlugins.Items.AddRange(Host.ImportPlugins.ToArray());
                if (comboImpoetPlugins.Items.Count > 0)
                    comboImpoetPlugins.SelectedIndex = 0;

                listExtensionRules.Items.Clear();
                foreach (ExtensionRule rule in ExtensionRules)
                {
                    listExtensionRules.Items.Add(new ListViewItem(new string[] { GetExt(rule.Extension), Host.ImportPlugins.Find(p => p.Guid == rule.ImporterGuid)?.Name ?? rule.ImporterGuid.ToString().ToUpper() })
                    {
                        Tag = rule,
                    });
                }
            }
        }

        private ExtensionRule SelectedRule { get; set; }

        private bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
                if (isSelected)
                {
                    buttonAdd.Text = resources.GetString("buttonApply.Text");
                    buttonAdd.Enabled = true;
                    buttonRemove.Enabled = true;
                }
                else
                {
                    buttonAdd.Text = resources.GetString("buttonAdd.Text");
                    buttonAdd.Enabled = GetExt(textExtension.Text) != null;
                    buttonRemove.Enabled = false;
                    //SelectedRule = null;
                }
            }
        }
        #endregion

        #region Methods

        #endregion



        private void ExtensionRulesSettingsControl_Load(object sender, EventArgs e)
        {
            Win32API.SetWindowTheme(listExtensionRules.Handle, "Explorer", null);
        }

        private string GetExt(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text == ".")
                return null;
            else
                return $"{(text[0] == '.' ? "" : ".")}{text}";
        }

        private void TextExtension_TextChanged(object sender, EventArgs e)
        {
            if (isSelected)
                listExtensionRules.SelectedItems.Clear();
            IsSelected = false;
        }


        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (IsSelected)
            {
                SelectedRule.ImporterGuid = (comboImpoetPlugins.SelectedItem as IImportPlugin).Guid;
                listExtensionRules.Items[listExtensionRules.SelectedIndices[0]].SubItems[1].Text =
                    Host.ImportPlugins.Find(i => i.Guid == SelectedRule.ImporterGuid)?.Name ?? SelectedRule.ImporterGuid.ToString().ToUpper();
            }
            else
            {
                ExtensionRule rule = new ExtensionRule(GetExt(textExtension.Text), (comboImpoetPlugins.SelectedItem as IImportPlugin).Guid);
                listExtensionRules.Items.Add(new ListViewItem(new string[] { rule.Extension, Host.ImportPlugins.Find(i => i.Guid == rule.ImporterGuid)?.Name ?? rule.ImporterGuid.ToString().ToUpper() })
                {
                    Tag = rule
                });
                ExtensionRules.Add(rule);
            }
            textExtension.Text = null;
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            ExtensionRules.Remove(SelectedRule);
            listExtensionRules.Items.Remove(listExtensionRules.Items[listExtensionRules.SelectedIndices[0]]);
        }

        private void ListExtensionRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listExtensionRules.SelectedIndices.Count > 0)
            {
                SelectedRule = listExtensionRules.Items[listExtensionRules.SelectedIndices[0]].Tag as ExtensionRule;
                textExtension.Text = SelectedRule.Extension;
                IsSelected = true;

                IImportPlugin plugin = Host.ImportPlugins.Find(i => i.Guid == SelectedRule.ImporterGuid);
                if (plugin != null)
                {
                    comboImpoetPlugins.SelectedItem = plugin;
                }
            }
            else
            {
                textExtension.Text = null;
            }
        }

        private void ComboImpoetPlugins_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is IImportPlugin plugin)
            {
                e.Value = plugin.Name;
            }
        }
    }
}
