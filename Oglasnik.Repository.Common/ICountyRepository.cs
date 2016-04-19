using Oglasnik.Common;
using Oglasnik.Model.Common;
using PagedList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oglasnik.Repository.Common
{
    public interface ICountyRepository
    {
        /// <summary>
        /// Asynchronously adds a county.
        /// </summary>
        /// <param name="county">The county to be added.</param>
        /// <returns>Returns <see cref="Task{Boolean}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> AddAsync(ICounty county);

        /// <summary>
        /// Asynchronously deletes the county with the given Id.
        /// </summary>
        /// <param name="id">Id of the county</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Asynchronously gets the county with the given Id.
        /// </summary>
        /// <param name="id">Id of the county.</param>
        /// <returns>Returns <see cref="Task{ICounty}"/></returns>
        Task<ICounty> GetAsync(Guid id);

        /// <summary>
        /// Asynchronously gets a range of counties which names contain the string given by the filter object.
        /// </summary>
        /// <param name="filter">The filter to be used</param>
        /// <param name="paging">An instance of <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">Sorting options to be applied.</param>
        /// <returns>Returns <see cref="Task{IPagedList{ICounty}}"/></returns>
        Task<IPagedList<ICounty>> GetAsync(IPagingParameters paging, ISortingParameters sorting, IFilter filter);

        /// <summary>
        /// Asynchronously updates a county.
        /// </summary>
        /// <param name="county">The county to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/></returns>
        Task<bool> UpdateAsync(ICounty county);
    }
}
