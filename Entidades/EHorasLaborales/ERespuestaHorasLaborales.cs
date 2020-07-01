using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EHorasLaborales
{
    public class ERespuestaHorasLaborales
    {
        public ERespuestaHorasLaborales()
        {
            HorasLaborales = new List<EOutHoras>();
            Error = new EError();
        }

        public List<EOutHoras> HorasLaborales { get; set; }
        public EError Error { get; set; }
    }
}
