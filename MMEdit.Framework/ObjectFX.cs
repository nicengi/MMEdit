using System.Collections.Generic;

namespace MMEdit
{
    public class ObjectFX
    {
        #region Constructor
        public ObjectFX(string widgetID)
        {
            WidgetID = widgetID;
            Data = new Dictionary<string, object>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取用于编辑 <see cref="ObjectFX"/> 的小部件 WidgetID。
        /// </summary>
        public virtual string WidgetID { get; }

        public IDictionary<string, object> Data { get; protected set; }
        #endregion
    }
}
