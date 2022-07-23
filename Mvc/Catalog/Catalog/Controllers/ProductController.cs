using Catalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [Route("catalog")]
    public class ProductController : Controller
    {
        private static Models.Catalog _catalog = new();

        [HttpGet("products")]
        public IActionResult Products()
        {
            return View(_catalog);
        }

        [HttpPost("products")]
        public IActionResult Products(Product product)
        {
            product.CategoryId = long.Parse(Request.Form["categories"]);
            _catalog.GetCategories().First(i => i.Id == product.CategoryId).AddNewProduct(product);
            return View(_catalog);
        }
    }
}
