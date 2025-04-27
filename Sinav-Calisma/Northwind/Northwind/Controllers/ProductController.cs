using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Repositories.Implementations;
using Northwind.ViewModels;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //var products = _productRepository.Listele().Select(product => _mapper.Map<ProductList_VM>(product)).ToList();
            //var products = _productRepository.Listele().Select(product => new
            //{
            //    product.ProductId,
            //    product.ProductName,
            //    product.OrderDetails.
            //}).ToList();

            var products = _productRepository.ListeleQueryable().Include(x => x.OrderDetails).SelectMany(p => p.OrderDetails, (p, od) => new ProductList_VM
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                QuantityPerUnit = od.Quantity.ToString(),
            }).ToList();
            return View(products);
        }
    }
}
