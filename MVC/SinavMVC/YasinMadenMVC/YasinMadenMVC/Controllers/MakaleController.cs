using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YasinMadenMVC.Models;
using YasinMadenMVC.Models.ViewModels.MakaleViewModels;
using YasinMadenMVC.Repositories;

namespace YasinMadenMVC.Controllers
{
    [Authorize]
    public class MakaleController : Controller
    {
        private readonly MakaleRepository _makaleRepository;
        private readonly KategoriRepository _kategoriRepository;
        private readonly UserRepository _userRepository;

        public MakaleController(MakaleRepository makaleRepository, KategoriRepository kategoriRepository, UserRepository userRepository)
        {
            _makaleRepository = makaleRepository;
            _kategoriRepository = kategoriRepository;
            _userRepository = userRepository;
        }

        // Yalnızca giriş yapmış kullanıcının makalelerini listele
        public IActionResult Index()
        {
            var user = _userRepository.AktifKullaniciGetir();
            var AktifKullaniciId = user.Id;

            // Kullanıcının makaleleri
            var makaleler = _makaleRepository
                .ListeleQueryable()
                .Include(m => m.User)
                .Include(m => m.Kategoriler)
                .Select(m => new MakaleListele_VM
                {
                    Id = m.Id,
                    Baslik = m.Baslik,
                    Icerik = m.Icerik,
                    YayinlanmaTarihi = m.YayinlanmaTarihi,
                    UserId = m.User.Id,
                    UserName = m.User.UserName,
                    Kategoriler = m.Kategoriler.Select(k => k.Kategori.Ad).ToList(),
                    
                }).Where(m => m.UserId == AktifKullaniciId).ToList();
            return View(makaleler);
        }

        // Makale detayını gösterir
        public IActionResult Details(int id)
        {
            // Kullanıcının makalesi değilse erişim engelle
            if (!KullanicininMakalesiMi(id))
            {
                return Forbid();
            }

            var makale = _makaleRepository.Bul(id);
            var makaleDetay = _makaleRepository.MakaleDetayGetir(makale);
            return View(makaleDetay);
        }

        // Makale oluşturma formunu gösterir
        public IActionResult Create()
        {
            MakaleEkleForm_VM vm = new()
            {
                Makale = new MakaleEkle_VM(),
                Kategoriler = _kategoriRepository.Listele().ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(MakaleEkle_VM makale)
        {
            if (ModelState.IsValid)
            {
                Makale yeniMakale = new()
                {
                    Baslik = makale.Baslik,
                    Icerik = makale.Icerik,
                    YayinlanmaTarihi = DateTime.Now,
                    User = _userRepository.AktifKullaniciGetir(),
                };

                // Kategorileri ekle
                foreach (var kategoriId in makale.SecilenKategoriIdleri)
                {
                    yeniMakale.Kategoriler.Add(new KategoriMakale { KategoriId = kategoriId });
                }
                _makaleRepository.Ekle(yeniMakale);

                return RedirectToAction("Index");
            }
            MakaleEkleForm_VM vm = new()
            {
                Makale = makale,
                Kategoriler = _kategoriRepository.Listele().ToList()
            };
            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            // Kullanıcının makalesi değilse erişim engelle
            if (!KullanicininMakalesiMi(id))
            {
                return Forbid();
            }

            
            var guncellenecekMakale = _makaleRepository
                .ListeleQueryable()
                .Include(m=>m.Kategoriler)
                .FirstOrDefault(m => m.Id == id);

            MakaleGuncelleForm_VM vm = new()
            {
                Kategoriler = _kategoriRepository.Listele().ToList(),
                Makale = new MakaleGuncelle_VM
                {
                    Id = guncellenecekMakale.Id,
                    Baslik = guncellenecekMakale.Baslik,
                    Icerik = guncellenecekMakale.Icerik,
                    SecilenKategoriIdleri = guncellenecekMakale.Kategoriler.Select(k => k.KategoriId).ToList()
                }
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(MakaleGuncelle_VM makale)
        {
            // Kullanıcının makalesi değilse erişim engelle
            if (!KullanicininMakalesiMi(makale.Id))
            {
                return Forbid();
            }
            if (ModelState.IsValid)
            {
                var guncellenecekMakale = _makaleRepository
                .ListeleQueryable()
                .Include(m => m.Kategoriler)
                .FirstOrDefault(m => m.Id == makale.Id);

                guncellenecekMakale.Baslik = makale.Baslik;
                guncellenecekMakale.Icerik = makale.Icerik;

                guncellenecekMakale.Kategoriler.Clear();
                foreach (var kategoriId in makale.SecilenKategoriIdleri)
                {
                    guncellenecekMakale.Kategoriler.Add(new KategoriMakale { KategoriId = kategoriId });
                }
                _makaleRepository.Guncelle(guncellenecekMakale);
                return RedirectToAction("Index");
            }
            

            MakaleGuncelleForm_VM vm = new()
            {
                Kategoriler = _kategoriRepository.Listele().ToList(),
                Makale = makale
            };
            return View(vm);
        }

        public IActionResult Delete(int id)
        {
            // Kullanıcının makalesi değilse erişim engelle
            if (!KullanicininMakalesiMi(id))
            {
                return Forbid();
            }

            var silinecekMakale = _makaleRepository.Bul(id);

            // Veritabanında olmayan bir kitapsa NotFound() döner.
            if (silinecekMakale == null)
            {
                return NotFound();
            }

            _makaleRepository.Sil(id);
            return RedirectToAction("Index");
        }
        private bool KullanicininMakalesiMi(int makaleId)
        {
            var user = _userRepository.AktifKullaniciGetir();
            return _makaleRepository
                .ListeleQueryable()
                .Any(m => m.UserId == user.Id && m.Id == makaleId);
        }
    }
}
