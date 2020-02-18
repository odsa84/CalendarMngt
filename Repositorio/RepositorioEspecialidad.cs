using AutoMapper;
using CalendarMngt.Entidades.EEspecialidad;
using CalendarMngt.Entidades.ETitulo;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia;
using CalendarMngt.Repositorio.Persistencia.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio
{
    public class RepositorioEspecialidad : IRepositorioEspecialidad
    {
        private readonly OperacionesEspecialidad operacionesdb;
        private readonly IMapper _mapper;

        public RepositorioEspecialidad(IMapper _mapper)
        {
            this.operacionesdb = new OperacionesEspecialidad();
            this._mapper = _mapper;
        }

        public ERespuestaEspecialidad Insertar(EInEspecialidad inEspecialidad)
        {
            Especialidad esp = _mapper.Map<Especialidad>(inEspecialidad);
            ERespuestaEspecialidad espOut = operacionesdb.OpeInsertar(esp);

            return espOut;
        }

        public List<EOutEspecialidad> Consultar()
        {
            var resultAux = operacionesdb.OpeConsultar();
            List<EOutEspecialidad> result = new List<EOutEspecialidad>();

            foreach(Especialidad esp in resultAux)
            {
                result.Add(_mapper.Map<EOutEspecialidad>(esp));
            }

            return result;
        }

        public EOutEspecialidad ConsultarPorId(long id)
        {
            var resultAux = operacionesdb.OpeConsultarPorId(id);
            EOutEspecialidad result = resultAux != null ? _mapper.Map<EOutEspecialidad>(resultAux) : null;             

            return result;
        }        
    }
}
