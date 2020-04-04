namespace DogShelter.Data.Models
{
    using System.Collections.Generic;

    using DogShelter.Data.Common.Models;

    public class Image : BaseModel<int>
    {
        public string Url { get; set; }

        public virtual ICollection<PostImages> PostImages { get; set; } = new HashSet<PostImages>();
    }
}
