namespace DogShelter.Web.Controllers
{
    using System;
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
    using Microsoft.EntityFrameworkCore;

    public class PostsController : BaseController
    {
        private const int pageSize = 5;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IImageService imageService;
        private readonly IPostService postService;

        public PostsController(
            UserManager<ApplicationUser> userManager,
            ICloudinaryService cloudinaryService,
            IImageService imageService,
            IPostService postService)
        {
            this.userManager = userManager;
            this.cloudinaryService = cloudinaryService;
            this.imageService = imageService;
            this.postService = postService;
        }

        [Authorize]
        public async Task<IActionResult> All(int page = 1)
        {

            var count = (int)Math.Ceiling((double)this.postService.PostsCount() / pageSize);
            var posts = await this.postService.GetAll<PostsViewModel>(pageSize, (page - 1) * pageSize);
            var viewModel = new PostWithPageCountViewModel()
            {
                Posts = posts,
                PagesCount = count,
                CurrentPage = page,
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
    }
}
