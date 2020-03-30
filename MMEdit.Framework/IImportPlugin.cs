using System.Drawing;

namespace MMEdit
{
    /// <summary>
    /// 提供 <see cref="ObjectFX"/> 的导入程序。
    /// </summary>
    public interface IImportPlugin : IPlugin
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
        /// 确定文件可以导入。
        /// </summary>
        /// <param name="path">文件路径。</param>
        /// <returns></returns>
        bool IsImportable(string path);

        /// <summary>
        /// 导入 <see cref="ObjectFX"/>。
        /// </summary>
        /// <param name="path">文件路径。</param>
        /// <returns></returns>
        ObjectFX Import(string path);
        #endregion
    }
}
