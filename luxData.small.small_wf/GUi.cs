using CefSharp;
using CefSharp.WinForms;
using luxData.small.small_wf.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luxData.small.small_wf
{
    public partial class GUI : Form, IView
    {
        public ChromiumWebBrowser chromeBrowser;

        public GUI()
        {
            InitializeComponent();
            new Presenter.Presenter(this);
            InitializeChromium();
        }

        public object DataSource
        {
            get => throw new NotImplementedException(); set
            {
                DataGrid.DataSource = value;
            }
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("http://ourcodeworld.com");
            // Add it to the form and fill it to the form window.
            GridSplitContainer.Panel1.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
