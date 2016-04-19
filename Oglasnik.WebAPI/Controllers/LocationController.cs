using AutoMapper;
using Oglasnik.Common;
using Oglasnik.Model.Common;
using Oglasnik.Services.Common;
using Oglasnik.WebAPI.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Oglasnik.WebAPI.Controllers
{
    [RoutePrefix("api/location")]
    public class LocationController : ApiController
    {
        #region Fields

        /// <summary>
        /// Store for the location service
        /// </summary>
        private readonly ILocationService locationService;

        #endregion

        #region Constructor


        /// <summary>
        /// Initializes a new instance of the <see cref="LocationController"/> class.
        /// </summary>
        /// <param name="service">The service of type <see cref="ILocationService"/>.</param>
        public LocationController(ILocationService service)
        {
            locationService = service;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Deletes a location.
        /// </summary>
        /// <param name="id">The identifier of the location to be deleted.</param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            if (await locationService.DeleteAsync(id))
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Gets the location with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            LocationModel location = Mapper.Map<LocationModel>(await locationService.GetAsync(id));

            if (location != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, location);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Gets a collection of locations that meet the criteria.
        /// </summary>
        /// <param name="q">The search query.</param>
        /// <param name="page">Page number</param>
        /// <param name="size">Page size, max. amount of results returned</param>
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

            PagedListViewModel<LocationModel> locations = Mapper.Map<PagedListViewModel<LocationModel>>(
                Mapper.Map<IPagedList<LocationModel>>(
                    await locationService.GetAsync(new PagingParameters(page, size), sortParams, filter)
                ));

            if (locations != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, locations);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Creates a new location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Post(LocationModel location)
        {
            if (await locationService.AddAsync(Mapper.Map<ILocation>(location)))
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Updates the specified location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<HttpResponseMessage> Put(LocationModel location)
        {
            if (ModelState.IsValid && await locationService.UpdateAsync(Mapper.Map<ILocation>(location)))
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


        