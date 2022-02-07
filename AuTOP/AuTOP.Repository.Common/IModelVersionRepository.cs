using AuTOP.Common;
using AuTOP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Repository.Common
{
    public interface IModelVersionRepository 
    {
       Task<List<ModelVersion>> GetAllModelVersions(Sorting sort, Paging paging);

       Task<ModelVersion> GetModelVersionById(string name);
    }
}
