using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luxData.small.small_wf.Utils
{
    public interface ISpatialiteManager
    {
        string DbPath { get; }

        void Fill(DataTable dataTable);
        void Update(DataTable dataTable);
    }

    class SpatialiteManager
    {
    }
}
