using AutoMapper;
using CalendarMngt.Entidades.ECliente;
using CalendarMngt.Interfaces;
using CalendarMngt.Repositorio.Persistencia;
using CalendarMngt.Repositorio.Persistencia.Modelo;
using System.Collections.Generic;

namespace CalendarMngt.Repositorio
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly OperacionesCliente operacionesdb;
        private readonly IMapper _mapper;

        public RepositorioCliente(IMapper _mapper)
        {
            operacionesdb = new OperacionesCliente(_mapper);
            this._mapper = _mapper;
        }

        public ERespuestaCliente Inertar(EInCliente inCliente)
        {
            Cliente cli = _mapper.Map<Cliente>(inCliente);
            ERespuestaCliente respuesta = operacionesdb.OpeInsertar(cli);

            return respuesta;
        }

        public List<EOutCliente> Consultar()
        {
            var resultAux = operacionesdb.OpeConsultar();
            List<EOutCliente> result = new List<EOutCliente>();

            foreach (Cliente cli in resultAux)
            {
                result.Add(_mapper.Map<EOutCliente>(cli));
            }

            return result;
        }

        public EOutCliente ConsultarPorId(long id)
        {
            var resultAux = operacionesdb.OpeConsultarPorId(id);
            EOutCliente result = null;

            if (resultAux != null)
                result = _mapper.Map<EOutCliente>(resultAux);

            return result;
        }

        public EOutCliente ConsultarPorCedula(string cedula)
        {
            var resultAux = operacionesdb.OpeConsultarPorCedula(cedula);
            EOutCliente result = null;

            if (resultAux != null)
                result = _mapper.Map<EOutCliente>(resultAux);

            return result;
        }
    }
}
