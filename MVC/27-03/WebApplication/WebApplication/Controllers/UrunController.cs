using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class UrunController : Controller
    {
        static List<Urun> urunler { get; set; } = new List<Urun>();
        public IActionResult Index()
        {

            return View(urunler);
        }
        public IActionResult UrunEkle()
        {

            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(Urun urun)
        {
            urunler.Add(urun);
            return RedirectToAction("Index");
        }
    }
}
