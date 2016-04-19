using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oglasnik.WebAPI.Models
{
    public class PagedListViewModel<T>
    {
        #region Properties

        ///<summary>
		/// Gets the number of elements contained on this page.
		///</summary>
        public int Count { get; set; }

        /// <summary>
		/// One-based index of the first item in the paged subset.
		/// </summary>
		/// <value>
		/// One-based index of the first item in the paged subset.
		/// </value>
        public int FirstItemOnPage { get; set; }

        /// <summary>
		/// Returns true if this is NOT the last subset within the superset.
		/// </summary>
		/// <value>
		/// Returns true if this is NOT the last subset within the superset.
		/// </value>
        public bool HasNextPage { get; set; }

        /// <summary>
		/// Returns true if this is NOT the first subset within the superset.
		/// </summary>
		/// <value>
		/// Returns true if this is NOT the first subset within the superset.
		/// </value>
        public bool HasPreviousPage { get; set; }

        /// <summary>
		/// Returns true if this is the first subset within the superset.
		/// </summary>
		/// <value>
		/// Returns true if this is the first subset within the superset.
		/// </value>
        public bool IsFirstPage { get; set; }

        /// <summary>
		/// Returns true if this is the last subset within the superset.
		/// </summary>
		/// <value>
		/// Returns true if this is the last subset within the superset.
		/// </value>
        public bool IsLastPage { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
		/// One-based index of the last item in the paged subset.
		/// </summary>
		/// <value>
		/// One-based index of the last item in the paged subset.
		/// </value>
        public int LastItemOnPage { get; set; }

        /// <summary>
		/// Total number of subsets within the superset.
		/// </summary>
		/// <value>
		/// Total number of subsets within the superset.
		/// </value>
        public int PageCount { get; set; }

        /// <summary>
		/// One-based index of this subset within the superset.
		/// </summary>
		/// <value>
		/// One-based index of this subset within the superset.
		/// </value>
        public int PageNumber { get; set; }

        /// <summary>
		/// Maximum size any individual subset.
		/// </summary>
		/// <value>
		/// Maximum size any individual subset.
		/// </value>
        public int PageSize { get; set; }

        /// <summary>
		/// Total number of objects contained within the superset.
		/// </summary>
		/// <value>
		/// Total number of objects contained within the superset.
		/// </value>
        public int TotalItemCount { get; set; }

        #endregion
    }
}