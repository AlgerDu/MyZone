using System;
using System.Linq;
using System.Text.RegularExpressions;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.Domain.Base;
using MyZone.Server.Models.Domain.Urls;

namespace MyZone.Server.Models.DataBase
{
    /// <summary>
    /// Url 领域模型
    /// </summary>
    public partial class Url : IAggregateRoot<string>
    {
        UrlServiceCollection _service;

        Host _host;

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
        public Host Host
        {
            get
            {
                if (_host == null)
                {
                    var context = _service.Load.Context as MyZoneContext;

                    var _host = context.Host
                            .FirstOrDefault(h => h.Name == HostName);

                    if (_host == null)
                    {
                        _host = new Host()
                        {
                            Name = HostName,
                            Uid = Guid.NewGuid()
                        };

                        context.Host.Add(_host);
                    }

                    _host.PageParses = context.PageParse
                            .Where(pp => pp.Url == _host.Name);
                }

                return _host;
            }
        }

        public PageParse Parse
        {
            get
            {
                return _service.Load.Context.PageParse
                        .FirstOrDefault(pp => pp.Url == UrlPath);
            }
        }

        void INeedService.InjecteService(IDServiceCollection collection)
        {
            _service = collection as UrlServiceCollection;
        }
    }
}