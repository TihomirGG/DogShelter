namespace DogShelter.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using DogShelter.Common;
    using DogShelter.Data.Models;
    using DogShelter.Services.Data.Contracts;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;
        private readonly IImageService imageService;

        public CloudinaryService(Cloudinary cloudinary, IImageService imageService)
        {
            this.cloudinary = cloudinary;
            this.imageService = imageService;
        }

        public async Task UploadAsync(ICollection<IFormFile> images)
        {
            foreach (var image in images)
            {
                byte[] imageInBytes;

                using var memoryStream = new MemoryStream();
                await image.CopyToAsync(memoryStream);
                imageInBytes = memoryStream.ToArray();

                using var destinationStream = new MemoryStream(imageInBytes);
                var param = new ImageUploadParams()
                {
                    File = new FileDescription(image.Name, destinationStream),
                };

                var result = await this.cloudinary.UploadAsync(param);
                var url = result.SecureUri.ToString();
                var urlForDb = url.Replace(GlobalConstants.DefaultCloudinaryLink, string.Empty);

                await this.imageService.AddAsync(urlForDb);
            }
        }

        public async Task UploadAsync(string url)
        {
            var param = new ImageUploadParams()
            {
                File = new FileDescription(url),
            };

            var result = await this.cloudinary.UploadAsync(param);
            var resultUrl = result.SecureUri.ToString();
            var urlForDb = url.Replace(GlobalConstants.DefaultCloudinaryLink, string.Empty);

            await this.imageService.AddAsync(urlForDb);
        }
    }
}
