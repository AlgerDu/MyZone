using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyZone.Server.Controllers
{
    /// <summary>
    /// 通用的一些网页爬取操作
    /// </summary>
    public class CrawlController : Controller
    {
        ILogger _logger;

        public CrawlController(ILogger<CrawlController> logger)
        {
            _logger = logger;
        }
    }
}