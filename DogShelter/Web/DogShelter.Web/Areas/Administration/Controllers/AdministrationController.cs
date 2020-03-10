namespace DogShelter.Web.Areas.Administration.Controllers
{
    using DogShelter.Common;
    using DogShelter.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
