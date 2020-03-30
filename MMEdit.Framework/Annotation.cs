using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MMEdit
{
    /// <summary>
    /// 定义可编辑对象注解。
    /// </summary>
    public class Annotation : ObjectFX, INotifyPropertyChanged, IFormattable
    {
        #region Constructor
        /// <summary>
        /// 初始化 <see cref="Annotation"/> 类的新实例。
        /// </summary>
        public Annotation() : base(null)
        {
            Data.Add("Type", null);
            Data.Add("Name", null);
            Data.Add("Value", null);
        }

        /// <summary>
        /// <inheritdoc cref="Annotation()"/>
        /// </summary>
        /// <param name="type">类型。</param>
        /// <param name="name">名称。</param>
        /// <param name="value">值。</param>
        public Annotation(string type, string name, object value) : this()
        {
            Type = type;
            Name = name;
            Value = value;
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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 获取或设置注解的值。
        /// </summary>
        public virtual object Value
        {
            get
            {
                return Data["Value"];
            }

            set
            {
                Data["Value"] = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// <inheritdoc cref="INotifyPropertyChanged.PropertyChanged"/>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 引发 <see cref="PropertyChanged"/> 事件。
        /// </summary>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Methods
        /// <summary>
        /// <inheritdoc cref="object.ToString()"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// <inheritdoc cref="IFormattable.ToString(string, IFormatProvider)"/>
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public virtual string ToString(string format, IFormatProvider formatProvider)
        {
            return ((ICustomFormatter)formatProvider.GetFormat(typeof(ICustomFormatter)))?.Format(format, this, formatProvider);
        }
        #endregion
    }
}
