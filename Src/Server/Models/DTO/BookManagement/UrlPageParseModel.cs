using System.Collections.Generic;

namespace MyZone.Server.Models.DTO.BookManagement
{
    public class ParseItemModel
    {
        public string SscriptCode { get; set; }
        public long PageType { get; set; }
        public long MinLength { get; set; }

        public bool Common { get; set; }
    }

    /// <summary>
    /// 小说的 url 爬去信息 
    /// </summary>
    public class UrlPageParseModel
    {
        public string Url { get; set; }

        public NovelCrawlUrlType Type { get; set; }

        public List<ParseItemModel> ParseItems { get; set; }

        public UrlPageParseModel()
        {
            ParseItems = new List<ParseItemModel>();
        }
    }
}