namespace DogShelter.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using cloudscribe.Pagination.Models;
    using DogShelter.Data.Models;
    using DogShelter.Services.Data.Contracts;
    using DogShelter.Web.ViewModels.CreateView;
    using DogShelter.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class PostsController : BaseController
    {
        private const int pageSize = 5;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IImageService imageService;
        private readonly IPostService postService;
        private readonly IAreaService areaService;

        public PostsController(
            UserManager<ApplicationUser> userManager,
            ICloudinaryService cloudinaryService,
            IImageService imageService,
            IPostService postService,
            IAreaService areaService)
        {
            this.userManager = userManager;
            this.cloudinaryService = cloudinaryService;
            this.imageService = imageService;
            this.postService = postService;
            this.areaService = areaService;
        }

        [Authorize]
        public async Task<IActionResult> All(int page = 1)
        {
            var area = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                Text = "All",
                Selected = true,
                },
            };
            var temp = this.areaService.GetAreasName();
            area.AddRange(temp.Select(x => new SelectListItem
            {
                Text = x,
            }));

            var userOrPost = new List<SelectListItem>()
            {
               new SelectListItem()
               {
                  Text = "Post",
                  Selected = true,
               },
               new SelectListItem()
               {
               Text = "User",
               },
            };
            var count = (int)Math.Ceiling((double)this.postService.PostsCount() / pageSize);
            var posts = await this.postService.GetAll<PostsViewModel>(pageSize, (page - 1) * pageSize);
            var viewModel = new PostWithPageCountViewModel()
            {
                Posts = posts,
                PagesCount = count,
                CurrentPage = page,
                Areas = area,
                UsersOrPosts = userOrPost,
            };
            return this.View("Posts", viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Posts/Create");
            }

            if (model.Images == null || model.Images.Count > 6)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var userId = user.Id;
            var postId = await this.postService.Create(model.Title, model.Description, model.Area, userId);
            await this.cloudinaryService.UploadAsync(model.Images, postId);
            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Detail(int id)
        {
            return this.View();
        }

        [Authorize]
        public async Task<IActionResult> Find(InputViewModel input)
        {
            if (input.UserOrPost == "Post")
            {
                var posts = await this.postService.FilteredPosts<PostsViewModel>(input.Search, input.Area);
                return this.View("PostResults", posts);
            }

            var users = await this.postService.FilteredUsers<UserResultViewModel>(input.Search);
            return this.View("UserResults", users);
        }

        [Authorize]
        public IActionResult Tracking()
        {
            return this.View();
        }
    }
}
