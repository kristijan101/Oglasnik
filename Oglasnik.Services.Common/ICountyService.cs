using Oglasnik.Common;
using Oglasnik.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Services.Common
{
    public interface ICountyService
    {
        /// <summary>
        /// Adds a county.
        /// </summary>
        /// <param name="county">The county instance to be added.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Add(ICounty cty);

        /// <summary>
        /// Deletes a county.
        /// </summary>
        /// <param name="county">The county instance to be deleted.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Delete(ICounty county);

        /// <summary>
        /// Deletes a county with the given Id.
        /// </summary>
        /// <param name="id">Id of the county to be deleted.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Delete(Guid id);

        /// <summary>
        /// Gets all counties.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ICounty>> GetAll();

        /// <summary>
        /// Gets the county with the specified Id.
        /// </summary>
        /// <param name="id">Id (of type <see cref="Guid"/>) of the county.</param>
        /// <returns>Returns the county requested or null if not found.</returns>
        Task<ICounty> GetById(Guid id);

        /// <summary>
        /// Gets a range of counties according to the applied filter.
        /// </summary>
        /// <param name="filter">Filter instance of type IFilter.</param>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/>.</returns>
        Task<IEnumerable<ICounty>> GetRange(IFilter filter, IPagingParameters paging);

        /// <summary>
        /// Gets a range of counties.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        Task<IEnumerable<ICounty>> GetRange(IPagingParameters paging);

        /// <summary>
        /// Gets a sorted range of counties.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">A class instance that implements <see cref="ISortingParameters"/>, holds sorting options.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        Task<IEnumerable<ICounty>> GetRange(IPagingParameters paging, ISortingParameters sorting);

        /// <summary>
        /// Updates a county.
        /// </summary>
        /// <param name="county">The county to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> Update(ICounty county);
    }
}
