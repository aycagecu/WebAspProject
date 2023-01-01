using AuthorizationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AuthorizationProject.Controllers
{
    public class CallHayvanApiController : Controller
    {
        static List<Hayvan> Hayvanlar = new List<Hayvan>();

        public async Task<IActionResult> Index()
        {
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7147/api/HayvanApi");
            string resString = await response.Content.ReadAsStringAsync();
            Hayvanlar = JsonConvert.DeserializeObject<List<Hayvan>>(resString);

            ViewData["HayvanKategori"] = new SelectList(Hayvanlar, "HayvanKategori", "HayvanKategori");
            ViewData["HayvanIrk"] = new SelectList(Hayvanlar, "HayvanIrk", "HayvanIrk");
            ViewBag.hayvanlar = Hayvanlar;
            return View();
        }


        [HttpPost]
        public IActionResult HayvanlariGetirPost([Bind("HayvanKategori", "HayvanIrk")] Hayvan h)
        {
            List<Hayvan> selHayvanlar;
            if (h.HayvanKategori == null)
            {
                if (h.HayvanIrk == null)
                {
                    selHayvanlar = Hayvanlar.ToList();
                }
                else selHayvanlar = Hayvanlar.Where(hy => hy.HayvanIrk == h.HayvanIrk).ToList();
            }
            else
            {
                if (h.HayvanIrk == null)
                {
                    selHayvanlar = Hayvanlar.Where(hy => hy.HayvanKategori == h.HayvanKategori).ToList();
                }
                else selHayvanlar = Hayvanlar.Where(hy => hy.HayvanKategori == h.HayvanKategori && hy.HayvanIrk == h.HayvanIrk).ToList();

            }
            return View(selHayvanlar);
        }



    }
}
