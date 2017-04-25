using System;

namespace MyZone.Server.Models.DTO.Novel
{
    /// <summary>
    /// 上次更新的信息
    /// </summary>
    public class NovelLastUpdateModel
    {
        /// <summary>
        /// 小说 Uid
        /// </summary>
        public Guid BookUid { get; set; }

        /// <summary>
        /// 上次更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}