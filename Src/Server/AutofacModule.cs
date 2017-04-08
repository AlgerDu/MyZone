using Autofac;
using MyZone.Server.Infrastructure;
using MyZone.Server.Infrastructure.Interface;
using MyZone.Server.Models.Domain.Books;

namespace MyZone.Server
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookRepository>().As<IBookRepository>().SingleInstance();
            builder.RegisterType<FunnyLazyLoading>().As<IFunnyLazyLoading>().SingleInstance();

            builder.RegisterType<BookFactory>().SingleInstance();
        }
    }
}