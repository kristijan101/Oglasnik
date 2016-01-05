using AutoMapper;
using Oglasnik.Model.Common;
using Oglasnik.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oglasnik.WebAPI.App_Start
{
    public class AutoMapperWebApiConfig : Profile
    {
        public AutoMapperWebApiConfig()
        {
            Mapper.CreateMap<ICounty, CountyModel>().ReverseMap();
            Mapper.CreateMap<ILocation, LocationModel>().ForMember(m => m.County, opt => opt.MapFrom(m => m.County.Name));
            Mapper.CreateMap<LocationModel, ILocation>().ForMember(m => m.County, opt => opt.Ignore());
        }
    }
}