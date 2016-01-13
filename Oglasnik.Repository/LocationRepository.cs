using AutoMapper;
using Oglasnik.Common;
using Oglasnik.DAL.Entities;
using Oglasnik.Model.Common;
using Oglasnik.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace Oglasnik.Repository
{
    public class LocationRepository : ILocationRepository
    {
        /// <summary>
        /// Store for the repository instance of type IRepository
        /// </summary>
        private IRepository repository;

        #region Constructor

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="repository">Repository instance of type IRepository</param>
        public LocationRepository(IRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a location of type ILocation.
        /// </summary>
        /// <param name="location">Instance of type ILocation to be added.</param>
        /// <returns>Returns <see cref="Task{Boolean}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Add(ILocation location)
        {
            if(location == null)
            {
                throw new ArgumentNullException("location");
            }

            return repository.AddAsync(Mapper.Map<LocationEntity>(location));
        }

        /// <summary>
        /// Deletes a location of type ILocation.
        /// </summary>
        /// <param name="location">Instance of type ILocation</param>
        /// <returns>Returns <see cref="Task{Boolean}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Delete(ILocation location)
        {
            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            return repository.DeleteAsync(Mapper.Map<LocationEntity>(location));
        }

        /// <summary>
        /// Deletes the location with the given Id.
        /// </summary>
        /// <param name="id">Id of the location</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Delete(Guid id)
        {
            LocationEntity location = new LocationEntity { Id = id };

            return repository.DeleteAsync(location);
        }

        /// <summary>
        /// Gets all locations.
        /// </summary>
        /// <returns>Returns <see cref="Task{IEnumerable{ILocation}}"/></returns>
        public async Task<IEnumerable<ILocation>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<ILocation>>(await repository.GetAll<LocationEntity>().ToListAsync());
        }

        /// <summary>
        /// Gets the location with the given Id.
        /// </summary>
        /// <param name="id">Id of the location to be fetched.</param>
        /// <returns>Returns <see cref="Task{ILocation}"/></returns>
        public async Task<ILocation> GetAsync(Guid id)
        {
            return Mapper.Map<ILocation>(await repository.GetById<LocationEntity>(id));
        }

        /// <summary>
        /// Gets a range of locations which names contain the string given by the filter object.
        /// </summary>
        /// <param name="filter">Filter instance of type IFilter</param>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ILocation}}"/></returns>
        public async Task<IEnumerable<ILocation>> GetRangeAsync(IFilter filter, IPagingParameters paging)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }
            if (paging == null)
            {
                throw new ArgumentNullException("paging");
            }

            var query = repository.GetAll<LocationEntity>()
                            .OrderBy(e => e.Name)
                            .Where(e => e.Name.ToLower().Contains(filter.SearchString.ToLower()))
                            .Skip((paging.PageNumber - 1) * paging.PageSize)
                            .Take(paging.PageSize);

            return Mapper.Map<IEnumerable<ILocation>>(await query.ToListAsync());
        }

        /// <summary>
        /// Gets a range of locations.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ILocation}}"/></returns>
        public async Task<IEnumerable<ILocation>> GetRangeAsync(IPagingParameters paging)
        {
            if (paging == null)
            {
                throw new ArgumentNullException("paging");
            }

            var query = repository.GetAll<LocationEntity>()
                            .OrderBy(e => e.Id)
                            .Skip((paging.PageNumber - 1) * paging.PageSize)
                            .Take(paging.PageSize);

            return Mapper.Map<IEnumerable<ILocation>>(await query.ToListAsync());
        }

        /// <summary>
        /// Gets a sorted range of locations.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">A class instance that implements <see cref="ISortingParameters"/>, holds sorting options.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ILocation>> GetRangeAsync(IPagingParameters paging, ISortingParameters sorting)
        {
            if (paging == null)
            {
                throw new ArgumentNullException("paging");
            }
            if (sorting == null)
            {
                throw new ArgumentNullException("sorting");
            }

            var query = repository.GetAll<LocationEntity>()
                            .OrderBy(sorting.SortBy + " " + sorting.SortDirection)
                            .Skip((paging.PageNumber - 1) * paging.PageSize)
                            .Take(paging.PageSize);

            return Mapper.Map<IEnumerable<ILocation>>(await query.ToListAsync());
        }

        /// <summary>
        /// Updates a location of type ILocation.
        /// </summary>
        /// <param name="location">The location to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Update(ILocation location)
        {
            if (location == null)
            {
                throw new ArgumentNullException("location");
            }

            LocationEntity entity = Mapper.Map<LocationEntity>(location);

            return repository.UpdateAsync(entity);
        }

        #endregion
    }
}
