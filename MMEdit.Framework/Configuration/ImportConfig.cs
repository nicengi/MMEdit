using System;
using System.Collections.Generic;
using System.IO;

namespace MMEdit.Configuration
{
    /// <summary>
    /// 表示导入配置。
    /// </summary>
    [Serializable]
    public class ImportConfig
    {
        #region Constructor
        /// <summary>
        /// 初始化 <see cref="ImportConfig"/> 类的新实例。
        /// </summary>
        public ImportConfig()
        {
            ExtensionRules = new List<ExtensionRule>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取扩展名规则集合。
        /// </summary>
        public List<ExtensionRule> ExtensionRules { get; set; }

        /// <summary>
        /// 获取导入配置文件的路径。
        /// </summary>
        public static string ImageConfigPath => Path.Combine(System.Windows.Forms.Application.UserAppDataPath, "Import.config");
        #endregion
    }
}
