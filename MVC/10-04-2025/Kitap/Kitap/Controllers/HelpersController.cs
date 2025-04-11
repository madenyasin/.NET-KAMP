using Microsoft.AspNetCore.Mvc;

namespace Kitap.Controllers
{
    public class HelpersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}
