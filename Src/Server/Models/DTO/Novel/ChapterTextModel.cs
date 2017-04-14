using System;

namespace MyZone.Server.Models.DTO.Novel
{
    /// <summary>
    /// 小说正文信息
    /// </summary>
    public class ChapterTextModel
    {
        public Guid Uid { get; set; }
        public string Txt { get; set; }
        public DateTime CreateTime { get; set; }
    }
}