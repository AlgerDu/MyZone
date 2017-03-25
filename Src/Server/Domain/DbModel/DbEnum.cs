using System;
using System.Collections.Generic;

namespace MyZone.Server.Domain.DbModel
{
    public partial class DbEnum
    {
        public DbEnum()
        {
            NovelCrawl = new HashSet<NovelCrawl>();
            PageParse = new HashSet<PageParse>();
            Url = new HashSet<Url>();
        }

        public long Id { get; set; }
        public string TextCn { get; set; }
        public string TextEn { get; set; }
        public long ParentId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<NovelCrawl> NovelCrawl { get; set; }
        public virtual ICollection<PageParse> PageParse { get; set; }
        public virtual ICollection<Url> Url { get; set; }
    }
}
