using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels.Login;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
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
                var result = _userManager.FindByNameAsync(login.KullaniciAdi).Result;
                if (result != null)
                {//üye var
                    var sifreDogruMu = _userManager.CheckPasswordAsync(result, login.Sifre).Result;

                    if (sifreDogruMu)
                    {// üye var sifre dgru
                       await _signInManager.SignInAsync(result, false);
                        return RedirectToAction("Index", "Kitap");
                    }
                }
                else
                {
                    ModelState.AddModelError("hata", "kullanıcı adı veya şifre yanlış");
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
                AppUser yeniUye = _mapper.Map<AppUser>(register);

                var result = await _userManager.CreateAsync(yeniUye, register.Sifre);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
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
