using Client_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client_MVC.Controllers
{
    public class UrunController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginDto login)
        {
            var response = await new HttpClient().PostAsJsonAsync("https://localhost:7134/api/Login", login);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                return Content(token);
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View();
        }
    }
}
