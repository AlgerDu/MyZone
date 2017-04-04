using System;
using MyZone.Server.Infrastructure.Interface;

namespace MyZone.Server.Models.DataBase
{
    public partial class Book : IAggregateRoot<Guid>
    {
        public Guid Key
        {
            get
            {
                return Uid;
            }
        }
    }
}