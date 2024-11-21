using System.Diagnostics;
using Ejercicio01.Models;
using Ejercicio01.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio01.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            List<ClsPersonaConCheck> listadoPersonasCheck = ListadoPersonaVM.ListadoPersonasConCheck;
            return View(listadoPersonasCheck);
        }

    }
}
