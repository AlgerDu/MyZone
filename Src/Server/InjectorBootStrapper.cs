using Autofac;
using Microsoft.Extensions.DependencyInjection;
using MyZone.Server.Infrastructure;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DataBase;
using MyZone.Server.Models.Domain.Books;

namespace MyZone.Server
{
    /// <summary>
    /// 依赖注入
    /// </summary>
    public static class InjectorBootStrapper
    {
        /// <summary>
        /// MyZone 相关依赖注入
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<MyZoneContext>();

            services.AddScoped<IFunnyLazyLoading, FunnyLazyLoading>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddSingleton<BookFactory>();
        }
    }
}