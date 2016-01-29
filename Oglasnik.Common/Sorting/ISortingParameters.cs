using System.Collections.Generic;

namespace Oglasnik.Common
{
    public interface ISortingParameters
    {
        #region Properties

        /// <summary>
        /// Gets the sort pairs.
        /// </summary>
        IList<ISortingPair> Sorters { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Joins sort expressions of each <see cref="ISortingPair"/> instance.
        /// </summary>
        /// <param name="delimiter">The delimiter to be used between joined expressions.</param>
        /// <returns>Returns a <see cref="string"/> with the concatenated sort expressions.</returns>
        string GetJoinedSortExpressions(char delimiter);

        #endregion
    }
}
