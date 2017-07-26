using System;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DataBase;

namespace MyZone.Server.Models.Domain.Books
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
        /// <summary>
        /// 通过作者和书名查找书籍（不同的作者可能会有相同名称的书籍）
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        Book Find(string bookName, string author);
    }
}