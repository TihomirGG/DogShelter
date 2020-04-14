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
        private readonly IRepository<ApplicationUser> userDb;

        public PostService(
            IRepository<Post> db,
            IRepository<ApplicationUser> userDb)
        {
            this.db = db;
            this.userDb = userDb;
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

        public async Task<IEnumerable<T>> FilteredPosts<T>(string title, string area)
        {
            var enumArea = (int)Enum.Parse(typeof(Area), area);
            return await this.db.AllAsNoTracking()
                     .Where(x => x.Title.ToLower().Contains(title.ToLower()) && (int)x.Area == enumArea)
                     .OrderByDescending(x => x.CreatedOn).To<T>().ToListAsync();

        }

        public async Task<IEnumerable<T>> FilteredUsers<T>(string username)
        {
            var users = await this.userDb.AllAsNoTracking()
                    .Where(x => x.UserName.ToLower().Contains(username.ToLower()))
                    .OrderByDescending(x => x.CreatedOn).To<T>().ToListAsync();
            return users;
        }

        public async Task<IEnumerable<T>> GetAll<T>(int? take = null, int skip = 0)
        {
            var query = this.db.AllAsNoTracking().OrderByDescending(x => x.CreatedOn).Skip(skip);
            if (take.HasValue)
            {
                query.Take(take.Value);
            }

            return await query.To<T>().ToListAsync();
        }

        public int PostsCount()
        {
            return this.db.All().Count();
        }
    }
}
