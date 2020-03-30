using MMEdit.Configuration;
using MMEdit.Forms;
using MMEdit.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Collections;

namespace MMEdit.Forms
{
    internal partial class MainForm : Form
    {
        #region Fields
        private AboutForm aboutForm;
        private SettingsForm settingsForm;
        #endregion

        #region Constructor
        public MainForm(Host host)
        {
            InitializeComponent();
            Host = host;

            foreach (IImportPlugin plugin in Host.ImportPlugins)
            {
                openFileDialog.CombineFilter(getFilter(plugin.Caption, plugin.Pattern));

                string getFilter(string caption, string pattern)
                {
                    return $"{caption.Replace("|", "")}|{pattern.Replace("|", "")}";
                }
            }
        }
        #endregion

        #region Properties
        private AboutForm AboutForm
        {
            get
            {
                if (aboutForm == null && Host != null)
                {
                    aboutForm = new AboutForm(Host);
                }
                return aboutForm;
            }
        }

        private SettingsForm SettingsForm
        {
            get
            {
                if (settingsForm == null && Host != null)
                {
                    settingsForm = new SettingsForm(Host.Settings);
                }
                return settingsForm;
            }
        }

        private Host Host { get; }

        public ObjectEdit ActiveEdit { get; private set; }
        #endregion

        #region Methods

        private void UpdateWidget(ObjectEdit edit)
        {
            try
            {
                Control widget = Host.CreateWidget<Control>(edit.ObjectFX)
                    ?? new MessageWidget(string.Format(Resources.Msg_WidgetNotFound, edit.ObjectFX.WidgetID));
                SetWidgetControl(widget);
            }
            catch (Exception e)
            {
                SetWidgetControl(new MessageWidget(e));
            }
        }

        private void SetWidgetControl(Control control)
        {
            panelWidget.SuspendLayout();
            panelWidget.Controls.Clear();
            panelWidget.Controls.Add(control);
            panelWidget.ResumeLayout();
            Focus(); //菜单快捷键失效问题。
        }

        private void SetStartControl()
        {
            if (Host.GetPlugin(Properties.Settings.Default.StartPage) is IStartPlugin start)
            {
                SetWidgetControl(start.CreateControl());
            }
            else
            {
                SetWidgetControl(null);
            }
        }

        public void ActivateEdit(ObjectEdit edit)
        {
            if (edit == null)
            {
                if (ActiveEdit != null)
                    ActiveEdit.OnStatusChanged(FileStatus.Closed);
                ActiveEdit = null;
                return;
            }

            if (ActiveEdit != null)
                ActiveEdit.StatusChanged -= Edit_FileStatusChanged;
            ActiveEdit = edit;
            ActiveEdit.StatusChanged += Edit_FileStatusChanged;
            ActiveEdit.OnStatusChanged(edit.IsSaved ? FileStatus.Opened : FileStatus.Changed);
        }

