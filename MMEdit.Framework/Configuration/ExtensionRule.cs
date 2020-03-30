using System;

namespace MMEdit.Configuration
{
    /// <summary>
    /// 定义扩展名导入规则。
    /// </summary>
    [Serializable]
    public class ExtensionRule
    {
        #region Constructor
        /// <summary>
        /// 初始化 <see cref="ExtensionRule"/> 类的新实例。
        /// </summary>
        public ExtensionRule()
        {

        }

        /// <summary>
        /// <inheritdoc cref="ExtensionRule.ExtensionRule()"/>
        /// </summary>
        /// <param name="extension"></param>
        /// <param name="importerGuid"></param>
        public ExtensionRule(string extension, Guid importerGuid)
        {
            Extension = extension;
            ImporterGuid = importerGuid;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取或设置扩展名。
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// 获取或设置导入程序 GUID。
        /// </summary>
        public Guid ImporterGuid { get; set; }
        #endregion
    }
}
