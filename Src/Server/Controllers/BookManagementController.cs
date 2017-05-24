using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DTO.NovelCrawl;

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

        /// <summary>
        /// 向系统中添加一本小说类型的书籍
        /// </summary>
        /// <param name="novle"></param>
        /// <returns></returns>
        public IResult<Guid> AddNovle(
            [FromBody]NovelAddModel novle
        )
        {
            return null;
        }
    }
}