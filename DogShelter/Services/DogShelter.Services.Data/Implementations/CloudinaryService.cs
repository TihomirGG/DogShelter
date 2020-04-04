namespace DogShelter.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using DogShelter.Common;
    using DogShelter.Data.Common.Repositories;
    using DogShelter.Data.Models;
    using DogShelter.Services.Data.Contracts;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;
        private readonly IImageService imageService;
        private readonly IRepository<PostImages> db;

        public CloudinaryService(
            Cloudinary cloudinary,
            IImageService imageService,
            IRepository<PostImages> db)
        {
            this.cloudinary = cloudinary;
            this.imageService = imageService;
            this.db = db;
        }

        public async Task<ICollection<Image>> UploadAsync(ICollection<IFormFile> images, int postId)
        {
            var allImages = new List<Image>();
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
                var imgId = await this.imageService.AddAsync(urlForDb);
                var postImage = new PostImages()
                {
                    ImageId = imgId,
                    PostId = postId,
                };
                await this.db.AddAsync(postImage);
                await this.db.SaveChangesAsync();
            }

            return allImages;
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
