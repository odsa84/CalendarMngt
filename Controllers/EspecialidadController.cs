using CalendarMngt.Entidades.EEspecialidad;
using CalendarMngt.Entidades.ETitulo;
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
    public class EspecialidadController : Controller
    {
        private readonly IRepositorioEspecialidad repositorioEspecialidad;

        public EspecialidadController(IRepositorioEspecialidad repositorioEspecialidad)
        {
            this.repositorioEspecialidad = repositorioEspecialidad;
        }

        [HttpGet]
        [Route("ConsultarEspecialidad")]
        public IActionResult Get()
        {
            return Ok(new EInEspecialidad());
        }

        [HttpPost]
        [Route("ConsultarEspecialidad")]
        public ERespuestaEspecialidad Consultar()
        {
            ERespuestaEspecialidad result = new ERespuestaEspecialidad()
            {
                Especialidades = repositorioEspecialidad.Consultar(),
            };

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("InsertarEspecialidad")]
        public ERespuestaEspecialidad Insertar(EInEspecialidad entrada)
        {
            ERespuestaEspecialidad respuesta = repositorioEspecialidad.Insertar(entrada);

            return respuesta;
        }

        [HttpGet("{id}")]
        public ERespuestaEspecialidad ConsultarPorId(long id)
        {
            ERespuestaEspecialidad result = new ERespuestaEspecialidad();
            EOutEspecialidad aux = repositorioEspecialidad.ConsultarPorId(id);
            if (aux != null)
                result.Especialidades.Add(aux);

            return ValidarRespuesta(result);
        }

        private ERespuestaEspecialidad ValidarRespuesta(ERespuestaEspecialidad result)
        {
            if (result.Especialidades.Count == 0)
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