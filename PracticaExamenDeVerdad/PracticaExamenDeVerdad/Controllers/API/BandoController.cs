using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticaExamenDeVerdad.Controllers.API
{
    [Route("api/bandos")]
    [ApiController]
    public class BandoController : ControllerBase
    {
        // GET: api/<BandoController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            try
            {
                List<ClsBando> listadoBandos = ClsListadoBl.GetBandos();
                salida = Ok(listadoBandos);
            }
            catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }
            return salida;
        }

        // GET api/<BandoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            try
            {
                ClsBando bando = ClsListadoBl.GetBando(id);
                salida = Ok(bando);
            }
            catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }
            return salida;
        }
    }
}
