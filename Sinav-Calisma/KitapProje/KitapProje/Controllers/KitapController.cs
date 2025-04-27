using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using KitapProje.Models;
using KitapProje.Models.ViewModels.KitapViewModels;
using KitapProje.Repositories.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KitapProje.Controllers
{
    [Authorize]
    public class KitapController : Controller
    {
        private readonly KitapRepository _kitapRepository;
        private readonly KategoriRepository _kategoriRepository;
        private readonly UserRepository _userRepository;

        public KitapController(KitapRepository kitapRepository, KategoriRepository kategoriRepository, UserRepository userRepository)
        {
            _kitapRepository = kitapRepository;
            _kategoriRepository = kategoriRepository;
            _userRepository = userRepository;
        }


        // giriş yapmış kullanıcının eklediği kitaplar
        public IActionResult Index()
        {
            var user = _userRepository.AktifKullaniciGetir();
            var AktifKullaniciId = user.Id;

            var kitaplar = _kitapRepository
                .ListeleQueryable()
                .Include(k => k.User)
                .Include(k => k.Kategoriler)
                .Select(k => new KitapListeleVM
                {
                    Id = k.Id,
                    Ad = k.Ad,
                    Fiyat = k.Fiyat,
                    SayfaSayisi = k.SayfaSayisi,
                    Ozet = k.Ozet,
                    UserName = k.User.UserName,
                    UserId = k.User.Id,
                    Kategoriler = k.Kategoriler.Select(kat => kat.Kategori.Ad).ToList()
                }).Where(k => k.UserId == AktifKullaniciId).ToList();
            return View(kitaplar);
        }

        public IActionResult Create()
        {
            KitapEkleFormVM vm = new()
            {
                Kategoriler = new SelectList(_kategoriRepository.Listele(), "Id", "Ad"),
                Kitap = new KitapEkleVM()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(KitapEkleVM kitap)
        {
            if (ModelState.IsValid)
            {
                // *** ÇALIŞAN YÖNTEM 1 ***

                Kitap yeniKitap = new()
                {
                    Ad = kitap.Ad,
                    Fiyat = kitap.Fiyat,
                    Ozet = kitap.Ozet,
                    SayfaSayisi = kitap.SayfaSayisi,
                    User = _userRepository.AktifKullaniciGetir()
                };

                foreach (var kategoriId in kitap.KategoriIdleri)
                {
                    yeniKitap.Kategoriler.Add(new KitapKategori { KategoriId = kategoriId });
                }
                _kitapRepository.Ekle(yeniKitap);

                // *** ÇALIŞAN YÖNTEM 2 ***

                //Kitap yeniKitap = new Kitap()
                //{
                //    Ad = kitap.Ad,
                //    Fiyat = kitap.Fiyat,
                //    Ozet = kitap.Ozet,
                //    SayfaSayisi = kitap.SayfaSayisi,
                //    User = _userRepository.AktifKullaniciGetir(),
                //    Kategoriler = kitap.KategoriIdleri.Select(x => new KitapKategori { KategoriId = x }).ToList(),
                //};


                //_kitapRepository.Ekle(yeniKitap);
                return RedirectToAction("Index");
            }
            KitapEkleFormVM vm = new()
            {
                Kategoriler = new SelectList(_kategoriRepository.Listele(), "Id", "Ad"),
                Kitap = new KitapEkleVM()
            };
            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            // kullanıcının kitapları

            var user = _userRepository.AktifKullaniciGetir();
            var aktifKullanicininKitaplari = _kitapRepository
                .ListeleQueryable()
                .Where(x => x.UserId == user.Id)
                .Select(x => x.Id).ToList();

            // kullanıcının kitapları değilse
            if (aktifKullanicininKitaplari == null || aktifKullanicininKitaplari.Count == 0)
            {
                // kullanıcı yetkisi yok
                return Forbid();
            }
            else if (!aktifKullanicininKitaplari.Contains(id))
            {
                return Forbid();

            }
            //var guncellenecekKitap = _kitapRepository.Bul(id); // ilişkili veri gelmiyor

            var guncellenecekKitap = _kitapRepository
                .ListeleQueryable()
                .Include(k => k.Kategoriler)
                .FirstOrDefault(k => k.Id == id);


            KitapGuncelleFormVM vm = new()
            {
                Kategoriler = new SelectList(_kategoriRepository.Listele(), "Id", "Ad"),
                Kitap = new KitapGuncelleVM
                {
                    Id = guncellenecekKitap.Id,
                    Ad = guncellenecekKitap.Ad,
                    Fiyat = guncellenecekKitap.Fiyat,
                    Ozet = guncellenecekKitap.Ozet,
                    SayfaSayisi = guncellenecekKitap.SayfaSayisi,
                    KategoriIdleri = guncellenecekKitap.Kategoriler.Select(kat => kat.KategoriId).ToList()
                }
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(KitapGuncelleVM kitap)
        {
            var user = _userRepository.AktifKullaniciGetir();
            var aktifKullanicininKitaplari = _kitapRepository
                .ListeleQueryable()
                .Where(x => x.UserId == user.Id)
                .Select(x => x.Id).ToList();

            // kullanıcının kitapları değilse
            if (aktifKullanicininKitaplari == null || aktifKullanicininKitaplari.Count == 0)
            {
                // kullanıcı yetkisi yok
                return Forbid();
            }
            else if (!aktifKullanicininKitaplari.Contains(kitap.Id))
            {
                return Forbid();

            }


            if (ModelState.IsValid)
            {
                var guncellenecekKitap = _kitapRepository
                    .ListeleQueryable()
                    .Include(k => k.Kategoriler)
                    .FirstOrDefault(k => k.Id == kitap.Id);

                guncellenecekKitap.Ad = kitap.Ad;
                guncellenecekKitap.SayfaSayisi = kitap.SayfaSayisi;
                guncellenecekKitap.Fiyat = kitap.Fiyat;
                guncellenecekKitap.Ozet = kitap.Ozet;



                guncellenecekKitap.Kategoriler.Clear();

                foreach (var kategoriId in kitap.KategoriIdleri)
                {
                    guncellenecekKitap.Kategoriler.Add(new KitapKategori { KategoriId = kategoriId });
                }
                _kitapRepository.Guncelle(guncellenecekKitap);
                return RedirectToAction("Index");
            }
            KitapGuncelleFormVM vm = new()
            {
                Kategoriler = new SelectList(_kategoriRepository.Listele(), "Id", "Ad"),
                Kitap = kitap
            };
            return View(vm);
        }

        public IActionResult Details(int id)
        {
            

            var kitapDetayVM= _kitapRepository
              .ListeleQueryable()
              .Include(k => k.User)
              .Include(k => k.Kategoriler)
              .Select(k => new KitapDetayVM
              {
                  Id = k.Id,
                  Ad = k.Ad,
                  Fiyat = k.Fiyat,
                  Ozet = k.Ozet,
                  SayfaSayisi = k.SayfaSayisi,
                  Kategoriler = k.Kategoriler.Select(kat => kat.Kategori.Ad).ToList(),
                  UserName = k.User.UserName
              })
              .FirstOrDefault(k => k.Id == id);
            return View(kitapDetayVM);
        }
        //public IActionResult Details(int id)
        //{
        //    var detay = _kitapRepository.KitapDetayGetir(_kitapRepository.Bul(id));
        //    return View(detay);
        //}
    }
}
