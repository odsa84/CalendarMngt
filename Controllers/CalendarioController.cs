using CalendarMngt.Entidades;
using CalendarMngt.Entidades.ECalendario;
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
    //[Authorize]    
    public class CalendarioController : ControllerBase
    {

        private readonly IRepositorioCalendario repositorioCalendario;

        public CalendarioController(IRepositorioCalendario repositorioCalendario)
        {
            this.repositorioCalendario = repositorioCalendario;
        }

        // GET api/values
        [HttpGet]
        [Route("ConsultarCalendario")]
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
        [Route("InsertarCalendario")]
        public ERespuestaCalendario Insertar(EInCalendario entrada)
        {
            ERespuestaCalendario respuesta = repositorioCalendario.Inertar(entrada);

            return respuesta;
        }

        [HttpPost]
        [Route("UpdateCalendario")]
        public ERespuestaCalendario Actualizar(EInCalendario entrada)
        {
            ERespuestaCalendario respuesta = repositorioCalendario.Actualizar(entrada);

            return respuesta;
        }

        [HttpPost]
        [Route("ConsultarCalendario")]
        public ERespuestaCalendario Consultar()
        {
            ERespuestaCalendario result = new ERespuestaCalendario();
            result.Calendarios = repositorioCalendario.Consultar();

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("CitasAgendadas")]
        public ERespuestaCalendario ConsultarAgendadas()
        {
            ERespuestaCalendario result = new ERespuestaCalendario();
            result.Calendarios = repositorioCalendario.ConsultarAgendadas();

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("ConsultarClientes")]
        public ERespuestaCliente ConsultarClientes()
        {
            ERespuestaCliente result = new ERespuestaCliente();
            result.Clientes = repositorioCalendario.ConsultarClientes();

            return ValidarRespuestaClientes(result);
        }

        [HttpPost]
        [Route("PorId")]
        public ERespuestaCalendario ConsultarPorId(EBodyConsultarPor entrada)
        {
            ERespuestaCalendario result = new ERespuestaCalendario();
            EOutCalendario aux = repositorioCalendario.ConsultarPorId(entrada.Id);
            if (aux != null)
                result.Calendarios.Add(aux);

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("PorClinica")]
        public ERespuestaCalendario ConsultarPorClinica(EBodyConsultarPor entrada)
        {
            ERespuestaCalendario result = new ERespuestaCalendario();
            result.Calendarios = repositorioCalendario.ConsultarPorClinica(entrada.Id);

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("PorDoctor")]
        public ERespuestaCalendario ConsultarPorDoctor(EBodyConsultarPor entrada)
        {
            ERespuestaCalendario result = new ERespuestaCalendario();
            result.Calendarios = repositorioCalendario.ConsultarPorDoctor(entrada.Id);

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("PorCliente")]
        public ERespuestaCalendario ConsultarPorCliente(EBodyConsultarPor entrada)
        {
            ERespuestaCalendario result = new ERespuestaCalendario();
            result.Calendarios = repositorioCalendario.ConsultarPorCliente(entrada.Id);

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("PorEstado")]
        public ERespuestaCalendario ConsultarPorEstado(EBodyConsultarPor entrada)
        {
            ERespuestaCalendario result = new ERespuestaCalendario();
            result.Calendarios = repositorioCalendario.ConsultarPorEstado(entrada.Id);

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("PorFecha")]
        public ERespuestaCalendario ConsultarPorFecha(EBodyConsultarPorFecha entrada)
        {
            ERespuestaCalendario result = new ERespuestaCalendario();
            result.Calendarios = repositorioCalendario.ConsultarPorFecha(entrada.Fecha);

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

        private ERespuestaCalendario ValidarRespuesta(ERespuestaCalendario result)
        {
            if (result.Calendarios.Count == 0)
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

        private ERespuestaCliente ValidarRespuestaClientes(ERespuestaCliente result)
        {
            if (result.Clientes.Count == 0)
            {
                result.Error.Codigo = "00";
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