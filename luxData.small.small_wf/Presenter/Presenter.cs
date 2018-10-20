using luxData.small.small_wf.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WizardDemo.Models;

namespace luxData.small.small_wf.Presenter
{
    class LDPresenter
    {
        public static string GeometryColumn = Properties.Settings.Default["geometryColumn"].ToString();
        public static string  IdColumn = Properties.Settings.Default["idColumn"].ToString();

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

        public LDPresenter(IView view)
        {
            View = view;

            View.ViewClosing += View_ViewClosing;
            View.BrowserLoadingComplete += InitProjectAfterBrowserLoad;
            View.AddingColumn += View_AddingColumn;
            View.DeletingColumn += View_DeletingColumn;

        }

        private void View_DeletingColumn(object sender, string columnName)
        {
            SpatialiteManager.DropColumn(columnName);
            DataTable.Columns.Remove(columnName);
        }

        private void View_AddingColumn(object sender, ViewModels.HeaderClickViewModel e)
        {
            SpatialiteManager.AddColumn(e.AddColumnViewModel.ColumnName, e.AddColumnViewModel.DataType);
            DataTable.Columns.Add(e.AddColumnViewModel.ColumnName, e.AddColumnViewModel.DataType.DataTypeToType());
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
            View.chromeBrowser.RegisterJsObject("cefCustomObject", new CefManager(SpatialiteManager, DataTable, View.chromeBrowser));



            foreach (DataRow row in DataTable.Rows)
            {
                var feature = FeatureSerializer.Serialize(IdColumn, GeometryColumn, row, DataTable);
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
