using System;
using System.Collections.Generic;

namespace MyZone.Server.Models.DataBase
{
    public partial class Host
    {
        public Host()
        {
            Url = new HashSet<Url>();
        }

        public Guid Uid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Url> Url { get; set; }
    }
}
