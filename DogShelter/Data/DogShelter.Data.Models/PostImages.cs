namespace DogShelter.Data.Models
{
    using System.Collections.Generic;

    using DogShelter.Data.Common.Models;

    public class PostImages : BaseModel<int>
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
