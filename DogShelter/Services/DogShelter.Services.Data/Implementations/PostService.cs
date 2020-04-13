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
    using DogShelter.Services.Mapping;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            return await this.db.All().OrderByDescending(x => x.CreatedOn).To<T>().ToListAsync();
        }
    }
}
