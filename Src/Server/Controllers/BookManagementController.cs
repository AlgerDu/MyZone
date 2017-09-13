using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Infrastructure.Results;
using MyZone.Server.Infrastructure.SearchBase;
using MyZone.Server.Models.DataBase;
using MyZone.Server.Models.Domain.Books;
using MyZone.Server.Models.DTO.BookManagement;
using MyZone.Server.Models.Domain.Urls;

namespace MyZone.Server.Controllers
{
    /// <summary>
    /// 数据管理
    /// </summary>
    [Route("api/[controller]")]
    public class BookManagementController : Controller
    {
        ILogger _logger;
        IMapper _mapper;
        IFunnyLazyLoading _lazy;
        IBookRepository _bookRepo;
        IUrlRepository _urlRepo;

        public BookManagementController(
            ILogger<BookManagementController> logger
            , IBookRepository bookRepo
            , IFunnyLazyLoading lazy
            , IMapper mapper
            , IUrlRepository urlRepo
        )
        {
            _logger = logger;
            _bookRepo = bookRepo;
            _lazy = lazy;
            _mapper = mapper;
            _urlRepo = urlRepo;
        }

        /// <summary>
        /// 获取小说列表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        [HttpPost("novel")]
        public ISearchResult<NovelListModel> Novel(
            [FromBody]SerachCondition condition
        )
        {
            var r = _bookRepo.Search(condition);

            return r.Map<Book, NovelListModel>(_mapper);
        }

        /// <summary>
        /// 设置小说的爬去网站
        /// </summary>
        /// <returns></returns>
        public IResult<bool> SetNovelCrawlSite(

        )
        {
            return Result.Error("尚未实现", false);
        }

        /// <summary>
        /// 获取小说的爬去网站
        /// </summary>
        /// <returns></returns>
        public IResult<bool> GetNovelCrawlSite(

        )
        {
            return Result.Error("尚未实现", false);
        }

        /// <summary>
        /// 向系统中添加一本小说类型的书籍
        /// </summary>
        /// <param name="novel"></param>
        /// <returns></returns>
        public IResult<Guid> AddNovel(
            [FromBody]NovelAddModel novel
            , [FromServices]BookFactory bookFactory
        )
        {
            var book = bookFactory.CreateNovel(novel);

            var find = _bookRepo.Find(book.Name, book.Author);

            if (find != null)
            {
                return Result.Error<Guid>("已经添加了相同作者和书名的书籍");
            }

            _bookRepo.Insert(book);

            _bookRepo.SaveChanges();

            return Result.Success(book.Key);
        }

        /// <summary>
        /// 修改一本小说的信息
        /// </summary>
        /// <param name="novel"></param>
        /// <returns></returns>
        public IResult UpdateNovel(
            [FromBody]NovelUpdateModel novel
        )
        {
            var book = _bookRepo.GetByKey(novel.Uid);

            if (book == null)
            {
                return Result.Error("小说不存在");
            }

            book.Name = novel.Name;
            book.Author = novel.Author;

            _bookRepo.Update(book);
            _bookRepo.SaveChanges();

            return Result.Success();
        }

        /// <summary>
        /// 获取小说的章节卷信息
        /// </summary>
        /// <returns></returns>
        public IResult<NovelCatalogChapterModel> Catalog(
            [FromBody]Guid bookUid
            )
        {
            var find = _bookRepo.GetByKey(bookUid);

            if (find == null)
            {
                return Result.Error<NovelCatalogChapterModel>("书籍不存在");
            }

            _lazy.LoadBookCatalog(find);

            var dto = _mapper.Map<NovelCatalogChapterModel>(find);

            return Result.Success(dto);
        }

        /// <summary>
        /// 重新爬去一本小说的全部章节
        /// </summary>
        /// <returns></returns>
        public IResult RecrawlNovel(
            [FromBody]Guid bookUid
            )
        {
            var find = _bookRepo.GetByKey(bookUid);

            if (find == null)
            {
                return Result.Error<NovelCatalogChapterModel>("书籍不存在");
            }

            _lazy.LoadBookCatalog(find);

            foreach (var c in find.Chapter)
            {
                c.NeedCrawl = true;
            }

            _bookRepo.Update(find);
            _bookRepo.SaveChanges();

            return Result.Success();
        }

        /// <summary>
        /// 重新爬去小说的部分章节
        /// </summary>
        /// <returns></returns>
        public IResult RecrawlChapters(
            [FromBody]RecrawlChapterListModel info
            )
        {
            var find = _bookRepo.GetByKey(info.BookUid);

            if (find == null)
            {
                return Result.Error<NovelCatalogChapterModel>("书籍不存在");
            }

            _lazy.LoadBookCatalog(find);

            var needRecrawlChapters = from c in find.Chapter
                                      from ic in info.Chapters
                                      where c.VolumeIndex == ic.VolumeIndex && c.VolumeNo == ic.VolumeNo
                                      select c;

            foreach (var c in needRecrawlChapters.ToList())
            {
                c.NeedCrawl = true;
            }

            _bookRepo.Update(find);
            _bookRepo.SaveChanges();

            return Result.Success();
        }

        /// <summary>
        /// 获取小说的爬去Url以及页面处理代码
        /// </summary>
        /// <param name="bookUid"></param>
        /// <returns></returns>
        public IResult<UrlPageParseModel> NovelCrwalInfo(
            [FromBody]Guid bookUid
            )
        {
            return null;
        }

        /// <summary>
        /// 设置小说的爬去Url以及页面处理代码
        /// </summary>
        /// <returns></returns>
        public IResult UpdateNovelCrwal()
        {
            return null;
        }
    }
}