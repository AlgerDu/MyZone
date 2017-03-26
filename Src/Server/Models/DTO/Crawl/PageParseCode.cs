namespace MyZone.Server.Models.DTO.Crawl
{
    /// <summary>
    /// 页面处理代码
    /// </summary>
    public class PageParseCodeDTO
    {
        /// <summary>
        /// 对应的 url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 页面数据提取的 SSCript 代码
        /// </summary>
        public string SSCriptCode { get; set; }

        /// <summary>
        /// 页面 HTML 文本的最小长度，用于最基本的爬取成功标志
        /// </summary>
        public long MinLength { get; set; }
    }
}