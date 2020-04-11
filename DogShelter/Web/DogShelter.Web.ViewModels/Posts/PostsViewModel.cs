namespace DogShelter.Web.ViewModels.Posts
{
    using System;
    using System.Linq;

    using AutoMapper;
    using DogShelter.Common;
    using DogShelter.Data.Models;
    using DogShelter.Services.Mapping;

    public class PostsViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ShortDescription => this.Description.Length > 40 ? this.Description.Substring(0, 40) + "..." : this.Description;

        public DateTime CreatedOn { get; set; }

        public string Link { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostsViewModel>()
                .ForMember(x => x.Link, options => options.MapFrom(y => GlobalConstants.DefaultCloudinaryLink + y.PostImages.Select(z => z.Image.Url).First()));
        }
    }
}
