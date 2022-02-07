using AuTOP.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Model.DomainModels
{
    public class ManufacturerDomainModel : DateTimeModel
    {
        private Guid id;
        private string name;

        public ManufacturerDomainModel(Guid id,string name,DateTime dateCreated,DateTime dateUpdated)
        {
            Id = id;
            Name = name;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;

        }

        public Guid Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
