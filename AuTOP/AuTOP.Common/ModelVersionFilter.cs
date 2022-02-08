using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Common
{
    public class ModelVersionFilter
    {
        private Guid searchId;
        private string searchBy;

        public ModelVersionFilter(Guid searchId, string searchBy)
        {
            SearchId = searchId;
            SearchBy = searchBy;
        }

        public Guid SearchId { get => searchId; set => searchId = value; }
        public string SearchBy { get => searchBy; set => searchBy = value; }
    }
}
