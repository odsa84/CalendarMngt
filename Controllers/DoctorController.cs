using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EDoctor;
using CalendarMngt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalendarMngt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly IRepositorioDoctor repositorioDoctor;

        public DoctorController(IRepositorioDoctor repositorioDoctor)
        {
            this.repositorioDoctor = repositorioDoctor;
        }

        [HttpGet]
        [Route("ConsultarDoctor")]
        public IActionResult Get()
        {
            return Ok(new EInDoctor());
        }

        [HttpPost]
        [Route("ConsultarDoctor")]
        public ERespuestaDoctor Consultar()
        {
            ERespuestaDoctor result = new ERespuestaDoctor();
            result.Doctores = repositorioDoctor.Consultar();

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("InsertarDoctor")]
        public ERespuestaDoctor Insertar(EInDoctor entrada)
        {
            ERespuestaDoctor respuesta = repositorioDoctor.Insertar(entrada);

            return respuesta;
        }

        [HttpGet("{id}")]
        public ERespuestaDoctor ConsultarPorId(long id)
        {
            ERespuestaDoctor result = new ERespuestaDoctor();
            EOutDoctor aux = repositorioDoctor.ConsultarPorId(id);
            if (aux != null)
                result.Doctores.Add(aux);

            return ValidarRespuesta(result);
        }

        [HttpGet("Clinica/{cli}")]
        public ERespuestaDoctor ConsultarPorClinica(long cli)
        {
            ERespuestaDoctor result = new ERespuestaDoctor()
            {
                Doctores = repositorioDoctor.ConsultarPorClinica(cli),
            };

            return ValidarRespuesta(result);
        }

        private ERespuestaDoctor ValidarRespuesta(ERespuestaDoctor result)
        {
            if (result.Doctores.Count == 0)
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