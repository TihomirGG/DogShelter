namespace DogShelter.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DogShelter.Services.Data.ServiceModels.Post;
    using Microsoft.AspNetCore.Http;

    public interface IPostService
    {
       public IEnumerable<PostServiceModel> GetAll();

        public Task<int> Create(string title, string description, string area, string userId);
    }
}
