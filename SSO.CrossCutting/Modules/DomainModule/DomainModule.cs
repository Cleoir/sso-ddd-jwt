using Autofac;
using SSO.Domain.Interfaces.Services;
using SSO.Domain.Services;

namespace SSO.CrossCutting.Modules.DomainModule
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserValidationService>().As<IUserValidationService>();
        }
    }
}
