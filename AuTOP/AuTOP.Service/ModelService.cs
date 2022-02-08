using AuTOP.Common;
using AuTOP.Model.DomainModels;
using AuTOP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Service
{
    class ModelService : IModelService
    {
        private IModelRepository modelRepository;
        private IModelVersionService modelVersionService;

        public ModelService(IModelRepository modelRepository)
        {
            this.modelRepository = modelRepository;
        }
        public async Task<List<ModelDomainModel>> GetAllModelsAsync(ModelFilter filter, Sorting sorting, Paging paging)
        {
            List<ModelDomainModel> domainModels = await modelRepository.GetAllModelsAsync(filter, sorting, paging);
            return domainModels;
        }

        public async Task<ModelDomainModel> GetModelAsync(Guid id)
        {
            ModelDomainModel domainModel = await modelRepository.GetModelById(id);
            domainModel.ModelVersions = await modelVersionService.GetAllModelVersionsAsync(new ModelVersionFilter(id, "ModelId"), new Sorting("", ""), new Paging(true));
            return domainModel;
        }

    }
}
