using Microsoft.AspNetCore.Mvc;

namespace html_elements.Controllers
{
    public class KitapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CreateViewModel model = new CreateViewModel
            {
                UserName = "null",
                Password = "12"
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            return View();
        }

    }

    public class CreateViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
