using EjercicioAzure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DAL;
using DAL.Conexion;
using Microsoft.Data.SqlClient;


namespace EjercicioAzure.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult Conexiones()
        {

            Conexion conexion = new Conexion();
            try
            {
                conexion.ObtenerConexion();


                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    ViewBag.estado = "Conexión exitosa";
                }
                else
                {
                    ViewBag.estado = "Error: la conexión no pudo establecerse";
                }


            }
            catch (Exception ex)
            {

                ViewBag.estado = "Error al intentar conectar con la base de datos";
            }
            finally
            {
                conexion.Close();
            }

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }

}
