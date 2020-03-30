using System;

namespace MMEdit
{
    /// <summary>
    /// 表示通用插件接口。
    /// </summary>
    public interface IPlugin : IDisposable
    {
        #region Properties
        /// <summary>
        /// 获取插件的 GUID。
        /// </summary>
        Guid Guid { get; }

        /// <summary>
        /// 获取插件的名称。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 获取插件的版本。
        /// </summary>
        string Version { get; }

        /// <summary>
        /// 获取插件的描述。
        /// </summary>
        string Description { get; }
        #endregion
    }

    /// <summary>
    /// 定义插件的抽象基类。
    /// </summary>
    public abstract class PluginBase : IPlugin, IHostConncet
    {
        #region Properties
        /// <summary>
        /// <inheritdoc cref="IPlugin.Guid"/>
        /// </summary>
        public abstract Guid Guid { get; }

        /// <summary>
        /// <inheritdoc cref="IPlugin.Name"/>
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// <inheritdoc cref="IPlugin.Version"/>
        /// </summary>
        public virtual string Version
        {
            get
            {
                return "1.0";
            }
        }

        /// <summary>
        /// <inheritdoc cref="IPlugin.Description"/>
        /// </summary>
        public virtual string Description
        {
            get
            {
                return Name;
            }
        }

        /// <summary>
        /// 获取或设置插件宿主。
        /// </summary>
        public IHost Host { get; protected set; }
        #endregion

        #region Methods
        /// <summary>
        /// <inheritdoc cref="IHostConncet.Initialize(IHost)"/>
        /// </summary>
        /// <param name="host"></param>
        public virtual void Initialize(IHost host)
        {
            Host = host;
        }

        #region IDisposable Support
        /// <summary>
        /// <inheritdoc cref="IDisposable.Dispose()"/>
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected virtual void Dispose(bool disposing)
        {

        }

        /// <summary>
        /// 析构函数。
        /// </summary>
        ~PluginBase()
        {
            Dispose(false);
        }

        /// <summary>
        /// <inheritdoc cref="IDisposable.Dispose()"/>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        #endregion
    }

    /// <summary>
    /// 为插件事件提供数据。
    /// </summary>
    public class PluginEventArgs : EventArgs
    {
        #region Constructor
        /// <summary>
        /// 初始化 <see cref="PluginEventArgs"/> 类的新实例。
        /// </summary>
        /// <param name="plugin">引发事件的插件。</param>
        public PluginEventArgs(IPlugin plugin)
        {
            Plugin = plugin;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取引发事件的插件。
        /// </summary>
        public IPlugin Plugin { get; }
        #endregion
    }

    /// <summary>
    /// 加载插件时引发的异常。
    /// </summary>
    [Serializable]
    public class PluginLoadException : Exception
    {
        #region Constructor
        /// <summary>
        /// 初始化 <see cref="PluginLoadException"/> 类的新实例。
        /// </summary>
        public PluginLoadException() { }

        /// <summary>
        /// <inheritdoc cref="PluginLoadException()"/>
        /// </summary>
        /// <param name="message">解释异常原因的错误消息。</param>
        public PluginLoadException(string message) : base(message) { }

        /// <summary>
        /// <inheritdoc cref="PluginLoadException()"/>
        /// </summary>
        /// <param name="message">解释异常原因的错误消息。</param>
        /// <param name="inner">导致当前异常的异常。</param>
        public PluginLoadException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// <inheritdoc cref="PluginLoadException()"/>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected PluginLoadException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        #endregion
    }
}
