using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuTOP.WebAPI.Models.DetailModel
{
    public class ManufacturerDetailModel
    {
        private string name;
        private List<ModelViewModel> models;
        public string Name { get => name; set => name = value; }
        public List<ModelViewModel> Models { get => models; set => models = value; }
    }
}