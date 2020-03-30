using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace MMEdit.Forms
{
    partial class AboutForm : Form
    {
        #region Constructor
        public AboutForm(Host host)
        {
            InitializeComponent();

            Text = string.Format(Text, AssemblyProduct);
            labelTitle.Text = AssemblyTitle;
            labelMMEdit.Text = string.Format(labelMMEdit.Text, AssemblyTitle, AssemblyVersion, AssemblyCopyright);

            foreach (IPlugin plugin in host.Plugins)
            {
                listPlugins.Items.Add(new ListViewItem()
                {
                    Text = $"{plugin.Name}{(string.IsNullOrWhiteSpace(plugin.Version) ? "" : " — ")}{plugin.Version}",
                    Tag = plugin,
                });
            }
        }
        #endregion

        #region Properties
        #region 程序集特性访问器

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
        #endregion

        #region Methods
        private void AboutForm_Load(object sender, EventArgs e)
        {
            Win32API.SetWindowTheme(listPlugins.Handle, "Explorer", null);
            if (listPlugins.Items.Count > 0)
            {
                listPlugins.Items[0].Selected = true;
                listPlugins.Select();
            }
        }

        private void AboutForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            Process.Start("https://github.com/nicengi/MMEdit");
            e.Cancel = true;
        }

        private void LinkProjectPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/nicengi/MMEdit");
        }

        private void LinkGetPlugins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/MMEdit");
        }

        private void ListInstalledPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPlugins.SelectedIndices.Count > 0)
            {
                IPlugin plugin = listPlugins.SelectedItems[0].Tag as IPlugin;
                textPluginDescription.Text = plugin.Description;
            }
        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            if (listPlugins.SelectedIndices.Count > 0)
            {
                IPlugin plugin = listPlugins.SelectedItems[0].Tag as IPlugin;
                Clipboard.SetText($"{plugin.Name}  {plugin.Version} — {plugin.Guid.ToString().ToUpper()}\r\n{plugin.Description}");
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
