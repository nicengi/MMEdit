using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMEdit
{
    [DefaultEvent("Click")]
    public partial class TileItem : UserControl
    {
        #region Fields
        private DateTime dateTime;
        #endregion

        #region Constructor
        public TileItem()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            labelDateTime.Text = new DateTime().ToString();

            labelName.Click += (s, e) => OnClick(e);
            labelFullName.Click += (s, e) => OnClick(e);
            labelDateTime.Click += (s, e) => OnClick(e);
            tableLayoutPanel.Click += (s, e) => OnClick(e);
        }
        #endregion

        #region Properties
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
                labelName.Text = value;
            }
        }

        [Browsable(true)]
        public Image Image
        {
            get
            {
                return pictureImage.Image;
            }

            set
            {
                pictureImage.Image = value;
            }
        }

        [Browsable(true)]
        public string FullName
        {
            get
            {
                return labelFullName.Text;
            }

            set
            {
                labelFullName.Text = value;
            }
        }

        [Browsable(true)]
        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }

            set
            {
                dateTime = value;
                labelDateTime.Text = dateTime.ToString("yyyy/M/d HH:mm");
            }
        }
        #endregion

        #region Methods
        private void HistoryItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BackColor = SystemColors.Highlight;
                labelName.ForeColor = SystemColors.HighlightText;
                labelFullName.ForeColor = SystemColors.HighlightText;
                labelDateTime.ForeColor = SystemColors.HighlightText;
            }
        }

        private void HistoryItem_MouseEnter(object sender, EventArgs e)
        {
            BackColor = SystemColors.GradientInactiveCaption;
        }

        private void HistoryItem_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Parent.BackColor;
            labelName.ForeColor = SystemColors.ControlText;
            labelFullName.ForeColor = SystemColors.GrayText;
            labelDateTime.ForeColor = SystemColors.GrayText;
        }

        private void HistoryItem_MouseUp(object sender, MouseEventArgs e)
        {
            if ((sender as Control).Bounds.Contains(e.Location))
            {
                BackColor = SystemColors.GradientInactiveCaption;
            }
            else
            {
                BackColor = Parent.BackColor;
            }
            labelName.ForeColor = SystemColors.ControlText;
            labelFullName.ForeColor = SystemColors.GrayText;
            labelDateTime.ForeColor = SystemColors.GrayText;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate(false);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Focused)
            {
                Rectangle rect = ClientRectangle;
                rect.Inflate(-1, -1);
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle, SystemColors.ActiveBorder, ButtonBorderStyle.Dashed);
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        private void TileItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnClick(EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void MenuItem_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(labelFullName.Text);
        }
        #endregion
    }
}
