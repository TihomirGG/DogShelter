namespace DogShelter.Web.Controllers
{
    using System.Threading.Tasks;

    using DogShelter.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public PostsController(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            return this.View("Posts");
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }
    }
}
