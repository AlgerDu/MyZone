using System.Linq;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DataBase;

namespace MyZone.Server.Models.Domain.Books
{
    public static class ExtLazyLoading
    {
        public static void LoadBookCatalog(this IFunnyLazyLoading lazy, Book book)
        {
            lazy.Context.Entry(book)
                .Collection(b => b.Chapter)
                .Load();

            lazy.Context.Entry(book)
                .Collection(b => b.Volume)
                .Load();
        }

        /// <summary>
        /// 加载 chapter 的 content 数据
        /// </summary>
        /// <param name="lazy"></param>
        /// <param name="chapter"></param>
        public static void LoadChapterContent(this IFunnyLazyLoading lazy, Chapter chapter)
        {
            lazy.Context.Entry(chapter)
                    .Reference(c => c.ContextU)
                    .Load();
        }
    }
}