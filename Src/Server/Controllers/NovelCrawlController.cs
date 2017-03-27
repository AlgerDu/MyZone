using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyZone.Server.Infrastructure.Helpers;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models;
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

                result.AddSuccessItem(i, null, book.Uid.ToString());
            }

            context.SaveChanges();

            return result;
        }

        /// <summary>
        /// 添加小说爬取需要的 URL
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ncUrls"></param>
        /// <returns></returns>
        public IBathOpsResult<string> AddNovelCrawlUrls(
            [FromServices]MyZoneContext context,
            [FromBody]NovelUrlInfoDTO[] ncUrls)
        {
            var result = new BathOpsResult<string>(ncUrls.Length);

            for (int i = 0; i < ncUrls.Length; i++)
            {
                var ncUrl = ncUrls[i];
                var book = context.Book
                    .Include(b => b.NovelCrawl)
                    .FirstOrDefault(b => b.Uid == ncUrl.BookUid);
                if (book == null)
                {
                    result.AddErrorItem(i, "书籍不存在");
                }
                else if (!UrlHelper.IsUrl(ncUrl.Url))
                {
                    result.AddErrorItem(i, "爬取 Url 不正确");
                }
                else if (book.NovelCrawl.FirstOrDefault(nc => nc.Url == ncUrl.Url) != null)
                {
                    result.AddErrorItem(i, "书籍已经添加过相同的爬取 URL");
                }
                else
                {
                    var hostStr = UrlHelper.GetHost(ncUrl.Url);
                    var pathStr = UrlHelper.GetPath(ncUrl.Url);

                    var host = context.Host.FirstOrDefault(h => h.Name == hostStr);
                    if (host == null)
                    {
                        host = new Host();
                        host.Uid = Guid.NewGuid();
                        host.Name = hostStr;

                        context.Host.Add(host);
                    }

                    var url = new Url();
                    url.HostUid = host.Uid;
                    url.RelativPath = pathStr;
                    url.Utype = (int)PageType.NovelCatalog;

                    context.Url.Add(url);

                    var nc = new NovelCrawl()
                    {
                        BookUid = ncUrl.BookUid,
                        Url = ncUrl.Url,
                        Nctype = (long)(ncUrl.IsOfficial ? NovelCrawlUrlType.Official : NovelCrawlUrlType.Third),
                    };
                    context.NovelCrawl.Add(nc);

                    if (ncUrl.CommonParseCode)
                    {
                        var cpp = context.PageParse.FirstOrDefault(p => p.Url == hostStr && p.Utype == (long)PageType.NovelCatalog);

                        if (cpp == null)
                        {
                            cpp = new PageParse()
                            {
                                Url = hostStr,
                                SscriptCode = ncUrl.SSCriptCode,
                                MinLength = -1,
                                Utype = (long)PageType.NovelCatalog
                            };
                            context.PageParse.Add(cpp);
                        }

                        var pp = new PageParse()
                        {
                            Url = ncUrl.Url,
                            SscriptCode = "",
                            MinLength = ncUrl.PageHtmlMinLength,
                            Utype = (long)PageType.NovelCatalog
                        };
                        context.PageParse.Add(pp);
                    }
                    else
                    {
                        var pp = new PageParse()
                        {
                            Url = ncUrl.Url,
                            SscriptCode = ncUrl.SSCriptCode,
                            MinLength = ncUrl.PageHtmlMinLength,
                            Utype = (long)PageType.NovelCatalog
                        };
                        context.PageParse.Add(pp);
                    }

                    context.SaveChanges();

                    result.AddSuccessItem(i);
                }
            }

            return result;
        }

        /// <summary>
        /// 爬虫获取小说需要的目录信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public IDResult<NovelCrawlCatalogDTO> NovelCatalog(
            [FromServices]MyZoneContext context,
            Guid uid)
        {
            var catalog = new NovelCrawlCatalogDTO();

            var book = context.Book
                .Include(b => b.Volume)
                .Include(b => b.Chapter)
                .FirstOrDefault(b => b.Uid == uid);

            if (book == null)
            {
                return DResult.Error<NovelCrawlCatalogDTO>("书籍不存在");
            }

            catalog.Vs = book.Volume
                .Select(v => new NovelCrawlVolumeDTO
                {
                    No = v.No,
                    Name = v.Name
                })
                .OrderBy(v => v.No)
                .ToArray();

            catalog.Cs = book.Chapter
                .Select(c => new NovelCrawlChapterDTO
                {
                    Uid = c.Uid,
                    VolumeNo = c.VolumeNo,
                    VolumeIndex = c.VolumeIndex,
                    Name = c.Name,
                    WordCount = c.WordCount,
                    PublishTime = c.PublishTime,
                    Vip = c.Vip,
                    NeedCrawl = c.NeedCrawl
                })
                .OrderBy(c => c.VolumeNo)
                .OrderBy(c => c.VolumeIndex)
                .ToArray();

            return DResult.Success(catalog);
        }

        /// <summary>
        /// 上传爬取好的小说卷信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="volume"></param>
        /// <returns></returns>
        public IDResult UploadVolume(
            [FromServices]MyZoneContext context,
            [FromBody]VolumeUploadDTO volume)
        {
            var book = context.Book
                .Include(b => b.Volume)
                .FirstOrDefault(b => b.Uid == volume.BookUid);

            if (book == null)
            {
                return DResult.Error("书籍不存在");
            }
            else if (book.Volume.FirstOrDefault(v => v.No == volume.No) != null)
            {
                return DResult.Error("存在相同编号的卷信息");
            }
            else
            {
                book.Volume.Add(new Volume
                {
                    BookUid = volume.BookUid,
                    No = volume.No,
                    Name = volume.Name
                });

                context.SaveChanges();

                return DResult.Success();
            }
        }
    }
}