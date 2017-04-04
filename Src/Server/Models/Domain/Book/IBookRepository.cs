using System;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DataBase;

namespace MyZone.Server.Models.Domain.Books
{
    public interface IBookRepository : IRepository<Book, Guid>
    {

    }
}