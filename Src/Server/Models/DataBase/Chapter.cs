using System;
using System.Collections.Generic;

namespace MyZone.Server.Models.DataBase
{
    public partial class Chapter
    {
        public Guid Uid { get; set; }
        public Guid BookUid { get; set; }
        public Guid? ContextUid { get; set; }
        public long VolumeNo { get; set; }
        public long VolumeIndex { get; set; }
        public string Name { get; set; }
        public DateTime PublishTime { get; set; }
        public int WordCount { get; set; }
        public bool Vip { get; set; }
        public bool NeedCrawl { get; set; }

        public virtual Book BookU { get; set; }
        public virtual Content ContextU { get; set; }
    }
}
