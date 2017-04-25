using System;

namespace MyZone.Server.Models.DTO.Novel
{

    public class NovelCatalogModel
    {
        public VolumeModel[] Vs { get; set; }

        public ChapterModel[] Cs { get; set; }
    }

    public class VolumeModel
    {
        public long No { get; set; }
        public string Name { get; set; }
    }

    public class ChapterModel
    {
        public Guid Uid { get; set; }
        public Guid? ContextUid { get; set; }
        public long VolumeNo { get; set; }
        public long VolumeIndex { get; set; }
        public string Name { get; set; }
        public DateTime PublishTime { get; set; }
        public int WordCount { get; set; }
        public bool Vip { get; set; }
    }
}