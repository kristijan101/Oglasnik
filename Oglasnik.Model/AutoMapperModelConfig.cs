using AutoMapper;
using Oglasnik.DAL.Entities;
using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Model
{
    public class AutoMapperModelConfig : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperModelConfig"/> class.
        /// </summary>
        public AutoMapperModelConfig()
        {
            Mapper.CreateMap<ICounty, CountyEntity>().ReverseMap();
            Mapper.CreateMap<ILocation, LocationEntity>().ReverseMap();
        }
    }
}
