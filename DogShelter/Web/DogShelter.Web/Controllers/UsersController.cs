namespace DogShelter.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : BaseController
    {
        public IActionResult Detail(string id)
        {
            return this.View();
        }
    }
}
