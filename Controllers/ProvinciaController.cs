using CalendarMngt.Entidades;
using CalendarMngt.Entidades.ECiudad;
using CalendarMngt.Entidades.ECliente;
using CalendarMngt.Entidades.EClinica;
using CalendarMngt.Entidades.EEstado;
using CalendarMngt.Entidades.EProvincia;
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
    public class ProvinciaController : ControllerBase
    {

        private readonly IRepositorioProvincia repositorioProvincia;

        public ProvinciaController(IRepositorioProvincia repositorioProvincia)
        {
            this.repositorioProvincia = repositorioProvincia;
        }

        // GET api/values
        [HttpGet]
        [Route("ConsultarProvincia")]
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
        [Route("InsertarProvincia")]
        public ERespuestaProvincia Insertar(EInProvincia entrada)
        {
            ERespuestaProvincia respuesta = repositorioProvincia.Insertar(entrada);

            return respuesta;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ConsultarProvincia")]
        public ERespuestaProvincia Consultar()
        {
            ERespuestaProvincia result = new ERespuestaProvincia();
            result.Provincias = repositorioProvincia.Consultar();

            return ValidarRespuesta(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PorNombre")]
        public ERespuestaProvincia ConsultarPorNombre(EBodyConsultarPorNombre entrada)
        {
            ERespuestaProvincia result = new ERespuestaProvincia();
            result.Provincias = repositorioProvincia.ConsultarPorNombre(entrada.Nombre);

            return ValidarRespuesta(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PorId")]
        public ERespuestaProvincia ConsultarPorId(EBodyConsultarPor entrada)
        {
            ERespuestaProvincia result = new ERespuestaProvincia();
            EOutProvincia aux = repositorioProvincia.ConsultarPorId(entrada.Id);
            if (aux != null)
                result.Provincias.Add(aux);

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

        private ERespuestaProvincia ValidarRespuesta(ERespuestaProvincia result)
        {
            if (result.Provincias.Count == 0)
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