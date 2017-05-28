using System;
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

namespace MyZone.Server.Controllers
{
    /// <summary>
    /// 数据管理
    /// </summary>
    public class BookManagementController : Controller
    {
        ILogger _logger;
        IBookRepository _bookRepo;
        IMapper _mapper;
        IFunnyLazyLoading _lazy;

        public BookManagementController(
            ILogger<BookManagementController> logger
            , IBookRepository bookRepo
            , IFunnyLazyLoading lazy
            , IMapper mapper
        )
        {
            _logger = logger;
            _bookRepo = bookRepo;
            _lazy = lazy;
            _mapper = mapper;
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
        /// 获取小说列表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public ISearchResult<NovelListModel> Novel(
            [FromBody]SerachCondition condition
        )
        {
            var r = _bookRepo.Search(condition);

            return new SearchResult<NovelListModel>(
                r.RecodCount,
                r.PageIndex,
                r.PageSize,
                _mapper.Map<IEnumerable<NovelListModel>>(r.Data));
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
        public IResult RecrawlChapters()
        {
            return null;
        }

        /// <summary>
        /// 获取小说的爬去Url以及页面处理代码
        /// </summary>
        /// <returns></returns>
        public IResult NovelCrwalInfo()
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