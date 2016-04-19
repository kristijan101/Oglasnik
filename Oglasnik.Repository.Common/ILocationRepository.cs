using Oglasnik.Common;
using Oglasnik.Model.Common;
using PagedList;
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
        /// Asynchronously adds a location.
        /// </summary>
        /// <param name="location">The location</param>
        /// <returns>Returns <see cref="Task{Boolean}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> AddAsync(ILocation county);

        /// <summary>
        /// Asynchronously deletes the location with the given Id.
        /// </summary>
        /// <param name="id">Id of the location</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Asynchronously gets the location with the given Id.
        /// </summary>
        /// <param name="id">Id of the location</param>
        /// <returns>Returns <see cref="Task{ILocation}"/></returns>
        Task<ILocation> GetAsync(Guid id);

        /// <summary>
        /// Asynchronously gets a range of locations which names contain the string given by the filter object.
        /// </summary>
        /// <param name="sorting">Sorting options</param>
        /// <param name="filter">The filter to be used</param>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IPagedList{ILocation}}"/></returns>
        Task<IPagedList<ILocation>> GetAsync(IPagingParameters paging, ISortingParameters sorting, IFilter filter);

        /// <summary>
        /// Asynchronously updates a location.
        /// </summary>
        /// <param name="location">The location to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> UpdateAsync(ILocation county);
    }
}
