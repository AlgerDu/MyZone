using System.Text.RegularExpressions;
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

        /// <summary>
        /// 获取主机名
        /// </summary>
        public string HostName
        {
            get
            {
                var array = Regex.Split(UrlPath, @"(^http[s]?://[^/:]+(:\d*)?)");
                return array[0];
            }
        }

        /// <summary>
        /// 主机
        /// </summary>
        public Host Host { get; set; }

        public PageParse Parse { get; set; }
    }
}