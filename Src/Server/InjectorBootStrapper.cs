using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MyZone.Server.Infrastructure;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.DataBase;
using MyZone.Server.Models.Domain.Books;
using MyZone.Server.Models.Domain.Urls;

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

        public static IServiceProvider MyZoneServices(this IServiceCollection services)
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            builder.RegisterType<MyZoneContext>();

            builder.RegisterType<FunnyLazyLoading>().As<IFunnyLazyLoading>().InstancePerRequest();

            builder.RegisterType<BookRepository>().As<IBookRepository>().InstancePerRequest();
            builder.RegisterType<BookFactory>().SingleInstance();

            builder.RegisterType<UrlRepository>().As<IUrlRepository>().InstancePerRequest();
            builder.RegisterType<BookFactory>().SingleInstance();

            builder.Populate(services);

            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}