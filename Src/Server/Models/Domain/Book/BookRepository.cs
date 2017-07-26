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
    public class BookRepository : BaseRepository<Book, Guid>, IBookRepository
    {
        public BookRepository(
            MyZoneContext contex,
            BookServiceCollection service
            ) : base(contex)
        {
            _service = service;
        }

        public Book Find(string bookName, string author)
        {
            var find = _dbSet.FirstOrDefault(b => b.Name == bookName && b.Author == author);
            return InjecteService(find);
        }
    }
}