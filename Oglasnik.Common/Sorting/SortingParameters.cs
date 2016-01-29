using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Common
{
    public class SortingParameters : ISortingParameters
    {
        #region Properties

        /// <summary>
        /// Gets the sort pairs.
        /// </summary>
        public IList<ISortingPair> Sorters { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SortingParameters"/> class.
        /// </summary>
        /// <param name="sorters">The sorters.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="sorters"/> is null.</exception>
        public SortingParameters(IList<ISortingPair> sorters)
        {
            if(sorters == null)
            {
                throw new ArgumentNullException();
            }

            Sorters = sorters;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Joins sort expressions of each <see cref="ISortingPair"/> instance.
        /// </summary>
        /// <param name="delimiter">The delimiter to be used between joined expressions.</param>
        /// <returns>Returns a <see cref="string"/> with the concatenated sort expressions.</returns>
        public string GetJoinedSortExpressions(char delimiter)
        {
            StringBuilder expression = new StringBuilder();

            for(int i = 0; i < Sorters.Count; i++)
            {
                expression.Append(Sorters[i].GetSortExpression());

                if(!(i == Sorters.Count - 1))
                {
                    expression.Append(delimiter + " ");
                }
            }
            return expression.ToString();
        }

        #endregion
    }
}
