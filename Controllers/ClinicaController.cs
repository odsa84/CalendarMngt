using CalendarMngt.Entidades;
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
    public class ClinicaController : ControllerBase
    {

        private readonly IRepositorioClinica repositorioClinica;

        public ClinicaController(IRepositorioClinica repositorioClinica)
        {
            this.repositorioClinica = repositorioClinica;
        }

        // GET api/values
        [HttpGet]
        [Route("ConsultarClinica")]
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
        [Route("InsertarClinica")]
        public ERespuesta Insertar(EInClinica entrada)
        {
            ERespuesta respuesta = repositorioClinica.Inertar(entrada);

            return respuesta;
        }

        [HttpPost]
        [Route("ActualizarClinica")]
        public ERespuesta Actualizar(EInClinica entrada)
        {
            ERespuesta respuesta = repositorioClinica.Actualizar(entrada);

            return respuesta;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ConsultarClinica")]
        public ERespuesta Consultar()
        {
            ERespuesta result = new ERespuesta();
            result.Clinicas = repositorioClinica.Consultar();

            return ValidarRespuesta(result);
        }

        [HttpGet("{usr}")]
        public ERespuesta ConsultarPorUsuario(string usr)
        {
            ERespuesta result = new ERespuesta();
            result.Clinicas = repositorioClinica.ConsultarPorUsuario(usr);

            return ValidarRespuesta(result);
        }

        [HttpGet("doctor/{doc}")]
        public ERespuesta ConsultarPorDoctor(long doc)
        {
            ERespuesta result = new ERespuesta();
            result.Clinicas = repositorioClinica.ConsultarPorDoctor(doc);

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("ClinicaPorId")]
        public ERespuesta ConsultarPorId(EBodyConsultarPor entrada)
        {
            ERespuesta result = new ERespuesta();
            EOutClinica aux = repositorioClinica.ConsultarPorId(entrada.Id);
            if (aux != null)
                result.Clinicas.Add(aux);

            return ValidarRespuesta(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PorCiudadEsp")]
        public ERespuesta ConsultaAvanzada(EBodyConsultarPorCiudadEsp entrada)
        {
            ERespuesta result = new ERespuesta();
            result.Clinicas = repositorioClinica.ConsultaAvanzada(entrada.IdCiudad, entrada.IdEspecialidad);

            return ValidarRespuesta(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PorCiudad")]
        public ERespuesta ConsultaAvanzadaPorCiudad(EBodyConsultarPorCiudadEsp entrada)
        {
            ERespuesta result = new ERespuesta();
            result.Clinicas = repositorioClinica.ConsultaAvanzadaPorCiudad(entrada.IdCiudad);

            return ValidarRespuesta(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PorEspecialidad")]
        public ERespuesta ConsultaAvanzadaPorEspecialidad(EBodyConsultarPorCiudadEsp entrada)
        {
            ERespuesta result = new ERespuesta();
            result.Clinicas = repositorioClinica.ConsultaAvanzadaPorEspecialidad(entrada.IdEspecialidad);

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

        private ERespuesta ValidarRespuesta(ERespuesta result)
        {
            if (result.Clinicas.Count == 0)
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