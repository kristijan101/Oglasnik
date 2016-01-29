using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Common
{
    public class PagingParameters : IPagingParameters
    {
        #region Fields

        /// <summary>
        /// The maximum page size
        /// </summary>
        private const int MaxPageSize = 100;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        public int PageNumber { get; private set; }

        /// <summary>
        /// Gets or sets the amount of results per page. The value can not be greater than <see cref="MaxPageSize"/>
        /// </summary>
        public int PageSize { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingParameters"/> class.
        /// </summary>
        public PagingParameters() : this(1, 10)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingParameters"/> class with the given page number.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="pageNumber"/> is not greater than 0.</exception>
        public PagingParameters(int pageNumber) : this(pageNumber, 10)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingParameters"/> class with the page number and it's size.
        /// </summary>
        /// <param name="pageNumber">Page number. Must be greater than 0.</param>
        /// <param name="pageSize">Page size. Must be greater than 0.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="pageNumber"/> or <paramref name="pageSize"/> are not greater than 0.</exception>
        public PagingParameters(int pageNumber, int pageSize)
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
            PageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }

        #endregion
    }
}
