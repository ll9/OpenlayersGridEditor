using CefSharp.WinForms;
using luxData.small.small_wf.Presenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luxData.small.small_wf.Utils
{
    class CefManager
    {
        public CefManager(SpatialiteManager spatialiteManager, DataTable dataTable, ChromiumWebBrowser browser)
        {
            SpatialiteManager = spatialiteManager;
            DataTable = dataTable;
            Browser = browser;
        }

        public SpatialiteManager SpatialiteManager { get; }
        public DataTable DataTable { get; }
        public ChromiumWebBrowser Browser { get; }

        public void UpdateGeometry(object _id, object _wkt)
        {
            var id = long.Parse(_id.ToString());
            var wkt = _wkt.ToString();
            Browser.Invoke((Action)(() => SpatialiteManager.UpdateGeometry(id, wkt)));

        }

        public int AddGeometry(object wkt)
        {
            var row = DataTable.NewRow();
            DataTable.Rows.Add(row);
            var id = Convert.ToInt32(row[LDPresenter.IdColumn]);

            Browser.Invoke((Action)(() =>
            {
                SpatialiteManager.Update(DataTable);
                UpdateGeometry(id, wkt);
            }));

            return id;
        }
    }
}
