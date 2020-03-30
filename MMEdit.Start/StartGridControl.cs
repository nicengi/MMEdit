using MMEdit.Configuration;
using System;
using System.Threading;
using System.Windows.Forms;

namespace MMEdit
{
    public partial class StartGridControl : UserControl
    {
        #region Fields

        #endregion

        #region Constructor
        public StartGridControl(IHost host)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            DoubleBuffered = true;
            Host = host;
        }
        #endregion

        #region Properties
        private IHost Host { get; }
        #endregion

        #region Methods
        public void UpdateList()
        {
            new Thread(() =>
            {
                panelList.Invoke(new Action(() =>
                {
                    panelList.SuspendLayout();
                    panelList.Controls.Clear();
                    for (int i = Host.Histories.Count - 1; i >= 0; i--)
                    {
                        History history = Host.Histories[i];
                        TileItem tile = new TileItem();
                        if (Host.GetPlugin(history.ImporterGuid) is IImportPlugin importer)
                        {
                            tile.Image = importer.Image;
                        }
                        tile.Text = history.Name;
                        tile.FullName = history.FullName;
                        tile.DateTime = history.DateTime;
                        tile.Tag = history;
                        tile.TabIndex = i;
                        tile.Click += Tile_Click;
                        panelList.Controls.Add(tile);
                    }
                    panelList.ResumeLayout();
                }));
            }).Start();
        }

        private void StartPageControl_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            History history = (sender as Control).Tag as History;
            Host.OpenEdit(history);
        }
        #endregion
    }
}
