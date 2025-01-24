using BL;
using ENT;
using ExamenApiLorenzo.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenApiLorenzo.Controllers.API
{
    [Route("api/personas")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        // GET: api/<PersonaController>
        [HttpGet("{idDpt}")]
        public IActionResult Get(int idDpt)
        {
            IActionResult salida;
            List<ClsPersona> listadoPersonas = ClsListadosBl.GetPersonaDepartamento(idDpt);
            try
            {
                List<PersonaConNombreDptEdad> listadoPersonajesDptEdad = new List<PersonaConNombreDptEdad>();
                foreach (ClsPersona persona in listadoPersonas)
                {
                    PersonaConNombreDptEdad personaDptEdad = new PersonaConNombreDptEdad(persona);
                    listadoPersonajesDptEdad.Add(personaDptEdad);
                }
                salida = Ok(listadoPersonajesDptEdad);
            }
            catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }
            return salida;
        }

        
    }
}
