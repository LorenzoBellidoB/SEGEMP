using Ejercicio1GTP.Models;
using Ejercicio1GTP.Models.DAL;
using Ejercicio1GTP.Models.ENT;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using PersonaViewModel = Ejercicio1GTP.Models.ENT.PersonaViewModel;

namespace Ejercicio1GTP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditarPersona()
        {
            var persona = DataAccessLayer.ObtenerPersonaAleatoria();
            var viewModel = new PersonaViewModel
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellidos = persona.Apellidos,
                IdDepartamento = persona.IdDepartamento,
                Departamentos = DataAccessLayer.ObtenerDepartamentos()
            };

            return View(viewModel);
        }

      
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
