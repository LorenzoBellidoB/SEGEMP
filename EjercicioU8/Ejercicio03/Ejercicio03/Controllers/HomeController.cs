using Ejercicio03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ejercicio03ENT;

namespace Ejercicio03.Controllers
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

      
        public ActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editar(ClsPersona persona)
        {
            string idPersona = persona.IdPersona;
            string nombre = persona.Nombre;
            string apellidos = persona.Apellidos;
            string edad = persona.Edad;


            return View("PersonaModificada", persona);
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
