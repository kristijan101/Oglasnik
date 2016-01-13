using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Common
{
    public interface ISortingParameters
    {
        /// <summary>
        /// Stores the names of the properties by which to sort the results.
        /// </summary>
        string SortBy { get; }
        
        /// <summary>
        /// Ascending or descending.
        /// </summary>
        string SortDirection { get; }
    }
}
