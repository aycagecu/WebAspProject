using Microsoft.AspNetCore.Mvc;

namespace AuthorizationProject.Controllers
{
    public class BasvuruController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Basvur()
        {
            return View();
        }
    }
}
