using CefSharp.WinForms;
using luxData.small.small_wf.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luxData.small.small_wf.Utils
{
    class CefManager
    {
        public CefManager(LDPresenter presenter, ChromiumWebBrowser browser)
        {
            Presenter = presenter;
            Browser = browser;
        }

        public LDPresenter Presenter { get; }
        public ChromiumWebBrowser Browser { get; }

        public void UpdateGeometry(object _id, object _wkt)
        {
            var id = long.Parse(_id.ToString());
            var wkt = _wkt.ToString();
            Browser.Invoke((Action)(() => Presenter.SpatialiteManager.UpdateGeometry(id, wkt)));
            
        }

        public void AddGeometry(object wkt)
        {
            Browser.Invoke((Action)(() =>
            {
                var row = Presenter.DataTable.NewRow();
                var id = Convert.ToInt32(row[LDPresenter.IdColumn]);
                Presenter.SpatialiteManager.Update(Presenter.DataTable);
                UpdateGeometry(id, wkt);
            }));
        }
    }
}
