using AutoMapper;
using Oglasnik.Common;
using Oglasnik.Common.Filters;
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
    [RoutePrefix("api/county")]
    public class CountyController : ApiController
    {
        private ICountyService countyService;

        #region Constructor

        /// <summary>
        /// The class constructor method.
        /// </summary>
        /// <param name="service">An instance of a service of type ICountyService.</param>
        public CountyController(ICountyService service)
        {
            countyService = service;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Processes a request to delete a county.
        /// </summary>
        /// <param name="id">The Id of a county to be deleted.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Retrieves all the counties and returns them in a response to the client.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Retrieves counties that meet the criteria.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="page">Page number</param>
        /// <param name="size">Max. amount of results per page.</param>
        /// <returns></returns>
        [Route("search/{page:int?}")]
        public async Task<HttpResponseMessage> GetCounties(string search, int page = 1, int size = 10)
        {
            IEnumerable<CountyModel> counties = Mapper.Map<IEnumerable<CountyModel>>(
                await countyService.GetRange(new Filter(search), new PagingParameters(page, size))
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

        /// <summary>
        /// Retrieves a sequence of counties.
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="size">Max. amount of results per page.</param>
        /// <param name="dir">Direction of the sort, ascending or descending.</param>
        /// <param name="sort">The property used to sort the results.</param>
        /// <returns></returns>
        [Route("{page:int}")]
        public async Task<HttpResponseMessage> GetCounties(int page, string sort = "", string dir = "", int size = 10)
        {
            IEnumerable<CountyModel> counties = Mapper.Map<IEnumerable<CountyModel>>(
                await countyService.GetRange(new PagingParameters(page, size), new CountySortingParameters(sort, dir))
                );

            if (counties != null)
            {
                return Request.CreateResponse(HttpStatusCode.Found, counties);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Gets the county with the given Id.
        /// </summary>
        /// <param name="id">The Id of the county.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new county.
        /// </summary>
        /// <param name="county">The county to be created.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates a county.
        /// </summary>
        /// <param name="county">The county to be updated.</param>
        /// <returns></returns>
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
