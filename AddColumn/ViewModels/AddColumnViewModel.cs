using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardDemo.Models;

namespace AddColumn.ViewModels
{
    public class AddColumnViewModel
    {
        public string ColumnName { get; set; }
        public DataType DataType { get; set; } = DataType.System_String;
    }
}
