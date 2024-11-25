using BL;
using CrudAsp.Models;
using ENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudAsp.Controllers
{
    public class PersonaController : Controller
    {
        // GET: PersonaController
        public ActionResult Index()
        {
            try
            {
                ClsListadoPersonasConNombreDept listado = new ClsListadoPersonasConNombreDept();

                return View(listado.ListadoPersonasNombreDept);
            }catch (Exception ex)
            {
                return View("Error");
            }
            
        }

        // GET: PersonaController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ClsPersonaConNombreDepartamento persona = new ClsPersonaConNombreDepartamento(id);

                return View(persona);
            }catch (Exception ex)
            {
                return View("Error");
            }
            
        }

        // GET: PersonaController/Create
        public ActionResult Create(int id)
        {
            ClsPersona persona = ClsServiciosBl.buscarPersonaBl(id);

            return View(persona);
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClsPersona persona)
        {
            try
            {
                int row = ClsServiciosBl.insertarPersonaBl(persona);

                ViewBag.Row = row;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Edit/5
        public ActionResult Edit(int id)
        {
            ClsPersona persona = ClsServiciosBl.buscarPersonaBl(id);
            return View(persona);
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClsPersona persona)
        {
            try
            {
                ClsServiciosBl.updatePersonaBl(persona);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                ClsPersona persona = ClsServiciosBl.buscarPersonaBl(id);

                return View(persona);
            }
            catch
            {
                return View("Error");
            }
            
        }

        // POST: PersonaController/Delete/5
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                int row = ClsServiciosBl.deletePersonaBl(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
