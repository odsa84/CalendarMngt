using CalendarMngt.Entidades;
using CalendarMngt.Entidades.ECiudad;
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
    public class CiudadController : ControllerBase
    {

        private readonly IRepositorioCiudad repositorioCiudad;

        public CiudadController(IRepositorioCiudad repositorioCiudad)
        {
            this.repositorioCiudad = repositorioCiudad;
        }

        // GET api/values
        [HttpGet]
        [Route("ConsultarCiudad")]
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
        [Route("InsertarCiudad")]
        public ERespuestaCiudad Insertar(EInCiudad entrada)
        {
            ERespuestaCiudad respuesta = repositorioCiudad.Insertar(entrada);

            return respuesta;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ConsultarCiudad")]
        public ERespuestaCiudad Consultar()
        {
            ERespuestaCiudad result = new ERespuestaCiudad();
            result.Ciudades = repositorioCiudad.Consultar();

            return ValidarRespuesta(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PorNombre")]
        public ERespuestaCiudad ConsultarPorNombre(EBodyConsultarPorNombre entrada)
        {
            ERespuestaCiudad result = new ERespuestaCiudad();
            result.Ciudades = repositorioCiudad.ConsultarPorNombre(entrada.Nombre);

            return ValidarRespuesta(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PorProvincia")]
        public ERespuestaCiudad ConsultarPorProvincia(EBodyConsultarPor entrada)
        {
            ERespuestaCiudad result = new ERespuestaCiudad();
            result.Ciudades = repositorioCiudad.ConsultarPorProvincia(entrada.Id);

            return ValidarRespuesta(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PorId")]
        public ERespuestaCiudad ConsultarPorId(EBodyConsultarPor entrada)
        {
            ERespuestaCiudad result = new ERespuestaCiudad();
            EOutCiudad aux = repositorioCiudad.ConsultarPorId(entrada.Id);
            if (aux != null)
                result.Ciudades.Add(aux);

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

        private ERespuestaCiudad ValidarRespuesta(ERespuestaCiudad result)
        {
            if (result.Ciudades.Count == 0)
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