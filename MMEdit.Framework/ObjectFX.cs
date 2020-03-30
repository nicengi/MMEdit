using System;
using System.Collections.Generic;

namespace MMEdit
{
    /// <summary>
    /// 表示可编辑对象，这是所有可编辑对象的最终基类。
    /// </summary>
    public class ObjectFX : INotifyStatusChanged, IFormattable
    {
        #region Constructor
        /// <summary>
        /// 初始化 <see cref="ObjectFX"/> 类的新实例。
        /// </summary>
        public ObjectFX()
        {
            Data = new Dictionary<string, object>();
        }

        /// <summary>
        /// <inheritdoc cref="ObjectFX.ObjectFX()"/>
        /// </summary>
        /// <param name="widgetID">编辑此对象的小部件 WidgetID。</param>
        public ObjectFX(string widgetID) : this()
        {
            WidgetID = widgetID;
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取或设置编辑此对象的小部件 WidgetID。
        /// </summary>
        public virtual string WidgetID { get; set; }

        /// <summary>
        /// 获取有关对象的其他用户定义信息的键/值对集合。
        /// </summary>
        public IDictionary<string, object> Data { get; protected set; }

        /// <summary>
        /// <inheritdoc cref="INotifyStatusChanged.StatusChanged"/>
        /// </summary>
        protected event EventHandler<FileStatusEventArgs> StatusChanged;
        event EventHandler<FileStatusEventArgs> INotifyStatusChanged.StatusChanged
        {
            add
            {
                StatusChanged += value;
            }

            remove
            {
                StatusChanged -= value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 通知对象状态已改变。
        /// </summary>
        /// <param name="status"></param>
        public virtual void OnStatusChanged(FileStatus status)
        {
            StatusChanged?.Invoke(this, new FileStatusEventArgs(status));
        }

        string IFormattable.ToString(string format, IFormatProvider formatProvider)
        {
            return ((ICustomFormatter)formatProvider.GetFormat(typeof(ICustomFormatter)))?.Format(format, this, formatProvider);
        }
        #endregion
    }
}
