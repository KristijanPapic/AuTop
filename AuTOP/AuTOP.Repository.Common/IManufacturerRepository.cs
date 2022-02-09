using AuTOP.Common;
using AuTOP.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuTOP.Repository
{
    public interface IManufacturerRepository
    {
        Task<List<ManufacturerDomainModel>> GetAllManufacturers(ManufacturerFilter filter, Sorting sort, Paging paging);
        Task<ManufacturerDomainModel> GetManufacturerByIdAsync(Guid id);
    }
}