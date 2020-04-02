namespace DogShelter.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AboutController : BaseController
    {
        [HttpGet("/About")]
        public IActionResult About()
        {
            return this.View();
        }
    }
}
