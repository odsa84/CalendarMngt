﻿using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EHorasLaborales;
using CalendarMngt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CalendarMngt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    [Authorize]
    public class HorasLaboralesController : Controller
    {
        private readonly IRepositorioHorasLaborales respositorioHorasLaborales;

        public HorasLaboralesController(IRepositorioHorasLaborales respositorioHorasLaborales)
        {
            this.respositorioHorasLaborales = respositorioHorasLaborales;
        }

        [HttpGet]
        [Route("ConsultarHorasLaborales")]
        public IActionResult Get()
        {
            return Ok(new EHorasLaborales());
        }

        [HttpPost]
        [Route("InsertarHorasLaborales")]
        public void Insertar(EHorasLaborales entrada)
        {
            respositorioHorasLaborales.Insertar(entrada);
        }

        [HttpPost]
        [Route("ConsultarActualizarDisponibilidad")]
        public ERespuestaHorasLaborales ConsultarActualizarDisponibilidad(EInHoras entrada)
        {
            ERespuestaHorasLaborales respuesta = respositorioHorasLaborales.ConsultarActualizarDisponibilidad(entrada);

            return respuesta;
        }

        [HttpPost]
        [Route("ActualizarDisponibilidad")]
        public ERespuestaHorasLaborales ActualizarDisponibilidad(EInHoras entrada)
        {
            ERespuestaHorasLaborales respuesta = respositorioHorasLaborales.ActualizarDisponibilidad(entrada);

            return respuesta;
        }

        [HttpPost]
        [Route("ConsultarPorDoctor")]
        public ERespuestaHorasLaborales ConsultarPorDoctor(EBodyConsultarPor entrada)
        {
            ERespuestaHorasLaborales result = new ERespuestaHorasLaborales()
            {
                HorasLaborales = respositorioHorasLaborales.ConsultarPorDoctor(entrada.Id)
            };

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("ConsultarPorDoctorClinica")]
        public ERespuestaHorasLaborales ConsultarPorDoctorClinica(EHorasLaboralesDoctorClinica entrada)
        {
            ERespuestaHorasLaborales result = new ERespuestaHorasLaborales()
            {
                HorasLaborales = respositorioHorasLaborales.ConsultarPorDoctorClinica(entrada.IdDoctor, entrada.IdClinica)
            };

            return ValidarRespuesta(result);
        }

        [HttpPost]
        [Route("ConsultarPorDoctorClinicaFecha")]
        public ERespuestaHorasLaborales ConsultarPorDoctorClinicaFecha(EHorasLaboralesDoctorClinicaFecha entrada)
        {
            ERespuestaHorasLaborales result = new ERespuestaHorasLaborales()
            {
                HorasLaborales = respositorioHorasLaborales.ConsultarPorDoctorClinicaFecha(entrada.IdDoctor,
                entrada.IdClinica, entrada.Fecha)
            };

            return ValidarRespuesta(result);
        }

        private ERespuestaHorasLaborales ValidarRespuesta(ERespuestaHorasLaborales result)
        {
            if (result.HorasLaborales.Count == 0)
            {
                result.Error.Codigo = "01";
                result.Error.Mensaje = "No hay horarios que mostrar.";
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