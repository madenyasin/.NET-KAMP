﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebApplication3.Areas.Admin.Models.ViewModels;
using WebApplication3.Data;
using WebApplication3.Managers;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly HaberDbContext _dbContext;
        private readonly HaberManager _haberManager;
        private readonly UserManager<Uye> _userManager;

        public HomeController(HaberDbContext dbContext, HaberManager haberManager, UserManager<Uye> userManager)
        {
            _dbContext = dbContext;
            _haberManager = haberManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var haberler = _dbContext.Haberler
                .Select(h => new HaberListele_VM
                {
                    Id = h.Id,
                    Baslik = h.Baslik,
                    ResimYolu = h.ResimYolu,
                    EklendigiTarih = h.EklendigiTarih,
                    UyeId = h.UyeId,
                    KategoriId = h.KategoriId
                })
                .ToList();
            return View(haberler);
        }

        [Authorize(Roles = "Admin,Editor")]
        public IActionResult Create()
        {
            var model = new HaberEkleForm_VM
            {
                Kategoriler = new SelectList(_dbContext.Kategoriler.ToList(), "Id", "Ad"),
                Haber = new HaberEkle_VM()
            };
            return View(model);

        }
        [Authorize(Roles ="Admin,Editor")]
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
                    return RedirectToAction("Index", "Home");
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

        [Authorize(Roles ="Admin, Editor")]
        public IActionResult Delete()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var haber = _dbContext.Haberler.Find(id);

            if (haber != null)
            {
                var user = _userManager.GetUserAsync(User).Result;
                if (user is null)
                {
                    ModelState.AddModelError("HATA", "Bu işlemi yapmaya yetkiniz yok.");
                    return RedirectToAction("Index", "Home");
                }
                var roles = _userManager.GetRolesAsync(user).Result;

                if (!(roles.Contains("Admin") || roles.Contains("Editor")) || roles is null)
                {
                    ModelState.AddModelError("HATA", "Bu işlemi yapmaya yetkiniz yok.");
                    return RedirectToAction("Index", "Home");
                }

                if (roles.Contains("Editor") && haber.UyeId != user.Id)
                {
                    ModelState.AddModelError("HATA", "Sadece kendi haberinizi silebilirsiniz.");
                    return RedirectToAction("Index", "Home");
                }

                _dbContext.Haberler.Remove(haber);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("HATA", "Haber bulunamadı.");
                return RedirectToAction("Index", "Home");
            }
        }



    }
}
