namespace MyZone.Server.Models.Domain.Books
{
    /// <summary>
    /// 添加小说类书籍使用
    /// </summary>
    public class NovelAddModel
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