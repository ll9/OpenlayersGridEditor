using luxData.small.small_wf.Utils;
using luxData.small.small_wf.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luxData.small.small_wf.Presenter
{
    class Presenter
    {
        public IView View { get; set; }
        public ProjectManager ProjectManager { get; set; }
        public SpatialiteManager SpatialiteManager { get; set; }
        public MapManager MapManager { get; set; }
        public CefManager CefManager { get; set; }
        public DataTable DataTable { get; set; }
        public string ProjectFolderPath
        {
            get
            {
                return Properties.Settings.Default["defaultFolder"].ToString();
            }
            set
            {
                Properties.Settings.Default["defaultFolder"] = value;
                Properties.Settings.Default.Save();
            }
        }

        public Presenter(IView view)
        {
            View = view;

            View.ViewClosing += View_ViewClosing;
            View.BrowserLoadingComplete += InitProjectAfterBrowserLoad;
        }

        private void InitProjectAfterBrowserLoad(object sender, EventArgs e)
        {
            MapManager = new MapManager(View.chromeBrowser);

            if (string.IsNullOrEmpty(ProjectFolderPath))
            {
                ProjectFolderPath = Application.StartupPath;
                ProjectManager = new ProjectManager(ProjectFolderPath);
                ProjectManager.BuildNewProject();
            }
            else
            {
                ProjectManager = new ProjectManager(ProjectFolderPath);
            }

            SpatialiteManager = new SpatialiteManager(ProjectManager.DbFilePath);

            LoadData();

            var geometryColumn = Properties.Settings.Default["geometryColumn"].ToString();
            var idColumn = Properties.Settings.Default["idColumn"].ToString();

            foreach (DataRow row in DataTable.Rows)
            {
                var feature = FeatureSerializer.Serialize(idColumn, geometryColumn, row, DataTable);
                if (feature != null)
                    MapManager.AddFeatureToMap(feature);
            }
            MapManager.FitZoom();
        }

        private void View_ViewClosing(object sender, EventArgs e)
        {
            SpatialiteManager.Update(DataTable);
        }

        /// <summary>
        /// Loads Data from to the View
        /// </summary>
        private void LoadData()
        {
            DataTable = SpatialiteManager.GetDataTable();

            View.DataSource = DataTable;
        }


    }
}
