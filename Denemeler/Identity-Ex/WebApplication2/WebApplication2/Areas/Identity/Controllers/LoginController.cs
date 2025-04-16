using Microsoft.AspNetCore.Mvc;
using WebApplication2.Areas.Identity.ViewModels;
using WebApplication2.Data;

namespace WebApplication2.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class LoginController : Controller
    {
        private readonly LibraryDbContext _dbContext;

        public LoginController(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login_VM login)
        {
            return View();
        }
    }
}
