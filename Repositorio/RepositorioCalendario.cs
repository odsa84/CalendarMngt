using AutoMapper;
using CalendarMngt.Entidades.ECalendario;
using CalendarMngt.Entidades.ECliente;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia;
using CalendarMngt.Repositorio.Persistencia.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio
{
    public class RepositorioCalendario : IRepositorioCalendario
    {
        private readonly OperacionesCalendario operacionesdb;
        private readonly IMapper _mapper;

        public RepositorioCalendario(IMapper _mapper)
        {
            this.operacionesdb = new OperacionesCalendario(_mapper);
            this._mapper = _mapper;
        }

        public ERespuestaCalendario Inertar(EInCalendario calendario)
        {
            Calendario cal = _mapper.Map<Calendario>(calendario);
            ERespuestaCalendario respuesta = operacionesdb.OpeInsertar(cal);

            return respuesta;
        }

        public ERespuestaCalendario Actualizar(EInCalendario calendario)
        {
            Calendario cal = _mapper.Map<Calendario>(calendario);
            ERespuestaCalendario respuesta = operacionesdb.OpeActualizar(cal);

            return respuesta;
        }

        public List<EOutCalendario> Consultar()
        {
            var resultAux = operacionesdb.OpeConsultar();
            List<EOutCalendario> result = new List<EOutCalendario>();

            foreach (Calendario cal in resultAux)
            {
                cal.IdClinicaNavigation.Calendario = null;
                cal.IdClienteNavigation.Calendario = null;
                cal.IdDoctorNavigation.Calendario = null;
                cal.IdEstadoNavigation.Calendario = null;
                result.Add(_mapper.Map<EOutCalendario>(cal));
            }

            return result;
        }

        public List<EOutCalendario> ConsultarAgendadas()
        {
            var resultAux = operacionesdb.OpeConsultarAgendadas();
            List<EOutCalendario> result = new List<EOutCalendario>();

            foreach (Calendario cal in resultAux)
            {
                cal.IdClinicaNavigation.Calendario = null;
                cal.IdClienteNavigation.Calendario = null;
                cal.IdDoctorNavigation.Calendario = null;
                cal.IdEstadoNavigation.Calendario = null;
                result.Add(_mapper.Map<EOutCalendario>(cal));
            }

            return result;
        }

        public List<EOutCliente> ConsultarClientes()
        {
            var resultAux = operacionesdb.OpeConsultarClientes();
            List<EOutCliente> result = new List<EOutCliente>();

            foreach (Cliente cal in resultAux)
            {
                result.Add(_mapper.Map<EOutCliente>(cal));
            }

            return result;

        }

        public EOutCalendario ConsultarPorId(long id)
        {
            var resultAux = operacionesdb.OpeConsultarPorId(id);
            EOutCalendario result = null;

            if (resultAux != null)
                result = _mapper.Map<EOutCalendario>(resultAux);

            return result;
        }

        public List<EOutCalendario> ConsultarPorCliente(long idCliente)
        {
            var resultAux = operacionesdb.OpeConsultarPorCliente(idCliente);
            List<EOutCalendario> result = new List<EOutCalendario>();

            foreach (Calendario cal in resultAux)
            {
                cal.IdClinicaNavigation.Calendario = null;
                cal.IdClienteNavigation.Calendario = null;
                cal.IdDoctorNavigation.Calendario = null;
                cal.IdEstadoNavigation.Calendario = null;
                result.Add(_mapper.Map<EOutCalendario>(cal));
            }

            return result;
        }

        public List<EOutCalendario> ConsultarPorClinica(long idClinica)
        {
            var resultAux = operacionesdb.OpeConsultarPorClinica(idClinica);
            List<EOutCalendario> result = new List<EOutCalendario>();

            foreach (Calendario cal in resultAux)
            {
                cal.IdClinicaNavigation.Calendario = null;
                cal.IdClienteNavigation.Calendario = null;
                cal.IdDoctorNavigation.Calendario = null;
                cal.IdEstadoNavigation.Calendario = null;
                result.Add(_mapper.Map<EOutCalendario>(cal));
            }

            return result;
        }

        public List<EOutCalendario> ConsultarPorDoctor(long idDoctor)
        {
            var resultAux = operacionesdb.OpeConsultarPorDoctor(idDoctor);
            List<EOutCalendario> result = new List<EOutCalendario>();

            foreach (Calendario cal in resultAux)
            {
                cal.IdClinicaNavigation.Calendario = null;
                cal.IdClienteNavigation.Calendario = null;
                cal.IdDoctorNavigation.Calendario = null;
                cal.IdEstadoNavigation.Calendario = null;
                result.Add(_mapper.Map<EOutCalendario>(cal));
            }

            return result;
        }

        public List<EOutCalendario> ConsultarPorEstado(long idEstado)
        {
            var resultAux = operacionesdb.OpeConsultarPorEstado(idEstado);
            List<EOutCalendario> result = new List<EOutCalendario>();

            foreach (Calendario cal in resultAux)
            {
                cal.IdClinicaNavigation.Calendario = null;
                cal.IdClienteNavigation.Calendario = null;
                cal.IdDoctorNavigation.Calendario = null;
                cal.IdEstadoNavigation.Calendario = null;
                result.Add(_mapper.Map<EOutCalendario>(cal));
            }

            return result;
        }

        public List<EOutCalendario> ConsultarPorFecha(DateTime fecha)
        {
            var resultAux = operacionesdb.OpeConsultarPorFecha(fecha);
            List<EOutCalendario> result = new List<EOutCalendario>();

            foreach (Calendario cal in resultAux)
            {
                cal.IdClinicaNavigation.Calendario = null;
                cal.IdClienteNavigation.Calendario = null;
                cal.IdDoctorNavigation.Calendario = null;
                cal.IdEstadoNavigation.Calendario = null;
                result.Add(_mapper.Map<EOutCalendario>(cal));
            }

            return result;
        }               
    }
}
