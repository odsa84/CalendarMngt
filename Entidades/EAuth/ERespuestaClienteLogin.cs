using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EAuth
{
    public class ERespuestaClienteLogin
    {
        public ERespuestaClienteLogin()
        {
            Error = new EError();
            Cliente = new EOutClienteLogin();
        }
        public EOutClienteLogin Cliente { get; set; }
        public EError Error { get; set; }
    }
}
