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
    public class TituloController : Controller
    {
        private readonly IRepositorioTitulo repositorioTitulo;

        public TituloController(IRepositorioTitulo repositorioTitulo)
        {
            this.repositorioTitulo = repositorioTitulo;
        }

        [HttpGet]
        [Route("ConsultarTitulo")]
        public IActionResult Get()
        {
            return Ok(new EInTitulo());
        }

        [HttpPost]
        [Route("ConsultarTitulo")]
        public ERespuestaTitulo Consultar()
        {
            ERespuestaTitulo result = new ERespuestaTitulo()
            {
                Titulos = repositorioTitulo.Consultar(),
            };

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("InsertarTitulo")]
        public ERespuestaTitulo Insertar(EInTitulo entrada)
        {
            ERespuestaTitulo respuesta = repositorioTitulo.Insertar(entrada);

            return respuesta;
        }

        [HttpGet("{id}")]
        public ERespuestaTitulo ConsultarPorId(long id)
        {
            ERespuestaTitulo result = new ERespuestaTitulo();
            EOutTitulo aux = repositorioTitulo.ConsultarPorId(id);
            if (aux != null)
                result.Titulos.Add(aux);

            return ValidarRespuesta(result);
        }

        private ERespuestaTitulo ValidarRespuesta(ERespuestaTitulo result)
        {
            if (result.Titulos.Count == 0)
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