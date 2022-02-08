using AuTOP.Common;
using AuTOP.Model;
using AuTOP.Repository;
using AuTOP.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Service
{
    class ModelVersionService : IModelVersionService
    {
        private IModelVersionRepository modelVersionRepository;
        private IModelRepository modelRepository;
        private IMotorRepository motorRepository;
        private ITransmissionRepository transmissionRepository;
        private IBodyShapeRepository bodyShapeRepository;

        public ModelVersionService(IModelVersionRepository modelVersionRepository, IModelRepository modelRepository, IMotorRepository motorRepository, ITransmissionRepository transmissionRepository, IBodyShapeRepository bodyShapeRepository)
        {
            this.modelVersionRepository = modelVersionRepository;
            this.modelRepository = modelRepository;
            this.motorRepository = motorRepository;
            this.transmissionRepository = transmissionRepository;
            this.bodyShapeRepository = bodyShapeRepository;
        }
        public async Task<List<ModelVersion>> GetAllModelVersionsAsync(ModelVersionFilter filter, Sorting sort, Paging paging)
        {
            List<ModelVersion> ModelVersions = await modelVersionRepository.GetAllModelVersions(filter, sort, paging);
            foreach (ModelVersion modelVersion in ModelVersions)
            {
                modelVersion.Motor = await motorRepository.GetByIdAsync(modelVersion.MotorId);
            }

            return ModelVersions;
        }
        public async Task<ModelVersion> GetModelVersionByNameAsync(Guid id)
        {
            ModelVersion domainModelVersion = await modelVersionRepository.GetModelVersionById(id);
            domainModelVersion.Model = await modelRepository.GetModelById(domainModelVersion.ModelId);
            domainModelVersion.Motor = await motorRepository.GetByIdAsync(domainModelVersion.MotorId);
            domainModelVersion.Transmission = await transmissionRepository.GetByIdAsync(domainModelVersion.TransmissionId);
            domainModelVersion.BodyShape = await bodyShapeRepository.GetByIdAsync(domainModelVersion.BodyShapeId);
            return domainModelVersion;
        }
    }
}
