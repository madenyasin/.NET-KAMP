using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Areas.AdminPanel.Models.ViewModels;
using WebApplication2.Areas.UyePanel.Models.ViewModels;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin")]
    public class PanelController : Controller
    {
        private readonly UrunDbContext _context;
        private readonly UserManager<Uye> _userManager;
        private readonly RoleManager<Rol> _roleManager;

        public PanelController(UrunDbContext context, UserManager<Uye> userManager, RoleManager<Rol> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
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
        public IActionResult Create()
        {

            UrunEkleForm_VM form = new()
            {
                Kategoriler = new SelectList(_context.Kategoriler, "KategoriId", "KategoriAdi"),
                Urun = new UrunEkle_VM()
            };
            return View(form);
        }
        [HttpPost]
        public IActionResult Create(UrunEkle_VM urun)
        {
            if (ModelState.IsValid)
            {
                var uyeId = _userManager.GetUserId(User);

                Urun yeniUrun = new()
                {
                    UrunAdi = urun.UrunAdi,
                    Fiyat = urun.Fiyat,
                    Resim = urun.Resim,
                    Aciklama = urun.Aciklama,
                    UyeId = int.Parse(uyeId),
                    KategoriId = urun.KategoriId,

                };

                _context.Urunler.Add(yeniUrun);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            UrunEkleForm_VM form = new()
            {
                Kategoriler = new SelectList(_context.Kategoriler, "KategoriId", "KategoriAdi"),
                Urun = new UrunEkle_VM()
            };
            return View(form);
        }
    }
}
