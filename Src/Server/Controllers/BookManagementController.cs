using System;
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

        public BookManagementController(
            ILogger<BookManagementController> logger
            , IBookRepository bookRepo
            , IMapper mapper
        )
        {
            _logger = logger;
            _bookRepo = bookRepo;
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
            return null;
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
            return null;
        }
    }
}