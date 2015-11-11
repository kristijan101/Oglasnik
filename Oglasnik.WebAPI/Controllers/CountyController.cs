using Oglasnik.Model.Common;
using Oglasnik.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Oglasnik.WebAPI.Controllers
{
    [RoutePrefix("api/county")]
    public class CountyController : ApiController
    {
        private ICountyService countyService;

        public CountyController(ICountyService service)
        {
            countyService = service;
        }

        [HttpGet]
        [Route("all")]
        public async Task<HttpResponseMessage> ListCountiesAsync()
        {
            IEnumerable<ICounty> counties = await countyService.GetAllAsync();

            if(counties != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, counties);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("new")]
        public async Task<HttpResponseMessage> CreateAsync(ICounty county)
        {
            if(await countyService.AddAsync(county) > 0)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
