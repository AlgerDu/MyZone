﻿using System;
using System.Collections.Generic;

namespace MyZone.Server.Models.DataBase
{
    public partial class Content
    {
        public Content()
        {
            Chapter = new HashSet<Chapter>();
        }

        public Guid Uid { get; set; }
        public string Txt { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditeTime { get; set; }
        public long ContentType { get; set; }

        public DbEnum ContentTypeNavigation { get; set; }
        public ICollection<Chapter> Chapter { get; set; }
    }
}
