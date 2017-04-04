using System;
using System.Collections.Generic;
using System.Linq;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DataBase;

namespace MyZone.Server.Models.Domain.Books
{
    public class BookRepository : IBookRepository
    {
        IQueryable<Book> IRepository<Book, Guid>.Entities => throw new NotImplementedException();

        IResult IRepository<Book, Guid>.Delete(Guid key)
        {
            throw new NotImplementedException();
        }

        IResult IRepository<Book, Guid>.Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        IBathOpsResult IRepository<Book, Guid>.Delete(IEnumerable<Book> entities)
        {
            throw new NotImplementedException();
        }

        Book IRepository<Book, Guid>.GetByKey(Guid key)
        {
            throw new NotImplementedException();
        }

        IResult IRepository<Book, Guid>.Insert(Book entity)
        {
            throw new NotImplementedException();
        }

        IBathOpsResult IRepository<Book, Guid>.Insert(IEnumerable<Book> entities)
        {
            throw new NotImplementedException();
        }

        IResult IRepository<Book, Guid>.Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}