        private void Edit_FileStatusChanged(object sender, FileStatusEventArgs e)
        {
            Text = string.IsNullOrWhiteSpace(ActiveEdit.FileName) || e.Status == FileStatus.Closed ? Util.AssemblyProduct
                : $"{(Settings.Default.AutoSave ? "" : (e.Status == FileStatus.Changed ? "*" : ""))}{Path.GetFileName(ActiveEdit.FileName)} - {Util.AssemblyProduct}";

            if (e.Status == FileStatus.Changed && Settings.Default.AutoSave)
            {
                ActiveEdit.Save();
            }
            else if (e.Status == FileStatus.Opened || e.Status == FileStatus.Reloaded)
            {
                UpdateWidget(ActiveEdit);
            }
            else if (e.Status == FileStatus.Closed)
            {
                SetStartControl();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Settings.Default.MainForm_Size != new Size(0, 0))
                Size = Settings.Default.MainForm_Size;

            if (Settings.Default.MainForm_Location != new Point(0, 0))
                Location = Settings.Default.MainForm_Location;

            if (ActiveEdit == null)
                SetStartControl();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ActiveEdit != null && !ActiveEdit.IsSaved)
            {
                DialogResult result = MessageBox.Show(string.Format(Resources.Msg_SaveFileOrNot, ActiveEdit.FileName ?? Resources.Empty), Resources.Save, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                switch (result)
                {
                    case DialogResult.Yes: ActiveEdit.Save(); break;
                    case DialogResult.Cancel: e.Cancel = true; break;
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.MainForm_Size = Size;
            Settings.Default.MainForm_Location = Location;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (Host.ImportPlugins.FindIndex(p => p.IsImportable(file)) > -1)
                {
                    Host.OpenEdit(file, !(ModifierKeys == Keys.Shift));
                }
            }
        }

        private void MenuItem_File_DropDownOpening(object sender, EventArgs e)
        {
            MenuItem_Open.Enabled = Host.ImportPlugins.Count > 0;
            //MenuItem_Start.Visible = Host.GetPlugin(Properties.Settings.Default.StartPage) != null;
            MenuItem_Save.Enabled = ActiveEdit != null && ActiveEdit.Exporter != null;
            MenuItem_SaveAs.Enabled = ActiveEdit != null && Host.ExportPlugins.Count > 0;
            MenuItem_Close.Enabled = ActiveEdit != null;
            MenuItem_AutoSave.Checked = Settings.Default.AutoSave;

            Separator_4.Visible =
            MenuItem_History_Clear.Visible =
            MenuItem_History.Visible = Host.Histories.Count > 0;

            MenuItem_History.DropDownItems.Clear();
            Host.Histories.ForEach(h => MenuItem_History.DropDownItems.Add(h.FullName, h.Image, MenuItem_History_DropDownItem_Click));
        }

        private void MenuItem_Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                IImportPlugin importer = Host.ImportPlugins[openFileDialog.FilterIndex - 1];
                Host.OpenEdit(importer, openFileDialog.FileName);
            }
            else return;
        }

        private void MenuItem_Start_Click(object sender, EventArgs e)
        {
            ActivateEdit(null);
            SetStartControl();
        }

        private void MenuItem_Close_Click(object sender, EventArgs e)
        {
            ActivateEdit(null);
        }

        private void MenuItem_Save_Click(object sender, EventArgs e)
        {
            ActiveEdit.Save();
        }

        private void MenuItem_SaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(ActiveEdit.FileName);
            saveFileDialog.FileName = Path.GetFileName(ActiveEdit.FileName);
            saveFileDialog.Filter = null;

            List<IExportPlugin> exporterList = Host.ExportPlugins.FindAll(p => p.IsExportable(ActiveEdit.ObjectFX));
            exporterList.ForEach(p => saveFileDialog.CombineFilter(getFilter(p.Caption, p.Pattern)));

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ActiveEdit.Save(exporterList[saveFileDialog.FilterIndex - 1], saveFileDialog.FileName);
                Host.InsertHistory(new History(ActiveEdit.FileName, ActiveEdit.Importer.Guid, ActiveEdit.Importer.Image?.GetThumbnail(16, 16), DateTime.Now));
            }

            string getFilter(string caption, string pattern)
            {
                return $"{caption.Replace("|", "")}|{pattern.Replace("|", "")}";
            }
        }

        private void MenuItem_AutoSave_Click(object sender, EventArgs e)
        {
            Settings.Default.AutoSave =
            MenuItem_AutoSave.Checked = !MenuItem_AutoSave.Checked;

            if (Settings.Default.AutoSave && !ActiveEdit.IsSaved)
            {
                ActiveEdit.Save();
            }
        }

        private void MenuItem_Settings_Click(object sender, EventArgs e)
        {
            SettingsForm.ShowDialog();
        }

        private void MenuItem_History_DropDownItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Host.OpenEdit(Host.Histories.Find(h => h.FullName == item.Text));
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
            AboutForm.ShowDialog();
        }
        #endregion
    }
}
