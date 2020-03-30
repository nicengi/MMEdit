namespace MMEdit.Configuration
{
    partial class GeneralSettingsControl
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelHistoryMaxCount = new System.Windows.Forms.Label();
            this.comboHistoryMaxCount = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.labelHistoryMaxCount, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.comboHistoryMaxCount, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(472, 381);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelHistoryMaxCount
            // 
            this.labelHistoryMaxCount.AutoSize = true;
            this.labelHistoryMaxCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHistoryMaxCount.Location = new System.Drawing.Point(3, 0);
            this.labelHistoryMaxCount.Name = "labelHistoryMaxCount";
            this.labelHistoryMaxCount.Size = new System.Drawing.Size(185, 26);
            this.labelHistoryMaxCount.TabIndex = 1;
            this.labelHistoryMaxCount.Text = "在菜单中显示的历史项目数量(&M):";
            this.labelHistoryMaxCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboHistoryMaxCount
            // 
            this.comboHistoryMaxCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHistoryMaxCount.FormattingEnabled = true;
            this.comboHistoryMaxCount.Location = new System.Drawing.Point(194, 3);
            this.comboHistoryMaxCount.Name = "comboHistoryMaxCount";
            this.comboHistoryMaxCount.Size = new System.Drawing.Size(50, 20);
            this.comboHistoryMaxCount.TabIndex = 1;
            // 
            // GeneralSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "GeneralSettingsControl";
            this.Size = new System.Drawing.Size(472, 381);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelHistoryMaxCount;
        private System.Windows.Forms.ComboBox comboHistoryMaxCount;
    }
}
