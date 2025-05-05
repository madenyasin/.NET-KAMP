using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YasinMadenMVC.Models;
using YasinMadenMVC.Models.ViewModels.MakaleViewModels;
using YasinMadenMVC.Repositories;

namespace YasinMadenMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly MakaleRepository _makaleRepository;

        public HomeController(UserRepository userRepository, MakaleRepository makaleRepository)
        {
            _userRepository = userRepository;
            _makaleRepository = makaleRepository;
        }

        // Tüm makalelerilisteler
        public IActionResult Index()
        {
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
                    UserName = m.User.UserName,
                    Kategoriler = m.Kategoriler.Select(k => k.Kategori.Ad).ToList()
                }).ToList();
                
            return View(makaleler);
        }


        // Makale detayını gösterir
        public IActionResult Details(int id)
        {
            var makale = _makaleRepository.Bul(id);
            var makaleDetay = _makaleRepository.MakaleDetayGetir(makale);
            return View(makaleDetay);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
