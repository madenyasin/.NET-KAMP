using Kitap.Data;
using Kitap.Models;
using Kitap.Models.VM;
using Kitap.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

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
                Ozet = x.Ozet,
                Fiyat = x.Fiyat,
                KapakResmi = x.KapakResmi,
                SayfaSayisi = x.SayfaSayisi,
                YazarId = x.YazarId,
                KategoriId = x.KategoriId,
                YayinEviId = x.YayinEviId,
                KategoriAdi = x.Kategori.Ad,
                YayinEviAdi = x.YayinEvi.Ad,
                YazarAdi = x.Yazar.TamIsim,
            }).ToList();
            return View(kitaplar);
        }
        public IActionResult Create()
        {
            KitapEkleForm_VM KitapForm = new()
            {
                Kategoriler = new SelectList(_dbContext.Kategoriler, "Id", "Ad"),
                Yazarlar = new SelectList(_dbContext.Yazarlar, "Id", "TamIsim"),
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

            var vm = new KitapEkleForm_VM
            {
                Kategoriler = new SelectList(_dbContext.Kategoriler, "Id", "Ad"),
                Yazarlar = new SelectList(_dbContext.Yazarlar, "Id", "TamIsim"),
                YayinEvis = new SelectList(_dbContext.YayinEvis, "Id", "Ad"),
                Kitap = new Kitap_VM()
            };
            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            var guncellenecekKitap = _dbContext.Kitaplar.Find(id);

            KitapGuncelleForm_VM guncelleForm = new()
            {
                Kategoriler = new SelectList(_dbContext.Kategoriler, "Id", "Ad"),
                Yazarlar = new SelectList(_dbContext.Yazarlar, "Id", "TamIsim"),
                YayinEvis = new SelectList(_dbContext.YayinEvis, "Id", "Ad"),
                Kitap = new KitapGuncelle_VM
                {
                    Id = guncellenecekKitap.Id,
                    Ad = guncellenecekKitap.Ad,
                    Fiyat = guncellenecekKitap.Fiyat,
                    KapakResmi = guncellenecekKitap.KapakResmi,
                    Ozet = guncellenecekKitap.Ozet,
                    SayfaSayisi = guncellenecekKitap.SayfaSayisi,
                    YazarId = guncellenecekKitap.YazarId,
                    KategoriId = guncellenecekKitap.KategoriId,
                    YayinEviId = guncellenecekKitap.YayinEviId,
                }
            };
            return View(guncelleForm);
        }

        [HttpPost]
        public IActionResult Edit(int id, KitapGuncelle_VM kitap)
        {
            var eskiKitap = _dbContext.Kitaplar
                    .Include(k => k.Yazar)
                    .Include(k => k.Kategori)
                    .Include(k => k.YayinEvi)
                    .FirstOrDefault(k => k.Id == id);

            if (ModelState.IsValid)
            {
                eskiKitap.Ad = kitap.Ad;
                eskiKitap.Fiyat = kitap.Fiyat;
                eskiKitap.Ozet = kitap.Ozet;
                eskiKitap.SayfaSayisi = kitap.SayfaSayisi;
                eskiKitap.YazarId = kitap.YazarId;
                eskiKitap.KategoriId = kitap.KategoriId;
                eskiKitap.YayinEviId = kitap.YayinEviId;

                if (kitap.KapakResmiDosyasi != null)
                {
                    eskiKitap.KapakResmi = FileOperations.ResimYukle(kitap.KapakResmiDosyasi);
                }

                _dbContext.Update(eskiKitap);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            KitapGuncelleForm_VM vm = new()
            {
                Kategoriler = new SelectList(_dbContext.Kategoriler, "Id", "Ad", kitap.KategoriId),
                Yazarlar = new SelectList(_dbContext.Yazarlar, "Id", "TamIsim", kitap.YazarId),
                YayinEvis = new SelectList(_dbContext.YayinEvis, "Id", "Ad", kitap.YayinEviId),
                Kitap = new KitapGuncelle_VM
                {
                    Id = kitap.Id,
                    Ad = kitap.Ad,
                    Fiyat = kitap.Fiyat,
                    KapakResmi = eskiKitap.KapakResmi,
                    Ozet = kitap.Ozet,
                    SayfaSayisi = kitap.SayfaSayisi,
                    YazarId = kitap.YazarId,
                    KategoriId = kitap.KategoriId,
                    YayinEviId = kitap.YayinEviId,
                }
            };
            return View(vm);
        }

        public IActionResult Details(int id)
        {
             var kitap = _dbContext.Kitaplar.Select(x => new KitapDetay_VM
            {
                Id = x.Id,
                Ad = x.Ad,
                Ozet = x.Ozet,
                Fiyat = x.Fiyat,
                KapakResmi = x.KapakResmi,
                SayfaSayisi = x.SayfaSayisi,
                YazarId = x.YazarId,
                KategoriId = x.KategoriId,
                YayinEviId = x.YayinEviId,
                KategoriAdi = x.Kategori.Ad,
                YayinEviAdi = x.YayinEvi.Ad,
                YazarAdi = x.Yazar.TamIsim,
            });

            return View(kitap);
        }
    }

}
