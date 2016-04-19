using AutoMapper;
using Oglasnik.Common;
using Oglasnik.DAL.Entities;
using Oglasnik.Model.Common;
using PagedList;

namespace Oglasnik.Repository
{
    public class AutoMapperRepositoryConfig : Profile
    {
        public AutoMapperRepositoryConfig()
        {
            Mapper.CreateMap<IPagedList<LocationEntity>, IPagedList<ILocation>>().ConvertUsing<PagedListTypeConverter<LocationEntity, ILocation>>();
            Mapper.CreateMap<IPagedList<CountyEntity>, IPagedList<ICounty>>().ConvertUsing<PagedListTypeConverter<CountyEntity, ICounty>>();
        }
    }
}
