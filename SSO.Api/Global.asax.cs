using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.WebApi;
using CommonServiceLocator;
using SSO.Api.App_Start;
using SSO.CrossCutting.Factory;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SSO.Api
{
    ///<Summary>
    ///</Summary>
    public class WebApiApplication : HttpApplication
    {
        ///<Summary>
        ///</Summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            var container = new IocConfig().GetContainer();
            var provider = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => provider);
            Factory.ServiceLocator = ServiceLocator.Current;
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
