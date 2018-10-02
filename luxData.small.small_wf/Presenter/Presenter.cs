using luxData.small.small_wf.Views;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luxData.small.small_wf.Presenter
{
    class Presenter
    {
        public IView View { get; set; }

        public Presenter(IView view)
        {
            View = view;

            LoadData();
        }

        private void LoadData()
        {
            var source = new List<Object>
            {
                new {name = "Bara", age = 22 },
                new {name = "haha", age = 23 },
                new {name = "blab", age = 24 },
                new {name = "nana", age = 25 }
            };

            View.DataSource = source;
        }
    }
}
