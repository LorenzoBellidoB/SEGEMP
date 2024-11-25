using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;
using PracticaExamen.Models;
using PracticaExamen.Models.VM;
using System.Diagnostics;

namespace PracticaExamen.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            List<ClsMafioso> listadoMafiosos = ClsListadosBL.obtenerTodosLosMafiososBL();
            return View(listadoMafiosos);
        }

        public IActionResult Details(int id)
        {
            MisionMafiososVM misiones = new MisionMafiososVM(id);

            return View(misiones);
        }

        public IActionResult Delete(int id)
        {
            ClsMafioso mafioso = ClsListadosBL.obtenerMafiosoPorIdBL(id);
            return View(mafioso);
        }

        [HttpPost]
        public IActionResult Delete(ClsMafioso mafioso)
        {
            try
            {
                ClsListadosBL.borrarMafiosoPorIdDAL(mafioso.Id);
                return View("Index");
            }
            catch (Exception ex) {
                return View();
            }

        }

    }
}
