using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Utilities;

namespace WebApplication1.Controllers
{
    public class UrunController : Controller
    {
        /*
         * eski usul
         * sakın yapma
         * neden
         * dependecy injection,'ı kullan
         */


        private readonly MarketDBContext _dbContext;


        // ctor injection...
        public UrunController(MarketDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var urunler = _dbContext.Urunler.Include(u => u.Kategori).ToList();


            return View(urunler);
        }


        public IActionResult Edit(int id)
        {

            var urun = _dbContext.Urunler.FirstOrDefault(x => x.UrunID == id);
            ViewBag.KategoriID = new SelectList(_dbContext.Kategoriler, "KategoriID", "KategoriAdi");
            return View(urun);
        }


        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost(Urun yeniUrun)
        {
            if (ModelState.IsValid)
            {

                var urun = _dbContext.Urunler.FirstOrDefault(x => x.UrunID == yeniUrun.UrunID) ;

                _dbContext.Remove(urun);
                _dbContext.Add(yeniUrun);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }


            return View();
        }
        public IActionResult Delete(int id)
        {
            var product = _dbContext.Urunler.ToList().FirstOrDefault(x => x.UrunID == id);
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteDevam(int id)
        {
            var product = _dbContext.Urunler.ToList().FirstOrDefault(x => x.UrunID == id);
            _dbContext.Urunler.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult TumKategoriler()
        {

            return View(_dbContext.Kategoriler.ToList());
        }
        public IActionResult Details(int id)
        {
            var urun = _dbContext.Urunler.Include(u => u.Kategori).ToList().FirstOrDefault(x => x.UrunID == id);
            return View(urun);
        }




        public IActionResult UrunEkle()
        {
            ViewBag.Kategoriler = new SelectList(_dbContext.Kategoriler, "KategoriID", "KategoriAdi");
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(Urun urun, IFormFile urunResmi)
        {

            //resim(dosya) ile ilgili yapılacaklar
            //1-dosyayı sunucuya yükle
            //2-dosya adını ürün modeline yaz

            
            urun.Resim = FileOperations.ResimYukle(urunResmi);

            _dbContext.Urunler.Add(urun);
            _dbContext.SaveChanges();


            return RedirectToAction("Index");
        }

        public IActionResult GuidOlustur()
        {
            string guid = Guid.NewGuid().ToString();
            return Content(guid);
        }



    }
}
