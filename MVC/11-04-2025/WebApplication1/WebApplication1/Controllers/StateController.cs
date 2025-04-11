using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detay()
        {
            string str = Request.QueryString.Value;
            return Content("gelen deger:\n\n" + str);
        }
        public IActionResult CerezOlustur()
        {
            CookieOptions options = new();
            options.Expires = DateTime.Now.AddDays(15);


            Response.Cookies.Append("cerezos", "süreli çerez içerisinde tutulan veri");
            return Content("çerez oluştur");
        }
        public IActionResult CerezdenOku()
        {
            string value = Request.Cookies["cerezos"];
            return Content("çerez verisi: \n\n" + value);
        }

        public IActionResult SessionOlustur()
        {
            HttpContext.Session.SetInt32("Id", 123);

            return Content("Session Oluştu");
        }
        public IActionResult SessiondanOku()
        {
            int? uyeId = HttpContext.Session.GetInt32("Id");

            return Content("Session Degeri: " + uyeId);
        }
    }
}
