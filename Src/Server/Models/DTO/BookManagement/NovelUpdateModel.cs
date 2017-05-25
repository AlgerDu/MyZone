using System;

namespace MyZone.Server.Models.DTO.BookManagement
{
    /// <summary>
    /// 更新小说信息
    /// </summary>
    public class NovelUpdateModel
    {
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}