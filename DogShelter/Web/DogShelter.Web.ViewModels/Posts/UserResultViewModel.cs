namespace DogShelter.Web.ViewModels.Posts
{
    using System;

    using AutoMapper;
    using DogShelter.Data.Models;
    using DogShelter.Services.Mapping;

    public class UserResultViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public int PostsCount { get; set; }

        public DateTime CreatedOn { get; set; }

        //public string Link { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            //configuration.CreateMap<ApplicationUser, UserResultViewModel>()
            //    .ForMember(x => x.Link, options => options.MapFrom(y => GlobalConstants.DefaultCloudinaryLink + y.PostImages.Select(z => z.Image.Url).First()));
            configuration.CreateMap<ApplicationUser, UserResultViewModel>()
                .ForMember(x => x.PostsCount, options => options.MapFrom(y => y.Posts.Count));

        }
    }
}
