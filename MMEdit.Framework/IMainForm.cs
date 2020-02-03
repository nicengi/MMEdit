namespace MMEdit
{
    public interface IMainForm
    {
        #region Properties

        /// <summary>
        /// 获取 <see cref="ObjectFX"/> 的导入程序。
        /// </summary>
        IImportPlugin Importer { get; }

        /// <summary>
        /// 获取默认的导出程序。
        /// </summary>
        IExportPlugin DefaultExporter { get; }

        /// <summary>
        /// 获取 <see cref="MMEdit.ObjectFX"/>。
        /// </summary>
        ObjectFX ObjectFX { get; }

        /// <summary>
        /// 获取文件名。
        /// </summary>
        string Filename { get; }

        /// <summary>
        /// 获取文件已保存。
        /// </summary>
        bool IsSaved { get; }
        #endregion

        #region Methods
        /// <summary>
        /// 从打开文件对话框打开文件。
        /// </summary>
        void OpenFX();

        /// <summary>
        /// 从指定的路径打开文件。
        /// </summary>
        /// <param name="path"></param>
        void OpenFX(string path);

        /// <summary>
        /// 从指定的历史项打开文件。
        /// </summary>
        /// <param name="history"></param>
        void OpenFX(HistoryItem history);

        /// <summary>
        /// 重新打开当前文件。
        /// </summary>
        void RefreshFX();

        void SaveFX();

        void SaveFX(string path);
        #endregion
    }
}
