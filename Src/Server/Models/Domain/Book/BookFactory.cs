using System;
using AutoMapper;
using MyZone.Server.Models.DataBase;
using MyZone.Server.Models.DTO.NovelCrawl;

namespace MyZone.Server.Models.Domain.Books
{
    /// <summary>
    /// 书籍工厂（暂时觉得不需要定义为接口）
    /// </summary>
    public class BookFactory
    {
        IMapper _mapper;

        public BookFactory(
            IMapper mapper
        )
        {
            _mapper = mapper;
        }

        /// <summary>
        /// 创建一本小说书籍
        /// </summary>
        public Book CreateNovel(NovelAddModel newNovel)
        {
            var newBook = _mapper.Map<Book>(newNovel);

            newBook.Uid = Guid.NewGuid();

            return newBook;
        }
    }
}