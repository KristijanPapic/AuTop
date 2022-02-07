using AuTOP.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Model.DomainModels
{
    public class ModelDomainModel : DateTimeModel
    {
        private Guid id;
        private Guid manufacturerId;
        private string name;

        public ModelDomainModel() { }

        public ModelDomainModel(Guid id, Guid manufacturerId, string name,DateTime dateCreated,DateTime dateUpdated)
        {
            Id = id;
            ManufacturerId = manufacturerId;
            Name = name;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
        }

        public Guid Id { get => id; set => id = value; }
        public Guid ManufacturerId { get => manufacturerId; set => manufacturerId = value; }
        public string Name { get => name; set => name = value; }
    }
}
