namespace MMEdit
{
    /// <summary>
    /// 表示小部件控件。
    /// </summary>
    public interface IWidgetControl
    {
        #region Properties
        /// <summary>
        /// 获取或设置可编辑对象。
        /// </summary>
        ObjectFX ObjectFX { get; set; }
        #endregion
    }
}
