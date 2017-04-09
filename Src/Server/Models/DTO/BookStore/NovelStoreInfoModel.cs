using System;

namespace MyZone.Server.Models.DTO.BookStore
{
    /// <summary>
    /// 小说在小说商店中的信息
    /// </summary>
    public class NovelStoreInfoModel
    {
        public Guid Uid { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        /// <summary>
        /// 章节数量
        /// </summary>
        /// <returns></returns>
        public int ChapterCount { get; set; }
    }
}