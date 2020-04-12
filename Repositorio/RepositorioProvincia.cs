using AutoMapper;
using CalendarMngt.Entidades.EEstado;
using CalendarMngt.Entidades.EProvincia;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia;
using CalendarMngt.Repositorio.Persistencia.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio
{
    public class RepositorioProvincia : IRepositorioProvincia
    {
        private readonly OperacionesProvincia operacionesdb;
        private readonly IMapper _mapper;

        public RepositorioProvincia(IMapper _mapper)
        {
            this.operacionesdb = new OperacionesProvincia();
            this._mapper = _mapper;
        }

        public ERespuestaProvincia Insertar(EInProvincia provincia)
        {
            Provincia prov = _mapper.Map<Provincia>(provincia);
            ERespuestaProvincia respuesta = operacionesdb.OpeInsertar(prov);

            return respuesta;
        }

        public List<EOutProvincia> Consultar()
        {
            var resultAux = operacionesdb.OpeConsultar();
            List<EOutProvincia> result = new List<EOutProvincia>();

            foreach (Provincia prov in resultAux)
            {
                result.Add(_mapper.Map<EOutProvincia>(prov));
            }

            return result;
        }

        public List<EOutProvincia> ConsultarPorNombre(string nombre)
        {
            var resultAux = operacionesdb.OpeConsultarPorNombre(nombre);
            List<EOutProvincia> result = new List<EOutProvincia>();

            foreach (Provincia prov in resultAux)
            {
                result.Add(_mapper.Map<EOutProvincia>(prov));
            }

            return result;
        }

        public EOutProvincia ConsultarPorId(long id)
        {
            var resultAux = operacionesdb.OpeConsultarPorId(id);
            EOutProvincia result = null;

            if (resultAux != null)
                result = _mapper.Map<EOutProvincia>(resultAux);

            return result;
        }
    }
}
