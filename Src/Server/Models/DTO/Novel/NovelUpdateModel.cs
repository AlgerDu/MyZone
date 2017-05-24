using System;

namespace MyZone.Server.Models.DTO.Novel
{
    /// <summary>
    /// 小说的更新信息
    /// </summary>
    public class NovelUpdateModel
    {
        public Guid BookUid { get; set; }

        /// <summary>
        /// 更新的章节数量
        /// </summary>
        /// <returns></returns>
        public int ChapterCount { get; set; }

        /// <summary>
        /// 最后的更新时间
        /// </summary>
        /// <returns></returns>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 最新的章节信息
        /// </summary>
        /// <returns></returns>
        public LastChapterModel LastChapter { get; set; }
    }

    /// <summary>
    /// 最新一章的章节信息
    /// </summary>
    public class LastChapterModel
    {
        public Guid Uid { get; set; }

        public long VolumeNo { get; set; }

        public long VolumeIndex { get; set; }

        public string Name { get; set; }
    }
}