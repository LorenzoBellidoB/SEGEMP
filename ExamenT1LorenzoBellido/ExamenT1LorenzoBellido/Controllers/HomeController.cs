using BL;
using ENT;
using ExamenT1LorenzoBellido.Models;
using ExamenT1LorenzoBellido.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamenT1LorenzoBellido.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Muestra la pagina principal con un desplegable de Misiones
        /// </summary>
        /// <returns>Listado de misiones</returns>
        public IActionResult Index()
        {
            // Me faltan los try catch

            MisionParaCandidatoVM misionParaCandidatoVM = new MisionParaCandidatoVM();
            return View(misionParaCandidatoVM);
        }

        /// <summary>
        /// Pone debajo una tabla de candidatos
        /// </summary>
        /// <param name="idMision">Id de la mision</param>
        /// <returns>Tabla de candicatos segun la mision</returns>
        
        [HttpPost]
        public IActionResult Index(int idMision)
        {
            // Me faltan los try catch
            MisionParaCandidatoVM misionParaCandidatoVM = new MisionParaCandidatoVM(idMision);

            return View(misionParaCandidatoVM);
        }

        /// <summary>
        /// Muestra los detalles de un candidato segun su id
        /// </summary>
        /// <param name="id">Id del candidato</param>
        /// <returns>Devuleve un candidato con sus detalles</returns>
        public IActionResult DetallesCandidato(int id)
        {
            // Me faltan los try catch
            ClsCandidato candidato = ClsListadosBl.buscarCandidatoPorIdBl(id);

            return View(candidato);
        }

    }
}
