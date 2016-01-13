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

namespace Oglasnik.WebAPI.Controllers
{
    [RoutePrefix("api/location")]
    public class LocationController : ApiController
    {
        private ILocationService locationService;

        #region Constructor

        /// <summary>
        /// The class constructor method.
        /// </summary>
        /// <param name="service">An instance of a service of type ILocationService.</param>
        public LocationController(ILocationService service)
        {
            locationService = service;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Processes a request to delete a location.
        /// </summary>
        /// <param name="id">The Id of a location to be deleted.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteLocation(Guid id)
        {
            if (await locationService.Delete(id))
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        public async Task<HttpResponseMessage> GetAllLocations()
        {
            IEnumerable<LocationModel> locations = Mapper.Map<IEnumerable<LocationModel>>(await locationService.GetAll());

            if (locations != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, locations);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> GetLocationById(Guid id)
        {
            LocationModel location = Mapper.Map<LocationModel>(await locationService.GetById(id));

            if (location != null)
            {
                return Request.CreateResponse(HttpStatusCode.Found, location);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        [Route("search/{page:int}")]
        public async Task<HttpResponseMessage> GetLocations(string search, int page, int size = 10)
        {
            IEnumerable<LocationModel> locations = Mapper.Map<IEnumerable<LocationModel>>(
                await locationService.GetRange(new Filter(search), new PagingParameters(page, size))
                );

            if (locations != null)
            {
                return Request.CreateResponse(HttpStatusCode.Found, locations);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        [Route("{page:int}")]
        public async Task<HttpResponseMessage> GetLocations(int page, string sort = "", string dir = "", int size = 10)
        {
            IEnumerable<LocationModel> locations = Mapper.Map<IEnumerable<LocationModel>>(
                await locationService.GetRange(new PagingParameters(page, size), new LocationSortingParameters(sort, dir))
                );

            if (locations != null)
            {
                return Request.CreateResponse(HttpStatusCode.Found, locations);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        public async Task<HttpResponseMessage> PostLocation(LocationModel location)
        {
            if (await locationService.Add(Mapper.Map<ILocation>(location)))
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateLocation(LocationModel location)
        {
            if (ModelState.IsValid && await locationService.Update(Mapper.Map<ILocation>(location)))
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


        