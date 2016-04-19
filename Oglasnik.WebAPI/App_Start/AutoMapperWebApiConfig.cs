using AutoMapper;
using Oglasnik.Common;
using Oglasnik.Model.Common;
using Oglasnik.WebAPI.Infrastructure;
using Oglasnik.WebAPI.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oglasnik.WebAPI.App_Start
{
    public class AutoMapperWebApiConfig : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperWebApiConfig"/> class.
        /// </summary>
        public AutoMapperWebApiConfig()
        {
            Mapper.CreateMap<ICounty, CountyModel>().ReverseMap();
            Mapper.CreateMap<ILocation, LocationModel>().ForMember(m => m.County, opt => opt.MapFrom(m => m.County.Name));
            Mapper.CreateMap<LocationModel, ILocation>().ForMember(m => m.County, opt => opt.Ignore());
            Mapper.CreateMap<IPagedList<ILocation>, IPagedList<LocationModel>>().ConvertUsing<PagedListTypeConverter<ILocation, LocationModel>>();
            Mapper.CreateMap<IPagedList<LocationModel>, PagedListViewModel<LocationModel>>().ConvertUsing<PagedListVMTypeConverter<LocationModel>>();
            Mapper.CreateMap<IPagedList<ICounty>, IPagedList<CountyModel>>().ConvertUsing<PagedListTypeConverter<ICounty, CountyModel>>();
            Mapper.CreateMap<IPagedList<CountyModel>, PagedListViewModel<CountyModel>>().ConvertUsing<PagedListVMTypeConverter<CountyModel>>();
        }
    }
}