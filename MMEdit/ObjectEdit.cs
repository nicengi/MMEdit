using System;

namespace MMEdit
{
    internal class ObjectEdit
    {
        #region Fields
        private IExportPlugin _Exporter;
        #endregion

        #region Constructor
        public ObjectEdit(IImportPlugin importer, string fileName)
        {
            Importer = importer ?? throw new ArgumentNullException(nameof(importer));
            FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            Import(FileStatus.Opened);
        }
        #endregion

        #region Properties
        public IImportPlugin Importer { get; private set; }

        public IExportPlugin Exporter
        {
            get
            {
                if (_Exporter == null)
                {
                    return Importer as IExportPlugin;
                }
                return _Exporter;
            }

            set
            {
                _Exporter = value;
            }
        }

        public ObjectFX ObjectFX { get; private set; }

        public string FileName { get; private set; }

        public bool IsSaved { get; private set; }
        #endregion

        #region Events
        public event EventHandler<FileStatusEventArgs> StatusChanged
        {
            add
            {
                if (ObjectFX != null)
                    ((INotifyStatusChanged)ObjectFX).StatusChanged += value;
            }

            remove
            {
                if (ObjectFX != null)
                    ((INotifyStatusChanged)ObjectFX).StatusChanged -= value;
            }
        }

        public virtual void OnStatusChanged(FileStatus status)
        {
            ObjectFX?.OnStatusChanged(status);
        }
        #endregion

        #region Methods
        private void ObjectFX_StatusChanged(object sender, FileStatusEventArgs e)
        {
            IsSaved = e.Status != FileStatus.Changed;
        }

        private void Import(FileStatus status)
        {
            StatusChanged -= ObjectFX_StatusChanged;
            ObjectFX = Importer.Import(FileName)
                ?? throw new Exception(string.Format(Properties.Resources.Msg_ImporterReturnsNull, Importer.Name));
            StatusChanged += ObjectFX_StatusChanged;
            OnStatusChanged(status);
        }

        /// <summary>
        /// 重新打开当前编辑。
        /// </summary>
        public void Reload()
        {
            Import(FileStatus.Reloaded);
        }

        /// <summary>
        /// 保存当前编辑。
        /// </summary>
        public void Save()
        {
            Save(FileName);
        }

        /// <summary>
        /// <inheritdoc cref="Save()"/>
        /// </summary>
        /// <param name="fileName">路径。</param>
        public void Save(string fileName)
        {
            if (Exporter == null)
                throw new Exception(string.Format(Properties.Resources.Msg_ExporterNotFound, fileName));
            Save(Exporter, fileName);
        }

        /// <summary>
        /// <inheritdoc cref="Save()"/>
        /// </summary>
        /// <param name="exporter"></param>
        /// <param name="fileName"></param>
        public void Save(IExportPlugin exporter, string fileName)
        {
            if (exporter == null) throw new ArgumentNullException(nameof(exporter));
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));
            exporter.Export(ObjectFX, fileName);
            if (Exporter == null)
            {
                Exporter = exporter;
            }
            FileName = fileName;
            OnStatusChanged(FileStatus.Saved);
        }
        #endregion
    }
}
