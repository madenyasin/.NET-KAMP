using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.ViewModels.Kitap;
using WebApplication1.Repositories.Implementations;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly KitapRepository _kitapRepository;

        public HomeController(KitapRepository kitapRepository)
        {
            _kitapRepository = kitapRepository;
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
    }
}
