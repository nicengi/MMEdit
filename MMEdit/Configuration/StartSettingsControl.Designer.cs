namespace MMEdit.Configuration
{
    partial class StartSettingsControl
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
            this.labelStartPlugins = new System.Windows.Forms.Label();
            this.comboStartPlugins = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelStartPlugins
            // 
            this.labelStartPlugins.AutoSize = true;
            this.labelStartPlugins.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelStartPlugins.Location = new System.Drawing.Point(0, 0);
            this.labelStartPlugins.Name = "labelStartPlugins";
            this.labelStartPlugins.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.labelStartPlugins.Size = new System.Drawing.Size(113, 15);
            this.labelStartPlugins.TabIndex = 1;
            this.labelStartPlugins.Text = "在启动时，打开(&P):";
            // 
            // comboStartPlugins
            // 
            this.comboStartPlugins.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboStartPlugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStartPlugins.FormattingEnabled = true;
            this.comboStartPlugins.Items.AddRange(new object[] {
            "(无)"});
            this.comboStartPlugins.Location = new System.Drawing.Point(0, 15);
            this.comboStartPlugins.Name = "comboStartPlugins";
            this.comboStartPlugins.Size = new System.Drawing.Size(472, 20);
            this.comboStartPlugins.TabIndex = 1;
            this.comboStartPlugins.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ComboStartPlugins_Format);
            // 
            // StartSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboStartPlugins);
            this.Controls.Add(this.labelStartPlugins);
            this.Name = "StartSettingsControl";
            this.Size = new System.Drawing.Size(472, 381);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStartPlugins;
        private System.Windows.Forms.ComboBox comboStartPlugins;
    }
}
