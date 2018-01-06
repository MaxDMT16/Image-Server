using System;
using System.IO;
using ImageServer.Domain.Configuration;
using ImageServer.Domain.Services.Abstractions.Image;
using ImageServer.Domain.Services.Contracts;

namespace ImageServer.Domain.Services.Implementations.Image
{
    public class StoreImageService : IStoreImageService
    {
        private readonly IStoreImageConfiguration _configuration;

        public StoreImageService(IStoreImageConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Store(ImageStorageRequest request)
        {
            if (request.Stream == null || request.Stream.Length == 0)
            {
                throw new InvalidOperationException("Stream is null or empty");
            }
            System.Drawing.Image image;

            try
            {
                image = System.Drawing.Image.FromStream(request.Stream);
            }
            catch (ArgumentException)
            {
                throw new InvalidOperationException("Can not read image from stream");
            }

            var fileName = GetFileName(request.FileName);

            image.Save($"{_configuration.Path}{Path.DirectorySeparatorChar}{fileName}");
        }

        private string GetFileName(string inputFileName)
        {
            var fileName = inputFileName.Replace("\"", string.Empty);
            return fileName;
        }
    }
}