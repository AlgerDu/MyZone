using System;

namespace MyZone.Server.Models.DTO.NovelCrawl
{
    /// <summary>
    /// 上传小说章节正文信息
    /// </summary>
    public class ChapterTextUploadDTO
    {
        /// <summary>
        /// 章节Guid
        /// </summary>
        public Guid cUid { get; set; }

        /// <summary>
        /// 章节正文
        /// </summary>
        public string Text { get; set; }
    }
}