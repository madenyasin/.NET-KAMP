using ManyToMany.Data;
using ManyToMany.Models;
using ManyToMany.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManyToMany.Controllers
{
    public class KitapController : Controller
    {
        private readonly KutuphaneDbContext _dbContext;

        public KitapController(KutuphaneDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            var kitaplar = _dbContext.Kitaplar
                .Select(k => new KitapListele_VM
                {
                    Id = k.Id,
                    Ad = k.Ad,
                    Ozet = k.Ozet,
                    ISBN = k.ISBN,
                    YazarAdlari = k.KitapYazar.Select(ky => ky.Yazar.Ad).ToList()
                }).ToList();
            return View(kitaplar);
        }

        public IActionResult Create()
        {
            KitapEkleForm_VM vm = new KitapEkleForm_VM
            {
                Kitap = new KitapEkle_VM()
                {
                    DenemeYazarlar = _dbContext.Yazarlar.Select(y => new SelectListItem
                    {
                        Value = y.Id.ToString(),
                        Text = y.Ad
                    }).ToList()
                },
                Yazarlar = new SelectList(_dbContext.Yazarlar, "Id", "Ad"),
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(KitapEkle_VM kitap)
        {
            if (ModelState.IsValid)
            {
                Kitap yeniKitap = new Kitap
                {
                    Ad = kitap.Ad,
                    Ozet = kitap.Ozet,
                    ISBN = kitap.ISBN,
                    KitapYazar = kitap.SecilenYazarIdleri
                        .Select(yazarId => new KitapYazar
                        {
                            YazarId = yazarId
                        }).ToList()
                };

                _dbContext.Kitaplar.Add(yeniKitap);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            KitapEkleForm_VM vm = new KitapEkleForm_VM
            {
                Kitap = new KitapEkle_VM(),
                Yazarlar = new SelectList(_dbContext.Yazarlar, "Id", "Ad"),
            };
            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            KitapGuncelleForm_VM vm = new KitapGuncelleForm_VM
            {
                Kitap = _dbContext.Kitaplar
                .Where(k => k.Id == id)
                .Select(k => new KitapGuncelle_VM
                {
                    Ad = k.Ad,
                    Ozet = k.Ozet,
                    SecilenYazarIdleri = k.KitapYazar.Select(ky => ky.YazarId).ToList()
                }).FirstOrDefault(),
                Yazarlar = new SelectList(_dbContext.Yazarlar, "Id", "Ad"),
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, KitapGuncelle_VM kitap)
        {
            if (ModelState.IsValid)
            {
                Kitap guncellenecekKitap = _dbContext.Kitaplar.Find(id);
                if (guncellenecekKitap != null)
                {
                    guncellenecekKitap.Ad = kitap.Ad;
                    guncellenecekKitap.Ozet = kitap.Ozet;

                    var mevcutKitapYazarlar = _dbContext.KitapYazar.Where(ky => ky.KitapId == id);
                    _dbContext.KitapYazar.RemoveRange(mevcutKitapYazarlar);

                    guncellenecekKitap.KitapYazar = kitap.SecilenYazarIdleri
                        .Select(yazarId => new KitapYazar
                        {
                            YazarId = yazarId
                        }).ToList();


                    _dbContext.Kitaplar.Update(guncellenecekKitap);
                    _dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            KitapGuncelleForm_VM vm = new KitapGuncelleForm_VM
            {
                Kitap = _dbContext.Kitaplar
           .Where(k => k.Id == id)
           .Select(k => new KitapGuncelle_VM
           {
               Ad = k.Ad,
               Ozet = k.Ozet,
               SecilenYazarIdleri = k.KitapYazar.Select(ky => ky.YazarId).ToList()
           }).FirstOrDefault(),
                Yazarlar = new SelectList(_dbContext.Yazarlar, "Id", "Ad"),
            };

            return View(vm);

        }
    }
}