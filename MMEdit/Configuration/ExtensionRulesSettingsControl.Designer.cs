namespace MMEdit.Configuration
{
    partial class ExtensionRulesSettingsControl
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
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtensionRulesSettingsControl));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelExtension = new System.Windows.Forms.Label();
            this.labelImportPlugin = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.textExtension = new System.Windows.Forms.TextBox();
            this.comboImpoetPlugins = new System.Windows.Forms.ComboBox();
            this.listExtensionRules = new System.Windows.Forms.ListView();
            this.columnExtension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnImportPlugin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonApply = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.labelExtension, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelImportPlugin, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonAdd, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.buttonRemove, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.textExtension, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.comboImpoetPlugins, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.listExtensionRules, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonApply, 2, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // labelExtension
            // 
            resources.ApplyResources(this.labelExtension, "labelExtension");
            this.labelExtension.Name = "labelExtension";
            // 
            // labelImportPlugin
            // 
            resources.ApplyResources(this.labelImportPlugin, "labelImportPlugin");
            this.labelImportPlugin.Name = "labelImportPlugin";
            // 
            // buttonAdd
            // 
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonRemove
            // 
            resources.ApplyResources(this.buttonRemove, "buttonRemove");
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.ButtonRemove_Click);
            // 
            // textExtension
            // 
            resources.ApplyResources(this.textExtension, "textExtension");
            this.textExtension.Name = "textExtension";
            this.textExtension.TextChanged += new System.EventHandler(this.TextExtension_TextChanged);
            // 
            // comboImpoetPlugins
            // 
            resources.ApplyResources(this.comboImpoetPlugins, "comboImpoetPlugins");
            this.comboImpoetPlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboImpoetPlugins.FormattingEnabled = true;
            this.comboImpoetPlugins.Name = "comboImpoetPlugins";
            this.comboImpoetPlugins.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ComboImpoetPlugins_Format);
            // 
            // listExtensionRules
            // 
            this.listExtensionRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnExtension,
            this.columnImportPlugin});
            this.tableLayoutPanel.SetColumnSpan(this.listExtensionRules, 4);
            resources.ApplyResources(this.listExtensionRules, "listExtensionRules");
            this.listExtensionRules.FullRowSelect = true;
            this.listExtensionRules.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listExtensionRules.HideSelection = false;
            this.listExtensionRules.MultiSelect = false;
            this.listExtensionRules.Name = "listExtensionRules";
            this.listExtensionRules.UseCompatibleStateImageBehavior = false;
            this.listExtensionRules.View = System.Windows.Forms.View.Details;
            this.listExtensionRules.SelectedIndexChanged += new System.EventHandler(this.ListExtensionRules_SelectedIndexChanged);
            // 
            // columnExtension
            // 
            resources.ApplyResources(this.columnExtension, "columnExtension");
            // 
            // columnImportPlugin
            // 
            resources.ApplyResources(this.columnImportPlugin, "columnImportPlugin");
            // 
            // buttonApply
            // 
            resources.ApplyResources(this.buttonApply, "buttonApply");
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // ExtensionRulesSettingsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel);
            resources.ApplyResources(this, "$this");
            this.Name = "ExtensionRulesSettingsControl";
            this.Load += new System.EventHandler(this.ExtensionRulesSettingsControl_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelExtension;
        private System.Windows.Forms.Label labelImportPlugin;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.TextBox textExtension;
        private System.Windows.Forms.ComboBox comboImpoetPlugins;
        private System.Windows.Forms.ListView listExtensionRules;
        private System.Windows.Forms.ColumnHeader columnExtension;
        private System.Windows.Forms.ColumnHeader columnImportPlugin;
        private System.Windows.Forms.Button buttonApply;
    }
}
