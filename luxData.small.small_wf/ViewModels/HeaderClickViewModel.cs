using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luxData.small.small_wf.ViewModels
{
    public class HeaderClickViewModel
    {
        public DataGridViewCellMouseEventArgs e;

        public HeaderClickViewModel(DataGridViewCellMouseEventArgs e)
        {
            this.e = e;
        }
    }
}
