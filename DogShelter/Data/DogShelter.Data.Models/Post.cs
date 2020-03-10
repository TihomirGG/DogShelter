namespace DogShelter.Data.Models
{
    using System.Collections.Generic;

    using DogShelter.Data.Common.Models;

    public class Post : BaseModel<int>
    {
        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<PostImage> PostImages { get; set; } = new HashSet<PostImage>();

    }
}
