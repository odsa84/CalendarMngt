using AutoMapper;
using CalendarMngt.Entidades.EEstado;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia;
using CalendarMngt.Repositorio.Persistencia.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio
{
    public class RepositorioEstado : IRepositorioEstado
    {

        private readonly OperacionesEstado operacionesdb;
        private readonly IMapper _mapper;

        public RepositorioEstado(IMapper _mapper)
        {
            this.operacionesdb = new OperacionesEstado();
            this._mapper = _mapper;
        }

        public ERespuestaEstado Insertar(EInEstado estado)
        {
            Estado est = _mapper.Map<Estado>(estado);
            ERespuestaEstado respuesta = operacionesdb.OpeInsertar(est);

            return respuesta;
        }

        public List<EOutEstado> Consultar()
        {
            var resultAux = operacionesdb.OpeConsultar();
            List<EOutEstado> result = new List<EOutEstado>();

            foreach (Estado est in resultAux)
            {
                result.Add(_mapper.Map<EOutEstado>(est));
            }

            return result;
        }

        public EOutEstado ConsultarPorId(long id)
        {
            var resultAux = operacionesdb.OpeConsultarPorId(id);
            EOutEstado result = null;

            if (resultAux != null)
                result = _mapper.Map<EOutEstado>(resultAux);

            return result;
        }        
    }
}
