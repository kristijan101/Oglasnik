using AutoMapper;
using Oglasnik.Common;
using Oglasnik.DAL.Entities;
using Oglasnik.Model.Common;
using Oglasnik.Repository.Common;
using PagedList;
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
        #region Fields

        /// <summary>
        /// Store for the repository instance of type <see cref="IRepository"/>
        /// </summary>
        private readonly IRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationRepository"/> class.
        /// </summary>
        /// <param name="repository">The repository of type <see cref="IRepository"/>.</param>
        public LocationRepository(IRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Asynchronously adds a location.
        /// </summary>
        /// <param name="location">The location to be added.</param>
        /// <returns>Returns <see cref="Task{Boolean}"/> indicating whether the operation was executed successfuly.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="location"/> is null.</exception>
        public Task<bool> AddAsync(ILocation location)
        {
            if(location == null)
            {
                throw new ArgumentNullException("location");
            }

            if(location.CountyID == Guid.Empty)
            {
                throw new Exception();
            }
            
            return repository.AddAsync(Mapper.Map<LocationEntity>(location));
        }

        /// <summary>
        /// Asynchronously deletes the location with the given Id.
        /// </summary>
        /// <param name="id">Id of the location</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> DeleteAsync(Guid id)
        {
            LocationEntity location = new LocationEntity { Id = id };

            return repository.DeleteAsync(location);
        }

        /// <summary>
        /// Asynchronously gets the location with the given Id.
        /// </summary>
        /// <param name="id">Id of the location to be fetched.</param>
        /// <returns>Returns <see cref="Task{ILocation}"/></returns>
        public async Task<ILocation> GetAsync(Guid id)
        {
            return Mapper.Map<ILocation>(await repository.GetAsync<LocationEntity>(id));
        }

        /// <summary>
        /// Asynchronously gets a range of locations which names contain the string given by the filter object.
        /// </summary>
        /// <param name="filter">Filter instance of type <see cref="IFilter"/></param>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IPagedList{ILocation}}"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="paging"/> is null.</exception>
        public async Task<IPagedList<ILocation>> GetAsync(IPagingParameters paging, ISortingParameters sorting, IFilter filter)
        {
            if (paging == null)
            {
                throw new ArgumentNullException("paging");
            }

            if (sorting == null)
            {
                IList<ISortingPair> sortPair = new List<ISortingPair>()
                {
                    new SortingPair("Name")
                };
                sorting = new SortingParameters(sortPair);
            }

            var query = repository.GetAll<LocationEntity>()
                            .OrderBy(sorting.GetJoinedSortExpressions());

            if(filter != null && !string.IsNullOrEmpty(filter.SearchString))
            {
                query = query.Where(e => e.Name.ToLower().Contains(filter.SearchString.ToLower()));
            }

            return Mapper.Map<IPagedList<ILocation>>(await query.ToPagedListAsync(paging.PageNumber, paging.PageSize));
        }

        /// <summary>
        /// Asynchronously updates a location.
        /// </summary>
        /// <param name="location">The location to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="location"/> is null.</exception>
        public Task<bool> UpdateAsync(ILocation location)
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
