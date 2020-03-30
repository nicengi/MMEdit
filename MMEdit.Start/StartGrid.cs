using System;
using System.Windows.Forms;

namespace MMEdit
{
    public class StartGrid : IStartPlugin, IHostConncet
    {
        #region Fields
        private StartGridControl startControl;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return Properties.Resources.Start_Name;
            }
        }

        public Guid Guid
        {
            get
            {
                return new Guid("{7925BC6C-6059-43EB-8052-AF0CCFC3C970}");
            }
        }

        public string Version
        {
            get
            {
                return "1.0";
            }
        }

        public string Description
        {
            get
            {
                return Name;
            }
        }

        public IHost Host { get; set; }
        #endregion

        #region Methods
        public void Initialize(IHost host)
        {
            Host = host;
        }

        public Control CreateControl()
        {
            startControl = new StartGridControl(Host);
            return startControl;
            /*
            if (startControl == null)
            {
                startControl = new StartGridControl(Host);
                return startControl;
            }
            startControl.UpdateList();
            return startControl;
            */
        }

        public void Dispose()
        {
            
        }
        #endregion
    }
}
