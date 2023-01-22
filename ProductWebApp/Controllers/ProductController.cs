using Microsoft.AspNetCore.Mvc;
using ProductWebApp.Models;
using ProductWebApp.Services.ProductService;
using System.Diagnostics;

namespace ProductWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger,IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpGet]
        [ResponseCache(Duration = 21400, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Index()
        {
            //Get Categories
            var categories = await _productService.GetCategories();
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Products(ProductQuery productQuery)
        {
            //Get Products by query and return partial view
            var products = await _productService.GetProductsByQuery(productQuery);
            return PartialView("_Products",products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
