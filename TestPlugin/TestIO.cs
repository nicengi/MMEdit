using MMEdit;
using System;
using System.Drawing;

namespace TestPlugin
{
    public class TestIO : PluginClass, IImportPlugin, IExportPlugin
    {
        #region Properties
        public override Guid Guid
        {
            get
            {
                return new Guid("{D28235F7-C443-4886-B1E7-33C44EA70DC6}");
            }
        }

        public override string Name
        {
            get
            {
                return "_Test Import/Export";
            }
        }

        public override string Description
        {
            get
            {
                return "提供导入/导出测试，莫得任何功能。";
            }
        }

        public string Caption
        {
            get
            {
                return "Test File";
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
        public void Export(ObjectFX obj, string path)
        {

        }

        public ObjectFX Import(string path)
        {
            return new _ObjectFX
            {
                WidgetID = "debug.widget"
            };
        }

        public bool IsExportable(ObjectFX obj)
        {
            return true;
        }

        public bool IsImportable(string path)
        {
            return true;
        }

        #endregion
    }

    public class _ObjectFX : ObjectFX
    {

    }
}
