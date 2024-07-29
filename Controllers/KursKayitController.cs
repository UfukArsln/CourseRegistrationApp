using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class KursKayitController : Controller
    {
        private readonly DataContext _contect;

        public KursKayitController(DataContext context)
        {
            _contect = context;
        }

        public async Task<IActionResult> Index()
        {
            var KursKayitlari = await _contect.KursKayitlari
                                                .Include(x => x.Ogrenci)
                                                .Include(y => y.Kurs)
                                                .ToListAsync();
            return View(KursKayitlari);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _contect.Ogrenciler.ToListAsync(), "OgrenciId", "AdSoyad");

            ViewBag.Kurslar = new SelectList(await _contect.Kurslar.ToListAsync(), "KursId", "Baslik");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KursKayit model)
        {
            model.KayitTarihi = DateTime.Now;
            _contect.KursKayitlari.Add(model);
            await _contect.SaveChangesAsync();

            return RedirectToAction("Index");
        }




    }
}