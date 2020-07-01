using CalendarMngt.Entidades.ECliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EAuth
{
    public class EOutClienteLogin
    {
        public string Token { get; set; }

        public DateTime ExpiresIn { get; set; }

        public EOutCliente Cliente { get; set; }

        public string Tipo { get; set; }
    }
}
