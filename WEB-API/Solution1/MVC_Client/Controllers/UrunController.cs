using Microsoft.AspNetCore.Mvc;
using MVC_Client.Models;

namespace MVC_Client.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            var urunler = client.GetFromJsonAsync<List<Product>>("http://localhost:5118/api/Baslangic/liste").Result;
            return View(urunler);
        }
    }
}
