using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DataBase;

namespace MyZone.Server.Models.Domain.Books
{
    public class BookRepository : IBookRepository
    {
        MyZoneContext _context;

        IQueryable<Book> IRepository<Book, Guid>.Entities => throw new NotImplementedException();

        public BookRepository(MyZoneContext contex)
        {
            _context = contex;
        }

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
            return _context.Book.FirstOrDefault(b => b.Uid == key);
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