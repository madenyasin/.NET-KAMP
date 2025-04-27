using System.Security.Claims;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Abstracts;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModels.Kitap;

namespace WebApplication1.Controllers
{
    public class KitapController : Controller
    {
        private readonly KitapRepository _kitapRepository;
        private readonly IMapper _mapper;

        public KitapController(KitapRepository kitapRepository, IMapper mapper)
        {
            _kitapRepository = kitapRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var kitaplar = _kitapRepository.ListeleQueryable()
                .Include(x => x.User)
                .ProjectTo<KitapListele_VM>(_mapper.ConfigurationProvider)
                .ToList();

            return View(kitaplar);
        }

        public IActionResult Create()
        {

            KitapEkleForm_VM vm = new KitapEkleForm_VM
            {
                Kitap = new KitapEkle_VM(),
                Kategoriler = new SelectList(_kitapRepository.Listele(), "Id", "Ad")
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(KitapEkle_VM kitap)
        {
            if (ModelState.IsValid)
            {
                Kitap yeniKitap = new Kitap
                {
                    Ad = kitap.Ad,
                    Fiyat = kitap.Fiyat,
                    Ozet = kitap.Ozet,
                    SayfaSayisi = kitap.SayfaSayisi,
                    Kategoriler = kitap.SecilenKategoriIdleri.Select(kategoriId => new KitapKategori { KategoriId = kategoriId }).ToList(),
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                _kitapRepository.Ekle(yeniKitap);
            }

            KitapEkleForm_VM vm = new KitapEkleForm_VM
            {
                Kitap = new KitapEkle_VM(),
                Kategoriler = new SelectList(_kitapRepository.Listele(), "Id", "Ad")
            };
            return View(vm);
        }
    }
}
