using Kitap.Data;
using Kitap.Models;
using Kitap.Models.VM;
using Kitap.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Kitap.Controllers
{
    public class KitapController : Controller
    {
        private readonly KutuphaneContext _dbContext;

        public KitapController(KutuphaneContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Kitap_VM> kitaplar = _dbContext.Kitaplar.Select(x => new Kitap_VM
            {
                Id = x.Id,
                Ad = x.Ad,
                Fiyat = x.Fiyat,
                KapakResmi = x.KapakResmi,
                KategoriAdi = x.Kategori.Ad,
                Ozet = x.Ozet,
                SayfaSayisi = x.SayfaSayisi,
                YayinEviAdi = x.YayinEvi.Ad,
                YazarAdi = x.Yazar.Ad
            }).ToList();
            return View(kitaplar);
        }
        public IActionResult Create()
        {
            KitapEkleForm_VM KitapForm = new()
            {
                Kategoriler = new SelectList(_dbContext.Kategoriler, "Id", "Ad"),
                Yazarlar = new SelectList(_dbContext.Yazarlar, "Id", "Ad"),
                YayinEvis = new SelectList(_dbContext.YayinEvis, "Id", "Ad"),
                Kitap = new Kitap_VM()
            };
            return View(KitapForm);
        }
        [HttpPost]
        public IActionResult Create(KitapEkle_VM kitap)
        {
            if (ModelState.IsValid)
            {
                Kitapp yeniKitap = new Kitapp
                {
                    Ad = kitap.Ad,
                    Fiyat = kitap.Fiyat,
                    KapakResmi = FileOperations.ResimYukle(kitap.KapakResmiDosyasi),
                    Ozet = kitap.Ozet,
                    SayfaSayisi = kitap.SayfaSayisi,
                    YayinEviId = kitap.YayinEviId,
                    YazarId = kitap.YazarId,
                    KategoriId = kitap.KategoriId
                };
                _dbContext.Kitaplar.Add(yeniKitap);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }
    }
}
