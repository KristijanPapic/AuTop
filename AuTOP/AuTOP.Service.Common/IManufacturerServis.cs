using AuTOP.Common;
using AuTOP.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuTOP.Service
{
    public interface IManufacturerServis
    {
        Task<List<ManufacturerDomainModel>> GetAllManufacturersAsync(ManufacturerFilter courseFilter, Sorting sort, Paging paging);
        Task<ManufacturerDomainModel> GetManufacturerByIdAsync(Guid id);
        Task PostManufacturerAsync(ManufacturerDomainModel manufacturer);
        Task PutManufacturerAsync(ManufacturerDomainModel manufacturer);
        Task DeleteManufacturerAsync(Guid id);

    }
}