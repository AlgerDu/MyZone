using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyZone.Server.Infrastructure.Helpers;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models;
using MyZone.Server.Models.DataBase;
using MyZone.Server.Models.DTO;
using MyZone.Server.Models.DTO.Crawl;

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

        /// <summary>
        /// 获取页面的处理代码
        /// </summary>
        /// <param name="url">页面 URL</param>
        /// <param name="type">页面类型</param>
        /// <returns></returns> <summary> <summary>
        //[HttpPost]
        public IDResult<PageParseCodeDTO> PageParseCode(
            [FromServices]MyZoneContext context,
            [FromBody]PageInfoDTO page)
        {
            var code = context.PageParse
                .FirstOrDefault(p => p.Url == page.Url && p.Utype == (long)page.Type);

            if (code == null || string.IsNullOrEmpty(code.SscriptCode))
            {
                var host = UrlHelper.GetHost(page.Url);
                var hostCode = context.PageParse.FirstOrDefault(p => p.Url == host && p.Utype == (long)page.Type);

                if (hostCode != null)
                {
                    return DResult.Success(new PageParseCodeDTO()
                    {
                        Url = page.Url,
                        SSCriptCode = hostCode.SscriptCode,
                        MinLength = code == null || code.MinLength <= 0 ? hostCode.MinLength : code.MinLength
                    });
                }
                else
                {
                    return DResult.Error<PageParseCodeDTO>("没有对应的解析代码");
                }
            }
            else
            {
                return DResult.Success(new PageParseCodeDTO()
                {
                    Url = page.Url,
                    SSCriptCode = code.SscriptCode,
                    MinLength = code.MinLength
                });
            }
        }

        /// <summary>
        /// 添加页面的处理 SsCode
        /// </summary>
        /// <param name="context"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IBathOpsResult<string> AddParsePage(
            [FromServices]MyZoneContext context,
            [FromBody]PageParseCodeDTO[] parses)
        {
            var result = new BathOpsResult<string>(parses.Length);
            return result;
        }
    }
}