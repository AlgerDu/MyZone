using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyZone.Server.Controllers
{
    /// <summary>
    /// 数据管理
    /// </summary>
    public class BookManagementController : Controller
    {
        ILogger _logger;

        public BookManagementController(
            ILogger<BookManagementController> logger
        )
        {
            _logger = logger;
        }
    }
}