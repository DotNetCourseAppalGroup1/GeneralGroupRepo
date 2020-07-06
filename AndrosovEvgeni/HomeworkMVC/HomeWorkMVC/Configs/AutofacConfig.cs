using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ProductDatabase.DatabaseRepository;
using ProductDatabase.Entity;
using ProductDatabase.Interfaces;

namespace HomeWorkMVC.Configs
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ProductRepository>().As<IReposInterface<Product>>();
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}