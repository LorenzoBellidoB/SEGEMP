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

        public IActionResult Conexion()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Conexion(Conexion conex)
        {
            try
            {
                conex = new Conexion();
                using (SqlConnection con = conex.ObtenerConexion())
                {
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        ViewBag.estado = "Conexi�n exitosa";
                    }
                    else
                    {
                        ViewBag.estado = "Error: la conexi�n no pudo establecerse";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.estado = "Error al intentar conectar con la base de datos";
            }

            return View();
        }
    }

}
