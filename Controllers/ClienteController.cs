using CalendarMngt.Entidades;
using CalendarMngt.Entidades.ECliente;
using CalendarMngt.Entidades.EClinica;
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
    public class ClienteController : ControllerBase
    {

        private readonly IRepositorioCliente repositorioCliente;

        public ClienteController(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        // GET api/values
        [HttpGet]
        [Route("ConsultarCliente")]
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

        [AllowAnonymous]
        [HttpPost]
        [Route("InsertarCliente")]
        public ERespuestaCliente Insertar(EInCliente entrada)
        {
            ERespuestaCliente respuesta = repositorioCliente.Inertar(entrada);

            return respuesta;
        }

        [HttpPost]
        [Route("ConsultarCliente")]
        public ERespuestaCliente Consultar()
        {
            ERespuestaCliente result = new ERespuestaCliente();
            result.Clientes = repositorioCliente.Consultar();

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("PorId")]
        public ERespuestaCliente ConsultarPorId(EBodyConsultarPor entrada)
        {
            ERespuestaCliente result = new ERespuestaCliente();
            EOutCliente aux = repositorioCliente.ConsultarPorId(entrada.Id);
            if (aux != null)
                result.Clientes.Add(aux);

            return ValidarRespuesta(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PorCedula")]
        public ERespuestaCliente ConsultarPorCedula(EBodyConsultarCedula entrada)
        {
            ERespuestaCliente result = new ERespuestaCliente();
            EOutCliente aux = repositorioCliente.ConsultarPorCedula(entrada.Cedula);
            if (aux != null)
                result.Clientes.Add(aux);

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

        private ERespuestaCliente ValidarRespuesta(ERespuestaCliente result)
        {
            if (result.Clientes.Count == 0)
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