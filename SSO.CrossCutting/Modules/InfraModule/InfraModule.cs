using Autofac;
using SSO.Domain.Interfaces.Repositories;
using SSO.Infra.Repositories;

namespace SSO.CrossCutting.Modules.InfraModule
{
    public class InfraModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
