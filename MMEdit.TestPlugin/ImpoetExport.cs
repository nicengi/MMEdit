using System;
using System.Drawing;
using System.IO;

namespace MMEdit.TestPlugin
{
    public class ImpoetExport : PluginBase, IImportPlugin, IExportPlugin
    {
        #region Fields

        #endregion

        #region Constructor

        #endregion

        #region Properties
        public override Guid Guid
        {
            get
            {
                return new Guid("{1D7F7E49-4E34-4FD7-8663-9071D5C879CB}");
            }
        }

        public override string Name
        {
            get
            {
                return "测试插件";
            }
        }

        public override string Version
        {
            get
            {
                return "1.0";
            }
        }

        public string Caption
        {
            get
            {
                return "测试文件";
            }
        }

        public string Pattern
        {
            get
            {
                return "*.fx";
            }
        }

        public Image Image
        {
            get
            {
                return null;
            }
        }
        #endregion

        #region Methods
        public override void Initialize(IHost host)
        {
            base.Initialize(host);
        }

        public bool IsExportable(ObjectFX obj)
        {
            return true;
        }

        public bool IsImportable(string path)
        {
            return Path.GetExtension(path) == ".fx";
        }

        public void Export(ObjectFX obj, string path)
        {
            
        }

        public ObjectFX Import(string path)
        {
            return new ObjectFX("MMEdit.Test");
        }
        #endregion
    }
}
