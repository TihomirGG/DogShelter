namespace DogShelter.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostService
    {
        Task<IEnumerable<T>> GetAll<T>(int? take = null, int skip = 0);

        Task<IEnumerable<T>> FilteredPosts<T>(string title, string area);

        Task<IEnumerable<T>> FilteredUsers<T>(string title);

        Task<int> Create(string title, string description, string area, string userId);

        int PostsCount();
    }
}
