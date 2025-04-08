using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Controllers
{
    public class UrunController : Controller
    {
        private readonly Market11Context _context;

        public UrunController(Market11Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<UrunVM> urunler = _context.Urunlers.Select(x => new UrunVM
            {
                UrunId = x.UrunId,
                UrunAdi = x.UrunAdi,
                Fiyat = x.Fiyat,
                KategoriAdi = x.Kategori.KategoriAdi,
                Resim = x.Resim
            }).ToList();
            return View(urunler);
        }
        public IActionResult UrunEkle()
        {
            UrunEklemeFormuVM urunFrm = new UrunEklemeFormuVM
            {
                Kategoriler = new SelectList(_context.Kategorilers, "KategoriId", "KategoriAdi"),
                Urun = new UrunEkleVM()
            };

            return View(urunFrm);
        }

        public IActionResult Details(int id)
        {
            var urunDetay = _context.Urunlers.Select(x => new UrunDetayVM
            {
                UrunId = x.UrunId,
                UrunAdi = x.UrunAdi,
                Aciklama = x.Aciklama,
                Fiyat = x.Fiyat,
                KategoriAdi = x.Kategori.KategoriAdi,
                Resim = x.Resim,
            }).FirstOrDefault(x => x.UrunId == id);

            return View(urunDetay);
        }

        [HttpPost]
        public IActionResult UrunEkle(UrunEkleVM urun)
        {
            if (ModelState.IsValid)
            {
                Urunler yeniUrun = new Urunler()
                {
                    UrunAdi = urun.UrunAdi,
                    Aciklama = urun.Aciklama,
                    Fiyat = urun.Fiyat,
                    KategoriId = urun.KategoriId,
                    Resim = FileOperations.ResimYukle(urun.ResimDosyasi)
                };
                _context.Urunlers.Add(yeniUrun);
                _context.SaveChanges();
                return RedirectToAction("Index");


            }
            return View();
        }


    }


}
