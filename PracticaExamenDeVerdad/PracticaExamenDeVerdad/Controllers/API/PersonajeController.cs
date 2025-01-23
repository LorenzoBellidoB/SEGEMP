using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;
using PracticaExamenDeVerdad.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaExamenDeVerdad.Controllers.API
{
    [Route("api/personajes")]
    [ApiController]
    public class PersonajeController : ControllerBase
    {
        // GET: api/<PersonajeController>
        [HttpGet]
        public IActionResult Get()
        {

            IActionResult salida;
            List<ClsPersonaje> listadoPersonajes = ClsListadoBl.GetPersonajes();
            try
            {
                List<ClsPersonajeConEdadBando> listadoPersonajesConEdadBando = new List<ClsPersonajeConEdadBando>();
                foreach (ClsPersonaje item in listadoPersonajes)
                {
                    ClsPersonajeConEdadBando clsPersonajeConEdadBando = new ClsPersonajeConEdadBando(item);
                    listadoPersonajesConEdadBando.Add(clsPersonajeConEdadBando);
                }
                salida = Ok(listadoPersonajesConEdadBando);
            }
            catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }
            return salida;
        }

        // GET api/<PersonajeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            ClsPersonaje personaje = ClsListadoBl.GetPersonaje(id);

            try
            {
                ClsPersonajeConEdadBando personajeConEdadBando = new ClsPersonajeConEdadBando(personaje);
                salida = Ok(personajeConEdadBando);
            }catch(Exception ex)
            {
                salida = BadRequest(ex.Message);
            }
            return salida;
        }

        // POST api/<PersonajeController>
        [HttpPost]
        public IActionResult Post(ClsPersonaje personaje)
        {
            IActionResult salida;
            try
            {
                if(personaje == null)
                {
                    salida = BadRequest("El personaje no puede ser nulo");
                }
                else
                {
                    if (ClsListadoBl.AddPersonaje(personaje))
                    {
                        salida = Ok(personaje);
                    }
                    else
                    {
                        salida = BadRequest("No se ha podido añadir el personaje");
                    }
                }
            }catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }
            return salida;
        }

        // PUT api/<PersonajeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ClsPersonaje personaje)
        {
            IActionResult salida;
            try
            {
                if (personaje == null)
                {
                    salida = BadRequest("El personaje no puede ser nulo");
                }
                else
                {
                    if (ClsListadoBl.UpdatePersonaje(id,personaje))
                    {
                        salida = Ok(personaje);
                    }
                    else
                    {
                        salida = BadRequest("No se ha podido actualizar el personaje");
                    }
                }
            }
            catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }
            return salida;
        }

        // DELETE api/<PersonajeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            try
            {
                if (ClsListadoBl.DeletePersonaje(id))
                {
                    salida = Ok();
                }
                else
                {
                    salida = BadRequest("No se ha podido borrar el personaje");
                }
            }
            catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }
            return salida;
        }
    }
}
