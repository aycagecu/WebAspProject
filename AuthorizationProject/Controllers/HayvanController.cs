﻿using AuthorizationProject.Data;
using AuthorizationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
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
            ViewData["HayvanIrk"] = new SelectList(dbContext.Hayvanlar, "HayvanIrk", "HayvanIrk");
            ViewBag.hayvanlar = dbContext.Hayvanlar.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult HayvanlariGetirPost([Bind("HayvanKategori","HayvanIrk")] Hayvan h)
        {
            List<Hayvan> selHayvanlar;
            if (h.HayvanKategori ==null)
            {
                if (h.HayvanIrk == null)
                {
                     selHayvanlar = dbContext.Hayvanlar.ToList();
                }
                else  selHayvanlar = dbContext.Hayvanlar.Where(hy => hy.HayvanIrk == h.HayvanIrk).ToList();
            }
            else 
            {
                if (h.HayvanIrk == null)
                {
                    selHayvanlar = dbContext.Hayvanlar.Where(hy => hy.HayvanKategori == h.HayvanKategori).ToList();
                }
                else selHayvanlar = dbContext.Hayvanlar.Where(hy => hy.HayvanKategori == h.HayvanKategori && hy.HayvanIrk == h.HayvanIrk).ToList();

            }
            return View(selHayvanlar);
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

