using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Infrastructure.Results;
using MyZone.Server.Models.DataBase;
using MyZone.Server.Models.Domain.Base;

namespace MyZone.Server.Models.Domain.Books
{
    public class BookRepository : IBookRepository
    {
        MyZoneContext _context;
        DbSet<Book> _dbSet;

        IQueryable<Book> IRepository<Book, Guid>.Entities
        {
            get
            {
                return _context.Book;
            }
        }

        public BookRepository(MyZoneContext contex)
        {
            _context = contex;
            _dbSet = _context.Set<Book>();
        }

        IResult IRepository<Book, Guid>.Delete(Guid key)
        {
            var toDeleteBook = GetByKey(key);

            if (toDeleteBook == null)
            {
                return Result.Error("书籍不存在");
            }
            else
            {
                return Delete(toDeleteBook);
            }
        }

        public IResult Delete(Book entity)
        {
            _dbSet.Remove(entity);
            return Result.Success();
        }

        IBathOpsResult IRepository<Book, Guid>.Delete(IEnumerable<Book> entities)
        {
            throw new NotImplementedException();
        }

        public Book GetByKey(Guid key)
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

        int IRepository<Book, Guid>.SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}