using System.Collections.Generic;

namespace MMEdit
{
    public class ObjectFX
    {
        #region Constructor
        public ObjectFX()
        {
            Data = new Dictionary<string, object>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取或设置用于编辑 <see cref="ObjectFX"/> 的小部件 WidgetID。！此属性由导入程序指定。！
        /// </summary>
        public virtual string WidgetID { get; set; }

        public IDictionary<string, object> Data { get; }
        #endregion
    }
}
