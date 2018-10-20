using AddColumn;
using AddColumn.ViewModels;
using CefSharp;
using CefSharp.WinForms;
using luxData.small.small_wf.Utils;
using luxData.small.small_wf.ViewModels;
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
        private Presenter.LDPresenter presenter;
        public HeaderClickViewModel HeaderClickViewModel { get; set; }

        public ChromiumWebBrowser chromeBrowser { get; set; }

        public GUI()
        {
            InitializeComponent();
            presenter = new Presenter.LDPresenter(this);
        }

        public DataTable DataSource
        {
            get => throw new NotImplementedException(); set
            {
                DataGrid.DataSource = value;
            }
        }

        public event EventHandler ViewClosing;
        public event EventHandler BrowserLoadingComplete;
        public event EventHandler<HeaderClickViewModel> AddingColumn;
        public event EventHandler<string> DeletingColumn;

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
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

        private void DataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) return;

            HeaderClickViewModel = new HeaderClickViewModel(e);
            GridHeaderMenuStrip.Show(Cursor.Position);

        }

        private void AddColumnToolStripItem_Click(object sender, EventArgs e)
        {
            var dialog = new AddColumnDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                HeaderClickViewModel.AddColumnViewModel = dialog.AddColumnViewModel;
                AddingColumn(sender, HeaderClickViewModel);
            }
        }

        private void DeleteColumnToolStripItem_Click(object sender, EventArgs e)
        {
            var columnName = DataGrid.Columns[HeaderClickViewModel.e.ColumnIndex].Name.ToString();
            DeletingColumn(sender, columnName);
        }
    }
}
