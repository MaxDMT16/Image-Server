using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ImageServer.Domain.Services.Abstractions.Image;
using ImageServer.Domain.Services.Contracts;
using System.Web.Http;

namespace ImageServer.WebAPI.Controllers
{
    [RoutePrefix("api/image")]
    public class ImageController : ApiController
    {
        private readonly IStoreImageService _storeImageService;

        public ImageController(IStoreImageService storeImageService)
        {
            _storeImageService = storeImageService;
        }

        [HttpPost]
        [Route("upload")]
        public async Task UploadImage()
        {
            var multipartData = await Request.Content.ReadAsMultipartAsync();

            var imageContent = multipartData.Contents.FirstOrDefault();

            var stream = await imageContent.ReadAsStreamAsync();

            var fileName = imageContent.Headers.ContentDisposition.FileName;

            var storeImageRequest = new ImageStorageRequest
            {
                Stream = stream,
                FileName = fileName
            };

            _storeImageService.Store(storeImageRequest);
        }
    }
}
