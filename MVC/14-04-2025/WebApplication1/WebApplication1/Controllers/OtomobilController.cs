using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class OtomobilController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string s)
        {
            return View();
        }
    }
}
