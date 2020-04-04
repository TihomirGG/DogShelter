namespace DogShelter.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DogShelter.Data.Common.Models;

    public class Post : BaseModel<int>
    {
        [MaxLength(15)]
        [Required]
        public string Title { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<PostImages> PostImages { get; set; } = new HashSet<PostImages>();

        public Area Area { get; set; }
    }
}
