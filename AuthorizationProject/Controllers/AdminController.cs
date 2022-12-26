using AuthorizationProject.Data;
using AuthorizationProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationProject.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext dbContext;

        public AdminController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BasvurulariGetir()
        {
            //tüm kullanıcının başvurularını gönderir.
            ViewBag.basvuru = from h in dbContext.Hayvanlar
                              join b in dbContext.Basvurular
                              on h.HayvanId equals b.HayvanID
                              join u in dbContext.Users
                              on b.UserName equals u.UserName
                              where b.BasvuruDurumu == "Onay Bekliyor"
                              select new
                              {
                                  h,
                                  u,
                                  b
                              };
            return View();
        }

        public IActionResult Onayla(int id)
        {
            var basvuru = dbContext.Basvurular.Where(b => b.BasvuruId == id).First();
            basvuru.BasvuruDurumu = "Onaylandi";
            dbContext.SaveChanges();
            return RedirectToAction("BasvurulariGetir");
        }

        public IActionResult Reddet(int id)
        {
            var basvuru = dbContext.Basvurular.Where(b => b.BasvuruId == id).First();
            basvuru.BasvuruDurumu = "reddedildi";
            dbContext.SaveChanges();
            return RedirectToAction("BasvurulariGetir");
        }

    }
}
