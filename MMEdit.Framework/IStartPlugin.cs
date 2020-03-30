using System.Windows.Forms;

namespace MMEdit
{
    /// <summary>
    /// 提供启动控件。
    /// </summary>
    public interface IStartPlugin : IPlugin
    {
        #region Methods
        /// <summary>
        /// 创建启动控件。
        /// </summary>
        Control CreateControl();
        #endregion
    }
}
