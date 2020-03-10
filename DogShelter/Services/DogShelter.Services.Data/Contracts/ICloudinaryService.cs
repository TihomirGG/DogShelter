namespace DogShelter.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DogShelter.Data.Models;
    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task UploadAsync(ICollection<IFormFile> images);

        Task UploadAsync(string url);
    }
}
