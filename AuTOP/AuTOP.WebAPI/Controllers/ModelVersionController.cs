using AutoMapper;
using AuTOP.Common;
using AuTOP.Model;
using AuTOP.Model.DomainModels;
using AuTOP.Service;
using AuTOP.WebAPI.Models;
using AuTOP.WebAPI.Models.DetailModel;
using AuTOP.WebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AuTOP.WebAPI.Controllers
{
    public class ModelVersionController : ApiController
    {
        private IMapper mapper;
        private IModelVersionService modelVersionService;

        public ModelVersionController(IMapper mapper,IModelVersionService modelVersionService)
        {
            this.mapper = mapper;
            this.modelVersionService = modelVersionService;
        }
        public async Task<HttpResponseMessage> GetAllModelVersions(Guid? searchOpt = null, string searchBy="Id",string sortBy = "Year", string sortMethod = "ASC", int page = 1)
        {
            Guid search;
            if (searchOpt.HasValue)
            {
                search = searchOpt.Value;
            }
            else
            {
                search = Guid.Empty;
            }
            ModelVersionFilter filter = new ModelVersionFilter(search, searchBy);
            Sorting sorting = new Sorting(sortBy, sortMethod);
            Paging paging = new Paging(page);
            List<ModelVersion> modelVersionsDomain = await modelVersionService.GetAllModelVersionsAsync(filter, sorting, paging);
            List<ModelVersionViewModel> modelVersionsView = mapper.Map<List<ModelVersion>, List<ModelVersionViewModel>>(modelVersionsDomain);
            return Request.CreateResponse(HttpStatusCode.OK, modelVersionsView);

        }
        public async Task<HttpResponseMessage> GetModelVersionById(Guid id)
        {
            ModelVersion modelVersionDomain = await modelVersionService.GetModelVersionByIdAsync(id,"Marko");
            ModelVersionDetailModel detailModel = mapper.Map<ModelVersion, ModelVersionDetailModel>(modelVersionDomain);
            return Request.CreateResponse(HttpStatusCode.OK, detailModel);

       }
    }
}