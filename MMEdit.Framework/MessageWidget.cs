using MMEdit.Properties;
using System;
using System.Windows.Forms;

namespace MMEdit
{
    /// <summary>
    /// 消息小部件。
    /// </summary>
    public partial class MessageWidget : WidgetControl
    {
        #region Fields
        private Exception exception;
        #endregion

        #region Constructor
        /// <summary>
        /// 初始化 <see cref="MessageWidget"/> 类的新实例。
        /// </summary>
        public MessageWidget()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
        }

        /// <summary>
        /// <inheritdoc cref="MessageWidget()"/>
        /// </summary>
        /// <param name="message">要显示的消息。</param>
        public MessageWidget(string message) : this()
        {
            Text = message;
            linkMore.Visible = false;
            pictureIcon.Image = Resources.information_white;
        }

        /// <summary>
        /// <inheritdoc cref="MessageWidget()"/>
        /// </summary>
        /// <param name="message">要显示的消息。</param>
        /// <param name="icon">要显示的图标。</param>
        public MessageWidget(string message, MessageBoxIcon icon) : this(message)
        {
            switch (Convert.ToInt32(icon))
            {
                case 16: //Error
                    pictureIcon.Image = Resources.cross_circle;
                    break;
                case 32: //Question
                    pictureIcon.Image = Resources.question_white;
                    break;
                case 48: //Exclamation
                    pictureIcon.Image = Resources.exclamation;
                    break;
                case 0:
                case 64: //Information
                    pictureIcon.Image = Resources.information_white;
                    break;
            }
        }

        /// <summary>
        /// <inheritdoc cref="MessageWidget()"/>
        /// </summary>
        /// <param name="exception">要显示的异常。</param>
        public MessageWidget(Exception exception) : this()
        {
            Exception = exception;
        }

        /// <summary>
        /// <inheritdoc cref="MessageWidget()"/>
        /// </summary>
        /// <param name="exception">要显示的异常。</param>
        /// <param name="onLinkClicked">单击“More”时引发 <see cref="LinkLabel.LinkClicked"/> 事件的事件处理程序。</param>
        public MessageWidget(Exception exception, LinkLabelLinkClickedEventHandler onLinkClicked) : this(exception)
        {
            if (onLinkClicked != null)
            {
                linkMore.LinkClicked += onLinkClicked;
                linkMore.LinkClicked -= LinkMore_LinkClicked;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取或设置与此控件关联的异常。
        /// </summary>
        public Exception Exception
        {
            get
            {
                return exception;
            }

            set
            {
                exception = value;
                pictureIcon.Image = Resources.exclamation;
                labelMessage.Text = exception.Message;
                linkMore.Links.Add(0, linkMore.Text.Length, "More");
                linkMore.LinkClicked += LinkMore_LinkClicked;
                linkMore.Visible = true;
            }
        }

        /// <summary>
        /// <inheritdoc cref="Control.Text"/>
        /// </summary>
        public override string Text
        {
            get
            {
                return labelMessage.Text;
            }

            set
            {
                labelMessage.Text = value;
            }
        }
        #endregion

        #region Methods
        private void LinkMore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Exception.StackTrace))
            {
                MessageBox.Show(Exception.StackTrace, "More");
                e.Link.Visited = true;
            }
        }
        #endregion
    }
}
