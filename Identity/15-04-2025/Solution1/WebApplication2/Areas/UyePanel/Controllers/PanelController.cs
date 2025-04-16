using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Areas.AdminPanel.Models.ViewModels;
using WebApplication2.Areas.UyePanel.Models.ViewModels;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Areas.UyePanel.Controllers
{
    [Area("UyePanel")]
    [Authorize(Roles = "Uye,Admin")]
    public class PanelController : Controller
    {
        private readonly UrunDbContext _context;
        private readonly UserManager<Uye> _userManager;

        public PanelController(UrunDbContext context, UserManager<Uye> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<UrunListele_VM> urunler = await _context.Urunler
                .Include(u => u.Uye)
                .Select(u => new UrunListele_VM
                {
                    UrunId = u.UrunId,
                    UrunAdi = u.UrunAdi,
                    Fiyat = u.Fiyat,
                    Resim = u.Resim,
                    Aciklama = u.Aciklama,
                    UyeId = u.UyeId,
                    KategoriId = u.KategoriId,
                    UyeAdi = u.Uye.UserName,
                    KategoriAdi = u.Kategori.KategoriAdi
                })
                .ToListAsync();
            return View(urunler);
        }
    }
}
