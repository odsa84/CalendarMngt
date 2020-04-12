using CalendarMngt.Entidades.ECalendario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.ECliente
{
    public class ERespuestaCalendario
    {

        public ERespuestaCalendario()
        {
            Calendarios = new List<EOutCalendario>();
            Error = new EError();
        }

        public List<EOutCalendario> Calendarios { get; set; }

        public EError Error { get; set; }
    }
}
