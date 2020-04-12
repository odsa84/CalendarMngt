using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EEstado
{
    public class ERespuestaEstado
    {

        public ERespuestaEstado()
        {
            Estados = new List<EOutEstado>();
            Error = new EError();
        }

        public List<EOutEstado> Estados { get; set; }

        public EError Error { get; set; }
    }
}
