namespace DogShelter.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DogShelter.Services.Data.ServiceModels.Post;

    public interface IPostService
    {
       public Task<IEnumerable<PostServiceModel>> GetAll();
    }
}
