using Microsoft.AspNetCore.Mvc;

namespace CardStorageService.Controllers
{
    public class CardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
