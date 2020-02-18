using AutoMapper;
using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EDoctor;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia;
using CalendarMngt.Repositorio.Persistencia.Modelo;
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
            this.operacionesdb = new OperacionesDoctor();
            this._mapper = _mapper;
        }

        public ERespuestaDoctor Insertar(EInDoctor inDoctor)
        {
            Doctor doc = _mapper.Map<Doctor>(inDoctor);
            ERespuestaDoctor eRespuesta = operacionesdb.OpeInsertar(doc);

            return eRespuesta;
        }
        public List<EOutDoctor> Consultar()
        {
            var resultAux = operacionesdb.OpeConsultar();
            List<EOutDoctor> result = new List<EOutDoctor>();
            foreach(Doctor doc in resultAux)
            {
                result.Add(_mapper.Map<EOutDoctor>(doc));
            }

            return result;
        }

        public EOutDoctor ConsultarPorId(long id)
        {
            var resultAux = operacionesdb.OpeConsultarPorId(id);
            EOutDoctor result = resultAux != null ? _mapper.Map<EOutDoctor>(resultAux) : null;

            return result;
        }        
    }
}
