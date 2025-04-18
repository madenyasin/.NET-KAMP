using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class KategoriController : Controller
    {
        private readonly KategoriRepository _kategoriRepository;

        public KategoriController(KategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }

        public IActionResult Index()
        {
            return View(_kategoriRepository.Listele());
        }
        

    }
}
