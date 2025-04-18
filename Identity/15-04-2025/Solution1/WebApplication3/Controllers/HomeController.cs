using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication3.Areas.Admin.Models.ViewModels;
using WebApplication3.Data;
using WebApplication3.Managers;
using WebApplication3.Models;
using WebApplication3.Utilities;
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
                    KategoriId = h.KategoriId,
                    EkleyenUyeAdi = h.Uye.Ad,
                    KategoriAdi = h.Kategori.Ad
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
        [Authorize(Roles = "Admin,Editor")]
        [HttpPost]
        public IActionResult Create(HaberEkle_VM haber)
        {
            if (ModelState.IsValid)
            {
                // Check if file was uploaded
                if (haber.KapakResmiDosyasi == null || haber.KapakResmiDosyasi.Length == 0)
                {
                    ModelState.AddModelError("Haber.KapakResmiDosyasi", "Kapak resmi gereklidir.");
                }
                else
                {
                    var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                    var resimYolu = FileOperations.ResimYukle(haber.KapakResmiDosyasi);

                    if (string.IsNullOrEmpty(resimYolu))
                    {
                        ModelState.AddModelError("Haber.KapakResmiDosyasi", "Resim yüklenirken bir hata oluştu.");
                    }
                    else
                    {
                        var yeniHaber = new Haber
                        {
                            Baslik = haber.Baslik,
                            Detay = haber.Detay,
                            ResimYolu = FileOperations.ResimYukle(haber.KapakResmiDosyasi),
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
                            ModelState.AddModelError("", "Haber eklenirken bir hata oluştu.");
                        }
                    }
                }
            }

            // If we got this far, something failed; redisplay form
            var model = new HaberEkleForm_VM
            {
                Kategoriler = new SelectList(_dbContext.Kategoriler.ToList(), "Id", "Ad"),
                Haber = haber
            };
            return View(model);
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

        public IActionResult Details(int id)
        {
            var haber = _dbContext.Haberler.Select(x => new HaberDetay_VM
            {
                Id = x.Id,
                Baslik = x.Baslik,
                Detay = x.Detay,
                ResimYolu = x.ResimYolu,
                EklendigiTarih = x.EklendigiTarih,
                UyeId = x.UyeId,
                EkleyenUyeAdi = x.Uye.Ad,
                KategoriId = x.KategoriId,
                KategoriAdi = x.Kategori.Ad
            }).FirstOrDefault(x => x.Id == id);

            if (haber == null)
            {
                ModelState.AddModelError("HATA", "Haber bulunamadı.");
                return RedirectToAction("Index", "Home");
            }

            return View(haber);
        }

        [Authorize(Roles = "Admin,Editor")]
        public IActionResult Edit(int id)
        {
            var haber = _dbContext.Haberler.Find(id);
            if (haber == null)
            {
                ModelState.AddModelError("HATA", "Haber bulunamadı.");
                return RedirectToAction("Index", "Home");
            }

            // Check authorization
            var user = _userManager.GetUserAsync(User).Result;
            var roles = _userManager.GetRolesAsync(user).Result;

            if (roles.Contains("Editor") && haber.UyeId != user.Id)
            {
                ModelState.AddModelError("HATA", "Sadece kendi haberinizi güncelleyebilirsiniz.");
                return RedirectToAction("Index", "Home");
            }

            var model = new HaberGuncelleForm_VM
            {
                Kategoriler = new SelectList(_dbContext.Kategoriler.ToList(), "Id", "Ad"),
                Haber = new HaberGuncelle_VM
                {
                    Id = haber.Id,
                    Baslik = haber.Baslik,
                    Detay = haber.Detay,
                    ResimYolu = haber.ResimYolu,
                    KategoriId = haber.KategoriId
                }
            };

            return View(model);
        }

        [Authorize(Roles = "Admin,Editor")]
        [HttpPost]
        public IActionResult Edit(HaberGuncelle_VM Haber)
        {
            if (ModelState.IsValid)
            {
                var haber = _dbContext.Haberler.Find(Haber.Id);
                if (haber == null)
                {
                    ModelState.AddModelError("HATA", "Haber bulunamadı.");
                    return RedirectToAction("Index", "Home");
                }

                // Check authorization
                var user = _userManager.GetUserAsync(User).Result;
                var roles = _userManager.GetRolesAsync(user).Result;

                if (roles.Contains("Editor") && haber.UyeId != user.Id)
                {
                    ModelState.AddModelError("HATA", "Sadece kendi haberinizi güncelleyebilirsiniz.");
                    return RedirectToAction("Index", "Home");
                }

                haber.Baslik = Haber.Baslik;
                haber.Detay = Haber.Detay;
                haber.ResimYolu = Haber.ResimYolu;
                haber.KategoriId = Haber.KategoriId;

                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            // If model state is invalid, return to the form with errors
            var model = new HaberGuncelleForm_VM
            {
                Kategoriler = new SelectList(_dbContext.Kategoriler.ToList(), "Id", "Ad"),
                Haber = Haber
            };

            return View(model);
        } 
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
