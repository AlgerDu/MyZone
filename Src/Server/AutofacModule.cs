using Autofac;
using MyZone.Server.Models.Domain.Books;

namespace MyZone.Server
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookRepository>().As<IBookRepository>();
        }
    }
}