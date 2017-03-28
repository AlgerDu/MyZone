using System;

namespace MyZone.Server.Models.DTO.NovelCrawl
{
    /// <summary>
    /// 上传小说章节信息
    /// </summary>
    public class ChapterUploadDTO
    {
        /// <summary>
        /// 小说 UID
        /// </summary>
        public Guid BookUid { get; set; }

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
    }
}