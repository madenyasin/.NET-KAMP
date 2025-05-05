using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaslangicController : ControllerBase
    {
        //[HttpGet]
        //public string Test()
        //{
        //    return "Test 123";
        //}
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Test 123");
        }

        [HttpGet("liste")]
        public IActionResult Listele()
        {
            List<Urun> urunler = new List<Urun>() {
                new Urun() { UrunID = 1, UrunAdi = "Kalem", Fiyat = 10.5 },
                new Urun() { UrunID = 2, UrunAdi = "Defter", Fiyat = 20.5 },
                new Urun() { UrunID = 3, UrunAdi = "Silgi", Fiyat = 5.5 }
            };
            return Ok(urunler);
        }
        [HttpPost]
        public IActionResult UrunEkle(Urun urun)
        {
            return Ok("eklenen veri" + urun.UrunAdi);
        }
    }
}
