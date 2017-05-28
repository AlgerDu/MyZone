using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DataBase;

namespace MyZone.Server.Models.Domain.Urls
{
    /// <summary>
    /// Url 仓储
    /// </summary>
    public interface IUrlRepository : IRepository<Url, string>
    {

    }
}