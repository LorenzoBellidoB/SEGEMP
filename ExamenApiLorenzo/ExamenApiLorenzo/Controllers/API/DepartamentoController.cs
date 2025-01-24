using BL;
using DAL;
using ENT;
using Microsoft.AspNetCore.Mvc;


namespace ExamenApiLorenzo.Controllers.API
{
    [Route("api/departamentos")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        // GET: api/<DepartamentoController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>();
            try
            {
                listadoDepartamentos = ClsListadosBl.GetDepartamentos();
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
            ClsDepartamento departamento = new ClsDepartamento();

            try
            {
                departamento = ClsListadosBl.GetDepartamento(id);
                salida = Ok(departamento);
            }
            catch (Exception ex) 
            { 
                salida= BadRequest(ex.Message);
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
