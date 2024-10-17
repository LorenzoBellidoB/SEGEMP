using Ejercicio1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio1.Controllers
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
            DateTime actual = DateTime.Now;
            if (actual.Hour <= 12 && actual.Hour >= 6)
            {
                ViewData["Hora"] = "Buenos dias";
            }
            else if(actual.Hour > 12 && actual.Hour <= 21)
            {
                ViewData["Hora"] = "Buenas tardes";
            }
            else
            {
                ViewData["Hora"] = "Buenas noches";
            }
            
            ViewBag["Fecha"] = actual;
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
    }
}
