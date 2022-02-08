using AuTOP.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using AutoMapper;
using AuTOP.WebAPI.Models;
using AuTOP.WebAPI.Models.DetailModel;

namespace AuTOP.WebAPI.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataSet,ManufacturerDomainModel>();
            CreateMap<ModelDomainModel, ModelViewModel>();
            CreateMap<ManufacturerDomainModel, ManufacturerDetailModel>();
            CreateMap<ManufacturerDomainModel, ManufacturerViewModel>();
            
        }
        
    }
}