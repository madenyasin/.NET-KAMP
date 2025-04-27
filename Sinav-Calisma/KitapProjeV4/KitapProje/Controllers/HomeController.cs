using System.Diagnostics;
using KitapProje.Models;
using KitapProje.Models.ViewModels.KitapViewModels;
using KitapProje.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KitapProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly KitapRepository _kitapRepository;

        public HomeController(KitapRepository kitapRepository)
        {
            _kitapRepository = kitapRepository;
        }

        /// <summary>
        /// Ana sayfada kitaplarý listele
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var kitaplar = _kitapRepository
                .ListeleQueryable()
                .Include(k => k.User)
                .Include(k => k.Kategoriler)
                .Select(k => new KitapListeleVM
                {
                    Id = k.Id,
                    Ad = k.Ad,
                    Fiyat = k.Fiyat,
                    Ozet = k.Ozet,
                    SayfaSayisi = k.SayfaSayisi,
                    UserName = k.User.UserName,
                    Kategoriler = k.Kategoriler.Select(kat => kat.Kategori.Ad).ToList()
                }).ToList();

            return View(kitaplar);
        }
        /// <summary>
        /// Kitap detay sayfasý
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var kitap = _kitapRepository.Bul(id);
            var kitapDetayVM = _kitapRepository.KitapDetayGetir(kitap);
            return View(kitapDetayVM);
        }
    }
}
