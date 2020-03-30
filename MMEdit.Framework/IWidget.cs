using System;

namespace MMEdit
{
    /// <summary>
    /// 表示小部件信息。
    /// </summary>
    public interface IWidget
    {
        #region Properties
        /// <summary>
        /// 获取小部件的名称。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 获取小部件的 ID。
        /// </summary>
        string WidgetID { get; }
        #endregion

        #region Methods
        /// <summary>
        /// 为可编辑对象创建 <see cref="IWidgetControl"/> 的新实例。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        IWidgetControl CreateWidget(ObjectFX obj);
        #endregion
    }

    /// <summary>
    /// 提供小部件的注册类，此类不可被继承。
    /// </summary>
    public sealed class WidgetClass : IWidget
    {
        #region Fields
        private string _Name;
        private Func<ObjectFX, IWidgetControl> createWidget;
        #endregion

        #region Constructor
        /// <summary>
        /// 初始化 <see cref="WidgetClass"/> 类的新实例。
        /// </summary>
        /// <param name="widgetID">小部件的 ID。</param>
        /// <param name="createWidget">创建小部件方法。</param>
        public WidgetClass(string widgetID, Func<ObjectFX, IWidgetControl> createWidget)
        {
            this.createWidget = createWidget;
            WidgetID = widgetID;
        }

        /// <summary>
        /// <inheritdoc cref="WidgetClass(string, Func{ObjectFX, IWidgetControl})"/>
        /// </summary>
        /// <param name="name">小部件的名称。</param>
        /// <param name="widgetID">小部件的 ID。</param>
        /// <param name="createWidget">创建小部件方法。</param>
        public WidgetClass(string name, string widgetID, Func<ObjectFX, IWidgetControl> createWidget) : this(widgetID, createWidget)
        {
            Name = name;
        }
        #endregion

        #region Properties
        /// <summary>
        /// <inheritdoc cref="IWidget.WidgetID"/>
        /// </summary>
        public string WidgetID { get; }

        /// <summary>
        /// <inheritdoc cref="IWidget.Name"/>
        /// </summary>
        public string Name
        {
            get
            {
                return _Name ?? WidgetID;
            }

            set
            {
                _Name = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// <inheritdoc cref="IWidget.CreateWidget(ObjectFX)"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IWidgetControl CreateWidget(ObjectFX obj)
        {
            return createWidget(obj);
        }
        #endregion
    }
}
