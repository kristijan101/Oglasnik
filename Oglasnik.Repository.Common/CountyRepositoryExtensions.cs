using Oglasnik.Common;
using Oglasnik.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oglasnik.Repository.Common
{
    public static class CountyRepositoryExtensions
    {
        /// <summary>
        /// Asynchronously gets a sorted range of counties.
        /// </summary>
        /// <param name="paging">An instance of <see cref="IPagingParameters"/>, provides paging options.</param>
        /// <param name="sorting">An instance of <see cref="ISortingParameters"/>, provides sorting options.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        public static Task<IEnumerable<ICounty>> GetAsync(this ICountyRepository repository, IPagingParameters paging, ISortingParameters sorting)
        {
            return repository.GetAsync(paging, sorting, null);
        }

        /// <summary>
        /// Asynchronously gets a list of counties.
        /// </summary>
        /// <param name="paging">An instance of <see cref="IPagingParameters"/>, provides paging options.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        public static Task<IEnumerable<ICounty>> GetAsync(this ICountyRepository repository, IPagingParameters paging)
        {
            return repository.GetAsync(paging, null, null);
        }
    }
}
