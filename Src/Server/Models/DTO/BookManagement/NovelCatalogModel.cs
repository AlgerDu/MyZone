using System;

namespace MyZone.Server.Models.DTO.BookManagement
{
    /// <summary>
    /// 爬虫需要的章节信息
    /// </summary>
    public class NovelCatalogChapterModel
    {
        /// <summary>
        /// 所属卷编号
        /// </summary>
        public long VolumeNo { get; set; }

        /// <summary>
        /// 卷内顺序号
        /// </summary>
        public long VolumeIndex { get; set; }

        /// <summary>
        /// 章节名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 字数
        /// </summary>
        public int WordCount { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishTime { get; set; }

        /// <summary>
        /// 是否 vip 章节
        /// </summary>
        public bool Vip { get; set; }

        public bool Crawled { get; set; }
    }

    /// <summary>
    /// 爬虫需要的卷信息
    /// </summary>
    public class NovelCatalogVolumeModel
    {
        /// <summary>
        /// 顺序号
        /// </summary>
        public long No { get; set; }

        /// <summary>
        /// 卷名
        /// </summary>
        public string Name { get; set; }
    }

    public class NovelCatalogModel
    {
        /// <summary>
        /// 所有卷信息
        /// </summary>
        public NovelCatalogVolumeModel[] Vs { get; set; }

        /// <summary>
        /// 所有章节信息
        /// </summary>
        public NovelCatalogChapterModel[] Cs { get; set; }
    }
}