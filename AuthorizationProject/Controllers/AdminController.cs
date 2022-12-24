using AuthorizationProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationProject.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BasvurularimGetir()
        {
            //şu an aktif olan kullanıcının başvurularını gönderir
            List<Basvuru> basvurular = dbContext.BasvurularToList();
            return View(basvurular);
        }
    }
}
