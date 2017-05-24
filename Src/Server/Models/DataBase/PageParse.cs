using System;
using System.Collections.Generic;

namespace MyZone.Server.Models.DataBase
{
    public partial class PageParse
    {
        public string Url { get; set; }
        public long PageType { get; set; }
        public long MinLength { get; set; }
        public string SscriptCode { get; set; }

        public virtual DbEnum PageTypeNavigation { get; set; }
    }
}
