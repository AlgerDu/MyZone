using System;
using System.Linq;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DataBase;

namespace MyZone.Server.Models.Domain.Urls
{
    public static class ExtLazyLoading
    {
        /// <summary>
        /// 加载 url 对应的解析代码
        /// </summary>
        /// <param name="lazy"></param>
        /// <param name="url"></param>
        public static void LoadUrlPageParse(this IFunnyLazyLoading lazy, Url url)
        {
            // var context = lazy.Context as MyZoneContext;
            // url.Parse = context.PageParse
            //         .FirstOrDefault(pp => pp.Url == url.UrlPath);
        }

        public static void LoadUrlHost(this IFunnyLazyLoading lazy, Url url)
        {
            var context = lazy.Context as MyZoneContext;

            var host = context.Host
                    .FirstOrDefault(h => h.Name == url.HostName);

            if (host == null)
            {
                host = new Host()
                {
                    Name = url.HostName,
                    Uid = Guid.NewGuid()
                };

                context.Host.Add(host);
            }

            host.PageParses = context.PageParse
                    .Where(pp => pp.Url == host.Name);
        }
    }
}