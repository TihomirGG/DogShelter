namespace DogShelter.Web.ViewModels.CreateView
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateInputModel
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(400, MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        public string Area { get; set; }

        public ICollection<IFormFile> Images { get; set; }
    }
}
