using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels.Kitap;
using WebApplication1.Repositories.Implementations;

namespace WebApplication1.Controllers
{
    public class KitapController : Controller
    {
        private readonly KategoriRepository _kategoriRepository;
        private readonly KitapRepository _kitapRepository;
        private readonly UserManager<AppUser> _userManager;

        public KitapController(KategoriRepository kategoriRepository, KitapRepository kitapRepository, UserManager<AppUser> userManager)
        {
            _kategoriRepository = kategoriRepository;
            _kitapRepository = kitapRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var kitaplar = _kitapRepository.ListeleQueryable();
            var kitaplarWithDetails = kitaplar
                .Include(k => k.User)
                .Include(k => k.Kategoriler)
                .ThenInclude(kk => kk.Kategori);

            var kitapViewModelleri = kitaplarWithDetails.Select(k => new KitapListeViewModel
            {
                Id = k.Id,
                Ad = k.Ad,
                Fiyat = k.Fiyat,
                Ozet = k.Ozet,
                SayfaSayisi = k.SayfaSayisi,
                KullaniciAdi = k.User.UserName,
                KategoriAdlari = k.Kategoriler.Select(kk => kk.Kategori.Ad).ToList()
            }).ToList();
            return View(kitapViewModelleri);
        }

        public IActionResult Details(int id)
        {
            var kitap = _kitapRepository
                .ListeleQueryable()
                .Include(k => k.User)
                .Include(k => k.Kategoriler)
                .ThenInclude(kk => kk.Kategori)
                .FirstOrDefault(k => k.Id == id);

            if (kitap == null)
                return NotFound();

            var detayViewModel = new KitapDetayViewModel
            {
                Id = kitap.Id,
                Ad = kitap.Ad,
                Fiyat = kitap.Fiyat,
                Ozet = kitap.Ozet,
                SayfaSayisi = kitap.SayfaSayisi,
                KullaniciAdi = kitap.User?.UserName ?? "Anonim",
                KategoriAdlari = kitap.Kategoriler?
                                    .Select(kk => kk.Kategori?.Ad)
                                    .Where(ad => ad != null)
                                    .ToList() ?? new List<string>()
            };

            return View(detayViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new KitapEkleViewModel
            {
                TumKategoriler = _kategoriRepository.Listele()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KitapEkleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.TumKategoriler = _kategoriRepository.Listele();
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var yeniKitap = new Kitap
            {
                Ad = model.Ad,
                Fiyat = model.Fiyat,
                Ozet = model.Ozet,
                SayfaSayisi = model.SayfaSayisi,
                UserId = user.Id,
                Kategoriler = model.SeciliKategoriIdleri.Select(katId => new KitapKategori
                {
                    KategoriId = katId
                }).ToList()
            };

            _kitapRepository.Ekle(yeniKitap);
            return RedirectToAction("Index", "Kitap");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var kitap = await _kitapRepository
                .ListeleQueryable()
                .Include(k => k.Kategoriler)
                .FirstOrDefaultAsync(k => k.Id == id);

            if (kitap == null)
                return NotFound();

            var tumKategoriler = _kategoriRepository.Listele();

            var vm = new KitapGuncelleViewModel
            {
                Id = kitap.Id,
                Ad = kitap.Ad,
                Fiyat = kitap.Fiyat,
                Ozet = kitap.Ozet,
                SayfaSayisi = kitap.SayfaSayisi,
                SeciliKategoriIdleri = kitap.Kategoriler.Select(k => k.KategoriId).ToList(),
                TumKategoriler = tumKategoriler
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(KitapGuncelleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.TumKategoriler = _kategoriRepository.Listele();
                return View(model);
            }

            var kitap = await _kitapRepository
                .ListeleQueryable()
                .Include(k => k.Kategoriler)
                .FirstOrDefaultAsync(k => k.Id == model.Id);

            if (kitap == null)
                return NotFound();

            // Güncelleme
            kitap.Ad = model.Ad;
            kitap.Fiyat = model.Fiyat;
            kitap.Ozet = model.Ozet;
            kitap.SayfaSayisi = model.SayfaSayisi;

            // Kategori eşleşmelerini sıfırla
            kitap.Kategoriler = model.SeciliKategoriIdleri.Select(id => new KitapKategori
            {
                KategoriId = id,
                KitapId = kitap.Id
            }).ToList();

            _kitapRepository.Guncelle(kitap);
            return RedirectToAction("Index", "Kitap");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var kitap = _kitapRepository.Bul(id);
            if (kitap == null)
                return NotFound();

            _kitapRepository.Sil(kitap.Id);
            return RedirectToAction("Index", "Kitap");
        }



    }
}
