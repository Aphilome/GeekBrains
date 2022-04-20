using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Timesheets.Models;

namespace Timesheets.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        /*
         
         POST   /api/contracts/create
         GET    /api/contracts/get-all
         GET    /api/contracts/get?id={}
         PUT    /api/contracts/edit?id={}    {body}
         DELETE /api/contracts/delete?id={}
         PUT    /api/contracts/set-invoice?id={}&invoice-id={}
         PUT    /api/contracts/set-task?id={}&task-id={}
        
         POST   /api/clients/create
         GET    /api/clients/get-all
         GET    /api/clients/get?id={}
         PUT    /api/clients/edit?id={}    {body}
         DELETE /api/clients/delete?id={}
         PUT    /api/clients/set-invoice?id={}&invoice-id={}
         PUT    /api/clients/pay-invoice?id={}

         POST   /api/employees/create
         GET    /api/employees/get-all
         GET    /api/employees/get?id={}
         PUT    /api/employees/edit?id={}    {body}
         DELETE /api/employees/delete?id={}
         PUT    /api/employees/set-task?id={}&task-id={}

         POST   /api/invoices/create
         GET    /api/invoices/get-all
         GET    /api/invoices/get?id={}
         PUT    /api/invoices/edit?id={}    {body}
         DELETE /api/invoices/delete?id={}

         POST   /api/tasks/create
         GET    /api/tasks/get-all
         GET    /api/tasks/get?id={}
         PUT    /api/tasks/edit?id={}    {body}
         DELETE /api/tasks/delete?id={}
        
         */

    }
}