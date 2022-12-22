using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationProject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="User")]
        public IActionResult BasvurulariGetir()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult TumBasvurulariGetir()
        {
            return View();
        }
    }
}
