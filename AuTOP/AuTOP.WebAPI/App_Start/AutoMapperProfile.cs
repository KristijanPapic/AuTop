using AuTOP.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using AutoMapper;

namespace AuTOP.WebAPI.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataTable,ManufacturerDomainModel>().ReverseMap();
        }
        
    }
}