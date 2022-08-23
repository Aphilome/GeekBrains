using Catalog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Catalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("test-files")]
        public async Task<IActionResult> TestReadFiles()
        {
            return Json(await ReadFilesWithParams(@"D:\fdsdfg\GeekBrains\Mvc\Catalog\Catalog\Controllers\HomeController.cs", @"D:\dsfgsdfg\GeekBrains\Mvc\Catalog\Catalog\Controllers\ProductController.cs"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<ICollection<string>> ReadFilesWithParams(params string[] filePaths)
        {
            var tasks = new List<Task<string[]>>();
            foreach (var filePath in filePaths)
            {
                if (System.IO.File.Exists(filePath))
                    tasks.Add(System.IO.File.ReadAllLinesAsync(filePath));
            }
            var result = await Task.WhenAll(tasks);

            return result
                .SelectMany(i => i)
                .ToArray();
        }
    }
}