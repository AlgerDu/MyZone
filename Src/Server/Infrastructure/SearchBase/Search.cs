using System;
using System.Collections.Generic;
using MyZone.Server.Infrastructure.Interface;

namespace MyZone.Server.Infrastructure.Results
{
    public class SearchFilter : ISearchFilter
    {
        public string Field { get; set; }

        public string Value { get; set; }

        public bool Order { get; set; }

        public string Op { get; set; }
    }

    public class SerachCondition : ISerachCondition
    {
        public long PageSize { get; set; }

        public long PageIndex { get; set; }

        public IEnumerable<ISearchFilter> FilterItems { get; set; }

        public SerachCondition()
        {
            FilterItems = new List<SearchFilter>();
        }
    }

    public class SearchResult<T> : ISearchResult<T>
        where T : class
    {
        public long PageSize { get; set; }

        public long PageIndex { get; set; }

        public long RecoderCount { get; set; }

        public IEnumerable<T> Data { get; set; }

        public int Code { get; set; }

        public string Message { get; set; }
    }
}