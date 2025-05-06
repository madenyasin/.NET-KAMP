using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Client_MVC.Models;

namespace Client_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            // HttpClient'ı oluştur
            var _httpClient = new HttpClient();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var loginData = new
                {
                    UserName = model.UserName,
                    Password = model.Password
                };

                var json = JsonSerializer.Serialize(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<TokenResponse>();

                    // Token'ı session'da saklayalım
                    HttpContext.Session.SetString("JWTToken", result.Token);

                    // Token'ı default HttpClient header'ına ekleyelim
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", result.Token);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Giriş işlemi sırasında bir hata oluştu: " + ex.Message);
                return View(model);
            }
        }
    }
}
