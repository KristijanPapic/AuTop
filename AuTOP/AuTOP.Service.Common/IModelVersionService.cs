﻿using AuTOP.Common;
using AuTOP.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuTOP.Service
{
    public interface IModelVersionService
    {
        Task<List<ModelVersion>> GetAllModelVersionsAsync(ModelVersionFilter filter, Sorting sort, Paging paging);
        Task<ModelVersion> GetModelVersionByIdAsync(Guid id);
    }
}