using System.Collections.Generic;
using AutoMapper;
using MyZone.Server.Infrastructure.Interface;

namespace MyZone.Server.Infrastructure.SearchBase
{
    public static class ExtEsarchResult
    {
        public static ISearchResult<D> Map<S, D>(this ISearchResult<S> src, IMapper mapper)
            where D : class
        {
            return new SearchResult<D>(
                src.RecodCount,
                src.PageIndex,
                src.PageSize,
                mapper.Map<IEnumerable<D>>(src.Data));
        }
    }
}