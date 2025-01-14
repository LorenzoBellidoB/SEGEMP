using BL;
using CrudAsp.Models;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudAsp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaApiController : ControllerBase
    {
        // GET: api/<PersonaApiController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            try
            {
                ClsListadoPersonasConNombreDept listado = new ClsListadoPersonasConNombreDept();
                salida = Ok(listado.ListadoPersonasNombreDept);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                salida = BadRequest(ex.Message);
            }

            return salida;
        }

        // GET api/<PersonaApiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            if (id <= 0)
            {
                salida = BadRequest("El id debe ser mayor a 0");
            }
            else
            {
                try
                {
                    ClsPersonaConNombreDepartamento persona = new ClsPersonaConNombreDepartamento(id);
                    if (persona == null)
                    {
                        salida = NotFound("No se ha encontrado la persona");
                    }
                    else
                    {
                        salida = Ok(persona);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    salida = BadRequest(ex.Message);
                }
            }



            return salida;
        }

        // POST api/<PersonaApiController>
        [HttpPost]
        public IActionResult Post(ClsPersona persona)
        {
            IActionResult salida;
            if (persona == null)
            {
                salida = BadRequest("La persona no puede ser nula");

            }
            else
            {
                try
                {
                    ClsServiciosBl.insertarPersonaBl(persona);
                    salida = Ok("Persona insertada correctamente");

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    salida = BadRequest(ex.Message);

                }
            }
            return salida;
        }

        // PUT api/<PersonaApiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ClsPersona persona)
        {
            IActionResult salida;

            if (id <= 0)
            {
                salida = BadRequest("El id debe ser mayor a 0");
            }
            else
            {
                try
                {
                    ClsServiciosBl.updatePersonaBl(persona);
                    salida = Ok("Persona actualizada correctamente");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    salida = BadRequest(ex.Message);
                }

            }
            return salida;
        }

        // DELETE api/<PersonaApiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            if (id <= 0)
            {
                salida = BadRequest("El id debe ser mayor a 0");
            }
            else
            {
                try
                {
                    ClsServiciosBl.deletePersonaBl(id);
                    salida = Ok("Persona borrada correctamente");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    salida = BadRequest(ex.Message);
                }
            }
            return salida;
        }
    }
}
