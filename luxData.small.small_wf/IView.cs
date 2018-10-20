using System;
using System.Data;
using CefSharp.WinForms;
using luxData.small.small_wf.ViewModels;

namespace luxData.small.small_wf
{
    public interface IView
    {
        ChromiumWebBrowser chromeBrowser { get; set; }
        DataTable DataSource { get; set; }
        HeaderClickViewModel HeaderClickViewModel { get; set; }

        event EventHandler<HeaderClickViewModel> AddingColumn;
        event EventHandler BrowserLoadingComplete;
        event EventHandler<string> DeletingColumn;
        event EventHandler ViewClosing;

        void InitializeChromium();
    }
}