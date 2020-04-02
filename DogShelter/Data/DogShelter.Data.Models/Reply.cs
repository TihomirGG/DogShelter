namespace DogShelter.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using DogShelter.Data.Common.Models;

    public class Reply : BaseModel<int>
    {
        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Description { get; set; }
    }
}
