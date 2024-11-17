using System.Diagnostics;
using BL;
using Ejercicio03.Models;
using Ejercicio03.ViewModels;
using ENT;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio03.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            try
            {

                ListadoCochesVM listadoCochesVM = new ListadoCochesVM();

                listadoCochesVM.ListadoMarcas = ClsListadoCochesBl.ObtenerMarcasBl();

                listadoCochesVM.ListadoModelos = null;

                return View(listadoCochesVM);


            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            try
            {

                ListadoCochesVM listadoCochesVM = new ListadoCochesVM();

                listadoCochesVM.ListadoMarcas = ClsListadoCochesBl.ObtenerMarcasBl();

                listadoCochesVM.ListadoModelos = ClsListadoCochesBl.ObtenerModelosBl();
                                

                return View(listadoCochesVM);

            }catch (Exception ex)
            {

                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

    }
}
