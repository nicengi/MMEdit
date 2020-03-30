namespace MMEdit.Forms
{
    partial class AboutForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelMMEdit = new System.Windows.Forms.Label();
            this.labelPlugins = new System.Windows.Forms.Label();
            this.textPluginDescription = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelPluginDescription = new System.Windows.Forms.Label();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.listPlugins = new System.Windows.Forms.ListView();
            this.columnPlugin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelMMEditFramework = new System.Windows.Forms.Label();
            this.panelLinks = new System.Windows.Forms.Panel();
            this.linkProjectPage = new System.Windows.Forms.LinkLabel();
            this.linkGetPlugins = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel.SuspendLayout();
            this.panelLinks.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Name = "labelTitle";
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.labelMMEdit, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelPlugins, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.textPluginDescription, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.buttonOK, 2, 6);
            this.tableLayoutPanel.Controls.Add(this.labelPluginDescription, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.buttonCopy, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.listPlugins, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.labelMMEditFramework, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.panelLinks, 1, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // labelMMEdit
            // 
            resources.ApplyResources(this.labelMMEdit, "labelMMEdit");
            this.labelMMEdit.Name = "labelMMEdit";
            // 
            // labelPlugins
            // 
            resources.ApplyResources(this.labelPlugins, "labelPlugins");
            this.labelPlugins.Name = "labelPlugins";
            // 
            // textPluginDescription
            // 
            this.textPluginDescription.BackColor = System.Drawing.Color.White;
            this.textPluginDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel.SetColumnSpan(this.textPluginDescription, 2);
            resources.ApplyResources(this.textPluginDescription, "textPluginDescription");
            this.textPluginDescription.Name = "textPluginDescription";
            this.textPluginDescription.ReadOnly = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // labelPluginDescription
            // 
            resources.ApplyResources(this.labelPluginDescription, "labelPluginDescription");
            this.labelPluginDescription.Name = "labelPluginDescription";
            // 
            // buttonCopy
            // 
            resources.ApplyResources(this.buttonCopy, "buttonCopy");
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.ButtonCopy_Click);
            // 
            // listPlugins
            // 
            this.listPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPlugin});
            this.tableLayoutPanel.SetColumnSpan(this.listPlugins, 2);
            resources.ApplyResources(this.listPlugins, "listPlugins");
            this.listPlugins.FullRowSelect = true;
            this.listPlugins.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listPlugins.HideSelection = false;
            this.listPlugins.MultiSelect = false;
            this.listPlugins.Name = "listPlugins";
            this.tableLayoutPanel.SetRowSpan(this.listPlugins, 2);
            this.listPlugins.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listPlugins.UseCompatibleStateImageBehavior = false;
            this.listPlugins.View = System.Windows.Forms.View.Details;
            this.listPlugins.SelectedIndexChanged += new System.EventHandler(this.ListInstalledPlugins_SelectedIndexChanged);
            // 
            // columnPlugin
            // 
            resources.ApplyResources(this.columnPlugin, "columnPlugin");
            // 
            // labelMMEditFramework
            // 
            resources.ApplyResources(this.labelMMEditFramework, "labelMMEditFramework");
            this.tableLayoutPanel.SetColumnSpan(this.labelMMEditFramework, 2);
            this.labelMMEditFramework.Name = "labelMMEditFramework";
            // 
            // panelLinks
            // 
            this.panelLinks.Controls.Add(this.linkProjectPage);
            this.panelLinks.Controls.Add(this.linkGetPlugins);
            resources.ApplyResources(this.panelLinks, "panelLinks");
            this.panelLinks.Name = "panelLinks";
            // 
            // linkProjectPage
            // 
            this.linkProjectPage.ActiveLinkColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.linkProjectPage, "linkProjectPage");
            this.linkProjectPage.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkProjectPage.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkProjectPage.Name = "linkProjectPage";
            this.linkProjectPage.TabStop = true;
            this.linkProjectPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkProjectPage_LinkClicked);
            // 
            // linkGetPlugins
            // 
            this.linkGetPlugins.ActiveLinkColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.linkGetPlugins, "linkGetPlugins");
            this.linkGetPlugins.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkGetPlugins.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkGetPlugins.Name = "linkGetPlugins";
            this.linkGetPlugins.TabStop = true;
            this.linkGetPlugins.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkGetPlugins_LinkClicked);
            // 
            // AboutForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.AboutForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panelLinks.ResumeLayout(false);
            this.panelLinks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelMMEdit;
        private System.Windows.Forms.Label labelMMEditFramework;
        private System.Windows.Forms.Label labelPlugins;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelPluginDescription;
        private System.Windows.Forms.TextBox textPluginDescription;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.ListView listPlugins;
        private System.Windows.Forms.ColumnHeader columnPlugin;
        private System.Windows.Forms.LinkLabel linkProjectPage;
        private System.Windows.Forms.LinkLabel linkGetPlugins;
        private System.Windows.Forms.Panel panelLinks;
    }
}
