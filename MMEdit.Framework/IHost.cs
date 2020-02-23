using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MMEdit
{
    /// <summary>
    /// 提供插件宿主。
    /// </summary>
    public interface IHost
    {
        #region Properties
        /// <summary>
        /// 获取已加载的插件列表。
        /// </summary>
        IList<IPlugin> Plugins { get; }
        /// <summary>
        /// 获取已加载的小部件列表。
        /// </summary>
        IList<IWidget> Widgets { get; }
        /// <summary>
        /// 获取主窗体。
        /// </summary>
        IMainForm MainForm { get; }
        #endregion

        #region Methods
        /// <summary>
        /// 创建与指定的 WidgetID 关联的 <see cref="IWidgetControl"/> 的新实例。
        /// </summary>
        /// <param name="widgetID"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        IWidgetControl CreateWidget(string widgetID, ObjectFX obj);

        /// <summary>
        /// 创建与指定的 WidgetID 关联的 <see cref="IWidgetControl"/> 的新实例，并转换为指定的类型。
        /// </summary>
        /// <param name="widgetID"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        T CreateWidget<T>(string widgetID, ObjectFX obj) where T : Control;

        /// <summary>
        /// 注册一个小部件，如果已注册有相同的 WidgetID 将被替换。
        /// </summary>
        /// <param name="widget"></param>
        void RegisterWidget(IWidget widget);

        void RegisterWidget(string widgetID, Func<ObjectFX, IWidgetControl> createFunc);

        bool UnregisterWidget(string widgetID);

        IPlugin GetPlugin(Guid guid);

        IPlugin GetPlugin(string guid);

        T GetPlugin<T>(Guid guid) where T : IPlugin;

        T GetPlugin<T>(string guid) where T : IPlugin;

        IPlugin GetPlugin(int index);

        /// <summary>
        /// 获取用户插件数据的路径。
        /// </summary>
        /// <param name="plugin"></param>
        /// <returns></returns>
        string GetPluginDataPath(IPlugin plugin);

        void LoadPlugin(string path);
        
        bool UnLoadPlugin(IPlugin plugin);
        #endregion

        #region Events
        /// <summary>
        /// 在加载 <see cref="IPlugin"/> 时发生。
        /// </summary>
        event EventHandler<PluginEventArgs> PluginLoaded;

        /// <summary>
        /// 在卸载 <see cref="IPlugin"/> 之前发生。
        /// </summary>
        event EventHandler<PluginEventArgs> PluginUnLoading;

        /// <summary>
        /// 在文件状态改变时发生。
        /// </summary>
        event EventHandler<FileStatusEventArgs> FileStatusChanged;

        /// <summary>
        /// 引发 <see cref="FileStatusChanged"/> 事件。
        /// </summary>
        /// <param name="e"></param>
        void OnFileStatusChanged(FileStatusEventArgs e);
        #endregion
    }

    /// <summary>
    /// 获取与插件宿主的连接。
    /// </summary>
    public interface IHostConncet
    {
        #region Properties
        IHost Host { get; set; }
        #endregion
    }
}
