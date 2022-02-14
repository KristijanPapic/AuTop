using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Common
{
    public class TransmissionFilter
    {
        private string searchBy;
        private string search;
        private Guid searchId;
        public TransmissionFilter(string search, string searchBy)
        {
            SearchBy = searchBy;
            Search = search;
        }
        public TransmissionFilter(Guid searchId, string searchBy)
        {
            SearchBy = searchBy;
            SearchId = searchId;
        }

        public string Search { get => search; set => search = value; }
        public string SearchBy { get => searchBy; set => searchBy = value; }
        public Guid SearchId { get => searchId; set => searchId = value; }
    }
}
