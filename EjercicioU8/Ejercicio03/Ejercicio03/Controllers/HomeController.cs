using Ejercicio03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ejercicio03ENT;

namespace Ejercicio03.Controllers
{
    /// <summary>
    /// Controlador principal para manejar las acciones de la aplicación.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Constructor del controlador HomeController.
        /// </summary>
        /// <param name="logger">Instancia de ILogger para el controlador.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Acción para la vista principal.
        /// </summary>
        /// <returns>Vista principal.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Acción para la vista de edición.
        /// </summary>
        /// <returns>Vista de edición.</returns>
        public ActionResult Editar()
        {
            return View();
        }

        /// <summary>
        /// Acción POST para editar una persona.
        /// </summary>
        /// <param name="persona">Objeto ClsPersona con los datos de la persona.</param>
        /// <returns>Vista PersonaModificada con los datos de la persona.</returns>
        [HttpPost]
        public ActionResult Editar(ClsPersona persona)
        {
            string idPersona = persona.IdPersona;
            string nombre = persona.Nombre;
            string apellidos = persona.Apellidos;
            string edad = persona.Edad;
            return View("PersonaModificada", persona);
        }

        /// <summary>
        /// Acción para la vista de privacidad.
        /// </summary>
        /// <returns>Vista de privacidad.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
