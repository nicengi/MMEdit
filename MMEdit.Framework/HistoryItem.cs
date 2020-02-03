using System;
using System.Drawing;
using System.IO;

namespace MMEdit
{
    /// <summary>
    /// 表示历史文件项目。
    /// </summary>
    [Serializable]
    public class HistoryItem
    {
        #region Constructor
        public HistoryItem()
        {

        }

        public HistoryItem(string fileName, Guid importerGuid)
        {
            Filename = fileName;
            ImporterGuid = importerGuid;
        }

        public HistoryItem(string fileName, Guid importerGuid, Image image) : this(fileName, importerGuid)
        {
            Image = image;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取或设置文件名。
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// 获取或设置导入程序 GUID。
        /// </summary>
        public Guid ImporterGuid { get; set; }

        /// <summary>
        /// 获取或设置图像。
        /// </summary>
        public Image Image { get; set; }
        #endregion

        /// <summary>
        /// 获取历史缓存文件的路径。
        /// </summary>
        public static string HistoryCachePath => Path.Combine(System.Windows.Forms.Application.UserAppDataPath, "Histories");
    }
}
