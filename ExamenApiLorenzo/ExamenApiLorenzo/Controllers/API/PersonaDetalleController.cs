using BL;
using ENT;
using ExamenApiLorenzo.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenApiLorenzo.Controllers.API
{
    [Route("api/persona/detalle")]
    [ApiController]
    public class PersonaDetalleController : ControllerBase
    {
    

        // GET api/<PersonaDetalleController>/5
        //GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            ClsPersona persona = new ClsPersona();

            try
            {
                persona = ClsListadosBl.GetPersona(id);
                if (persona == null)
                {
                    salida = BadRequest("Persona no encontrada");
                }
                else
                {
                    PersonaConNombreDptEdad personaDpt = new PersonaConNombreDptEdad(persona);
                    salida = Ok(personaDpt);
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
