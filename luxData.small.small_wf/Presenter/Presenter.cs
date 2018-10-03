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

            View.ViewClosing += View_ViewClosing;
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
