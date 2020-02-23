namespace MMEdit
{
    /// <summary>
    /// 提供一个用来编辑 <see cref="MMEdit.ObjectFX"/> 的控件。
    /// </summary>
    public interface IWidgetControl
    {
        #region Properties
        /// <summary>
        /// 获取或设置 <see cref="MMEdit.ObjectFX"/>。
        /// </summary>
        ObjectFX ObjectFX { get; set; }
        #endregion
    }
}
