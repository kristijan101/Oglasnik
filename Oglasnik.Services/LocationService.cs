using Oglasnik.Common;
using Oglasnik.Model.Common;
using Oglasnik.Repository.Common;
using Oglasnik.Services.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oglasnik.Services
{
    public class LocationService : ILocationService
    {
        #region Fields

        /// <summary>
        /// Store for the <see cref="ILocationRepository"/> repository.
        /// </summary>
        private readonly ILocationRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public LocationService(ILocationRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Asynchronously adds a location to the repository.
        /// </summary>
        /// <param name="location">The location instance to be added.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="location"/> is null.</exception>
        public Task<bool> AddAsync(ILocation location)
        {
            if(location == null)
            {
                throw new ArgumentNullException("location");
            }

            return repository.AddAsync(location);
        }

        /// <summary>
        /// Asynchronously deletes a location with the given Id.
        /// </summary>
        /// <param name="id">Id of the location to be deleted.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> DeleteAsync(Guid id)
        {
            return repository.DeleteAsync(id);
        }

        /// <summary>
        /// Asynchronously gets the location with the specified Id.
        /// </summary>
        /// <param name="id">Id (of type <see cref="Guid"/>) of the location.</param>
        /// <returns>Returns the location requested or null if not found.</returns>
        public Task<ILocation> GetAsync(Guid id)
        {
            return repository.GetAsync(id);
        }

        /// <summary>
        /// Asynchronously gets a range of locations which names contain the string given by the filter object.
        /// </summary>
        /// <param name="filter">Filter instance of type IFilter</param>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">Sorting options</param>
        /// <returns>Returns <see cref="Task{IPagedList{ILocation}}"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="paging"/> is null.</exception>
        public Task<IPagedList<ILocation>> GetAsync(IPagingParameters paging, ISortingParameters sorting, IFilter filter)
        {
            if(paging == null)
            {
                throw new ArgumentNullException("paging");
            }

            return repository.GetAsync(paging, sorting, filter);
        }

        /// <summary>
        /// Asynchronously updates a location.
        /// </summary>
        /// <param name="location">The location to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="location"/> is null.</exception>
        public Task<bool> UpdateAsync(ILocation location)
        {
            if(location == null)
            {
                throw new ArgumentNullException("location");
            }
            return repository.UpdateAsync(location);
        }

        #endregion
    }
}
