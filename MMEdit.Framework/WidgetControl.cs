using System.Windows.Forms;

namespace MMEdit
{
    /// <summary>
    /// 提供一个用来编辑 <see cref="MMEdit.ObjectFX"/> 的控件。
    /// </summary>
    public class WidgetControl : UserControl
    {
        #region Constructor
        /// <summary>
        /// 初始化 <see cref="WidgetControl"/> 类的新实例。
        /// </summary>
        public WidgetControl()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取或设置 <see cref="MMEdit.ObjectFX"/>。
        /// </summary>
        public virtual ObjectFX ObjectFX { get; set; }
        #endregion
    }
}

