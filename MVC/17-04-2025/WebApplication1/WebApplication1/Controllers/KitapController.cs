using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class KitapController : Controller
    {
        private readonly KitapRepository _kitapRepository;
        private readonly KategoriRepository _kategoriRepository;
        private readonly YayineviRepository _yayineviRepository;
        private readonly YazarRepository _yazarRepository;
        private readonly IMapper _mapper;

        public KitapController(KitapRepository kitapRepository, KategoriRepository kategoriRepository, YayineviRepository yayineviRepository, YazarRepository yazarRepository, IMapper mapper)
        {
            _kitapRepository = kitapRepository;
            _kategoriRepository = kategoriRepository;
            _yayineviRepository = yayineviRepository;
            _yazarRepository = yazarRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_kitapRepository.Listele());
        }

        public IActionResult Create()
        {
            var vm = new KitapEkleFormViewModel
            {
                Kitap = new KitapEkleViewModel(),
                Kategoriler = new SelectList(_kategoriRepository.Listele(), "Id", "Ad"),
                Yazarlar = new SelectList(_yazarRepository.Listele(), "Id", "Ad"),
                Yayinevleri = new SelectList(_yayineviRepository.Listele(), "Id", "Ad"),
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(KitapEkleViewModel kitap)
        {
            if (ModelState.IsValid)
            {
                //Kitap yeniKitap = _mapper.Map<Kitap>(kitap);
                Kitap yeniKitap = new();
                _mapper.Map(kitap, yeniKitap);

                _kitapRepository.Ekle(yeniKitap);
                return RedirectToAction("Index");
            }


            var vm = new KitapEkleFormViewModel
            {
                Kitap = new KitapEkleViewModel(),
                Kategoriler = new SelectList(_kategoriRepository.Listele(), "Id", "Ad"),
                Yazarlar = new SelectList(_yazarRepository.Listele(), "Id", "Ad"),
                Yayinevleri = new SelectList(_yayineviRepository.Listele(), "Id", "Ad"),
            };
            return View(vm);
        }



        public IActionResult Edit(int id)
        {
            var kitap = _kitapRepository.Bul(id);

            var vm = new KitapGuncelleFormViewModel
            {
                Kategoriler = new SelectList(_kategoriRepository.Listele(), "Id", "Ad"),
                Yazarlar = new SelectList(_yazarRepository.Listele(), "Id", "Ad"),
                Yayinevleri = new SelectList(_yayineviRepository.Listele(), "Id", "Ad"),
                Kitap = _mapper.Map<KitapGuncelleViewModel>(kitap)


            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(int id, KitapGuncelleViewModel kitap)
        {

            if (ModelState.IsValid)
            {
                var guncellenecekKitap = _kitapRepository.Bul(id);

                guncellenecekKitap = _mapper.Map(kitap, guncellenecekKitap);

                _kitapRepository.Guncelle(guncellenecekKitap);
                return RedirectToAction("Index");
            }


            var vm = new KitapGuncelleFormViewModel
            {
                Kategoriler = new SelectList(_kategoriRepository.Listele(), "Id", "Ad"),
                Yazarlar = new SelectList(_yazarRepository.Listele(), "Id", "Ad"),
                Yayinevleri = new SelectList(_yayineviRepository.Listele(), "Id", "Ad"),
                Kitap = kitap
            };
            return View(vm);
        }

        public IActionResult Details(int id)
        {
            //return View(_kitapRepository.GetKitapDetay(id));
            return View(_kitapRepository.KitapDetayGetir(id));
        }

    }
}
