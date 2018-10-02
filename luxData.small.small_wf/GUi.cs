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
        public GUI()
        {
            InitializeComponent();
            new Presenter.Presenter(this);
        }

        public object DataSource
        {
            get => throw new NotImplementedException(); set
            {
                DataGrid.DataSource = value;
            }
        }
    }
}
