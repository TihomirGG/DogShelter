namespace DogShelter.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DogShelter.Data.Models;
    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task<ICollection<Image>> UploadAsync(ICollection<IFormFile> images, int postId);

        Task UploadAsync(string url);
    }
}
