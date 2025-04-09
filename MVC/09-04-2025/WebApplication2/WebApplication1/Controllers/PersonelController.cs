using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PersonelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Personel personel)
        {
            if (ModelState.IsValid)
            {
                return Content("VALID");
            }
            return View();
        }

        public IActionResult KullaniciEkle()
        {
            return View();
        }
        public IActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MusteriEkle(Musteri musteri)
        {
            return View();
        }

        [HttpPost]
        public IActionResult KullaniciEkle(KullaniciEkleVM kullanici)
        {
            if (ModelState.IsValid)
            {
                return Content("İşlem Başarılı");

            }
            return View();
        }
    }
}
