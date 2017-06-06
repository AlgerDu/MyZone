using System;
using MyZone.Server.Infrastructure.Interface;

namespace MyZone.Server.Models.Domain.Base
{
    /// <summary>
    /// 领域模型基类
    /// </summary>
    public class BaseDomainModel : INeedService
    {
        /// <summary>
        /// 服务提供者
        /// </summary>
        protected IDServiceProvider _provider { get; private set; }

        private bool _hasGetService = false;

        public void InjecteService(IDServiceProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// 检查所有的服务是否已经加载，没有则加载
        /// </summary>
        protected void CheckService()
        {
            if (!_hasGetService)
            {
                lock (this)
                {
                    if (!_hasGetService)
                    {
                        GetAllService();
                    }
                }
            }
        }

        /// <summary>
        /// 从 privoder 中获取所有的服务
        /// </summary>
        protected virtual void GetAllService()
        {

        }
    }
}