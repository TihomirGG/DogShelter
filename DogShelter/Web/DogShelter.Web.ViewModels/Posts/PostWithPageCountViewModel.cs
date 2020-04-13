namespace DogShelter.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    public class PostWithPageCountViewModel
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public IEnumerable<PostsViewModel> Posts { get; set; }

    }
}
