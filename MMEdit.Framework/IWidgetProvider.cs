namespace MMEdit
{
    /// <summary>
    /// 小部件提供程序（插件）。
    /// </summary>
    public interface IWidgetProvider : IPlugin
    {
        #region Methods
        IWidget[] GetWidgets();
        #endregion
    }
}
