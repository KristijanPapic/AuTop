using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuTOP.WebAPI.Models
{
    public class ManufacturerViewModel
    {
        private string name;
        private Guid id;
        public string Name { get => name; set => name = value; }
        public Guid Id { get => id; set => id = value; }
    }
}