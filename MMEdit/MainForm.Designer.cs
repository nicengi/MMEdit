namespace MMEdit
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                Host.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator_1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_AutoSave = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator_2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator_3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_History = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_History_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator_4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Tool = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panelWidget = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File,
            this.MenuItem_Edit,
            this.MenuItem_Tool,
            this.MenuItem_Help});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(404, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // MenuItem_File
            // 
            this.MenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Open,
            this.Separator_1,
            this.MenuItem_Save,
            this.MenuItem_SaveAs,
            this.MenuItem_AutoSave,
            this.Separator_2,
            this.MenuItem_Settings,
            this.Separator_3,
            this.MenuItem_History,
            this.MenuItem_History_Clear,
            this.Separator_4,
            this.MenuItem_Exit});
            this.MenuItem_File.Name = "MenuItem_File";
            this.MenuItem_File.Size = new System.Drawing.Size(58, 21);
            this.MenuItem_File.Text = "文件(&F)";
            this.MenuItem_File.DropDownOpening += new System.EventHandler(this.MenuItem_File_DropDownOpening);
            // 
            // MenuItem_Open
            // 
            this.MenuItem_Open.Image = global::MMEdit.Properties.Resources.folder_open_document;
            this.MenuItem_Open.Name = "MenuItem_Open";
            this.MenuItem_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuItem_Open.Size = new System.Drawing.Size(215, 22);
            this.MenuItem_Open.Text = "打开(&O)";
            this.MenuItem_Open.Click += new System.EventHandler(this.MenuItem_Open_Click);
            // 
            // Separator_1
            // 
            this.Separator_1.Name = "Separator_1";
            this.Separator_1.Size = new System.Drawing.Size(212, 6);
            // 
            // MenuItem_Save
            // 
            this.MenuItem_Save.Image = global::MMEdit.Properties.Resources.disk;
            this.MenuItem_Save.Name = "MenuItem_Save";
            this.MenuItem_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuItem_Save.Size = new System.Drawing.Size(215, 22);
            this.MenuItem_Save.Text = "保存(&S)";
            this.MenuItem_Save.Click += new System.EventHandler(this.MenuItem_Save_Click);
            // 
            // MenuItem_SaveAs
            // 
            this.MenuItem_SaveAs.Name = "MenuItem_SaveAs";
            this.MenuItem_SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.MenuItem_SaveAs.Size = new System.Drawing.Size(215, 22);
            this.MenuItem_SaveAs.Text = "另存为(&A)...";
            this.MenuItem_SaveAs.Click += new System.EventHandler(this.MenuItem_SaveAs_Click);
            // 
            // MenuItem_AutoSave
            // 
            this.MenuItem_AutoSave.Name = "MenuItem_AutoSave";
            this.MenuItem_AutoSave.Size = new System.Drawing.Size(215, 22);
            this.MenuItem_AutoSave.Text = "自动保存(&U)";
            this.MenuItem_AutoSave.Click += new System.EventHandler(this.MenuItem_AutoSave_Click);
            // 
            // Separator_2
            // 
            this.Separator_2.Name = "Separator_2";
            this.Separator_2.Size = new System.Drawing.Size(212, 6);
            // 
            // MenuItem_Settings
            // 
            this.MenuItem_Settings.Name = "MenuItem_Settings";
            this.MenuItem_Settings.Size = new System.Drawing.Size(215, 22);
            this.MenuItem_Settings.Text = "设置(&I)...";
            this.MenuItem_Settings.Visible = false;
            this.MenuItem_Settings.Click += new System.EventHandler(this.MenuItem_Settings_Click);
            // 
            // Separator_3
            // 
            this.Separator_3.Name = "Separator_3";
            this.Separator_3.Size = new System.Drawing.Size(212, 6);
            this.Separator_3.Visible = false;
            // 
            // MenuItem_History
            // 
            this.MenuItem_History.Image = global::MMEdit.Properties.Resources.clock_history;
            this.MenuItem_History.Name = "MenuItem_History";
            this.MenuItem_History.Size = new System.Drawing.Size(215, 22);
            this.MenuItem_History.Text = "最近使用的文件";
            // 
            // MenuItem_History_Clear
            // 
            this.MenuItem_History_Clear.Name = "MenuItem_History_Clear";
            this.MenuItem_History_Clear.Size = new System.Drawing.Size(215, 22);
            this.MenuItem_History_Clear.Text = "清空文件列表(&C)";
            this.MenuItem_History_Clear.Click += new System.EventHandler(this.MenuItem_History_Clear_Click);
            // 
            // Separator_4
            // 
            this.Separator_4.Name = "Separator_4";
            this.Separator_4.Size = new System.Drawing.Size(212, 6);
            // 
            // MenuItem_Exit
            // 
            this.MenuItem_Exit.Name = "MenuItem_Exit";
            this.MenuItem_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.MenuItem_Exit.Size = new System.Drawing.Size(215, 22);
            this.MenuItem_Exit.Text = "退出(&E)";
            this.MenuItem_Exit.Click += new System.EventHandler(this.MenuItem_Exit_Click);
            // 
            // MenuItem_Edit
            // 
            this.MenuItem_Edit.Name = "MenuItem_Edit";
            this.MenuItem_Edit.Size = new System.Drawing.Size(59, 21);
            this.MenuItem_Edit.Text = "编辑(&E)";
            this.MenuItem_Edit.Visible = false;
            // 
            // MenuItem_Tool
            // 
            this.MenuItem_Tool.Name = "MenuItem_Tool";
            this.MenuItem_Tool.Size = new System.Drawing.Size(59, 21);
            this.MenuItem_Tool.Text = "工具(&T)";
            this.MenuItem_Tool.Visible = false;
            // 
            // MenuItem_Help
            // 
            this.MenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_About});
            this.MenuItem_Help.Name = "MenuItem_Help";
            this.MenuItem_Help.Size = new System.Drawing.Size(61, 21);
            this.MenuItem_Help.Text = "帮助(&H)";
            // 
            // MenuItem_About
            // 
            this.MenuItem_About.Name = "MenuItem_About";
            this.MenuItem_About.Size = new System.Drawing.Size(166, 22);
            this.MenuItem_About.Text = "关于 MMEdit(&A)";
            this.MenuItem_About.Click += new System.EventHandler(this.MenuItem_About_Click);
            // 
            // panelWidget
            // 
            this.panelWidget.AutoScroll = true;
            this.panelWidget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWidget.Location = new System.Drawing.Point(0, 25);
            this.panelWidget.Name = "panelWidget";
            this.panelWidget.Size = new System.Drawing.Size(404, 436);
            this.panelWidget.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 461);
            this.Controls.Add(this.panelWidget);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "MMEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Open;
        private System.Windows.Forms.ToolStripSeparator Separator_1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Save;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_AutoSave;
        private System.Windows.Forms.ToolStripSeparator Separator_2;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Settings;
        private System.Windows.Forms.ToolStripSeparator Separator_3;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_History;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_History_Clear;
        private System.Windows.Forms.ToolStripSeparator Separator_4;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Tool;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_About;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Panel panelWidget;
    }
}

