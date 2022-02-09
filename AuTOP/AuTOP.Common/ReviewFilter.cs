using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Common
{
    public class ReviewFilter
    {
        private string searchBy;
        private Guid search;

        public ReviewFilter(string searchBy, Guid search)
        {
            SearchBy = searchBy;
            Search = search;
        }

        public string SearchBy { get => searchBy; set => searchBy = value; }
        public Guid Search { get => search; set => search = value; }
    }
}
