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
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<MyZoneContext>();

            services.AddScoped<IFunnyLazyLoading, FunnyLazyLoading>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddSingleton<BookFactory>();
        }
    }
}