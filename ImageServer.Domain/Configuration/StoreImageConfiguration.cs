using System.Configuration;

namespace ImageServer.Domain.Configuration
{
    public class StoreImageConfiguration : ConfigurationSection, IStoreImageConfiguration
    {
        [ConfigurationProperty("path")]
        public string Path
        {
            get => (string) this["path"];
            set => this["path"] = value;
        }
    }
}