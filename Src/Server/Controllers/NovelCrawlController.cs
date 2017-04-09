using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyZone.Server.Infrastructure.Helpers;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Infrastructure.Results;
using MyZone.Server.Models;
using MyZone.Server.Models.DataBase;
using MyZone.Server.Models.Domain.Books;
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
        IFunnyLazyLoading _lazy;
        IMapper _mapper;
        IBookRepository _bookRepository;

        public NovelCrawlController(
            ILogger<NovelCrawlController> logger
            , IBookRepository bookRepository
            , IFunnyLazyLoading lazy
            , IMapper mapper)
        {
            _logger = logger;
            _lazy = lazy;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// 添加需要爬取的小说信息
        /// </summary>
        /// <param name="novels"></param>
        /// <returns></returns>
        public IBathOpsResult<string> AddNovels(
            [FromServices]BookFactory bookFactory,
            [FromBody]NovelAddModel[] novels)
        {
            var result = new BathOpsResult<string>(novels.Length);

            var index = 0L;

            foreach (var novle in novels)
            {
                var book = bookFactory.CreateNovel(novle);

                if (_bookRepository.Insert(book).Code == 0)
                    result.AddSuccessItem(index++, null, book.Uid.ToString());
                else
                    result.AddErrorItem(index++, "添加失败");
            }

            _bookRepository.SaveChanges();

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
        public IResult<NovelCatalogModel> NovelCatalog(
             Guid uid)
        {
            var book = _bookRepository.GetByKey(uid);

            if (book == null)
            {
                return Result.Error<NovelCatalogModel>("书籍不存在");
            }

            _lazy.LoadBookCatalog(book);

            var catalog = _mapper.Map<NovelCatalogModel>(book);

            return Result.Success(catalog);
        }

        /// <summary>
        /// 上传爬取好的小说卷信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="volume"></param>
        /// <returns></returns>
        public IResult UploadVolume(
            [FromBody]VolumeUploadModel volume)
        {
            var book = _bookRepository.GetByKey(volume.BookUid);

            if (book == null)
            {
                return Result.Error("书籍不存在");
            }
            else
            {
                _lazy.LoadBookCatalog(book);

                var r = book.AddVolume(_mapper.Map<Volume>(volume));

                if (r.Code == 0)
                {
                    _bookRepository.Update(book);
                    _bookRepository.SaveChanges();
                }

                return r;
            }
        }

        /// <summary>
        /// 上传爬取好的小说章节信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="chapter"></param>
        /// <returns></returns>
        public IResult UploadChapter(
            [FromServices]MyZoneContext context,
            [FromBody]ChapterUploadDTO chapter)
        {
            var book = context.Book
                .Include(b => b.Chapter)
                .FirstOrDefault(b => b.Uid == chapter.BookUid);

            if (book == null)
            {
                return Result.Error("书籍不存在");
            }
            else if (book.Chapter.FirstOrDefault(c => c.VolumeNo == chapter.VolumeNo && c.VolumeIndex == chapter.VolumeIndex) != null)
            {
                return Result.Error("存在相同的章节信息");
            }
            else
            {
                book.Chapter.Add(new Chapter
                {
                    Uid = chapter.Uid,
                    BookUid = chapter.BookUid,
                    Name = chapter.Name,
                    VolumeNo = chapter.VolumeNo,
                    VolumeIndex = chapter.VolumeIndex,
                    PublishTime = chapter.PublishTime,
                    Vip = chapter.Vip,
                    WordCount = chapter.WordCount,
                    NeedCrawl = true
                });

                context.SaveChanges();
                return Result.Success();
            }
        }

        /// <summary>
        /// 上传小说章节正文信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public IResult UploadChapterText(
            [FromServices]MyZoneContext context,
            [FromBody]ChapterTextUploadDTO text)
        {
            var chapter = context.Chapter
                .FirstOrDefault(c => c.Uid == text.cUid);

            if (chapter == null)
            {
                return Result.Error("章节信息不存在");
            }
            else if (!chapter.NeedCrawl)
            {
                return Result.Error("章节不需要重新爬取");
            }
            else
            {
                chapter.NeedCrawl = false;

                chapter.ContextU = new Content
                {
                    Uid = Guid.NewGuid(),
                    Txt = text.Text,
                    CreateTime = DateTime.Now,
                    Ctype = (long)ContentType.NovelBody
                };

                context.SaveChanges();
                return Result.Success();
            }
        }

        public IResult<NovelCrawl[]> BookCrawlUrl(
            [FromServices]MyZoneContext context,
            Guid uid)
        {
            var urls = context.NovelCrawl
                .Where(nc => nc.BookUid == uid);

            return Result.Success(urls.ToArray());
        }
    }
}