using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EClinicaDoctor;
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

        [AllowAnonymous]
        [HttpPost]
        [Route("ConsultarDoctor")]
        public ERespuestaClinicaDoctor Consultar()
        {
            ERespuestaClinicaDoctor result = new ERespuestaClinicaDoctor()
            {
                Doctores = repositorioDoctor.Consultar()
            };

            return ValidarRespuestaClinicaDoctor(result);
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

        [AllowAnonymous]
        [HttpGet("Clinica/{cli}")]
        public ERespuestaClinicaDoctor ConsultarPorClinica(long cli)
        {
            ERespuestaClinicaDoctor result = new ERespuestaClinicaDoctor()
            {
                Doctores = repositorioDoctor.ConsultarPorClinica(cli)
            };

            return ValidarRespuestaClinicaDoctor(result);
        }

        [AllowAnonymous]
        [HttpPost("PorCiudadEsp")]
        public ERespuestaClinicaDoctor ConsultaAvanzada(EBodyConsultarPorCiudadEsp entrada)
        {
            ERespuestaClinicaDoctor result = new ERespuestaClinicaDoctor()
            {
                Doctores = repositorioDoctor.ConsultaAvanzada(entrada.IdCiudad, entrada.IdEspecialidad)
            };

            return ValidarRespuestaClinicaDoctor(result);
        }

        [AllowAnonymous]
        [HttpPost("PorClinicaEsp")]
        public ERespuestaClinicaDoctor ConsultaPorClinicaEspecialidad(EBodyConsultarPorClinicaEsp entrada)
        {
            ERespuestaClinicaDoctor result = new ERespuestaClinicaDoctor()
            {
                Doctores = repositorioDoctor.ConsultaPorClinicaEspecialidad(entrada.IdClinica, entrada.IdEspecialidad)
            };

            return ValidarRespuestaClinicaDoctor(result);
        }

        private ERespuestaDoctor ValidarRespuesta(ERespuestaDoctor result)
        {
            if (result.Doctores.Count == 0)
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

        private ERespuestaClinicaDoctor ValidarRespuestaClinicaDoctor(ERespuestaClinicaDoctor result)
        {
            if (result.Doctores.Count == 0)
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