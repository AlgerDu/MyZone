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
        public BookRepository(DbContext contex) : base(contex)
        { }
    }
}