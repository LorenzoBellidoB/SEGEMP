using BL;
using Mandaloriano.Models;
using Mandaloriano.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mandaloriano.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            try
            {
                ListadoPersonaVM listadoPersonaVM = new ListadoPersonaVM();

                listadoPersonaVM.Listado = ClsAcceso.ListadoCompletoMisionesBl();

                return View(listadoPersonaVM);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            ListadoPersonaVM listadoPersonaVM = new ListadoPersonaVM();

            listadoPersonaVM.Listado = ClsAcceso.ListadoCompletoMisionesBl();

            listadoPersonaVM.MisionSelected = ClsAcceso.MisionSelectedBl(id);

            return View(listadoPersonaVM);
        }


    }
}
