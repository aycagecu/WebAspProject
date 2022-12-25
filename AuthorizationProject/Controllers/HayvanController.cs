using AuthorizationProject.Data;
using AuthorizationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AuthorizationProject.Controllers
{
    public class HayvanController : Controller
    {
        ApplicationDbContext dbContext;
        public HayvanController(ApplicationDbContext cont)
        {
            dbContext = cont;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HayvanlariGetir()
        {
            ViewData["HayvanKategori"] = new SelectList(dbContext.Hayvanlar, "HayvanKategori", "HayvanKategori");
            ViewData["HayvanCins"] = new SelectList(dbContext.Hayvanlar, "HayvanCins", "HayvanCins");
            var hayvanlar = dbContext.Hayvanlar.ToList();
            return View(hayvanlar);
        }
        public IActionResult HayvanEkle()
        {
            return View();    //hayvan ekleme formuna götüren view
        }

        [HttpPost]
        public IActionResult HayvanEklePost(Hayvan h, IFormFile file)
        {
            string path;
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                file.CopyToAsync(stream);
                h.HayvanResim = path;
            }

            dbContext.Add(h);
            dbContext.SaveChanges();
            return RedirectToAction("HayvanlariGetir");
        }

        //hayvanı db e kaydeder ve hayvan goruntule sayfasina dondurur
    }



}

