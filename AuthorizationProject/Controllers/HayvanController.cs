using AuthorizationProject.Data;
using AuthorizationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Collections.Specialized;
using System.Drawing;

namespace AuthorizationProject.Controllers
{
    public class HayvanController : Controller
    {
        ApplicationDbContext dbContext;
        private readonly IStringLocalizer<HomeController> _localizer;
        public HayvanController(ApplicationDbContext cont, IStringLocalizer<HomeController> localizer)
        {
            dbContext = cont;
            _localizer = localizer;
        }
        public IActionResult Index()
        {
            return View();
        }




        public IActionResult HayvanEkle()
        {
            return View();    //hayvan ekleme formuna götüren view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HayvanEkle([Bind("HayvanId,HayvanKategori,HayvanYas,HayvanIrk,HayvanCinsiyet,HayvanSehir,HayvanResim")] Hayvan h, IFormFile file)
        {
            string path;
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", file.FileName);

                using var stream = new FileStream(path, FileMode.Create);

                file.CopyToAsync(stream);
                h.HayvanResim = path;
            }
            if (ModelState.IsValid)
            {
                dbContext.Add(h);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "CallHayvanApi");
            }
            return View(h);
        }

        //hayvanı db e kaydeder ve hayvan goruntule sayfasina dondurur
    }



}

