using Ejercicio2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio2.Controllers
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
        /// Acción POST para la vista principal.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <returns>Vista de saludo.</returns>
        [HttpPost]
        public IActionResult Index(string nombre)
        {
            ViewBag.Nombre = nombre;
            return View("Saludo");
        }

        /// <summary>
        /// Acción para la vista de saludo.
        /// </summary>
        /// <returns>Vista de saludo.</returns>
        public IActionResult Saludo()
        {
            return View();
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
