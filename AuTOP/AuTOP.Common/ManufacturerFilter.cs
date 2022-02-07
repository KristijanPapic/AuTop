using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Common
{
    public class ManufacturerFilter
    {
        private string search;
        private bool dontGetModels = false;

        public ManufacturerFilter(string search)
        {
            Search = search;
        }

        public string Search { get => search; set => search = value; }
        public bool DontGetModels { get => dontGetModels; set => dontGetModels = value; }
    }
}
