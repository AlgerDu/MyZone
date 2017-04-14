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

                var lastChapter = book.Chapter
                            .OrderByDescending(c => c.VolumeNo)
                            .ThenByDescending(c => c.VolumeIndex)
                            .FirstOrDefault();

                updateInfo.UpdateTime = lastChapter.PublishTime;

                if (updateInfo.ChapterCount > 0)
                {
                    updateInfo.LastChapter = _mapper.Map<LastChapterModel>(lastChapter);
                }

                result.AddSuccessItem(index, updateInfo);
            }

            return result;
        }

        /// <summary>
        /// 获取小说某个章节前后的章节信息
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public IResult<NovelCatalogModel> Catalog(
            [FromBody]NovelCatalogQueryModel queryInfo
        )
        {
            var book = _bookRepository.GetByKey(queryInfo.BookUid);

            if (book == null)
            {
                return Result.Error<NovelCatalogModel>("小说不存在");
            }

            _lazy.LoadBookCatalog(book);

            var cs = book.Chapter;

            var forward = cs.OrderByDescending(c => c.VolumeNo)
                            .ThenByDescending(c => c.VolumeIndex)
                     .Where(c => (c.VolumeNo == queryInfo.VolumeNo && c.VolumeIndex <= queryInfo.VolumeIndex) || c.VolumeNo < queryInfo.VolumeNo);

            if (queryInfo.ForwardCount > -1)
                forward = forward.Take(queryInfo.ForwardCount);

            var backward = cs.OrderBy(c => c.VolumeNo)
                             .ThenBy(c => c.VolumeIndex)
                     .Where(c => (c.VolumeNo == queryInfo.VolumeNo && c.VolumeIndex >= queryInfo.VolumeIndex) || c.VolumeNo > queryInfo.VolumeNo);

            if (queryInfo.BackwardCount > -1)
                backward = backward.Take(queryInfo.BackwardCount);

            var all = backward.Concat(forward);
            all = all.OrderByDescending(c => c.VolumeNo)
                            .ThenByDescending(c => c.VolumeIndex);

            var vs = from v in book.Volume
                     from vNo in all.Select(c => c.VolumeNo).Distinct()
                     where v.No == vNo
                     select v;

            var data = new NovelCatalogModel();

            data.Vs = _mapper.Map<VolumeModel[]>(vs);
            data.Cs = _mapper.Map<ChapterModel[]>(all);

            return Result.Success(data);
        }

        /// <summary>
        /// 获取章节的正文信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public IResult<ChapterTextModel> ChapterText(
            [FromBody]CHapterTextQueryModel query
        )
        {
            var book = _bookRepository.GetByKey(query.BookUid);

            if (book == null) Result.Error("书籍不存在");

            _lazy.LoadBookCatalog(book);

            var chapter = book.GetChapter(query.VolumeNo, query.VolumeIndex);

            if (chapter == null) Result.Error("书籍的章节不存在");

            _lazy.LoadChapterContent(chapter);

            if (chapter.ContextU == null) Result.Error("尚未收录章节正文内容");

            return Result.Success(_mapper.Map<ChapterTextModel>(chapter.ContextU));
        }
    }
}