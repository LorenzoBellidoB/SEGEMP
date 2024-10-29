using Ejercicio04.Models;
using Ejercicio04.Models.DAL;
using Ejercicio04.Models.ENT;
using Ejercicio04.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio04.Controllers
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

        public ActionResult EditarPersona()
        {
            ClsPersona persona = ClsListado.ObtenerPersonaAleatoria(); // Llamada al método estático

            var viewModel = new ClsEditarPersonaVM
            {
                nombre = persona.nombre,
                apellidos = persona.apellidos,
                idDepartamento = persona.idDepartamento
            };

            return View(viewModel);
        }
        // A este action se accede cuando el usuario pulsa el botón en la vista tipo submit
        //[HttpPost]
        //public ActionResult EditarPersona(string Nombre)
        //{
        //    ClsPersona persona = ClsListado.ObtenerPersonaAleatoria(); // Llamada al método estático

        //    var viewModel = new ClsEditarPersonaVM
        //    {
        //        nombre = Nombre,
        //        apellidos = persona.apellidos,
        //        idDepartamento = persona.idDepartamento
        //    };

        //    return View(viewModel);
        //}
        [HttpPost]
        public ActionResult EditarPersona(ClsPersona persona)
        {

            var viewModel = new ClsEditarPersonaVM
            {
                nombre = persona.nombre,
                apellidos = persona.apellidos,
                idDepartamento = persona.idDepartamento
            };

            return View(viewModel);
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
