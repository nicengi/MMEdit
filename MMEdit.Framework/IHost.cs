using MMEdit.Configuration;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MMEdit
{
    /// <summary>
    /// 表示插件宿主。
    /// </summary>
    public interface IHost
    {
        #region Properties
        /// <summary>
        /// 获取主窗体。
        /// </summary>
        Form MainForm { get; }

        /// <summary>
        /// 获取已加载的插件列表。
        /// </summary>
        IReadOnlyList<IPlugin> Plugins { get; }

        /// <summary>
        /// 获取导入插件列表。
        /// </summary>
        IReadOnlyList<IImportPlugin> ImportPlugins { get; }

        /// <summary>
        /// 获取导出插件列表。
        /// </summary>
        IReadOnlyList<IExportPlugin> ExportPlugins { get; }

        /// <summary>
        /// 获取启动插件列表。
        /// </summary>
        IReadOnlyList<IStartPlugin> StartPlugins { get; }

        /// <summary>
        /// 获取已注册的小部件列表。
        /// </summary>
        IReadOnlyList<IWidget> Widgets { get; }

        /// <summary>
        /// 获取已注册的设置列表。
        /// </summary>
        IReadOnlyList<ICustomSettings> Settings { get; }

        /// <summary>
        /// 获取历史项目列表。
        /// </summary>
        IList<History> Histories { get; }

        /// <summary>
        /// 获取导入配置。
        /// </summary>
        ImportConfig ImportConfig { get; }
        #endregion

        #region Events
        /// <summary>
        /// 在加载 <see cref="IPlugin"/> 时发生。
        /// </summary>
        event EventHandler<PluginEventArgs> PluginLoaded;
        #endregion

        #region Methods

        #region Widgets
        /// <summary>
        /// <inheritdoc cref="IWidget.CreateWidget(ObjectFX)"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        IWidgetControl CreateWidget(ObjectFX obj);

        /// <summary>
        /// <inheritdoc cref="IWidget.CreateWidget(ObjectFX)"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        T CreateWidget<T>(ObjectFX obj) where T : Control;

        /// <summary>
        /// <inheritdoc cref="IWidget.CreateWidget(ObjectFX)"/>
        /// </summary>
        /// <param name="widgetID">小部件 ID。</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        IWidgetControl CreateWidget(string widgetID, ObjectFX  obj);

        /// <summary>
        /// <inheritdoc cref="IWidget.CreateWidget(ObjectFX)"/>
        /// </summary>
        /// <param name="widgetID">小部件 ID。</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        T CreateWidget<T>(string widgetID, ObjectFX obj) where T : Control;

        /// <summary>
        /// 注册小部件，如果已有相同的 WidgetID 将被替换。
        /// </summary>
        /// <param name="widget">小部件信息。</param>
        void RegisterWidget(IWidget widget);

        /// <summary>
        /// <inheritdoc cref="RegisterWidget(IWidget)"/>
        /// </summary>
        /// <param name="widgetID"></param>
        /// <param name="createFunc"></param>
        void RegisterWidget(string widgetID, Func<ObjectFX, IWidgetControl> createFunc);

        /// <summary>
        /// <inheritdoc cref="RegisterWidget(IWidget)"/>
        /// </summary>
        /// <param name="widgets">小部件信息集合。</param>
        void RegisterWidgets(IWidget[] widgets);
        #endregion

        #region Plugins
        /// <summary>
        /// 使用 GUID 查找插件。
        /// </summary>
        /// <param name="guid">要查找的 GUID。</param>
        /// <returns></returns>
        IPlugin GetPlugin(Guid guid);

        /// <summary>
        /// <inheritdoc cref="GetPlugin(Guid)"/>
        /// </summary>
        /// <param name="guid">要查找的 GUID。</param>
        /// <returns></returns>
        IPlugin GetPlugin(string guid);

        /// <summary>
        /// <inheritdoc cref="GetPlugin(Guid)"/>
        /// </summary>
        /// <typeparam name="T">要转换的类型。</typeparam>
        /// <param name="guid">要查找的 GUID。</param>
        /// <returns></returns>
        T GetPlugin<T>(Guid guid) where T : IPlugin;

        /// <summary>
        /// <inheritdoc cref="GetPlugin(Guid)"/>
        /// </summary>
        /// <typeparam name="T">要转换的类型。</typeparam>
        /// <param name="guid">要查找的 GUID。</param>
        /// <returns></returns>
        T GetPlugin<T>(string guid) where T : IPlugin;

        /// <summary>
        /// 获取用户的插件数据的路径。
        /// </summary>
        /// <param name="plugin">插件。</param>
        /// <returns></returns>
        string GetPluginDataPath(IPlugin plugin);
        #endregion

        #region Edit
        /// <summary>
        /// 从文件打开编辑。
        /// </summary>
        /// <param name="fileName">文件名。</param>
        /// <param name="applyRules">应用扩展名导入规则。</param>
        void OpenEdit(string fileName, bool applyRules = true);

        /// <summary>
        /// 从历史记录打开编辑。
        /// </summary>
        /// <param name="history"></param>
        void OpenEdit(History history);

        /// <summary>
        /// <inheritdoc cref="OpenEdit(string, bool)"/>
        /// </summary>
        /// <param name="importer">导入程序。</param>
        /// <param name="fileName">文件名。</param>
        void OpenEdit(IImportPlugin importer, string fileName);
        #endregion

        /// <summary>
        /// 注册设置。
        /// </summary>
        /// <param name="settings">自定义设置。</param>
        void RegisterSettings(ICustomSettings settings);

        /// <summary>
        /// 将 <see cref="History"/> 插入到历史列表的指定索引处。
        /// </summary>
        /// <param name="history">历史项目。</param>
        /// <param name="index">索引。</param>
        void InsertHistory(History history, int index = 0);

        #endregion
    }

    /// <summary>
    /// 获取与插件宿主的连接。
    /// </summary>
    public interface IHostConncet
    {
        #region Methods
        /// <summary>
        /// 与插件宿主连接。
        /// </summary>
        /// <param name="host">插件宿主。</param>
        void Initialize(IHost host);
        #endregion
    }
}
