using System;

namespace Oglasnik.Common
{
    public class SortingPair : ISortingPair
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating if the order direction is ascending.
        /// </summary>
        public bool Ascending { get; set; }

        /// <summary>
        /// Gets or sets the order by field.
        /// </summary>
        public string OrderBy { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SortingPair"/> class with the given order by field and ascending sort direction.
        /// </summary>
        /// <param name="orderBy">The order by field.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="orderBy"/> is null, empty or consists only of white-space characters.</exception>
        public SortingPair(string orderBy) : this(orderBy, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortingPair"/> class.
        /// </summary>
        /// <param name="orderBy">The order by field.</param>
        /// <param name="ascending">Indicates if the sort direction is ascending.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="orderBy"/> is null, empty or consists only of white-space characters.</exception>
        public SortingPair(string orderBy, bool ascending)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                throw new ArgumentNullException("orderBy");
            }
            
            OrderBy = orderBy;
            Ascending = ascending;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Gets the sort expression.
        /// </summary>
        /// <returns>
        /// The sort expression.
        /// </returns>
        public string GetSortExpression()
        {
            return OrderBy + " " + (Ascending ? "asc" : "desc");
        }

        #endregion
    }
}
