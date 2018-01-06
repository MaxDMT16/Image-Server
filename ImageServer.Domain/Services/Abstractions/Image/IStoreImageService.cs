using ImageServer.Domain.Services.Contracts;

namespace ImageServer.Domain.Services.Abstractions.Image
{
    public interface IStoreImageService
    {
        void Store(ImageStorageRequest request);
    }
}