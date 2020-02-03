using System;

namespace MMEdit.Fx
{
    public class Annotation : ObjectFX
    {
        #region Constructor
        /// <summary>
        /// 初始化 <see cref="Annotation"/> 类的新实例。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Annotation(string type, string name, string value) : this()
        {
            Type = type;
            Name = name;
            Value = value;
        }

        /// <summary>
        /// 初始化 <see cref="Annotation"/> 类的新实例。
        /// </summary>
        public Annotation()
        {
            Data.Add("Type", null);
            Data.Add("Name", null);
            Data.Add("Value", null);
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取或设置注解的类型。
        /// </summary>
        public string Type
        {
            get
            {
                return (string)Data["Type"];
            }

            set
            {
                Data["Type"] = value;
            }
        }

        /// <summary>
        /// 获取或设置注解的名称。
        /// </summary>
        public string Name
        {
            get
            {
                return (string)Data["Name"];
            }

            set
            {
                Data["Name"] = value;
            }
        }

        /// <summary>
        /// 获取或设置注解的值。
        /// </summary>
        public string Value
        {
            get
            {
                return (string)Data["Value"];
            }

            set
            {
                Data["Value"] = value;
                OnValueChanged();
            }
        }

        public override string WidgetID
        {
            get
            {
                throw new Exception($"此属性在 {typeof(Annotation).FullName} 中不可用。");
            }

            set
            {
                throw new Exception($"此属性在 {typeof(Annotation).FullName} 中不可用。");
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// 当 <see cref="Value"/> 属性的值改变时发生。
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// 引发 <see cref="ValueChanged"/> 事件。
        /// </summary>
        protected void OnValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
