using Oglasnik.Common;
using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Repository.Common
{
    public interface ILocationRepository
    {
        /// <summary>
        /// Adds a location of type ILocation.
        /// </summary>
        /// <param name="location">Instance of type ILocation to be added.</param>
        /// <returns>Returns <see cref="Task{Boolean}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Add(ILocation county);

        /// <summary>
        /// Deletes a location of type ILocation.
        /// </summary>
        /// <param name="location">Instance of type ILocation</param>
        /// <returns>Returns <see cref="Task{Boolean}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Delete(ILocation county);

        /// <summary>
        /// Deletes the location with the given Id.
        /// </summary>
        /// <param name="id">Id of the location</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Delete(Guid id);

        /// <summary>
        /// Gets all locations.
        /// </summary>
        /// <returns>Returns <see cref="Task{IEnumerable{ILocation}}"/></returns>
        Task<IEnumerable<ILocation>> GetAllAsync();

        /// <summary>
        /// Gets the location with the given Id.
        /// </summary>
        /// <param name="id">Id of the location to be fetched.</param>
        /// <returns>Returns <see cref="Task{ILocation}"/></returns>
        Task<ILocation> GetAsync(Guid id);

        /// <summary>
        /// Gets a range of locations which names contain the string given by the filter object.
        /// </summary>
        /// <param name="filter">Filter instance of type IFilter</param>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ILocation}}"/></returns>
        Task<IEnumerable<ILocation>> GetRangeAsync(IFilter filter, IPagingParameters paging);

        /// <summary>
        /// Gets a range of locations.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ILocation}}"/></returns>
        Task<IEnumerable<ILocation>> GetRangeAsync(IPagingParameters paging);

        /// <summary>
        /// Gets a sorted range of locations.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">A class instance that implements <see cref="ISortingParameters"/>, holds sorting options.</param>
        /// <returns></returns>
        Task<IEnumerable<ILocation>> GetRangeAsync(IPagingParameters paging, ISortingParameters sorting);

        /// <summary>
        /// Updates a location of type ILocation.
        /// </summary>
        /// <param name="location">The location to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Update(ILocation county);
    }
}
