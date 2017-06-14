using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DataBase;

namespace MyZone.Server.Models.Domain.Urls
{
    /// <summary>
    /// Url 领域对象需要的 服务 collection
    /// </summary>
    public class UrlServiceCollection : IDServiceCollection
    {
        public MyZoneContext Context { get; private set; }

        public UrlServiceCollection(
            MyZoneContext context
        )
        {
            Context = context;
        }
    }
}