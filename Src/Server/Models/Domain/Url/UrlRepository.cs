using MyZone.Server.Models.DataBase;
using MyZone.Server.Models.Domain.Base;

namespace MyZone.Server.Models.Domain.Urls
{
    public class UrlRepository : BaseRepository<Url, string>, IUrlRepository
    {
        public UrlRepository(
            MyZoneContext context
            , UrlServiceCollection service) : base(context)
        {
            _service = service;
        }
    }
}