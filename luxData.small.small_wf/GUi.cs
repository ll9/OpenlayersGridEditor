﻿using CefSharp;
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
        public ChromiumWebBrowser chromeBrowser { get; set; }

        public GUI()
        {
            InitializeComponent();
            InitializeChromium();
            new Presenter.Presenter(this);
        }

        public object DataSource
        {
            get => throw new NotImplementedException(); set
            {
                DataGrid.DataSource = value;
            }
        }

        public event EventHandler ViewClosing;
        public event EventHandler BrowserLoadingComplete;

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            var page = $@"{Application.StartupPath}\html_resources\index.html";
            chromeBrowser = new ChromiumWebBrowser(page);
            // Add it to the form and fill it to the form window.
            GridSplitContainer.Panel1.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
            chromeBrowser.LoadingStateChanged += ChromeBrowser_LoadingStateChanged;
        }

        private void ChromeBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false)
            {
                chromeBrowser.Invoke((Action)(() => BrowserLoadingComplete(sender, e)));
            }
        }

        private void GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
            ViewClosing(sender, e);
        }

        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                chromeBrowser.ShowDevTools();
            }
        }
    }
}
