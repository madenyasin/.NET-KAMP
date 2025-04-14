using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using WebApplication1.CustomFilters;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.VM.Arac;
using WebApplication1.Models.VM.Login;

namespace WebApplication1.Controllers
{
    [SessionVarMi]
    public class GaleriController : Controller
    {
        private readonly GaleriDbContext _dbContext;

        public GaleriController(GaleriDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [SessionVarMi]
        public IActionResult Index()
        {
            return View(_dbContext.Araclar.ToList());
        }
        public IActionResult Create()
        {
            AracEkleForm_VM form = new()
            {
                Markalar = new SelectList(_dbContext.Markalar, "Id", "Ad"),
                Arac = new AracEkle_VM()
            };
            return View(form);
        }
        [HttpPost]
        public IActionResult Create(AracEkle_VM arac)
        {

            int? uyeId = HttpContext.Session.GetInt32("Id");
            var uye = _dbContext.Uyeler.FirstOrDefault(
               x => x.Id == uyeId);

            if (uye != null)
            {


                if (ModelState.IsValid)
                {
                    Arac yeniArac = new()
                    {
                        Aciklama = arac.Aciklama,
                        Fiyat = arac.Fiyat,
                        Plaka = arac.Plaka,
                        Model = arac.Model,
                        Renk = arac.Renk,
                        MarkaId = arac.MarkaId,
                        EkleyenUyeId = arac.EkleyenUyeId,
                    };



                    _dbContext.Araclar.Add(yeniArac);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");

                }
            }

            AracEkleForm_VM form = new()
            {
                Markalar = new SelectList(_dbContext.Markalar, "Id", "Ad"),
                Arac = new AracEkle_VM()
            };
            return View(form);
        }

        public IActionResult Login()
        {
            LoginForm_VM form = new()
            {
                Login = new Login_VM()
            };
            return View(form);
        }


        [HttpPost]
        public IActionResult Login(Login_VM login)
        {
            var hasher = new PasswordHasher<Uye>();
            if (ModelState.IsValid)
            {

                if (login.Sifre != login.SifreTekrar)
                {
                    return NoContent();
                }

                //var uye = _dbContext.Uyeler.FirstOrDefault(
                //    x => x.KullaniciAdi == login.KullaniciAdi
                //    && x.Sifre == login.Sifre);
                var uye = _dbContext.Uyeler.FirstOrDefault(
                    x => x.KullaniciAdi == login.KullaniciAdi
                    && x.Sifre == login.Sifre);

                if (uye != null)
                {
                    HttpContext.Session.SetInt32("Id", uye.Id);
                    return RedirectToAction(nameof(Index));
                }
            }


            LoginForm_VM form = new()
            {
                Login = new Login_VM()
            };
            return View(form);
        }
    }
}
