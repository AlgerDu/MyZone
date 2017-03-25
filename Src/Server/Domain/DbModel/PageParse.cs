using System;
using System.Collections.Generic;

namespace MyZone.Server.Domain.DbModel
{
    public partial class PageParse
    {
        public string Url { get; set; }
        public long Utype { get; set; }
        public long MinLength { get; set; }
        public string SscriptCode { get; set; }

        public virtual DbEnum UtypeNavigation { get; set; }
    }
}
