namespace DogShelter.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostService
    {
        Task<IEnumerable<T>> GetAll<T>();

        Task<int> Create(string title, string description, string area, string userId);
    }
}
