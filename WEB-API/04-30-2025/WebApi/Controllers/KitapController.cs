using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapController : ControllerBase
    {
        public static List<Kitap> Kitaplar { get; set; } = new List<Kitap>();


        [HttpGet("Listele")]
        public IActionResult Listele()
        {
            return Ok(Kitaplar);
        }

        [HttpGet("Ara/{id}")]
        public IActionResult KitapBul(int id)
        {
            var kitap = Kitaplar.FirstOrDefault(k => k.KitapID == id);
            return Ok(kitap);
        }

        [HttpPost("Ekle")]
        public IActionResult KitapEkle(Kitap kitap)
        {
            if (kitap == null)
            {
                return BadRequest();
            }
            Kitaplar.Add(kitap);
            return Ok();
        }
    }
}
