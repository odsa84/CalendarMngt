using AutoMapper;
using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EClinica;
using CalendarMngt.Entidades.EClinicaDoctor;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia;
using CalendarMngt.Repositorio.Persistencia.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio
{
    public class RepositorioClinica : IRepositorioClinica
    {
        private readonly OperacionesClinica operacionesdb;
        private readonly IMapper _mapper;

        public RepositorioClinica(IMapper _mapper)
        {
            operacionesdb = new OperacionesClinica(_mapper);
            this._mapper = _mapper;
        }

        public ERespuesta Inertar(EInClinica inClinica)
        {
            Clinica cli = _mapper.Map<Clinica>(inClinica);
            ERespuesta respuesta = operacionesdb.OpeInsertar(cli);

            return respuesta;
        }

        public ERespuesta Actualizar(EInClinica inClinica)
        {
            Clinica cli = _mapper.Map<Clinica>(inClinica);
            ERespuesta respuesta = operacionesdb.OpeActualizar(cli);

            return respuesta;
        }

        public List<EOutClinica> Consultar()
        {
            var resultAux = operacionesdb.OpeConsultar();
            List<EOutClinica> result = new List<EOutClinica>();

            foreach (Clinica cli in resultAux)
            {
                result.Add(_mapper.Map<EOutClinica>(cli));
            }

            return result;
        }

        public List<EOutClinica> ConsultarPorUsuario(string idUsuario)
        {
            var resultAux = operacionesdb.OpeConsultarPorUsuario(idUsuario);
            List<EOutClinica> result = new List<EOutClinica>();

            foreach (Clinica cli in resultAux)
            {
                result.Add(_mapper.Map<EOutClinica>(cli));
            }

            return result;
        }

        public List<EOutClinica> ConsultarPorDoctor(long idDoctor)
        {
            var resultAux = operacionesdb.OpeConsultarPorDoctor(idDoctor);
            List<EOutClinica> result = new List<EOutClinica>();

            foreach (Clinica cli in resultAux)
            {
                result.Add(_mapper.Map<EOutClinica>(cli));
            }

            return result;
        }

        public EOutClinica ConsultarPorId(long id)
        {
            var resultAux = operacionesdb.OpeConsultarPorId(id);
            EOutClinica result = null;

            if (resultAux != null)
                result = _mapper.Map<EOutClinica>(resultAux);

            return result;
        }

        public List<EOutClinica> ConsultaAvanzada(long idCiudad, long idEsp)
        {
            var resultAux = operacionesdb.OpeConsultaAvanzada(idCiudad, idEsp);
            List<EOutClinica> result = new List<EOutClinica>();

            foreach (Clinica cli in resultAux)
            {
                /*foreach (Calendario cal in cli.Calendario)
                {
                    cal.IdClienteNavigation = null;
                    cal.IdClinicaNavigation = null;
                    cal.IdDoctorNavigation = null;
                }*/
                //cli.ClinicaDoctor = null;
                //cli.IdCiudadNavigation.IdProvinciaNavigation = null;
                result.Add(_mapper.Map<EOutClinica>(cli));
            }

            return result;
        }

        public List<EOutClinica> ConsultaAvanzadaPorCiudad(long idCiudad)
        {
            var resultAux = operacionesdb.OpeConsultaAvanzadaPorCiudad(idCiudad);
            List<EOutClinica> result = new List<EOutClinica>();

            foreach (Clinica cli in resultAux)
            {
                result.Add(_mapper.Map<EOutClinica>(cli));
            }

            return result;
        }

        public List<EOutClinica> ConsultaAvanzadaPorEspecialidad(long idEsp)
        {
            var resultAux = operacionesdb.OpeConsultaAvanzadaPorEspecialidad(idEsp);
            List<EOutClinica> result = new List<EOutClinica>();

            foreach (Clinica cli in resultAux)
            {
                result.Add(_mapper.Map<EOutClinica>(cli));
            }

            return result;
        }
    }
}
