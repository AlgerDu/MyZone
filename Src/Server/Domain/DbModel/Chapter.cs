using System;
using System.Collections.Generic;

namespace Server.Domain.DbModel
{
    public partial class Chapter
    {
        public Guid Uid { get; set; }
        public Guid BookUid { get; set; }
        public long VolumeNo { get; set; }
        public long VolumeIndex { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public DateTime PublishTime { get; set; }
        public int WordCount { get; set; }

        public virtual Book BookU { get; set; }
    }
}
