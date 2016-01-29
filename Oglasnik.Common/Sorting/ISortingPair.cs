namespace Oglasnik.Common
{
    public interface ISortingPair
    {
        #region Properties
        /// <summary>
        /// Gets a value indicating if order direction is ascending.
        /// </summary>
        bool Ascending { get; set; }
        
        /// <summary>
        /// Gets or sets the order by field.
        /// </summary>
        string OrderBy { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the sort expression.
        /// </summary>
        /// <returns>The sort expression.</returns>
        string GetSortExpression();

        #endregion
    }
}