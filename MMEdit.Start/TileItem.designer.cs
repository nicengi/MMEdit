namespace MMEdit
{
    partial class TileItem
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureImage = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.pictureImage, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelDateTime, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.labelFullName, 1, 1);
            this.tableLayoutPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(542, 48);
            this.tableLayoutPanel.TabIndex = 0;
            this.tableLayoutPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HistoryItem_MouseDown);
            this.tableLayoutPanel.MouseEnter += new System.EventHandler(this.HistoryItem_MouseEnter);
            this.tableLayoutPanel.MouseLeave += new System.EventHandler(this.HistoryItem_MouseLeave);
            this.tableLayoutPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HistoryItem_MouseUp);
            // 
            // pictureImage
            // 
            this.pictureImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureImage.Location = new System.Drawing.Point(0, 0);
            this.pictureImage.Margin = new System.Windows.Forms.Padding(0);
            this.pictureImage.Name = "pictureImage";
            this.pictureImage.Size = new System.Drawing.Size(24, 24);
            this.pictureImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureImage.TabIndex = 0;
            this.pictureImage.TabStop = false;
            this.pictureImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HistoryItem_MouseDown);
            this.pictureImage.MouseEnter += new System.EventHandler(this.HistoryItem_MouseEnter);
            this.pictureImage.MouseLeave += new System.EventHandler(this.HistoryItem_MouseLeave);
            this.pictureImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HistoryItem_MouseUp);
            // 
            // labelName
            // 
            this.labelName.AutoEllipsis = true;
            this.labelName.AutoSize = true;
            this.labelName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.Location = new System.Drawing.Point(30, 0);
            this.labelName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(506, 24);
            this.labelName.TabIndex = 0;
            this.labelName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HistoryItem_MouseDown);
            this.labelName.MouseEnter += new System.EventHandler(this.HistoryItem_MouseEnter);
            this.labelName.MouseLeave += new System.EventHandler(this.HistoryItem_MouseLeave);
            this.labelName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HistoryItem_MouseUp);
            // 
            // labelDateTime
            // 
            this.labelDateTime.AutoSize = true;
            this.labelDateTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDateTime.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelDateTime.Location = new System.Drawing.Point(542, 0);
            this.labelDateTime.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelDateTime.Name = "labelDateTime";
            this.labelDateTime.Size = new System.Drawing.Size(1, 24);
            this.labelDateTime.TabIndex = 0;
            this.labelDateTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelDateTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HistoryItem_MouseDown);
            this.labelDateTime.MouseEnter += new System.EventHandler(this.HistoryItem_MouseEnter);
            this.labelDateTime.MouseLeave += new System.EventHandler(this.HistoryItem_MouseLeave);
            this.labelDateTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HistoryItem_MouseUp);
            // 
            // labelFullName
            // 
            this.labelFullName.AutoEllipsis = true;
            this.labelFullName.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.labelFullName, 2);
            this.labelFullName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFullName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelFullName.Location = new System.Drawing.Point(30, 24);
            this.labelFullName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(509, 24);
            this.labelFullName.TabIndex = 0;
            this.labelFullName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HistoryItem_MouseDown);
            this.labelFullName.MouseEnter += new System.EventHandler(this.HistoryItem_MouseEnter);
            this.labelFullName.MouseLeave += new System.EventHandler(this.HistoryItem_MouseLeave);
            this.labelFullName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HistoryItem_MouseUp);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Copy});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // MenuItem_Copy
            // 
            this.MenuItem_Copy.Image = global::MMEdit.Properties.Resources.documents;
            this.MenuItem_Copy.Name = "MenuItem_Copy";
            this.MenuItem_Copy.Size = new System.Drawing.Size(124, 22);
            this.MenuItem_Copy.Text = "复制路径";
            this.MenuItem_Copy.Click += new System.EventHandler(this.MenuItem_Copy_Click);
            // 
            // TileItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "TileItem";
            this.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
            this.Size = new System.Drawing.Size(558, 84);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TileItem_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HistoryItem_MouseDown);
            this.MouseEnter += new System.EventHandler(this.HistoryItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.HistoryItem_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HistoryItem_MouseUp);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureImage)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox pictureImage;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDateTime;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Copy;
    }
}
