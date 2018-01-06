using System.Web.Configuration;
using Autofac;
using ImageServer.Domain.Configuration;
using ImageServer.Domain.Services.Implementations.Image;

namespace ImageServer.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StoreImageService>().AsImplementedInterfaces();

            var storeImageConfigurationSection = WebConfigurationManager.GetSection("StoreImage") as StoreImageConfiguration;
            builder.RegisterInstance(storeImageConfigurationSection).AsImplementedInterfaces();
        }
    }
}