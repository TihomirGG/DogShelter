namespace DogShelter.Data.Models
{
    using DogShelter.Data.Common.Models;

    public class PostImage : BaseModel<int>
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
