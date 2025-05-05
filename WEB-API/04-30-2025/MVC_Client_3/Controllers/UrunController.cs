using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Client_3.Models;
using MVC_Client_3.Models.ViewModels;
using System.Net.Http;

namespace MVC_Client_3.Controllers
{
    public class UrunController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        string strUrl = "";

        public UrunController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            strUrl = _configuration.GetValue<string>("BaseUrl");
        }

        // GET: UrunController
        public IActionResult Index()
        {
            var result = _httpClient.GetFromJsonAsync<List<Urun>>(strUrl + "Urun/join").Result;
            return View(result);

        }



        // GET: UrunController/Create
        public ActionResult Create()
        {
            UrunEkleFormVM urunEkleFormVM = new UrunEkleFormVM();
            urunEkleFormVM.Urun = new UrunEkleVM();
            urunEkleFormVM.Kategoriler = new SelectList(TumKategoriler().Result, "KategoriID", "KategoriAdi");
            return View(urunEkleFormVM);

        }

        // POST: UrunController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UrunEkleVM urun)
        {
            var result = _httpClient.PostAsJsonAsync(strUrl + "Urun", urun).Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Ürün eklenirken hata oluştu.");
            }
            return View();

        }

        private async Task<List<Kategori>?> TumKategoriler()
        {
            return await _httpClient.GetFromJsonAsync<List<Kategori>>(strUrl + "Kategori");
        } 
    }
}
