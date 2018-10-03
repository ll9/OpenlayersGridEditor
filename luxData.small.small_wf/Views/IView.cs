using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luxData.small.small_wf.Views
{
    interface IView
    {
        object DataSource { get; set; }
        event EventHandler ViewClosing;
    }
}
