namespace DogShelter.Services.Data.Implementations
{
    using System.Threading.Tasks;

    using DogShelter.Data.Common.Repositories;
    using DogShelter.Data.Models;
    using DogShelter.Services.Data.Contracts;

    public class ImageService : IImageService
    {
        private readonly IRepository<Image> repository;

        public ImageService(IRepository<Image> repository)
        {
            this.repository = repository;
        }

        public async Task<int> AddAsync(string url)
        {
            var img = new Image()
            {
                Url = url,
            };
            await this.repository.AddAsync(img);
            await this.repository.SaveChangesAsync();
            return img.Id;
        }
    }
}
