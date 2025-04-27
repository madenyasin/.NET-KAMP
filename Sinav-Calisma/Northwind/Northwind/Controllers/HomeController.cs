using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Product");
        }

    }
}
