using Oglasnik.Common;
using Oglasnik.Model.Common;
using Oglasnik.Repository.Common;
using Oglasnik.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Services
{
    public class LocationService : ILocationService
    {
        private ILocationRepository repository;

        /// <summary>
        /// The class constructor method.
        /// </summary>
        /// <param name="repository">Instance of ILocationRepository type.</param>
        public LocationService(ILocationRepository repository)
        {
            this.repository = repository;
        }

        #region Methods

        /// <summary>
        /// Adds a location to the repository.
        /// </summary>
        /// <param name="location">The location instance to be added.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Add(ILocation location)
        {
            return repository.Add(location);
        }

        /// <summary>
        /// Deletes a location from the repository.
        /// </summary>
        /// <param name="location">The location instance to be deleted.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Delete(ILocation location)
        {
            return repository.Delete(location);
        }

        /// <summary>
        /// Deletes a location with the given Id.
        /// </summary>
        /// <param name="id">Id of the location to be deleted.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Delete(Guid id)
        {
            return repository.Delete(id);
        }

        /// <summary>
        /// Gets all locations from the repository.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ILocation>> GetAll()
        {
            return repository.GetAllAsync();
        }

        /// <summary>
        /// Gets the location with the specified Id.
        /// </summary>
        /// <param name="id">Id (of type <see cref="Guid"/>) of the location.</param>
        /// <returns>Returns the location requested or null if not found.</returns>
        public Task<ILocation> GetById(Guid id)
        {
            return repository.GetAsync(id);
        }

        /// <summary>
        /// Gets a range of locations which names contain the string given by the filter object.
        /// </summary>
        /// <param name="filter">Filter instance of type IFilter</param>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ILocation}}"/></returns>
        public Task<IEnumerable<ILocation>> GetRange(IFilter filter, IPagingParameters paging)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }
            if(paging == null)
            {
                throw new ArgumentNullException("paging");
            }

            return repository.GetRangeAsync(filter, paging);
        }

        /// <summary>
        /// Gets a range of locations.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ILocation}}"/></returns>
        public Task<IEnumerable<ILocation>> GetRange(IPagingParameters paging)
        {
            if (paging == null)
            {
                throw new ArgumentNullException("paging");
            }

            return repository.GetRangeAsync(paging);
        }

        /// <summary>
        /// Gets a sorted range of locations.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">A class instance that implements <see cref="ISortingParameters"/>, holds sorting options.</param>
        /// <returns></returns>
        public Task<IEnumerable<ILocation>> GetRange(IPagingParameters paging, ISortingParameters sorting)
        {
            if (paging == null)
            {
                throw new ArgumentNullException("paging");
            }
            if (sorting == null)
            {
                throw new ArgumentNullException("sorting");
            }

            return repository.GetRangeAsync(paging, sorting);
        }

        /// <summary>
        /// Updates a location.
        /// </summary>
        /// <param name="location">The location to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        public Task<bool> Update(ILocation location)
        {
            return repository.Update(location);
        }

        #endregion
    }
}
