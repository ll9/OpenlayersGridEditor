using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometryDialog
{
    public partial class NewGeometryDialog : Form
    {
        public NewGeometryDialog()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            PropertiesFlowPanel.Controls.Add(new UserControl1());
        }
    }
}
