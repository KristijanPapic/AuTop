using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using AuTOP.Common;
using AuTOP.Model.DomainModels;
using AuTOP.Service;
using AuTOP.Service.Common;
using AuTOP.WebAPI.Models;
using AuTOP.WebAPI.Models.DetailModel;
using AuTOP.WebAPI.Models.InputModel;

namespace AuTOP.WebAPI.Controllers
{
    public class ManufacturerController :ApiController
    {
        private IManufacturerServis manufacturerServis;
        private IMapper mapper;

        public ManufacturerController(IManufacturerServis manufacturerServis,IMapper mapper)
        {
            this.manufacturerServis = manufacturerServis;
            this.mapper = mapper;
        }
        public async Task<HttpResponseMessage> GetAllManufacturersAsync(string name = "", string sortBy = "Name", string sortMethod = "", int page = 1)
        {
            ManufacturerFilter filter = new ManufacturerFilter
            {
                Name = name
            };
            Sorting sorting = new Sorting(sortBy, sortMethod);
            Paging paging = new Paging(page);
            List<ManufacturerDomainModel> domainManufacturers = await manufacturerServis.GetAllManufacturersAsync(filter,sorting,paging);
            List<ManufacturerViewModel> viewManufacturers = mapper.Map<List<ManufacturerDomainModel>, List<ManufacturerViewModel>>(domainManufacturers);
            return Request.CreateResponse(HttpStatusCode.OK,viewManufacturers);
  
        }
        public async Task<HttpResponseMessage> GetManufacturerByIdAsync(Guid id)
        {
            ManufacturerDomainModel domainManufacturer = await manufacturerServis.GetManufacturerByIdAsync(id);
            ManufacturerDetailModel detailManufacturer = mapper.Map<ManufacturerDomainModel, ManufacturerDetailModel>(domainManufacturer);
            return Request.CreateResponse(HttpStatusCode.OK,domainManufacturer);
        }

        public async Task<HttpResponseMessage> PostManufacturerAsync(ManufacturerInputModel manufacturer)
        {
            ManufacturerDomainModel domainManufacturer = mapper.Map<ManufacturerInputModel, ManufacturerDomainModel>(manufacturer);
            await manufacturerServis.PostManufacturerAsync(domainManufacturer);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        public async Task<HttpResponseMessage> PutManufacturerAsync(ManufacturerInputModel manufacturer)
        {
            ManufacturerDomainModel domainManufacturer = mapper.Map<ManufacturerInputModel, ManufacturerDomainModel>(manufacturer);
            await manufacturerServis.PutManufacturerAsync(domainManufacturer);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        public async Task<HttpResponseMessage> DeleteManufacturerAsync(Guid id)
        {
            await manufacturerServis.DeleteManufacturerAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }



    }
}