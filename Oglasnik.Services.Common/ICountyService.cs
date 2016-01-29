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
        /// Asynchronously adds a county.
        /// </summary>
        /// <param name="county">The county instance to be added.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> AddAsync(ICounty cty);

        /// <summary>
        /// Asynchronously deletes a county with the given Id.
        /// </summary>
        /// <param name="id">Id of the county to be deleted.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Asynchronously gets the county with the specified Id.
        /// </summary>
        /// <param name="id">Id of the county.</param>
        /// <returns>Returns the county requested or null if not found.</returns>
        Task<ICounty> GetAsync(Guid id);

        /// <summary>
        /// Asynchronously gets a range of counties according to the applied filter.
        /// </summary>
        /// <param name="filter">The filter to be used.</param>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">Sorting options</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/>.</returns>
        Task<IEnumerable<ICounty>> GetAsync(IPagingParameters paging, ISortingParameters sorting, IFilter filter);

        /// <summary>
        /// Asynchronously updates a county.
        /// </summary>
        /// <param name="county">The county to be updated.</param>
        /// <returns>Returns <see cref="Task{bool}"/> indicating whether the operation was executed successfuly.</returns>
        Task<bool> UpdateAsync(ICounty county);
    }
}
