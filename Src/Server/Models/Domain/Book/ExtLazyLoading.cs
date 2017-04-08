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
    }
}