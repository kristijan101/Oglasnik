using AutoMapper;
using Oglasnik.Common;
using Oglasnik.Model.Common;
using Oglasnik.Services.Common;
using Oglasnik.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Oglasnik.WebAPI.Controllers
{
    [RoutePrefix("api/county")]
    public class CountyController : ApiController
    {
        #region Fields

        /// <summary>
        /// Store for the county service.
        /// </summary>
        private readonly ICountyService countyService;

        #endregion

        #region Constructor


        /// <summary>
        /// Initializes a new instance of the <see cref="CountyController"/> class.
        /// </summary>
        /// <param name="service">The service of type <see cref="ICountyService"/>.</param>
        public CountyController(ICountyService service)
        {
            countyService = service;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Deletes a county.
        /// </summary>
        /// <param name="id">The identifier of the county to be deleted.</param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            if(await countyService.DeleteAsync(id))
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Gets the county with the given Id.
        /// </summary>
        /// <param name="id">The identifier of the county.</param>
        /// <returns></returns>
        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            CountyModel county = Mapper.Map<CountyModel>(await countyService.GetAsync(id));

            if (county != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, county);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Gets a collection of counties that meet the criteria.
        /// </summary>
        /// <param name="q">The search string</param>
        /// <param name="page">Page number</param>
        /// <param name="size">Max. amount of results per page.</param>
        /// <param name="sort">Order by field</param>
        /// <param name="asc">Ascending sort direction</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Get(string q = "", int page = 1, int size = 20, string sort = "", bool asc = true)
        {
            IFilter filter = string.IsNullOrWhiteSpace(q) ? null : new Filter(q);
            ISortingParameters sortParams = null;

            if (!string.IsNullOrWhiteSpace(sort))
            {
                sortParams = new SortingParameters(
                                new List<ISortingPair>()
                                {
                                    new SortingPair(sort, asc)
                                }
                             );
            }

            IEnumerable<CountyModel> counties = Mapper.Map<IEnumerable<CountyModel>>(
                await countyService.GetAsync(new PagingParameters(page, size), sortParams, filter)
                );

            if (counties != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, counties);
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
        public async Task<HttpResponseMessage> Post(CountyModel county)
        {
            if (await countyService.AddAsync(Mapper.Map<ICounty>(county)))
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
        public async Task<HttpResponseMessage> Put(CountyModel county)
        {
            if(ModelState.IsValid && await countyService.UpdateAsync(Mapper.Map<ICounty>(county)))
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
