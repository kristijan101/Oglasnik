using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Common
{
    public class PagingParameters : IPagingParameters
    {
        private const int MaxPageSize = 100;
        private int _pageSize;

        #region Properties

        /// <summary>
        /// Gets/sets the current page number.
        /// </summary>
        public int PageNumber { get; private set; }

        /// <summary>
        /// Gets/sets the amount of results per page. The value can not be greater than <see cref="MaxPageSize"/>
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            private set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }

        #endregion

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="pageNumber">Page number. Must be greater than 0.</param>
        /// <param name="pageSize">Page size. Must be greater than 0.</param>
        public PagingParameters(int pageNumber = 1, int pageSize = 10)
        {
            if(pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException("pageNumber", "Page number must be greater than 0.");
            }
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("pageSize", "Page size must be greater than 0.");
            }

            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
