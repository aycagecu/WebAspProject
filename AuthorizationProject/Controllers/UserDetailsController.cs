using AuthorizationProject.Data;
using AuthorizationProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationProject.Controllers
{
    [Authorize(Roles ="user")]
    public class UserDetailsController : Controller
    {
        ApplicationDbContext dbContext;
        public UserDetailsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BasvurularimiGetir()
        {
            //şu an aktif olan kullanıcının başvurularını gönderir
            List<Basvuru> basvurular = dbContext.Basvurular.Where(u=>u.UserName==User.Identity.Name).ToList();
            return View(basvurular);
        }

       
    }
}
