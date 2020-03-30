using System.Windows.Forms;

namespace MMEdit
{
    /// <summary>
    /// 小部件控件的基类，实现 <see cref="IWidgetControl"/>。
    /// </summary>
    public class WidgetControl : UserControl, IWidgetControl
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
        /// <inheritdoc cref="IWidgetControl.ObjectFX"/>
        /// </summary>
        public virtual ObjectFX ObjectFX { get; set; }
        #endregion
    }
}

