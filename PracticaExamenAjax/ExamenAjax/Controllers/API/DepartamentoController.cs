using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamenAjax.Controllers.API
{
    [Route("api/departamento")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        // GET: api/<DepartamentoController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            try
            {
                List<ClsDepartamento> listadoDepartamentos = ClsListadosBl.ListadoDepartamentosBL();
                salida = Ok(listadoDepartamentos);
            }
            catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }
            return salida;
        }

        // GET api/<DepartamentoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            try
            {
                ClsDepartamento departamento = ClsListadosBl.BuscarDepartamentoBL(id);
                salida = Ok(departamento);
            }
            catch (Exception ex)
            {
                salida = BadRequest(ex.Message);
            }
            return salida;
        }

        // POST api/<DepartamentoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartamentoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartamentoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
