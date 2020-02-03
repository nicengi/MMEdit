using System.Windows.Forms;

namespace MMEdit.Widgets
{
    public partial class MessageWidget : WidgetControl
    {
        #region Constructor
        public MessageWidget()
        {
            InitializeComponent();
            Dock = DockStyle.Top;
        }

        public MessageWidget(string text) : this()
        {
            Text = text;
        }
        #endregion

        #region Properties
        public override string Text
        {
            get
            {
                return label.Text;
            }

            set
            {
                label.Text = value;
            }
        }
        #endregion
    }
}
