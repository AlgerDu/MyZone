using System;
using Microsoft.EntityFrameworkCore;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DataBase;

namespace MyZone.Server.Infrastructure
{
    public class FunnyLazyLoading : IFunnyLazyLoading
    {
        DbContext _context;

        public DbContext Context
        {
            get
            {
                return _context;
            }
        }

        public FunnyLazyLoading(
            MyZoneContext context
        )
        {
            _context = context;
        }
    }
}