using Catalog.Models;
using Catalog.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [Route("catalog")]
    public class ProductController : Controller
    {
        private static Models.Catalog _catalog = new();
        private readonly IProductService _productService;

        public ProductController(
            IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public IActionResult Products()
        {
            return View(_catalog);
        }

        [HttpPost("products")]
        public async Task<IActionResult> Products(Product product, CancellationToken cancellationToken) // уже
        {
            product.CategoryId = long.Parse(Request.Form["categories"]);
            await _productService.Add(_catalog, product, cancellationToken);
            return View(_catalog);
        }
    }
}
