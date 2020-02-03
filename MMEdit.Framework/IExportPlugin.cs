using System.Drawing;

namespace MMEdit
{
    /// <summary>
    /// 提供 <see cref="ObjectFX"/> 导出程序（插件）。
    /// </summary>
    public interface IExportPlugin : IPlugin
    {
        #region Properties
        /// <summary>
        /// 获取文件说明。
        /// </summary>
        string Caption { get; }

        /// <summary>
        /// 获取文件名筛选模式。
        /// </summary>
        string Pattern { get; }

        /// <summary>
        /// 获取文件图标。
        /// </summary>
        Image Image { get; }
        #endregion

        #region Methods
        /// <summary>
        /// 确定 <see cref="ObjectFX"/> 可以导出。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool IsExportable(ObjectFX obj);

        void Export(ObjectFX obj, string path);
        #endregion
    }
}
