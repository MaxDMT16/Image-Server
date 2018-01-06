using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using ImageServer.Domain;

namespace ImageServer.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ContainerBuilder builder = new ContainerBuilder();
            
            builder.RegisterModule<DomainModule>();
            builder.RegisterModule<WebAPIModule>();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
