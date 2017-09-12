using System;
using System.Collections.Generic;

namespace MyZone.Server.Models.DataBase
{
    public partial class NovelCrawl
    {
        public Guid BookUid { get; set; }
        public string Url { get; set; }
        public long CrawlUrlType { get; set; }
        public DateTime? LastCrawlTime { get; set; }

        public Book BookU { get; set; }
        public DbEnum CrawlUrlTypeNavigation { get; set; }
    }
}
