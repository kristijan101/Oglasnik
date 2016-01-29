using Oglasnik.Common;
using Oglasnik.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oglasnik.Services.Common
{
    public static class CountyServiceExtensions
    {
        /// <summary>
        /// Asynchronously gets a sorted range of counties.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <param name="sorting">A class instance that implements <see cref="ISortingParameters"/>, holds sorting options.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        public static Task<IEnumerable<ICounty>> GetAsync(this ICountyService countyService, IPagingParameters paging, ISortingParameters sorting)
        {
            return countyService.GetAsync(paging, sorting, null);
        }

        /// <summary>
        /// Asynchronously gets a range of counties.
        /// </summary>
        /// <param name="paging">A class instance that implements <see cref="IPagingParameters"/>, holds paging data.</param>
        /// <returns>Returns <see cref="Task{IEnumerable{ICounty}}"/></returns>
        public static Task<IEnumerable<ICounty>> GetAsync(this ICountyService countyService, IPagingParameters paging)
        {
            return countyService.GetAsync(paging, null, null);
        }
    }
}
