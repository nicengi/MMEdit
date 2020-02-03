using System.Drawing;

namespace MMEdit
{
    /// <summary>
    /// 提供文件导入程序（插件）。
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
        /// <param name="path"></param>
        /// <returns></returns>
        bool IsImportable(string path);

        ObjectFX Import(string path);
        #endregion
    }
}
