using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using Web.Api.Core;
using Web.Api.Core.Gateways.Repositories;
using Web.Api.Core.Interfaces;
using Web.Api.Core.UseCases;
using Web.Api.Infrastructure;
using Web.Api.Infrastructure.EntityFramework;

namespace refactor_me
{
    public static class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ApplicationDataContext>().As<ApplicationDataContext>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductUseCase>().As<IProductUseCase>();

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}