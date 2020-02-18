using AutoMapper;
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
    public class RepositorioTitulo : IRepositorioTitulo
    {
        private readonly OperacionesTitulo operacionesdb;
        private readonly IMapper _mapper;

        public RepositorioTitulo(IMapper _mapper)
        {
            this.operacionesdb = new OperacionesTitulo();
            this._mapper = _mapper;
        }

        public ERespuestaTitulo Insertar(EInTitulo inTitulo)
        {
            Titulo titulo = _mapper.Map<Titulo>(inTitulo);
            ERespuestaTitulo tituloOut = operacionesdb.OpeInsertar(titulo);

            return tituloOut;
        }

        public List<EOutTitulo> Consultar()
        {
            var resultAux = operacionesdb.OpeConsultar();
            List<EOutTitulo> result = new List<EOutTitulo>();

            foreach(Titulo titulo in resultAux)
            {
                result.Add(_mapper.Map<EOutTitulo>(titulo));
            }

            return result;
        }

        public EOutTitulo ConsultarPorId(long id)
        {
            var resultAux = operacionesdb.OpeConsultarPorId(id);
            EOutTitulo result = resultAux != null ? _mapper.Map<EOutTitulo>(resultAux) : null;             

            return result;
        }        
    }
}
