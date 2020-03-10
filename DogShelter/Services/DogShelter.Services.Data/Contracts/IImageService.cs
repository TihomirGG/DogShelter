namespace DogShelter.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IImageService
    {
        Task AddAsync(string url);
    }
}
