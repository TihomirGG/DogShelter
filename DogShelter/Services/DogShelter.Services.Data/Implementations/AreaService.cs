namespace DogShelter.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DogShelter.Data.Common.Repositories;
    using DogShelter.Data.Models;
    using DogShelter.Services.Data.Contracts;

    public class AreaService : IAreaService
    {
        private readonly IRepository<Post> db;

        public AreaService(IRepository<Post> db)
        {
            this.db = db;
        }

        public IEnumerable<string> GetAreasName()
          => Enum.GetValues(typeof(Area)).Cast<Area>().Select(x => x.ToString()).ToList();
    }
}
