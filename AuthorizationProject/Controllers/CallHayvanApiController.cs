using AuthorizationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AuthorizationProject.Controllers
{
    public class CallHayvanApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Hayvan> Hayvanlar = new List<Hayvan>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7147/api/HayvanApi");
            string resString = await response.Content.ReadAsStringAsync();
            Hayvanlar = JsonConvert.DeserializeObject<List<Hayvan>>(resString);

            ViewData["HayvanKategori"] = new SelectList(Hayvanlar, "HayvanKategori", "HayvanKategori");
            ViewData["HayvanIrk"] = new SelectList(Hayvanlar, "HayvanIrk", "HayvanIrk");
            ViewBag.hayvanlar = Hayvanlar;
            return View();
        }



    }
}
