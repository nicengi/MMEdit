using MMEdit.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MMEdit
{
    public partial class MainForm : Form, IMainForm
    {
        #region Fields
        private SelectPluginDialog selectPluginDialog = new SelectPluginDialog();
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            IsSaved = true;
            Host = new Host(this);
            Host.PluginLoaded += Host_PluginLoaded;
            Host.FileStatusChanged += Host_FileStatusChanged;
            Host.LoadPlugins();

            AutoScaleMode = AutoScaleMode.None;
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

#if DEBUG
            foreach (var item in Host.Plugins)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Version: {item.Version}");
                Console.WriteLine($"Guid: {item.Guid}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"DataPath:{Host.GetPluginDataPath(item)}");
            }
#endif
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取插件宿主。
        /// </summary>
        private Host Host { get; }

        /// <summary>
        /// 获取或设置 <see cref="ObjectFX"/> 的导入程序。
        /// </summary>
        public IImportPlugin Importer { get; private set; }

        /// <summary>
        /// 获取默认的导出程序。
        /// </summary>
        public IExportPlugin DefaultExporter => Importer as IExportPlugin;

        /// <summary>
        /// 获取或设置 <see cref="MMEdit.ObjectFX"/>。
        /// </summary>
        public ObjectFX ObjectFX { get; private set; }

        /// <summary>
        /// 获取或设置文件名。
        /// </summary>
        public string Filename { get; private set; }

        /// <summary>
        /// 获取或设置文件已保存。
        /// </summary>
        public bool IsSaved { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// 从打开文件对话框打开文件。
        /// </summary>
        public void OpenFX()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                IImportPlugin importer = Host.ImportPlugins[openFileDialog.FilterIndex - 1];
                OpenFX(importer, openFileDialog.FileName);
            }
            else return;
        }

        /// <summary>
        /// 从指定的路径打开文件。
        /// </summary>
        /// <param name="path"></param>
        public void OpenFX(string path)
        {
            List<IImportPlugin> importerList = Host.ImportPlugins.FindAll(p => p.IsImportable(path));

            if (importerList.Count == 1)
            {
                OpenFX(importerList[0], path);
            }
            else
            {
                selectPluginDialog.Text = "选择导入器";
                selectPluginDialog.PluginList = importerList.ConvertAll<IPlugin>(p => p);

                if (selectPluginDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenFX((IImportPlugin)selectPluginDialog.SelectedPlugin, path);
                }
            }
        }

        /// <summary>
        /// 从指定的历史项打开文件。
        /// </summary>
        /// <param name="history"></param>
        public void OpenFX(HistoryItem history)
        {
            IImportPlugin importer = Host.GetPlugin(history.ImporterGuid) as IImportPlugin;

            if (importer == null)
            {
                MessageBox.Show($"无法从历史记录打开文件，导入程序(Guid:{history.ImporterGuid})已无法找到。", "打开", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(history.Filename))
            {
                MessageBox.Show($"无法从历史记录打开文件，文件“{history.Filename}”不存在。", "打开", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenFX(importer, history.Filename);
        }

        private void OpenFX(IImportPlugin importer, string path)
        {
            Filename = path;
            Importer = importer;

            try
            {
                ObjectFX = Importer.Import(path) ?? throw new Exception($"“{Importer.Name}(Guid:{Importer.Guid})”未能正确导入文件。返回值是 null。");
            }
            catch (Exception e)
            {
                Filename = null;
                Importer = null;
                ObjectFX = null;

                MessageBox.Show(e.Message, "打开", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            panelWidget.Visible = false;
            panelWidget.SuspendLayout();
            panelWidget.Controls.Clear();

            WidgetControl widget;
            try
            {
                widget = Host.CreateWidget(ObjectFX.WidgetID, ObjectFX) ?? new Widgets.MessageWidget($"没有找到小部件“{ObjectFX.WidgetID}”。");
            }
            catch (Exception e)
            {
                widget = new Widgets.MessageWidget($"{e.Message}");
            }

            panelWidget.Controls.Add(widget);
            panelWidget.ResumeLayout();
            panelWidget.Visible = true;

            Host.OnFileStatusChanged(new FileStatusEventArgs(FileStatus.Opened));
        }

        public void RefreshFX()
        {
            OpenFX(Importer, Filename);
        }

        public void SaveFX()
        {
            SaveFX(Filename);
        }

        /// <summary>
        /// 将 <see cref="ObjectFX"/> 导出到指定的路径。
        /// </summary>
        /// <param name="path"></param>
        public void SaveFX(string path)
        {
            IExportPlugin exporter = DefaultExporter;

            if (exporter == null || string.IsNullOrWhiteSpace(path))
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(path);
                saveFileDialog.FileName = Path.GetFileName(path);
                saveFileDialog.Filter = null;

                List<IExportPlugin> exporterList = Host.ExportPlugins.FindAll(e => e.IsExportable(ObjectFX));
                exporterList.ForEach(p => saveFileDialog.CombineFilter(getFilter(p.Caption, p.Pattern)));

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    exporter = exporterList[saveFileDialog.FilterIndex - 1];
                    path = saveFileDialog.FileName;
                }
                else return;
            }

            Filename = path;
            exporter.Export(ObjectFX, path);
            Host.OnFileStatusChanged(new FileStatusEventArgs(FileStatus.Saved));
        }

        private static string getFilter(string caption, string pattern)
        {
            return $"{caption.Replace("|", "")}|{pattern.Replace("|", "")}";
        }

        private void Host_PluginLoaded(object sender, PluginEventArgs e)
        {
            IPlugin plugin = e.Plugin;

            if (plugin is IImportPlugin import)
            {
                openFileDialog.CombineFilter(getFilter(import.Caption, import.Pattern));
            }
            //if (plugin is IExportPlugin export)
            //{
            //    saveFileDialog.CombineFilter(getFilter(export.Caption, export.Pattern));
            //}
            //throw new PluginLoadException($"{e.Plugin} loaded.");
        }

        private void Host_FileStatusChanged(object sender, FileStatusEventArgs e)
        {
            Text = string.IsNullOrWhiteSpace(Filename) ? "MMEdit" : $"{(Settings.Default.AutoSave ? "" : (e.Status == FileStatus.Changed ? " * " : ""))}{Path.GetFileName(Filename)} - MMEdit";

            if (e.Status == FileStatus.Saved || e.Status == FileStatus.Opened)
            {
                IsSaved = true;
                Host.InsertHistoryItem(new HistoryItem(Filename, Importer.Guid, Importer.Image?.GetThumbnail(16, 16)));
            }
            else IsSaved = false;

            if (Settings.Default.AutoSave && e.Status == FileStatus.Changed)
            {
                SaveFX(Filename);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Settings.Default.MainForm_Size != new Size(0, 0))
                Size = Settings.Default.MainForm_Size;

            if (Settings.Default.MainForm_Location != new Point(0, 0))
                Location = Settings.Default.MainForm_Location;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsSaved)
            {
                DialogResult result = MessageBox.Show($"是否保存文件“{Filename ?? "(空)"}”？", "保存", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                switch (result)
                {
                    case DialogResult.Yes: SaveFX(Filename); break;
                    case DialogResult.Cancel: e.Cancel = true; break;
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.MainForm_Size = Size;
            Settings.Default.MainForm_Location = Location;
            Settings.Default.Save();
            Host.SerializeHistories();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length == 1)
                e.Effect = Host.ImportPlugins.FindIndex(p => p.IsImportable(files[0])) > -1 ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length == 1)
                OpenFX(files[0]);
        }

        private void MenuItem_File_DropDownOpening(object sender, EventArgs e)
        {
            MenuItem_Open.Enabled = Host.ImportPlugins.Count > 0;
            MenuItem_Save.Enabled = ObjectFX != null && DefaultExporter != null;
            MenuItem_SaveAs.Enabled = ObjectFX != null && Host.ExportPlugins.Count > 0;
            MenuItem_AutoSave.Checked = Settings.Default.AutoSave;

            Separator_4.Visible =
            MenuItem_History_Clear.Visible =
            MenuItem_History.Visible = Host.Histories.Count > 0;

            MenuItem_History.DropDownItems.Clear();
            Host.Histories.ForEach(h => MenuItem_History.DropDownItems.Add(h.Filename, h.Image, MenuItem_History_DropDownItem_Click));
        }

        private void MenuItem_History_DropDownItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            OpenFX(Host.Histories.Find(h => h.Filename == item.Text));
        }

        private void MenuItem_Open_Click(object sender, EventArgs e)
        {
            OpenFX();
        }

        private void MenuItem_Save_Click(object sender, EventArgs e)
        {
            SaveFX(Filename);
        }

        private void MenuItem_SaveAs_Click(object sender, EventArgs e)
        {
            SaveFX(null);
        }

        private void MenuItem_AutoSave_Click(object sender, EventArgs e)
        {
            Settings.Default.AutoSave =
            MenuItem_AutoSave.Checked = !MenuItem_AutoSave.Checked;

            if (Settings.Default.AutoSave && !IsSaved)
            {
                SaveFX(Filename);
            }
        }

        private void MenuItem_Settings_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_History_Clear_Click(object sender, EventArgs e)
        {
            Host.Histories.Clear();
        }

        private void MenuItem_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuItem_About_Click(object sender, EventArgs e)
        {
            string text = $"{AssemblyProduct}\n{string.Format("版本 {0}", AssemblyVersion)}\n{AssemblyCopyright}\n\n{AssemblyDescription}";
            MessageBox.Show(text, $"关于 {AssemblyTitle}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region 程序集特性访问器
        private string AssemblyTitle
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

        private string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private string AssemblyDescription
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

        private string AssemblyProduct
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

        private string AssemblyCopyright
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

        private string AssemblyCompany
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
    }
}
