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
            ViewBag.basvuru = from h in dbContext.Hayvanlar
                              join b in dbContext.Basvurular
                              on h.HayvanId equals b.HayvanID
                              join u in dbContext.Users
                              on b.UserName equals u.UserName
                              where b.UserName == User.Identity.Name
                              select new
                              {
                                  h,
                                  u,
                                  b
                              };
            return View();
        }

       
    }
}
