namespace MMEdit.Forms
{
    partial class SelectPluginDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelSelectPlugin = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.comboPluginList = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel.Controls.Add(this.labelSelectPlugin, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonCancel, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.buttonOK, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.labelDescription, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.comboPluginList, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(8, 4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(593, 222);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelSelectPlugin
            // 
            this.labelSelectPlugin.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.labelSelectPlugin, 3);
            this.labelSelectPlugin.Location = new System.Drawing.Point(3, 0);
            this.labelSelectPlugin.Name = "labelSelectPlugin";
            this.labelSelectPlugin.Size = new System.Drawing.Size(134, 17);
            this.labelSelectPlugin.TabIndex = 1;
            this.labelSelectPlugin.Text = "选择导入和导出程序(&S):";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(498, 189);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(92, 30);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOK.Location = new System.Drawing.Point(400, 189);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(92, 30);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.labelDescription, 3);
            this.labelDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDescription.Location = new System.Drawing.Point(3, 48);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(587, 138);
            this.labelDescription.TabIndex = 2;
            // 
            // comboPluginList
            // 
            this.tableLayoutPanel.SetColumnSpan(this.comboPluginList, 3);
            this.comboPluginList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboPluginList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPluginList.FormattingEnabled = true;
            this.comboPluginList.Location = new System.Drawing.Point(3, 20);
            this.comboPluginList.Name = "comboPluginList";
            this.comboPluginList.Size = new System.Drawing.Size(587, 25);
            this.comboPluginList.TabIndex = 1;
            this.comboPluginList.SelectedIndexChanged += new System.EventHandler(this.ComboPluginList_SelectedIndexChanged);
            // 
            // SelectPluginDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(609, 238);
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(615, 244);
            this.Name = "SelectPluginDialog";
            this.Padding = new System.Windows.Forms.Padding(8, 4, 8, 12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SelectPluginDialog";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelSelectPlugin;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.ComboBox comboPluginList;
    }
}