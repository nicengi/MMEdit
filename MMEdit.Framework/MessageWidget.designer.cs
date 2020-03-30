namespace MMEdit
{
    partial class MessageWidget
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
            this.pictureIcon = new System.Windows.Forms.PictureBox();
            this.linkMore = new System.Windows.Forms.LinkLabel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.pictureIcon, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.linkMore, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.labelMessage, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(300, 24);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // pictureIcon
            // 
            this.pictureIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureIcon.Location = new System.Drawing.Point(0, 0);
            this.pictureIcon.Margin = new System.Windows.Forms.Padding(0);
            this.pictureIcon.Name = "pictureIcon";
            this.pictureIcon.Size = new System.Drawing.Size(24, 24);
            this.pictureIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureIcon.TabIndex = 1;
            this.pictureIcon.TabStop = false;
            // 
            // linkMore
            // 
            this.linkMore.ActiveLinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkMore.AutoSize = true;
            this.linkMore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkMore.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkMore.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkMore.Location = new System.Drawing.Point(107, 0);
            this.linkMore.Margin = new System.Windows.Forms.Padding(0);
            this.linkMore.Name = "linkMore";
            this.linkMore.Size = new System.Drawing.Size(193, 24);
            this.linkMore.TabIndex = 2;
            this.linkMore.TabStop = true;
            this.linkMore.Text = "More";
            this.linkMore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkMore.VisitedLinkColor = System.Drawing.SystemColors.HotTrack;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelMessage.Location = new System.Drawing.Point(24, 0);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(83, 24);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.Text = "MessageWidget";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MessageWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "MessageWidget";
            this.Size = new System.Drawing.Size(300, 24);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.PictureBox pictureIcon;
        private System.Windows.Forms.LinkLabel linkMore;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}
