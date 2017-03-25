using System;
using System.Collections.Generic;

namespace Server.Domain.DbModel
{
    public partial class NovelCrawl
    {
        public Guid BookUid { get; set; }
        public string Url { get; set; }
        public long Nctype { get; set; }

        public virtual Book BookU { get; set; }
        public virtual DbEnum NctypeNavigation { get; set; }
    }
}
