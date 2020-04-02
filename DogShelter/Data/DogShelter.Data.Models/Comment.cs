namespace DogShelter.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using DogShelter.Data.Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Description { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
