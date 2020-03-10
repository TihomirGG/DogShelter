namespace DogShelter.Web.Controllers
{
    using System.Diagnostics;
    using DogShelter.Data.Models;
    using DogShelter.Web.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public HomeController(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (this.signInManager.IsSignedIn(this.User))
            {
                return this.Redirect("/All");
            }
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
