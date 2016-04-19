using Oglasnik.Common;
using Oglasnik.Model.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oglasnik.Services.Common
{
    public interface ILocationService
    {
        /// <summary>
        /// Asynchronously adds a location.
        /// </summary>
        /// <param name="location">The location instance to be added.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> AddAsync(ILocation location);

        /// <summary>
        /// Asynchronously deletes a location with the given Id.
        /// </summary>
        /// <param name="id">Id of the location to be deleted.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Asynchronously gets the location with the specified Id.
        /// </summary>
        /// <param name="id">Id of the county.</param>
        /// <returns>Returns the location requested or null if not found.</returns>
        Task<ILocation> GetAsync(Guid id);

        /// <summary>
        /// Asynchronously gets a range of locations which names contain the string given by the filter object.
        /// </summary>
        /// <param name="filter">Filter instance of type IFilter</param>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">Sorting options</param>
        /// <returns>Returns <see cref="Task{IPagedList{ILocation}}"/></returns>
        Task<IPagedList<ILocation>> GetAsync(IPagingParameters paging, ISortingParameters sorting, IFilter filter);

        /// <summary>
        /// Asynchronously updates a location.
        /// </summary>
        /// <param name="location">The county to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> UpdateAsync(ILocation location);
    }
}
