namespace DogShelter.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using DogShelter.Data.Common.Repositories;
    using DogShelter.Data.Models;
    using DogShelter.Services.Data.Contracts;
    using DogShelter.Services.Data.ServiceModels.Post;

    public class PostService : IPostService
    {
        private readonly IRepository<Post> db;

        public PostService(IRepository<Post> db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<PostServiceModel>> GetAll()
        {
            var posts = this.db.All().OrderBy(x => x.CreatedOn)
              .Select(x => new PostServiceModel
              {
                  Username = x.User.UserName,
                  CreatedOn = x.CreatedOn.ToString("MM/dd/yyyy HH:mm"),
                  Description = x.Description,
                  Links = x.PostImages.Where(f => f.PostId == x.Id)
                  .Select(l => l.Image.Url).ToArray(),
              }).ToList();
            return posts;
        }
    }
}
