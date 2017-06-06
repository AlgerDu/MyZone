using Autofac;

namespace Server.Infrastructure.Interface
{
    public interface IServicePrivoder
    {
        /// <summary>
        /// IoC 容器
        /// </summary>
        IContainer Container { get; set; }
    }
}