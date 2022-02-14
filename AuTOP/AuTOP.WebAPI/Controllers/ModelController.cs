﻿using AutoMapper;
using AuTOP.Common;
using AuTOP.Model.DomainModels;
using AuTOP.Service;
using AuTOP.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AuTOP.WebAPI.Controllers
{
    public class ModelController : ApiController
    {
        private IModelService modelService;
        private IMapper mapper;

        public ModelController(IModelService modelServis, IMapper mapper)
        {
            this.modelService = modelServis;
            this.mapper = mapper;
        }
        public async Task<HttpResponseMessage> GetAllModels(ModelFilter filter = null, string sortBy = "Name", string sortMethod = "", int page = 1)
        {
            if(filter == null)
            {
                filter = new ModelFilter();
            }
            Sorting sorting = new Sorting(sortBy, sortMethod);
            Paging paging = new Paging(page);
            List<ModelDomainModel> domainModels = await modelService.GetAllModelsAsync(filter, sorting, paging);
            List<ModelViewModel> viewModels = mapper.Map<List<ModelDomainModel>, List<ModelViewModel>>(domainModels);
            return Request.CreateResponse(HttpStatusCode.OK, viewModels);

        }
        public async Task<HttpResponseMessage> GetModel(Guid id)
        {
            ModelDomainModel domainModel = await modelService.GetModelAsync(id);
            ModelViewModel viewModel = mapper.Map<ModelDomainModel, ModelViewModel>(domainModel);
            return Request.CreateResponse(HttpStatusCode.OK, viewModel);

        }
    }
}