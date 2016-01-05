using AutoMapper;
using Oglasnik.Common;
using Oglasnik.Model.Common;
using Oglasnik.Services.Common;
using Oglasnik.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Oglasnik.WebAPI.Controllers
{
    public class CountyController : ApiController
    {
        private ICountyService countyService;

        #region Constructor

        public CountyController(ICountyService service)
        {
            countyService = service;
        }
        #endregion

        #region Methods

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteCounty(Guid id)
        {
            if(await countyService.Delete(id))
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        public async Task<HttpResponseMessage> GetAllCounties()
        {
            IEnumerable<CountyModel> counties = Mapper.Map<IEnumerable<CountyModel>>(await countyService.GetAll());
            
            if(counties != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, counties);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> GetCounties(string search, int pageNum, int pageSize)
        {
            IEnumerable<CountyModel> counties = Mapper.Map<IEnumerable<CountyModel>>(
                await countyService.GetRange(new DefaultFilter(search, pageNum, pageSize))
                );

            if(counties != null)
            {
                return Request.CreateResponse(HttpStatusCode.Found, counties);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        public async Task<HttpResponseMessage> GetCountyById(Guid id)
        {
            CountyModel county = Mapper.Map<CountyModel>(await countyService.GetById(id));

            if (county != null)
            {
                return Request.CreateResponse(HttpStatusCode.Found, county);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        public async Task<HttpResponseMessage> PostCounty(CountyModel county)
        {
            if (await countyService.Add(Mapper.Map<ICounty>(county)))
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateCounty(CountyModel county)
        {
            if(ModelState.IsValid && await countyService.Update(Mapper.Map<ICounty>(county)))
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        #endregion
    }
}
