using AuTOP.Common;
using AuTOP.Model.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuTOP.Service
{
    public interface IManufacturerServis
    {
        Task<List<ManufacturerDomainModel>> GetAllManufacturersAsync(ManufacturerFilter courseFilter, Sorting sort, Paging paging);
    }
}