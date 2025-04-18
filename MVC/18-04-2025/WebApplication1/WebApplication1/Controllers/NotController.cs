using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class NotController : Controller
    {
        private readonly KategoriRepository _kategoriRepository;
        private readonly NotRepository? _notRepository;
        private readonly UserManager<Uye> _userManager;
        private readonly SignInManager<Uye> _signInManager;
        private readonly LoginService _loginService;
        private readonly IMapper _mapper;

        public NotController(KategoriRepository kategoriRepository, NotRepository? notRepository, UserManager<Uye> userManager, SignInManager<Uye> signInManager, LoginService loginService, IMapper mapper)
        {
            _kategoriRepository = kategoriRepository;
            _notRepository = notRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _loginService = loginService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _loginService.GetCurrentUserId().Result;

            var notlar = _notRepository.ListeleQueryable().Where(x => x.UyeId == userId)
                .ToList();
            return View(notlar);
        }

        public IActionResult Create()
        {
            var model = new NotEkleFormViewModel
            {
                Kategoriler = new SelectList(_kategoriRepository.Listele(), "Id", "Ad"),
                Not = new NotEkleViewModel()
            };
            return View(model);

        }

        [HttpPost]
        public IActionResult Create(NotEkleViewModel not)
        {
            if (ModelState.IsValid)
            {
                var uyeId = _loginService.GetCurrentUserId().Result;

                var notModel = _mapper.Map<Not>(not);
                notModel.UyeId = uyeId;
                notModel.OlusturmaTarihi = DateTime.Now;

                _notRepository.Ekle(notModel);
                return RedirectToAction("Index");
            }
            else
            {
                var model = new NotEkleFormViewModel
                {
                    Kategoriler = new SelectList(_kategoriRepository.Listele(), "Id", "Ad"),
                    Not = not
                };
                return View(model);
            }
        }

        public IActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                var not = _notRepository.Bul(id);
                var model = new NotGuncelleFormViewModel
                {
                    Kategoriler = new SelectList(_kategoriRepository.Listele(), "Id", "Ad"),
                    Not = _mapper.Map<NotGuncelleViewModel>(not)
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Edit(NotGuncelleViewModel not)
        {
            if (ModelState.IsValid)
            {
                var not = _notRepository.Bul(not.Id);
                not.Ad = not.Ad;
                not.Aciklama = not.Aciklama;
                not.BitisTarihi = not.BitisTarihi;
                not.Durum = not.Durum;
                not.KategoriId = not.KategoriId;
                _notRepository.Guncelle(not);
                return RedirectToAction("Index");
            }
            var model = new NotGuncelleFormViewModel
            {
                Kategoriler = new SelectList(_kategoriRepository.Listele(), "Id", "Ad"),
                Not = Not
            };
            return View(model);
        }

        public IActionResult Delete(int id)
        {

            _notRepository.Sil(id);
            return RedirectToAction("Index");
        }
    }
}
