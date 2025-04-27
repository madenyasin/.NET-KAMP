using KitapProje.Models.ViewModels.KitapViewModels;
using KitapProje.Repositories.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KitapProje.Controllers
{
    [Authorize]
    public class KitapController : Controller
    {
        private readonly KitapRepository _kitapRepository;
        private readonly UserRepository _userRepository;

        public KitapController(KitapRepository kitapRepository, UserRepository userRepository)
        {
            _kitapRepository = kitapRepository;
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
    }
}
