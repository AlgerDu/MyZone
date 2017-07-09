using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DataBase;
using MyZone.Server.Models.Domain.Urls;

namespace MyZone.Server.Models.Domain.Books
{
    /// <summary>
    /// Book 领域对象需要的服务集合
    /// </summary>
    public class BookServiceCollection : IDServiceCollection
    {
        public MyZoneContext Context { get; private set; }

        public IUrlRepository UrlRepo { get; private set; }

        public BookServiceCollection(
            MyZoneContext context,
            IUrlRepository urlRepo
        )
        {
            Context = context;
            UrlRepo = urlRepo;
        }
    }
}