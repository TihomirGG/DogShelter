namespace DogShelter.Services.Data.ServiceModels.Post
{
    using System;
    using System.Collections.Generic;

    public class PostServiceModel
    {
        public string Username { get; set; }

        public string Description { get; set; }

        public string CreatedOn { get; set; }

        public IEnumerable<string> Links { get; set; }
    }
}
