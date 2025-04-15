using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        private readonly UrunDbContext _dbContext;
        private readonly UserManager<Uye> _userManager;
        private readonly SignInManager<Uye> _signInManager;

        public LoginController(UrunDbContext dbContext, UserManager<Uye> userManager, SignInManager<Uye> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }




        //Login
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Login_VM login)
        {
            if (ModelState.IsValid)
            {
                var result = _userManager.FindByNameAsync(login.UserName).Result;

                if (result is not null)
                {// üye var
                    var sifreDogruMu = _userManager.CheckPasswordAsync(result, login.Password).Result;
                    if (sifreDogruMu)
                    {// üye var ve şifre doğru
                        await _signInManager.SignInAsync(result, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register_VM uye)
        {
            if (ModelState.IsValid)
            {

                Uye yeniUye = new()
                {
                    Ad = uye.Ad,
                    Soyad = uye.Soyad,
                    Adres = uye.Adres,
                    Email = uye.EPosta,
                    UserName = uye.KullaniciAdi
                };

                var result = await _userManager.CreateAsync(yeniUye, uye.Sifre);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(yeniUye, "Uye");
                    return RedirectToAction("", "Login");
                }
                else
                {
                    string str = "";
                    foreach (var item in result.Errors)
                    {
                        str += item.Description;
                    }
                    //return Content(str);
                    ModelState.AddModelError("HATA", str);
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}
