namespace DogShelter.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class PostWithPageCountViewModel
    {
        public int CurrentPage { get; set; }

        public string Search { get; set; }

        public string Area { get; set; }

        public List<SelectListItem> Areas { get; set; }

        public string UserOrPost { get; set; }

        public List<SelectListItem> UsersOrPosts { get; set; }

        public int PagesCount { get; set; }

        public IEnumerable<PostsViewModel> Posts { get; set; }

    }
}
