using System;
using System.Collections.Generic;

namespace MyZone.Server.Models.DataBase
{
    public partial class Url
    {
        public string UrlPath { get; set; }
        public long Utype { get; set; }

        public virtual DbEnum UtypeNavigation { get; set; }
    }
}
