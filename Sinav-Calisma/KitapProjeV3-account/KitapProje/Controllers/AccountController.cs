using KitapProje.Models;
using KitapProje.Models.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KitapProje.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private string KITAP_CONTROLLER = "Kitap";
        private string HOME_CONTROLLER = "Home";
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            // Kullanıcı zaten giriş yapmışsa, Home sayfasına yönlendir
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", HOME_CONTROLLER);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", KITAP_CONTROLLER);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        public IActionResult Login()
        {
            // Kullanıcı zaten giriş yapmışsa, Home sayfasına yönlendir
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", HOME_CONTROLLER);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }



            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", KITAP_CONTROLLER);
            }

            ModelState.AddModelError(string.Empty, "E-posta veya şifre hatalı.");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", HOME_CONTROLLER);
        }

        public IActionResult Index()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Index", KITAP_CONTROLLER);
        }
    }
}
