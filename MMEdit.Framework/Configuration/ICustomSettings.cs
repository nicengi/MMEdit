using System.Collections.Generic;
using System.Windows.Forms;

namespace MMEdit.Configuration
{
    /// <summary>
    /// 定义自定义设置。
    /// </summary>
    public interface ICustomSettings
    {
        /// <summary>
        /// 获取标签文本。
        /// </summary>
        string Text { get; }

        /// <summary>
        /// 获取子设置集合。
        /// </summary>
        IList<ICustomSettings> Settings { get; }

        /// <summary>
        /// 存储设置属性的当前值。
        /// </summary>
        void Save();

        /// <summary>
        /// 创建控件。
        /// </summary>
        /// <returns></returns>
        Control CreateControl();
    }
}