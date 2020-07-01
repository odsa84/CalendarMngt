using AutoMapper;
using CalendarMngt.Entidades.ECliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia.Modelo
{
    internal class OperacionesCliente
    {
        private readonly IMapper _mapper;

        public OperacionesCliente(IMapper _mapper)
        {
            this._mapper = _mapper;
        }

        internal ERespuestaCliente OpeInsertar(Cliente cliente)
        {
            ERespuestaCliente eRespuesta = new ERespuestaCliente();
            using (var cli = new cita_doctorContext())
            {
                cli.Cliente.Add(cliente);
                try
                {                    
                    cli.SaveChanges();
                    eRespuesta.Clientes.Add(_mapper.Map<EOutCliente>(cliente));
                    eRespuesta.Error.Codigo = "00";
                    eRespuesta.Error.Mensaje = "Ok";
                }
                catch (Exception e)
                {
                    eRespuesta.Error.Codigo = "01";
                    eRespuesta.Error.Mensaje = e.Message;

                    return eRespuesta;
                }
            }

            return eRespuesta;

        }

        internal List<Cliente> OpeConsultar()
        {
            List<Cliente> Lst;
            using (var cliente = new cita_doctorContext())
            {
                var clinicaLst = (from cli in cliente.Cliente
                                  .Where(c => (c.Estado == true))
                                  select cli);

                Lst = clinicaLst.ToList();

                if (Lst.Count() == 0)
                {
                    return new List<Cliente>();
                }
            }

            return Lst;
        }

        internal Cliente OpeConsultarPorId(long id)
        {
            using (var cliente = new cita_doctorContext())
            {
                var clienteLst = (from cli in cliente.Cliente
                                  .Where(cli => (cli.Id == id) && (cli.Estado == true))
                                  select cli);

                if (clienteLst.ToList().Count() == 0)
                {
                    return null;
                }

                return clienteLst.ToList()[0];
            }
        }

        internal Cliente OpeConsultarPorCedula(string cedula)
        {
            using (var cliente = new cita_doctorContext())
            {
                var clienteLst = (from cli in cliente.Cliente
                                  .Where(cli => (cli.Cedula.Equals(cedula)) && (cli.Estado == true))
                                  select cli);

                if (clienteLst.ToList().Count() == 0)
                {
                    return null;
                }

                return clienteLst.ToList()[0];
            }
        }

        internal Cliente OpeConsultarPorEmail(string email)
        {
            using (var cliente = new cita_doctorContext())
            {
                var clienteLst = (from cli in cliente.Cliente
                                  .Where(cli => (cli.Email.Equals(email)) && (cli.Estado == true))
                                  select cli);

                if (clienteLst.ToList().Count() == 0)
                {
                    return null;
                }

                return clienteLst.ToList()[0];
            }
        }
    }
}
