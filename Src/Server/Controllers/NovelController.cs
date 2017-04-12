using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Infrastructure.Results;
using MyZone.Server.Models.Domain.Books;
using MyZone.Server.Models.DTO.Novel;

namespace MyZone.Server.Controllers
{
    public class NovelController : Controller
    {
        ILogger _logger;
        IBookRepository _bookRepository;
        IFunnyLazyLoading _lazy;
        IMapper _mapper;

        public NovelController(
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
        /// 获取小说的更新内容
        /// </summary>
        /// <param name="lastInfos"></param>
        /// <returns></returns>
        public IBathOpsResult<NovelUpdateModel> Update(
            [FromBody]NovelLastUpdateModel[] lastInfos
        )
        {
            var result = new BathOpsResult<NovelUpdateModel>(lastInfos.Length);

            var index = -1;

            foreach (var info in lastInfos)
            {
                index++;
                var book = _bookRepository.GetByKey(info.BookUid);

                if (book == null)
                {
                    result.AddErrorItem(index, "小说不存在");
                    break;
                }

                _lazy.LoadBookCatalog(book);

                var updateInfo = new NovelUpdateModel();
                updateInfo.BookUid = info.BookUid;

                updateInfo.ChapterCount = book.Chapter
                                .Where(c => c.PublishTime > info.UpdateTime)
                                .Count();

                if (updateInfo.ChapterCount > 0)
                {
                    var lastChapter = book.Chapter
                                .OrderByDescending(c => c.VolumeNo)
                                .ThenByDescending(c => c.VolumeIndex)
                                .FirstOrDefault();

                    updateInfo.LastChapter = _mapper.Map<LastChapterModel>(lastChapter);
                }

                result.AddSuccessItem(index, updateInfo);
            }

            return result;
        }
    }
}