using Oglasnik.Common;
using Oglasnik.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oglasnik.Services.Common
{
    public static class LocationServiceExtensions
    {
        /// <summary>
        /// Asynchronously gets a sorted range of locations.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">A class instance that implements <see cref="ISortingParameters"/>, holds sorting options.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ILocation}}"/></returns>
        public static Task<IEnumerable<ILocation>> GetAsync(this ILocationService locationService, IPagingParameters paging, ISortingParameters sorting)
        {
            return locationService.GetAsync(paging, sorting, null);
        }

        /// <summary>
        /// Asynchronously gets a range of locations.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ILocation}}"/></returns>
        public static Task<IEnumerable<ILocation>> GetAsync(this ILocationService locationService, IPagingParameters paging)
        {
            return locationService.GetAsync(paging, null, null);
        }
    }
}
