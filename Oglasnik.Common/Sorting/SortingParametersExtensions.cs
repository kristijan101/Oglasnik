namespace Oglasnik.Common
{
    public static class SortingParametersExtensions
    {
        /// <summary>
        /// Joins sort expressions of each <see cref="ISortingPair"/> instance, using a ',' character as the delimiter.
        /// </summary>
        /// <returns>Returns a <see cref="string"/> with the concatenated sort expressions.</returns>
        public static string GetJoinedSortExpressions(this ISortingParameters sortParams)
        {
            return sortParams.GetJoinedSortExpressions(',');
        }
    }
}
