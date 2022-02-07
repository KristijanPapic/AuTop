using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Common
{
    public class ModelFilter
    {
        private string searchBy;
        private string search;

        public ModelFilter(string search,string searchBy)
        {
            SearchBy = searchBy;
            Search = search;
        }

        public string Search { get => search; set => search = value; }
        public string SearchBy { get => searchBy; set => searchBy = value; }
    }
}
