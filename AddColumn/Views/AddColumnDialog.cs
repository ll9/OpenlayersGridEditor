using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WizardDemo.Models;

namespace AddColumn
{
    public partial class AddColumnDialog : Form
    {
        public ViewModels.AddColumnViewModel AddColumnViewModel { get; set; } = new ViewModels.AddColumnViewModel();

        public AddColumnDialog()
        {
            InitializeComponent();
            DataTypeBox.DataSource = Enum.GetValues(typeof(DataType)).Cast<DataType>().ToList();
            DataTypeBox.DataBindings.Add("SelectedItem", AddColumnViewModel, "DataType");
            NameBox.DataBindings.Add("Text", AddColumnViewModel, "ColumnName");
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Should add prop with colname {AddColumnViewModel.ColumnName} and Datatye {AddColumnViewModel.DataType}");
        }
    }
}
