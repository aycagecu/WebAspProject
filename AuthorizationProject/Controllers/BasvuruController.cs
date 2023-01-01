using AuthorizationProject.Data;
using AuthorizationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using System.Security.Principal;

namespace AuthorizationProject.Controllers
{
    public class BasvuruController : Controller
    {
        ApplicationDbContext dbContext;
        public BasvuruController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Basvur(int id)
        {
            //if (!User.Identity.IsAuthenticated) return  Redirect("/Areas/Identity/Pages/Account/Login.cshtml");
            TempData["id"] = id;
            return View();
        }

        public IActionResult İslemAlindi(string str1, string kontrol1, string kontrol2, string kontrol3, string kontrol4)
        {

            Basvuru b = new Basvuru();
            b.BasvuruFormu = "Adresiniz : "+str1 + "\n" +
                "Başka evcil hayvanınız var mı? "+ kontrol1 + "\n" +
                "Hastalık veya kaza durumunda sağlık hizmetlerine götürmeyi kabul ediyor musunuz? " + kontrol2 + "\n" +
                "Dönemsel kontrol ziyaretlerine izin veriyor musunuz? " + kontrol3 + "\n"+
                "Sahiplenmek istediğiniz hayvanın ileride kısırlaştırılmasını kabul ediyor musunuz? " + kontrol4;
            b.BasvuruTarihi = DateTime.Now;
            b.BasvurulanHayvan = dbContext.Hayvanlar.Where(h => h.HayvanId == Convert.ToInt32(TempData["id"])).First();
            b.BasvuruDurumu = "Onay Bekliyor";
            b.BasvuranUser = dbContext.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            b.HayvanID = dbContext.Hayvanlar.Where(h => h.HayvanId == Convert.ToInt32(TempData["id"])).Select(h => h.HayvanId).FirstOrDefault();
            b.UserName = (from u in dbContext.Users
                          where u.UserName == User.Identity.Name
                          select u.UserName).FirstOrDefault();
            dbContext.Add(b);
            dbContext.SaveChanges();
            return View(b);
        }

    }
}
