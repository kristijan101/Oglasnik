using AutoMapper;
using Oglasnik.WebAPI.Models;
using PagedList;

namespace Oglasnik.WebAPI.Infrastructure
{
    public class PagedListVMTypeConverter<T> : ITypeConverter<IPagedList<T>, PagedListViewModel<T>>
    {
        /// <summary>
        /// Performs conversion from source to destination type
        /// </summary>
        /// <param name="context">Resolution context</param>
        /// <returns>
        /// Destination object
        /// </returns>
        public PagedListViewModel<T> Convert(ResolutionContext context)
        {
            IPagedList<T> source = (IPagedList<T>)context.SourceValue;

            return new PagedListViewModel<T>
            {
                Count = source.Count,
                FirstItemOnPage = source.FirstItemOnPage,
                HasNextPage = source.HasNextPage,
                HasPreviousPage = source.HasPreviousPage,
                IsFirstPage = source.IsFirstPage,
                IsLastPage = source.IsLastPage,
                Items = source,
                LastItemOnPage = source.LastItemOnPage,
                PageCount = source.PageCount,
                PageNumber = source.PageNumber,
                PageSize = source.PageSize,
                TotalItemCount = source.TotalItemCount
            };
        }
    }
}