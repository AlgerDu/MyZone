namespace MyZone.Server.Models.DTO.NovelCrawl
{
    /// <summary>
    /// 用来新增需要爬取的小说
    /// </summary>
    public class NovelInfoDTO
    {
        /// <summary>
        /// 小说名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 作者名
        /// </summary>
        public string Author { get; set; }
    }
}