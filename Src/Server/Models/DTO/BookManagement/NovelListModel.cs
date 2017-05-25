using System;

namespace MyZone.Server.Models.DTO.BookManagement
{
    /// <summary>
    /// 小说管理列表信息
    /// </summary>
    public class NovelListModel
    {
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}