using System;
using System.Collections.Generic;

namespace MyZone.Server.Models.DataBase
{
    public partial class Volume
    {
        public Guid BookUid { get; set; }
        public long No { get; set; }
        public string Name { get; set; }

        public virtual Book BookU { get; set; }
    }
}
