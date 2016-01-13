using Oglasnik.Common;
using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Repository.Common
{
    public interface ICountyRepository
    {
        /// <summary>
        /// Adds a county of type ICounty.
        /// </summary>
        /// <param name="county">Instance of type ICounty to be added.</param>
        /// <returns>Returns <see cref="Task{Boolean}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Add(ICounty county);

        /// <summary>
        /// Deletes a county of type ICounty.
        /// </summary>
        /// <param name="county">Instance of type ICounty</param>
        /// <returns>Returns <see cref="Task{Boolean}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Delete(ICounty county);

        /// <summary>
        /// Deletes the county with the given Id.
        /// </summary>
        /// <param name="id">Id of the county</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Delete(Guid id);

        /// <summary>
        /// Gets all counties.
        /// </summary>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        Task<IEnumerable<ICounty>> GetAllAsync();

        /// <summary>
        /// Gets the county with the given Id.
        /// </summary>
        /// <param name="id">Id of the county to be fetched.</param>
        /// <returns>Returns <see cref="Task{ICounty}"/></returns>
        Task<ICounty> GetAsync(Guid id);

        /// <summary>
        /// Gets a range of counties which names contain the string given by the filter object.
        /// </summary>
        /// <param name="filter">Filter instance of type IFilter</param>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        Task<IEnumerable<ICounty>> GetRangeAsync(IFilter filter, IPagingParameters paging);

        /// <summary>
        /// Gets a range of counties.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        Task<IEnumerable<ICounty>> GetRangeAsync(IPagingParameters paging);

        /// <summary>
        /// Gets a sorted range of counties.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">A class instance that implements <see cref="ISortingParameters"/>, holds sorting options.</param>
        /// <returns></returns>
        Task<IEnumerable<ICounty>> GetRangeAsync(IPagingParameters paging, ISortingParameters sorting);

        /// <summary>
        /// Updates a county of type ICounty.
        /// </summary>
        /// <param name="county">The county to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/></returns>
        Task<bool> Update(ICounty county);
    }
}
