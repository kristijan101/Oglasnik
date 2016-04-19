using AutoMapper;
using PagedList;
using System.Collections.Generic;

namespace Oglasnik.Common
{
    public class PagedListTypeConverter<T, U> : ITypeConverter<IPagedList<T>, IPagedList<U>>
    {
        /// <summary>
        /// Performs conversion from source to destination type
        /// </summary>
        /// <param name="context">Resolution context</param>
        /// <returns>
        /// Destination object
        /// </returns>
        public IPagedList<U> Convert(ResolutionContext context)
        {
            IPagedList<T> source = (IPagedList<T>)context.SourceValue;

            return new PagedList<U>(Mapper.Map<IEnumerable<U>>(source), source.PageNumber, source.PageSize);
        }
    }
}
