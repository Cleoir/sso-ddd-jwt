using System.Web.Http;
using WebActivatorEx;
using SSO.Api;
using Swashbuckle.Application;
using System;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SSO.Api
{
    ///<Summary>
    ///</Summary>
    public class SwaggerConfig
    {
        ///<Summary>
        ///</Summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {                    
                        c.SingleApiVersion("v1", "SSO.Api");
                        c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\bin\SSO.Api.xml");
                    })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle("Example utility swagger.");
                    c.DocExpansion(DocExpansion.List);
                });
        }
    }
}
