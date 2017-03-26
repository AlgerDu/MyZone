using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DataBase;
using MyZone.Server.Models.DTO;
using MyZone.Server.Models.DTO.NovelCrawl;

namespace MyZone.Server.Controllers
{
    /// <summary>
    /// 书籍（小说）爬取相关
    /// </summary>
    public class NovelCrawlController : Controller
    {
        ILogger _logger;

        public NovelCrawlController(ILogger<NovelCrawlController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 添加需要爬取的小说信息
        /// </summary>
        /// <param name="novels"></param>
        /// <returns></returns>
        public IBathOpsResult<string> AddNovels(
            [FromServices]MyZoneContext context,
            [FromBody]NovelInfoDTO[] novels)
        {
            var result = new BathOpsResult<string>(novels.Length);

            for (int i = 0; i < novels.Length; i++)
            {
                var novel = novels[i];
                var book = new Book();
                book.Uid = Guid.NewGuid();
                book.Name = novel.Name;
                book.Author = novel.Author;

                context.Book.Add(book);

                result.AddSuccessItem(i, book.Uid.ToString());
            }

            context.SaveChanges();

            return result;
        }
    }
}