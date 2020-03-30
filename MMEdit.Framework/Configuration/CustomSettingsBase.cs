using System.Collections.Generic;
using System.Windows.Forms;

namespace MMEdit.Configuration
{
    /// <summary>
    /// 定义自定义设置的基类。
    /// </summary>
    public abstract class CustomSettingsBase : ICustomSettings
    {
        #region Constructor
        /// <summary>
        /// 初始化 <see cref="CustomSettingsBase"/> 类的新实例。
        /// </summary>
        public CustomSettingsBase()
        {
            Settings = new List<ICustomSettings>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取或设置标签文本。
        /// </summary>
        public string Text { get; protected set; }

        /// <summary>
        /// 获取子设置集合。
        /// </summary>
        public List<ICustomSettings> Settings { get; }

        IList<ICustomSettings> ICustomSettings.Settings
        {
            get
            {
                return Settings;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 存储设置属性的当前值。
        /// </summary>
        public abstract void Save();

        /// <summary>
        /// <see cref="Settings"/> <inheritdoc cref="CustomSettingsBase.Save()"/>
        /// </summary>
        protected virtual void SaveSettings()
        {
            Settings.ForEach(s => s.Save());
        }

        /// <summary>
        /// 创建控件。
        /// </summary>
        /// <returns></returns>
        public abstract Control CreateControl();
        #endregion
    }
}
