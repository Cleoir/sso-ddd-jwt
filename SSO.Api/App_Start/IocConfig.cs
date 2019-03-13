using Autofac;
using Autofac.Integration.WebApi;
using SSO.CrossCutting.Modules.DomainModule;
using SSO.CrossCutting.Modules.InfraModule;
using System.Reflection;
using System.Web.Http;


namespace SSO.Api.App_Start
{
    /// <summary>
    /// </summary>
    public class IocConfig
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();

            RegisterModules(builder);

            return builder.Build();
        }

        private void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new InfraModule());
        }
    }
}