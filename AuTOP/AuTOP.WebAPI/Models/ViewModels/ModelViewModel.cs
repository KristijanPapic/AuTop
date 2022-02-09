using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuTOP.WebAPI.Models
{
    public class ModelViewModel
    {
        private string name;
        private ManufacturerViewModel manufacturer;

        public string Name { get => name; set => name = value; }
        public ManufacturerViewModel Manufacturer { get => manufacturer; set => manufacturer = value; }
    }
}