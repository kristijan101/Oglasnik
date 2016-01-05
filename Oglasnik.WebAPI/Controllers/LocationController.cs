using AutoMapper;
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
    public class LocationController : ApiController
    {
        private ILocationService locationService;

        #region Constructor

        public LocationController(ILocationService service)
        {
            locationService = service;
        }
        #endregion

        #region Methods

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

        public async Task<HttpResponseMessage> GetLocations(string search, int pageNum, int pageSize)
        {
            IEnumerable<LocationModel> locations = Mapper.Map<IEnumerable<LocationModel>>(
                await locationService.GetRange(new Common.DefaultFilter(search, pageNum, pageSize))
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


        