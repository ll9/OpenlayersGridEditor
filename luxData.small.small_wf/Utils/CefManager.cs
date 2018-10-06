using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luxData.small.small_wf.Utils
{
    class CefManager
    {
        public CefManager(Presenter.Presenter presenter, ChromiumWebBrowser browser)
        {
            Presenter = presenter;
            Browser = browser;
        }

        public Presenter.Presenter Presenter { get; }
        public ChromiumWebBrowser Browser { get; }

        public void UpdateGeometry(object _id, object _wkt)
        {
            var id = long.Parse(_id.ToString());
            var wkt = _wkt.ToString();
            Browser.Invoke((Action)(() => Presenter.SpatialiteManager.UpdateGeometry(id, wkt)));
            
        }
    }
}
