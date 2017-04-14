using System;

namespace MyZone.Server.Models.DTO.Novel
{
    /// <summary>
    /// 获取小说章节的请求信息
    /// </summary>
    public class NovelCatalogQueryModel
    {
        public Guid BookUid { get; set; }

        public int VolumeNo { get; set; }

        public int VolumeIndex { get; set; }

        /// <summary>
        /// 向前的章节数 -1 时表示一直到开始
        /// </summary>
        /// <returns></returns>
        public int ForwardCount { get; set; }

        /// <summary>
        /// 向后章节数 -1 时表示一直到最后
        /// </summary>
        /// <returns></returns>
        public int BackwardCount { get; set; }
    }
}