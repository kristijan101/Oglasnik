using Oglasnik.Common;
using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Services.Common
{
    public interface ILocationService
    {
        /// <summary>
        /// Adds a location.
        /// </summary>
        /// <param name="location">The location instance to be added.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Add(ILocation location);

        /// <summary>
        /// Deletes a location.
        /// </summary>
        /// <param name="location">The location instance to be deleted.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Delete(ILocation location);

        /// <summary>
        /// Deletes a location with the given Id.
        /// </summary>
        /// <param name="id">Id of the location to be deleted.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Delete(Guid id);

        /// <summary>
        /// Gets all locations.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ILocation>> GetAll();

        /// <summary>
        /// Gets the location with the specified Id.
        /// </summary>
        /// <param name="id">Id (of type <see cref="Guid"/>) of the county.</param>
        /// <returns>Returns the location requested or null if not found.</returns>
        Task<ILocation> GetById(Guid id);

        /// <summary>
        /// Gets a range of locations which names contain the string given by the filter object.
        /// </summary>
        /// <param name="filter">Filter instance of type IFilter</param>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ILocation}}"/></returns>
        Task<IEnumerable<ILocation>> GetRange(IFilter filter, IPagingParameters paging);

        /// <summary>
        /// Gets a range of locations.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ILocation}}"/></returns>
        Task<IEnumerable<ILocation>> GetRange(IPagingParameters paging);

        /// <summary>
        /// Gets a sorted range of locations.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">A class instance that implements <see cref="ISortingParameters"/>, holds sorting options.</param>
        /// <returns></returns>
        Task<IEnumerable<ILocation>> GetRange(IPagingParameters paging, ISortingParameters sorting);

        /// <summary>
        /// Updates a location.
        /// </summary>
        /// <param name="location">The county to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Update(ILocation location);
    }
}
