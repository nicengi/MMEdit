using System;
using System.Drawing;
using System.IO;

namespace MMEdit.Configuration
{
    /// <summary>
    /// 表示历史项目。
    /// </summary>
    [Serializable]
    public class History
    {
        #region Constructor
        /// <summary>
        /// 初始化 <see cref=" History"/> 类的新实例。
        /// </summary>
        public History()
        {
            DateTime = DateTime.Now;
        }

        /// <summary>
        /// <inheritdoc cref="History()"/>
        /// </summary>
        /// <param name="fileName">文件名。</param>
        /// <param name="importerGuid">导入程序 GUID。</param>
        public History(string fileName, Guid importerGuid) : this()
        {
            FullName = fileName;
            ImporterGuid = importerGuid;
        }

        /// <summary>
        /// <inheritdoc cref="History()"/>
        /// </summary>
        /// <param name="fileName">文件名。</param>
        /// <param name="importerGuid">导入程序 GUID。</param>
        /// <param name="image">图像。</param>
        public History(string fileName, Guid importerGuid, Image image) : this(fileName, importerGuid)
        {
            Image = image;
        }

        /// <summary>
        /// <inheritdoc cref="History()"/>
        /// </summary>
        /// <param name="fileName">文件名。</param>
        /// <param name="importerGuid">导入程序 GUID。</param>
        /// <param name="image">图像。</param>
        /// <param name="dateTime">日期时间。</param>
        public History(string fileName, Guid importerGuid, Image image, DateTime dateTime) : this(fileName, importerGuid, image)
        {
            DateTime = dateTime;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取文件的名称。
        /// </summary>
        public string Name
        {
            get
            {
                return Path.GetFileName(FullName);
            }
        }

        /// <summary>
        /// 获取或设置文件的完整名称。
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 获取或设置导入程序 GUID。
        /// </summary>
        public Guid ImporterGuid { get; set; }

        /// <summary>
        /// 获取或设置图像。
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// 获取日期时间。
        /// </summary>
        public DateTime DateTime { get; set; }
        #endregion

        /// <summary>
        /// 获取历史缓存文件的路径。
        /// </summary>
        public static string HistoryCachePath => Path.Combine(System.Windows.Forms.Application.UserAppDataPath, "Histories");
    }
}
