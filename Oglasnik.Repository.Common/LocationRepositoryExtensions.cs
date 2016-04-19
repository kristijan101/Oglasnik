using Oglasnik.Common;
using Oglasnik.Model.Common;
using PagedList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oglasnik.Repository.Common
{
    public static class LocationRepositoryExtensions
    {
        /// <summary>
        /// Asynchronously gets a sorted range of locations.
        /// </summary>
        /// <param name="paging">An instance of <see cref="IPagingParameters"/>, provides paging options.</param>
        /// <param name="sorting">An instance of <see cref="ISortingParameters"/>, provides sorting options.</param>
        /// <returns>Returns <see cref="Task{IPagedList{ILocation}}"/></returns>
        public static Task<IPagedList<ILocation>> GetAsync(this ILocationRepository repository, IPagingParameters paging, ISortingParameters sorting)
        {
            return repository.GetAsync(paging, sorting, null);
        }

        /// <summary>
        /// Asynchronously gets a list of locations.
        /// </summary>
        /// <param name="paging">An instance of <see cref="IPagingParameters"/>, provides paging options.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ILocation}}"/></returns>
        public static Task<IPagedList<ILocation>> GetAsync(this ILocationRepository repository, IPagingParameters paging)
        {
            return repository.GetAsync(paging, null, null);
        }
    }
}
