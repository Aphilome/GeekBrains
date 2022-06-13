using Catalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    public class CatalogController : Controller
    {
        private static Models.Catalog _catalog = new();

        [HttpGet]
        public IActionResult Categories()
        {
            return View(_catalog);
        }

        [HttpPost]
        public IActionResult Categories(Category category)
        {
            _catalog.Categories.Add(category);
            return View(_catalog);
        }
    }
}
