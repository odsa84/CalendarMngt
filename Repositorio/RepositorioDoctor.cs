using AutoMapper;
using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EClinicaDoctor;
using CalendarMngt.Entidades.EDoctor;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia;
using CalendarMngt.Repositorio.Persistencia.Modelo;
using CalendarMngt.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio
{
    public class RepositorioDoctor : IRepositorioDoctor
    {
        private readonly OperacionesDoctor operacionesdb;
        private readonly IMapper _mapper;

        public RepositorioDoctor(IMapper _mapper)
        {
            this.operacionesdb = new OperacionesDoctor(_mapper);
            this._mapper = _mapper;
        }

        public ERespuestaDoctor Insertar(EInDoctor inDoctor)
        {
            inDoctor.Password = Hash.Crear(inDoctor.Password, "jor290714luc300617");
            Doctor doc = _mapper.Map<Doctor>(inDoctor);
            ERespuestaDoctor eRespuesta = operacionesdb.OpeInsertar(doc);

            return eRespuesta;
        }
        public List<EOutClinicaDoctor> Consultar()
        {
            var resultAux = operacionesdb.OpeConsultar();
            List<EOutClinicaDoctor> result = new List<EOutClinicaDoctor>();
            foreach (ClinicaDoctor doc in resultAux)
            {
                doc.IdDoctorNavigation.ClinicaDoctor = null;
                foreach (DoctorTitulo dt in doc.IdDoctorNavigation.DoctorTitulo)
                {
                    dt.IdDoctorNavigation = null;
                    dt.IdTituloNavigation.DoctorTitulo = null;
                }

                foreach (DoctorEspecialidad de in doc.IdDoctorNavigation.DoctorEspecialidad)
                {
                    de.IdDoctorNavigation = null;
                    de.IdEspecialidadNavigation.DoctorEspecialidad = null;
                }

                result.Add(_mapper.Map<EOutClinicaDoctor>(doc));
            }

            return result;
        }

        public EOutDoctor ConsultarPorId(long id)
        {
            var resultAux = operacionesdb.OpeConsultarPorId(id);
            EOutDoctor result = resultAux != null ? _mapper.Map<EOutDoctor>(resultAux) : null;

            return result;
        }  
        
        public List<EOutClinicaDoctor> ConsultarPorClinica(long idClinica)
        {
            var resultAux = operacionesdb.OpeConsultarPorClinica(idClinica);
            List<EOutClinicaDoctor> result = new List<EOutClinicaDoctor>();
            foreach (ClinicaDoctor doc in resultAux)
            {
                doc.IdClinicaNavigation.ClinicaDoctor = null;
                result.Add(_mapper.Map<EOutClinicaDoctor>(doc));
            }

            return result;
        }

        public List<EOutClinicaDoctor> ConsultaAvanzada(long idCiudad, long idEsp)
        {
            var resultAux = operacionesdb.OpeConsultaAvanzada(idCiudad, idEsp);
            List<EOutClinicaDoctor> result = new List<EOutClinicaDoctor>();
            foreach (ClinicaDoctor doc in resultAux)
            {
                foreach (Calendario cal in doc.IdClinicaNavigation.Calendario)
                {
                    cal.IdClienteNavigation = null;
                    cal.IdClinicaNavigation = null;
                    cal.IdDoctorNavigation = null;
                    cal.IdEstadoNavigation.Calendario = null;
                }
                doc.IdClinicaNavigation.ClinicaDoctor = null;
                doc.IdDoctorNavigation.Calendario = null;
                doc.IdDoctorNavigation.ClinicaDoctor = null;
                doc.IdDoctorNavigation.DoctorTitulo = null;
                result.Add(_mapper.Map<EOutClinicaDoctor>(doc));
            }

            return result;
        }

        public List<EOutClinicaDoctor> ConsultaPorClinicaEspecialidad(long idClinica, long idEsp)
        {
            var resultAux = new List<ClinicaDoctor>();
            if (idEsp == 0)
            {
                resultAux = operacionesdb.OpeConsultarPorClinica(idClinica);
            }
            else if (idClinica != 0 && idEsp != 0)
            {
                resultAux = operacionesdb.OpeConsultaPorClinicaEspecialidad(idClinica, idEsp);
            }

            List<EOutClinicaDoctor> result = new List<EOutClinicaDoctor>();
            foreach (ClinicaDoctor doc in resultAux)
            {
                foreach (Calendario cal in doc.IdClinicaNavigation.Calendario)
                {
                    cal.IdClienteNavigation = null;
                    cal.IdClinicaNavigation = null;
                    cal.IdDoctorNavigation = null;
                    cal.IdEstadoNavigation.Calendario = null;
                }
                doc.IdClinicaNavigation.ClinicaDoctor = null;
                doc.IdDoctorNavigation.Calendario = null;
                doc.IdDoctorNavigation.ClinicaDoctor = null;
                doc.IdDoctorNavigation.DoctorTitulo = null;
                result.Add(_mapper.Map<EOutClinicaDoctor>(doc));
            }

            return result;
        }
    }
}
