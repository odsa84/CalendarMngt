using CalendarMngt.Entidades;
using CalendarMngt.Entidades.ECliente;
using CalendarMngt.Entidades.EClinica;
using CalendarMngt.Entidades.EEstado;
using CalendarMngt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CalendarMngt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    [Authorize]    
    public class EstadoController : ControllerBase
    {

        private readonly IRepositorioEstado repositorioEstado;

        public EstadoController(IRepositorioEstado repositorioEstado)
        {
            this.repositorioEstado = repositorioEstado;
        }

        // GET api/values
        [HttpGet]
        [Route("ConsultarEstado")]
        public IActionResult Get()
        {
            return Ok(new EBodyConsultarPor());
        }

        // GET api/values/5
       /* [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }*/

        [HttpPost]
        [Route("InsertarEstado")]
        public ERespuestaEstado Insertar(EInEstado entrada)
        {
            ERespuestaEstado respuesta = repositorioEstado.Insertar(entrada);

            return respuesta;
        }

        [HttpPost]
        [Route("ConsultarEstado")]
        public ERespuestaEstado Consultar()
        {
            ERespuestaEstado result = new ERespuestaEstado();
            result.Estados = repositorioEstado.Consultar();

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("PorId")]
        public ERespuestaEstado ConsultarPorId(EBodyConsultarPor entrada)
        {
            ERespuestaEstado result = new ERespuestaEstado();
            EOutEstado aux = repositorioEstado.ConsultarPorId(entrada.Id);
            if (aux != null)
                result.Estados.Add(aux);

            return ValidarRespuesta(result);
        }        

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private ERespuestaEstado ValidarRespuesta(ERespuestaEstado result)
        {
            if (result.Estados.Count == 0)
            {
                result.Error.Codigo = "01";
                result.Error.Mensaje = "No se encontraron datos en la base";
            }
            else
            {
                result.Error.Codigo = "00";
                result.Error.Mensaje = "Ok";
            }

            return result;
        }
    }
}