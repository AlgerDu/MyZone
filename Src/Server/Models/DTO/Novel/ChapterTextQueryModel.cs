using System;

namespace MyZone.Server.Models.DTO.Novel
{
    /// <summary>
    /// 小说正文的请求信息
    /// </summary>
    public class CHapterTextQueryModel
    {
        public Guid BookUid { get; set; }

        public int VolumeNo { get; set; }

        public int VolumeIndex { get; set; }
    }
}