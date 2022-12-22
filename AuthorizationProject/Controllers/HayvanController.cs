using Microsoft.AspNetCore.Mvc;

namespace AuthorizationProject.Controllers
{
    public class HayvanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HayvanEkle()
        {
            return View();
        }


        public IActionResult HayvanlarıGöster()
        {
            return View();
        }
    }
}
