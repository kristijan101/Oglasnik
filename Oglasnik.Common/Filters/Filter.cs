using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Common.Filters
{
    public class Filter : IFilter
    {
        public string SearchString { get; private set; }

        /// <summary>
        /// The constructor class.
        /// </summary>
        /// <param name="searchString">The string to be searched for. Required.</param>
        public Filter(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException("searchString");
            }

            SearchString = searchString;
        }
    }
}
