using System.Diagnostics;
using BL01;
using Ejercicio01.Models;
using Ejercicio01.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Ejercicio01.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ejercicio01()
        {
            try
            {
                ListadoPersonasVM listadoPersonaVM = new ListadoPersonasVM();
                listadoPersonaVM.ListadoPersonas = ListadoPersonasBl.ObtenerListadoPersonasBl();
                foreach (var persona in listadoPersonaVM.ListadoPersonas)
                {
                    listadoPersonaVM.ListadoPersonasConCheck = new List<PersonaConCheck>(); 
                    // Crear un objeto PersonaConCheck basado en la información de Persona
                    var personaConCheck = new PersonaConCheck(persona, false);

                    // Agregarlo a la nueva lista
                    listadoPersonaVM.ListadoPersonasConCheck.Add(personaConCheck);
                }

                return View(listadoPersonaVM.ListadoPersonasConCheck);
            }
            catch (Exception ex)
            {
                
                return View("Error");
            }

        }

    }
}
