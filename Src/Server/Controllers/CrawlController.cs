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
        public IResult<PageParseCodeDTO> PageParseCode(
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
                    return Result.Success(new PageParseCodeDTO()
                    {
                        Url = page.Url,
                        SSCriptCode = hostCode.SscriptCode,
                        MinLength = code == null || code.MinLength <= 0 ? hostCode.MinLength : code.MinLength,
                        IsCommon = true,
                        Type = (PageType)hostCode.Utype
                    });
                }
                else
                {
                    return Result.Error<PageParseCodeDTO>("没有对应的解析代码");
                }
            }
            else
            {
                return Result.Success(new PageParseCodeDTO()
                {
                    Url = page.Url,
                    SSCriptCode = code.SscriptCode,
                    MinLength = code.MinLength,
                    IsCommon = false,
                    Type = (PageType)code.Utype
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

            for (int i = 0; i < parses.Length; i++)
            {
                var parse = parses[i];
                var hostStr = UrlHelper.GetHost(parse.Url);
                var pathStr = UrlHelper.GetPath(parse.Url);

                var pp = context.PageParse
                    .FirstOrDefault(p => p.Url == parse.Url);

                if (pp == null && !parse.IsCommon)
                {
                    context.PageParse.Add(new PageParse
                    {
                        Url = parse.Url,
                        SscriptCode = parse.SSCriptCode,
                        MinLength = parse.MinLength,
                        Utype = (long)parse.Type
                    });
                    result.AddSuccessItem(i);
                }
                else if (!parse.IsCommon)
                {
                    result.AddErrorItem(i, "页面已经存在处理代码");
                }
                else if (pp != null || context.PageParse.FirstOrDefault(p => p.Url == hostStr && p.Utype == (long)parse.Type) != null)
                {
                    result.AddErrorItem(i, "页面已经存在处理代码");
                }
                else
                {
                    context.PageParse.Add(new PageParse
                    {
                        Url = hostStr,
                        SscriptCode = parse.SSCriptCode,
                        MinLength = -1,
                        Utype = (long)parse.Type
                    });
                    if (pathStr != "" && pathStr != "/")
                    {
                        context.PageParse.Add(new PageParse
                        {
                            Url = parse.Url,
                            SscriptCode = "",
                            MinLength = parse.MinLength,
                            Utype = (long)parse.Type
                        });
                    }
                    result.AddSuccessItem(i);
                }
            }
            context.SaveChanges();
            return result;
        }
    }
}