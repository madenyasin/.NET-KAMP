using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class LoginController : Controller
    {
        private readonly HaberDbContext _dbContext;
        private readonly UserManager<Uye> _userManager;
        private readonly SignInManager<Uye> _signInManager;

        public LoginController(HaberDbContext dbContext, UserManager<Uye> userManager, SignInManager<Uye> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login_VM login)
        {
            if (ModelState.IsValid)
            {
                var result = _userManager.FindByNameAsync(login.UserName).Result;

                if (result is not null) // üye var
                {
                    var sifreDogruMu = _userManager.CheckPasswordAsync(result, login.Password).Result;
                    if (sifreDogruMu)
                    {// sifre doğru
                        await _signInManager.SignInAsync(result, false);
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {// sifre yanlış
                        ModelState.AddModelError("", "Şifre yanlış");
                    }
                }
                else
                {// üye yok
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                }
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register_VM register)
        {
            if (ModelState.IsValid)
            {
                Uye yeniUye = new Uye()
                {
                    Ad = register.Ad,
                    Soyad = register.Soyad,
                    Email = register.EPosta,
                    UserName = register.KullaniciAdi,
                };

                var result = await _userManager.CreateAsync(yeniUye, register.Sifre);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(yeniUye, "Uye");
                    return RedirectToAction("Login", "Login");

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
            return RedirectToAction("Index", "Home");
        }

    }
}
