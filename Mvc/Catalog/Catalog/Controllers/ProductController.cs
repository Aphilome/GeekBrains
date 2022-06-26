using Catalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [Route("catalog")]
    public class ProductController : Controller
    {
        private static Models.Catalog _catalog = new()
        {
            Categories = new List<Models.Category>
            {
                new Models.Category
                {
                    Id = 1,
                    Name = "Vegetables",
                    Products = new List<Models.Product>
                    {
                        new Models.Product
                        {
                            Id = 1,
                            Name = "Potetor"
                        },
                        new Models.Product
                        {
                            Id = 2,
                            Name = "Tomato"
                        }
                    },
                },
                new Models.Category
                {
                    Id = 2,
                    Name = "Fruits",
                    Products = new List<Models.Product>
                    {
                        new Models.Product
                        {
                            Id = 1,
                            Name = "Apple"
                        },
                        new Models.Product
                        {
                            Id = 2,
                            Name = "Orange"
                        }
                    },
                },
            }
        };

        [HttpGet("products")]
        public IActionResult Products()
        {
            return View(_catalog);
        }

        [HttpPost("products")]
        public IActionResult Products(Product product)
        {
            product.CategoryId = long.Parse(Request.Form["categories"]);
            _catalog.Categories.First(i => i.Id == product.CategoryId).Products.Add(product);
            return View(_catalog);
        }
    }
}
