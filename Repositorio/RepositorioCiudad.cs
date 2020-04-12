using AutoMapper;
using CalendarMngt.Entidades.ECiudad;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia;
using CalendarMngt.Repositorio.Persistencia.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio
{
    public class RepositorioCiudad : IRepositorioCiudad
    {
        private readonly OperacionesCiudad operacionesdb;
        private readonly IMapper _mapper;

        public RepositorioCiudad(IMapper _mapper)
        {
            this.operacionesdb = new OperacionesCiudad();
            this._mapper = _mapper;
        }

        public ERespuestaCiudad Insertar(EInCiudad ciudad)
        {
            Ciudad ciu = _mapper.Map<Ciudad>(ciudad);
            ERespuestaCiudad respuesta = operacionesdb.OpeInsertar(ciu);

            return respuesta;
        }

        public List<EOutCiudad> Consultar()
        {
            var resultAux = operacionesdb.OpeConsultar();
            List<EOutCiudad> result = new List<EOutCiudad>();

            foreach (Ciudad ciu in resultAux)
            {
                result.Add(_mapper.Map<EOutCiudad>(ciu));
            }

            return result;
        }

        public List<EOutCiudad> ConsultarPorNombre(string nombre)
        {
            var resultAux = operacionesdb.OpeConsultarPorNombre(nombre);
            List<EOutCiudad> result = new List<EOutCiudad>();

            foreach (Ciudad ciu in resultAux)
            {
                result.Add(_mapper.Map<EOutCiudad>(ciu));
            }

            return result;
        }

        public List<EOutCiudad> ConsultarPorProvincia(long idProvincia)
        {
            var resultAux = operacionesdb.OpeConsultarPorProvincia(idProvincia);
            List<EOutCiudad> result = new List<EOutCiudad>();

            foreach (Ciudad ciu in resultAux)
            {
                result.Add(_mapper.Map<EOutCiudad>(ciu));
            }

            return result;
        }

        public EOutCiudad ConsultarPorId(long id)
        {
            var resultAux = operacionesdb.OpeConsultarPorId(id);
            EOutCiudad result = null;

            if (resultAux != null)
                result = _mapper.Map<EOutCiudad>(resultAux);

            return result;
        }
    }
}
