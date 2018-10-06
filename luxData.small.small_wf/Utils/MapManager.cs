using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luxData.small.small_wf.Utils
{
    class MapManager
    {
        public ChromiumWebBrowser Browser { get; }

        public MapManager(ChromiumWebBrowser browser)
        {
            Browser = browser;
        }

        /// <summary>
        /// Adds feature to openlayers
        /// </summary>
        /// <param name="feature">Feature in geosjon format</param>
        public void AddFeatureToMap(string feature)
        {
            Browser.ExecuteScriptAsync($"layerManager.addFeature({feature})");
        }

        /// <summary>
        /// Zooms to the extend of the vector layer
        /// </summary>
        public void FitZoom()
        {
            Browser.ExecuteScriptAsync($"layerManager.fitZoom()");
        }
    }
}
