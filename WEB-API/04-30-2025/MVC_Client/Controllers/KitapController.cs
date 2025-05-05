using Microsoft.AspNetCore.Mvc;
using MVC_Client.Models;

namespace MVC_Client.Controllers
{
    public class KitapController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5057/");
            var kitaplar = client.GetFromJsonAsync<IEnumerable<Kitap>>("api/Kitap/Listele").Result;


            return View(kitaplar ?? new List<Kitap>());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                Kitap yeniKitap = new Kitap
                {
                    KitapAdi = kitap.KitapAdi,
                    Yazar = kitap.Yazar,
                    Yayinevi = kitap.Yayinevi
                };
                HttpClient client = new HttpClient();

                var response = client.PostAsJsonAsync("http://localhost:5057/api/Kitap/Ekle", yeniKitap).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Content("Kitap başarıyla eklendi.");
                }
                else
                {
                    ModelState.AddModelError("", "Kitap eklenirken bir hata oluştu.");
                }
                return RedirectToAction("Index");
            }
            return View(kitap);

        }
    }
}
