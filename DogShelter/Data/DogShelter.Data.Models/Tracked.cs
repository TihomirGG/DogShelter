namespace DogShelter.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using DogShelter.Data.Common.Models;

    public class Tracked : BaseModel<int>
    {
        public int PostId { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
