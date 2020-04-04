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
    using Microsoft.AspNetCore.Http;

    public class PostService : IPostService
    {
        private readonly IRepository<Post> db;

        public PostService(IRepository<Post> db)
        {
            this.db = db;
        }

        public async Task<int> Create(string title, string description, string area, string userId)
        {
            var post = new Post()
            {
                Title = title,
                Description = description,
                Area = (Area)Enum.Parse(typeof(Area), area),
                UserId = userId,
            };
            await this.db.AddAsync(post);
            await this.db.SaveChangesAsync();
            return post.Id;
        }

        public IEnumerable<PostServiceModel> GetAll()
        {
            var posts = this.db.All().OrderBy(x => x.CreatedOn)
              .Select(x => new PostServiceModel
              {
                  Username = x.User.UserName,
                  CreatedOn = x.CreatedOn.ToString("MM/dd/yyyy HH:mm"),
                  Description = x.Description,
              }).ToList();
            return posts;
        }
    }
}
