using System;

namespace MyZone.Server.Models.DTO.NovelCrawl
{
    /// <summary>
    /// 小说对应的爬取 Url 及处理方式
    /// </summary>
    public class NovelUrlInfoDTO
    {
        /// <summary>
        /// 小说 UID
        /// </summary>
        public Guid BookUid { get; set; }

        /// <summary>
        /// 爬取的 Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Url 页面对应的处理方式
        /// </summary>
        public string SSCriptCode { get; set; }

        /// <summary>
        /// SSCriptCode 是否可以通用（同一域名下所有的相同类型的域名都可以使用）
        /// </summary>
        public bool CommonParseCode { get; set; }

        /// <summary>
        /// 页面 Html 字符串最小长度
        /// </summary>
        public int PageHtmlMinLength { get; set; }

        /// <summary>
        /// 是否官网
        /// </summary>
        public bool IsOfficial { get; set; }
    }
}