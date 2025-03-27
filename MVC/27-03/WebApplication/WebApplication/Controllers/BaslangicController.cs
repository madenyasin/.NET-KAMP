using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class BaslangicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VeriAktar()
        {

            ViewData["mesaj"] = "Merhaba";
            ViewBag.Message = "Hello";

            Urun urun = new Urun() { UrunID = 1, UrunAdi = "T Cetveli", Fiyat = 1500 };

            ViewData["urun"] = urun;
            ViewBag.Product = urun;

            List<Urun> urunler = new List<Urun>
            {
                new Urun(){ UrunID = 1, UrunAdi = "T Cetveli", Fiyat = 1500 },
                new Urun(){ UrunID = 2, UrunAdi = "T Cetveli", Fiyat = 1500 },
                new Urun(){ UrunID = 3, UrunAdi = "T Cetveli", Fiyat = 1500 }
            };

            ViewBag.Products = urunler;
            ViewData["urunler"] = urunler;

            return View();
        }

        public IActionResult ModelKullanimi()
        {
            Urun urun = new Urun() { UrunID = 1, UrunAdi = "T Cetveli", Fiyat = 1500 };


            return View(urun);
        }
        public IActionResult TumUrunler()
        {
            List<Urun> urunler = new List<Urun>
            {
                new Urun(){ UrunID = 1, UrunAdi = "T Cetveli", Fiyat = 1500 },
                new Urun(){ UrunID = 2, UrunAdi = "T Cetveli", Fiyat = 1500 },
                new Urun(){ UrunID = 3, UrunAdi = "T Cetveli", Fiyat = 1500 }
            };
            return View(urunler);
        }
        public IActionResult VeriAl()
        {
            return View();

        }
        public IActionResult VerileriYakala_GET()
        {
            string veriler = Request.QueryString.Value;
            Console.WriteLine(veriler);
            return Content(veriler);
        }
        public IActionResult VerileriYakala_RF()
        {
            string ad = Request.Form["ad"];
            string soyad = Request.Form["soyad"];
            string yas = Request.Form["yas"];
            return Content(ad + soyad + yas);
        }
        public IActionResult VerileriYakala_IFC(IFormCollection frm)
        {
            string ad = frm["ad"];
            string soyad = frm["soyad"];
            string yas = frm["yas"];
            return Content(ad + soyad + yas);
        }
        public IActionResult VerileriYakala_PRMs(string ad, string soyad, int yas)
        {
            return Content(ad + soyad + yas);
        }
        public IActionResult VerileriYakalaModel(Personel personel)
        {
            return Content(personel.Ad + personel.Soyad + personel.Yas);
        }

        //public string Index()
        //{
        //    return "Merhaba MVC Core";
        //}
    }
}
