using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SepetController : Controller
    {
        private readonly Yy2UrunDbContext _dbContext;
        private const string SepetCookieAdi = "SepetCookie";

        public SepetController(Yy2UrunDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var urunler = _dbContext.Urunlers.ToList();
            return View(urunler);
        }
        public IActionResult Sepet()
        {
            var sepet = Request.Cookies[SepetCookieAdi];
            var urunIds = string.IsNullOrEmpty(sepet) ? new List<int>() : sepet.Split(',').Select(int.Parse).ToList();

            var urunler = _dbContext.Urunlers
                .Where(u => urunIds.Contains(u.UrunId))
                .ToList();

            return View(urunler);
        }
        public IActionResult SepeteEkle(int id)
        {
            var urun = _dbContext.Urunlers.FirstOrDefault(u => u.UrunId == id);
            var sepet = Request.Cookies[SepetCookieAdi];
            var urunIds = string.IsNullOrEmpty(sepet) ? new List<int>() : sepet.Split(',').Select(int.Parse).ToList();

            if (!urunIds.Contains(id))
            {
                urunIds.Add(id);
                Response.Cookies.Append(SepetCookieAdi, string.Join(",", urunIds), new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7)
                });
            }

            return RedirectToAction("Index");
        }
    }
}
