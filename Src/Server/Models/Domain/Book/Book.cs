using System;
using System.Collections.Generic;
using System.Linq;
using MyZone.Server.Infrastructure.Interface;

namespace MyZone.Server.Models.DataBase
{
    /// <summary>
    /// 书籍领域模型
    /// </summary>
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