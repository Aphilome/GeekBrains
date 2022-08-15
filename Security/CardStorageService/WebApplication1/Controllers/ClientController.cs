using Microsoft.AspNetCore.Mvc;

namespace CardStorageService.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
