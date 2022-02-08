using AuTOP.Common;
using AuTOP.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuTOP.Repository
{
    public interface IModelRepository
    {
        Task<List<ModelDomainModel>> GetAllModelsAsync(ModelFilter filter, Sorting sort, Paging paging);
    }
}