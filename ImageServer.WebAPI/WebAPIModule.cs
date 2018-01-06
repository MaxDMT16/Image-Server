using Autofac;
using Autofac.Integration.WebApi;

namespace ImageServer.WebAPI
{
    public class WebAPIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(ThisAssembly);
        }
    }
}