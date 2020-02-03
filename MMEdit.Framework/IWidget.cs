using System;

namespace MMEdit
{
    /// <summary>
    /// 提供小部件。
    /// </summary>
    public interface IWidget
    {
        #region Properties
        /// <summary>
        /// 获取小部件名称。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 获取小部件 ID。
        /// </summary>
        string WidgetID { get; }
        #endregion

        #region Methods
        /// <summary>
        /// 使用指定的 <see cref="ObjectFX"/> 创建小部件。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        WidgetControl CreateWidget(ObjectFX obj);
        #endregion
    }

    /// <summary>
    /// 提供小部件注册类。
    /// </summary>
    public class WidgetClass : IWidget
    {
        #region Fields
        private Func<ObjectFX, WidgetControl> createFunc;
        #endregion

        #region Constructor
        public WidgetClass(string widgetID, Func<ObjectFX, WidgetControl> createFunc)
        {
            this.createFunc = createFunc;
            WidgetID = widgetID;
        }

        public WidgetClass(string widgetID, string name, Func<ObjectFX, WidgetControl> createFunc) : this(widgetID, createFunc)
        {
            Name = name;
        }
        #endregion

        #region Properties
        public string WidgetID { get; }

        private string _Name;
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
        public WidgetControl CreateWidget(ObjectFX obj)
        {
            return createFunc(obj);
        }
        #endregion
    }
}
