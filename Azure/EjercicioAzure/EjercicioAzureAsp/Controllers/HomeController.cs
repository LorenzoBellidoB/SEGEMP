using EjercicioAzureAsp.Models;
using ENT;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EjercicioAzureAsp.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            List<ClsPersona> personas = DAL.ListadoDal.ListadoCompletoDal();
                return View(personas);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
    }
}
