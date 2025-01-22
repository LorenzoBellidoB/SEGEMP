using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenAjax.Controllers.API
{
    [Route("api/persona")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        // GET: api/<ApiController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            try
            {
                List<ClsPersona> listadoPersona = ClsListadosBl.ListadoPersonasBL();
                salida = Ok(listadoPersona);
            }catch(Exception ex)
            {
                salida = BadRequest(ex.Message);
            }
            return salida;
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            try
            {
                ClsPersona persona = ClsListadosBl.BuscarPersonaBL(id);
                salida = Ok(persona);
            }catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }
            return salida;
        }

        // POST api/<ApiController>
        [HttpPost]
        public IActionResult Post(ClsPersona persona)
        {
            if (persona == null)
            {
                return BadRequest("La persona no puede ser nula");
            }
            else
            {
                try
                {
                    return Ok(ClsListadosBl.AddPersonaBL(persona));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ClsPersona persona)
        {
            if (persona == null)
            {
                return BadRequest("La persona no puede ser nula");
            }
            else
            {
                try
                {
                    return Ok(ClsListadosBl.UpdatePersonaBL(id, persona));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(ClsListadosBl.DeletePersonaBL(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
