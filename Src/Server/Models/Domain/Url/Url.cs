using MyZone.Server.Infrastructure.Interface;

namespace MyZone.Server.Models.DataBase
{
    /// <summary>
    /// Url 领域模型
    /// </summary>
    public partial class Url : IAggregateRoot<string>
    {
        public string Key
        {
            get
            {
                return UrlPath;
            }
        }
    }
}