using System.IO;

namespace ImageServer.Domain.Services.Contracts
{
    public class ImageStorageRequest
    {
        public Stream Stream { get; set; }
        public string FileName { get; set; }
    }
}