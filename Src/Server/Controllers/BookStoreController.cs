using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Infrastructure.SearchBase;
using MyZone.Server.Models.Domain.Books;
using MyZone.Server.Models.DTO.BookStore;

namespace MyZone.Server.Controllers
{
    /// <summary>
    /// 书店
    /// </summary>
    public class BookStoreController : Controller
    {
        ILogger _logger;
        IBookRepository _bookRepository;
        IFunnyLazyLoading _lazy;
        IMapper _mapper;

        public BookStoreController(
            ILogger<BookStoreController> logger
            , IBookRepository bookRepository
            , IFunnyLazyLoading lazy
            , IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _lazy = lazy;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取小说类型书籍
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ISearchResult<NovelStoreInfoModel> Novel(
            [FromBody]SerachCondition condition
        )
        {
            var result = new SearchResult<NovelStoreInfoModel>(_bookRepository.Entities.Count())
            {
                PageSize = condition.PageSize,
                PageIndex = condition.PageIndex,
                Code = 0
            };
            var books = _bookRepository.Entities
                                .Skip((int)condition.SkipCount)
                                .Take((int)condition.PageSize)
                                .ToList();

            foreach (var book in books)
            {
                _lazy.LoadBookCatalog(book);

                var i = _mapper.Map<NovelStoreInfoModel>(book);

                result.AddRecord(i);
            }

            return result;
        }
    }
}