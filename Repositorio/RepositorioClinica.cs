﻿using AutoMapper;
using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EClinica;
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
            operacionesdb = new OperacionesClinica();
            this._mapper = _mapper;
        }

        public ERespuesta Inertar(EInClinica inClinica)
        {
            Clinica cli = _mapper.Map<Clinica>(inClinica);
            ERespuesta respuesta = operacionesdb.OpeInsertar(cli);

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

        public EOutClinica ConsultarPorId(long id)
        {
            var resultAux = operacionesdb.OpeConsultarPorId(id);
            EOutClinica result = null;

            if (resultAux != null)
                result = _mapper.Map<EOutClinica>(resultAux);

            return result;
        }
    }
}
