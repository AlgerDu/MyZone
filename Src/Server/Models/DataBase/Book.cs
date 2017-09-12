using System;
using System.Collections.Generic;

namespace MyZone.Server.Models.DataBase
{
    public partial class Book
    {
        public Book()
        {
            Chapter = new HashSet<Chapter>();
            NovelCrawl = new HashSet<NovelCrawl>();
            Volume = new HashSet<Volume>();
        }

        public Guid Uid { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

        public ICollection<Chapter> Chapter { get; set; }
        public ICollection<NovelCrawl> NovelCrawl { get; set; }
        public ICollection<Volume> Volume { get; set; }
    }
}
