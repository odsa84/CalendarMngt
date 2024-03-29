﻿using AutoMapper;
using CalendarMngt.Entidades.EHorasLaborales;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia;
using CalendarMngt.Repositorio.Persistencia.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio
{
    public class RepositorioHorasLaborales : IRepositorioHorasLaborales
    {
        private readonly OperacionesHorasLaborales operacionesdb;
        private readonly IMapper _mapper;

        public RepositorioHorasLaborales(IMapper _mapper)
        {
            this.operacionesdb = new OperacionesHorasLaborales(_mapper);
            this._mapper = _mapper;
        }

        public void Insertar(EHorasLaborales eHorasLaborales)
        {
            if(eHorasLaborales.toDeleteEvent.Count() > 0)
            {
                List<HorasLaborales> toDelete = new List<HorasLaborales>();
                eHorasLaborales.toDeleteEvent.ForEach(e => {
                    HorasLaborales h = new HorasLaborales
                    {
                        Id = e.Id
                    };
                    toDelete.Add(h);
                });

                operacionesdb.OpeDelete(toDelete);
            }

            eHorasLaborales.Horas.ForEach(e =>
            {
                EInHoras inHoras = new EInHoras
                {
                    Id = e.Id,
                    HoraInicio = e.HoraInicio,
                    HoraFin = e.HoraFin,
                    Fecha = e.Fecha,
                    IdDoctor = eHorasLaborales.IdDoctor,
                    IdClinica = eHorasLaborales.IdClinica,
                    Disponible = true
                };

                HorasLaborales hl = _mapper.Map<HorasLaborales>(inHoras);

                operacionesdb.OpeInsertar(hl);
            });
        }

        public ERespuestaHorasLaborales ActualizarDisponibilidad(EInHoras inHoras)
        {
            HorasLaborales hl = _mapper.Map<HorasLaborales>(inHoras);
            ERespuestaHorasLaborales respuesta = operacionesdb.OpeActualizarDisponibilidad(hl);

            return respuesta;
        }

        public ERespuestaHorasLaborales ConsultarActualizarDisponibilidad(EInHoras inHoras)
        {
            ERespuestaHorasLaborales respuesta = new ERespuestaHorasLaborales();

            HorasLaborales laborales = operacionesdb.OpeConsultarPorId(inHoras.Id);
            if(laborales != null)
            {
                if (laborales.Disponible == true)
                {
                    HorasLaborales hl = _mapper.Map<HorasLaborales>(inHoras);
                    hl.Disponible = false;
                    respuesta = operacionesdb.OpeActualizarDisponibilidad(hl);
                } else
                {
                    //respuesta.HorasLaborales.Add(_mapper.Map<EOutHoras>(laborales));
                    respuesta.Error.Codigo = "01";
                    respuesta.Error.Mensaje = "No Disponible";
                }
            } else
            {
                respuesta.Error.Codigo = "02";
                respuesta.Error.Mensaje = "No existe el horario seleccionado";
            }           

            return respuesta;
        } 

        public List<EOutHoras> ConsultarPorDoctor(long idDoctor)
        {
            var resultAux = operacionesdb.OpeConsultarPorDoctor(idDoctor);
            List<EOutHoras> result = new List<EOutHoras>();

            foreach(HorasLaborales hl in resultAux)
            {
                result.Add(_mapper.Map<EOutHoras>(hl));
            }

            return result;
        }

        public List<EOutHoras> ConsultarPorDoctorClinica(long idDoctor, long idClinica)
        {
            var resultAux = operacionesdb.OpeConsultarPorDoctorClinica(idDoctor, idClinica);
            List<EOutHoras> result = new List<EOutHoras>();

            foreach (HorasLaborales hl in resultAux)
            {
                result.Add(_mapper.Map<EOutHoras>(hl));
            }

            return result;
        }

        public List<EOutHoras> ConsultarPorDoctorClinicaFecha(long idDoctor, long idClinica, string fecha)
        {
            var resultAux = operacionesdb.OpeConsultarPorDoctorClinicaFecha(idDoctor, idClinica, fecha);
            List<EOutHoras> result = new List<EOutHoras>();

            foreach (HorasLaborales hl in resultAux)
            {
                result.Add(_mapper.Map<EOutHoras>(hl));
            }

            return result;
        }
    }
}
