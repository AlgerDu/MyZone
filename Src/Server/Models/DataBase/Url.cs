using System;
using System.Collections.Generic;

namespace MyZone.Server.Models.DataBase
{
    public partial class Url
    {
        public Guid HostUid { get; set; }
        public string RelativPath { get; set; }
        public long Utype { get; set; }
        public DateTime LastCrawlTime { get; set; }

        public virtual Host HostU { get; set; }
        public virtual DbEnum UtypeNavigation { get; set; }
    }
}
