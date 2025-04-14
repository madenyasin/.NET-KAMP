using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using WebApplication1.Data;
using WebApplication1.Models.VM.Login;
using WebApplication1.Utilities;

namespace WebApplication1.Controllers
{
    public class UyeController: Controller
    {
        private readonly GaleriDbContext _dbContext;

        public UyeController(GaleriDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Loginn()
        {
            return View("LoginUye");
        }
        [HttpPost]
        public IActionResult Loginn(Login_VM login)
        {
            if (login.Sifre != login.SifreTekrar)
            {
                return NoContent();
            }

            var user = _dbContext.Uyeler.Where(x => x.KullaniciAdi == login.KullaniciAdi
            && x.Sifre == Md5Hasher.HashOlustur(login.KullaniciAdi, login.Sifre)).SingleOrDefault();

            if (user != null)
            {
                Request.HttpContext.Session.SetInt32("Id", user.Id);
                return RedirectToAction(nameof(Index), "Otomobil");
            }


            return View();
        }
        public string Test()
        {
            return Md5Hasher.HashOlustur("123456", "a");
            
        }


    }
}
