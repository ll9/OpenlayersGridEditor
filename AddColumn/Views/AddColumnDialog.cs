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
            if (ValidateResult())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateResult()
        {
            if (string.IsNullOrEmpty(AddColumnViewModel.ColumnName))
            {
                MessageBox.Show("Column Name may not be empty");
                return false;
            }
            return true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
