using System;

namespace MMEdit
{
    /// <summary>
    /// 通用插件接口。
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
    /// 提供插件的抽象基类，包含 <see cref="IHostConncet"/> 。
    /// </summary>
    public abstract class PluginClass : IPlugin, IHostConncet
    {
        #region Properties
        public abstract Guid Guid { get; }

        public abstract string Name { get; }

        public virtual string Version
        {
            get
            {
                return "1.0.0.0";
            }
        }

        public virtual string Description
        {
            get
            {
                return Name;
            }
        }

        private IHost _Host;
        public virtual IHost Host
        {
            get
            {
                return _Host;
            }

            set
            {
                _Host = value;
                Initialize(_Host);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 此方法在 <see cref="Host"/> 的值被改变时被调用。
        /// </summary>
        /// <param name="host"></param>
        protected virtual void Initialize(IHost host) { }

        public virtual void Dispose()
        {

        }
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
        /// <param name="plugin"></param>
        public PluginEventArgs(IPlugin plugin)
        {
            Plugin = plugin;
        }
        #endregion

        #region Properties
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
        /// 初始化 <see cref="PluginLoadException"/> 类的新实例。
        /// </summary>
        /// <param name="message">解释异常原因的错误消息。</param>
        public PluginLoadException(string message) : base(message) { }

        /// <summary>
        /// 初始化 <see cref="PluginLoadException"/> 类的新实例。
        /// </summary>
        /// <param name="message">解释异常原因的错误消息。</param>
        /// <param name="inner">导致当前异常的异常。</param>
        public PluginLoadException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// 初始化 <see cref="PluginLoadException"/> 类的新实例。
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected PluginLoadException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        #endregion
    }
}
