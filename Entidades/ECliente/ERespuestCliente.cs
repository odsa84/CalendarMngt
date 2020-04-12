using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.ECliente
{
    public class ERespuestaCliente
    {

        public ERespuestaCliente()
        {
            Clientes = new List<EOutCliente>();
            Error = new EError();
        }

        public List<EOutCliente> Clientes { get; set; }

        public EError Error { get; set; }
    }
}
