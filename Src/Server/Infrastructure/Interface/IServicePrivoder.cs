using Autofac;

namespace MyZone.Server.Infrastructure.Interface
{
    public interface IServiceProvider
    {
        /// <summary>
        /// 获取一个实例
        /// </summary>
        T Resolve<T>();
    }
}