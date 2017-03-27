using System;

namespace MyZone.Server.Models.DTO.NovelCrawl
{
    /// <summary>
    /// 爬虫需要的章节信息
    /// </summary>
    public class NovelCrawlChapterDTO
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public Guid Uid { get; set; }

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

        /// <summary>
        /// 是否需要爬取
        /// </summary>
        public bool NeedCrawl { get; set; }
    }

    /// <summary>
    /// 爬虫需要的卷信息
    /// </summary>
    public class NovelCrawlVolumeDTO
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

    /// <summary>
    /// 爬虫需要获取到的小说目录信息
    /// </summary>
    public class NovelCrawlCatalogDTO
    {
        /// <summary>
        /// 所有卷信息
        /// </summary>
        public NovelCrawlVolumeDTO[] Vs { get; set; }

        /// <summary>
        /// 所有章节信息
        /// </summary>
        public NovelCrawlChapterDTO[] Cs { get; set; }

        public NovelCrawlCatalogDTO()
        {
            Vs = new NovelCrawlVolumeDTO[0];
            Cs = new NovelCrawlChapterDTO[0];
        }
    }
}