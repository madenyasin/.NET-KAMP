using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Areas.Admin.Models.ViewModels;
using WebApplication3.Data;
using WebApplication3.Managers;
using WebApplication3.Models;

namespace WebApplication3.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly HaberManager _haberManager;
        private readonly HaberDbContext _dbContext;
        private readonly UserManager<Uye> _userManager;

        public AdminController(HaberManager haberManager, HaberDbContext dbContext, UserManager<Uye> userManager)
        {
            _haberManager = haberManager;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Create()
        {
            var model = new HaberEkleForm_VM
            {
                Kategoriler = new SelectList(_dbContext.Kategoriler.ToList(), "Id", "Ad"),
                Haber = new HaberEkle_VM()
            };
            return View(model);

        }
        [HttpPost]
        public IActionResult Create(HaberEkle_VM haber)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                var yeniHaber = new Haber
                {
                    Baslik = haber.Baslik,
                    Detay = haber.Detay,
                    ResimYolu = haber.ResimYolu,
                    KategoriId = haber.KategoriId,
                    UyeId = user.Id,
                    EklendigiTarih = DateTime.Now,

                };
                var sonuc = _haberManager.HaberEkleAsync(yeniHaber).Result;
                if (sonuc)
                {
                    return Redirect("~/Home/Index/");
                }
                else
                {
                    ModelState.AddModelError("HATA", "Haber eklenirken bir hata oluştu.");
                }
            }
            var model = new HaberEkleForm_VM
            {
                Kategoriler = new SelectList(_dbContext.Kategoriler.ToList(), "Id", "Ad"),
                Haber = new HaberEkle_VM()
            };
            return View(model);
        }
    }
}