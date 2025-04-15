using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Areas.UyePanel.Controllers
{
    [Area("UyePanel")]
    [Authorize(Roles = "Uye")]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
