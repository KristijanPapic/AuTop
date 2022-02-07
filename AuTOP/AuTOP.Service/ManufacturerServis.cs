using AuTOP.Common;
using AuTOP.Model.DomainModels;
using AuTOP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuTOP.Service.Common;

namespace AuTOP.Service
{
    class ManufacturerServis : IManufacturerServis
    {
        private IManufacturerRepository manufacturerRepository;
        public async Task<List<ManufacturerDomainModel>> GetAllManufacturersAsync(ManufacturerFilter courseFilter, Sorting sort, Paging paging)
        {
            List<ManufacturerDomainModel> manufacturers = await manufacturerRepository.GetAllManufacturers(courseFilter, sort, paging);
            return manufacturers; ;
        }
    }
}
