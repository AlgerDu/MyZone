using System;

namespace MyZone.Server.Models.DTO.NovelCrawl
{
    /// <summary>
    /// 上传小说卷信息
    /// </summary>
    public class VolumeUploadModel
    {
        /// <summary>
        /// 小说 UID
        /// </summary>
        public Guid BookUid { get; set; }

        /// <summary>
        /// 顺序号
        /// </summary>
        public long No { get; set; }

        /// <summary>
        /// 卷名
        /// </summary>
        public string Name { get; set; }
    }
}