using System;
using System.Collections.Generic;
using MyZone.Server.Infrastructure.Interface;

namespace MyZone.Server.Infrastructure.SearchBase
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

        public long SkipCount
        {
            get
            {
                return PageSize * (PageIndex - 1);
            }
        }

        public SerachCondition()
        {
            FilterItems = new List<SearchFilter>();
        }
    }

    public class SearchResult<T> : ISearchResult<T>
        where T : class
    {
        IList<T> _data;

        public long PageSize { get; set; }

        public long PageIndex { get; set; }

        public long RecoderCount { get; private set; }

        public IEnumerable<T> Data
        {
            get
            {
                return _data;
            }
        }

        public int Code { get; set; }

        public string Message { get; set; }

        public SearchResult(long recoderCount)
        {
            RecoderCount = recoderCount;
            _data = new List<T>();
        }

        public void AddRecord(T record)
        {
            _data.Add(record);
        }
    }
}