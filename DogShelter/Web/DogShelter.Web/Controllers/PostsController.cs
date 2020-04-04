namespace DogShelter.Web.Controllers
{
    using System.Threading.Tasks;

    using DogShelter.Data.Models;
    using DogShelter.Services.Data.Contracts;
    using DogShelter.Web.ViewModels.CreateView;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : BaseController
    {
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
        public async Task<IActionResult> All()
        {
            return this.View("Posts");
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
    }
}
