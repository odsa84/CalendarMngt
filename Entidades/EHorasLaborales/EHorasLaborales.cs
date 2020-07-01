using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EHorasLaborales
{
    public class EHorasLaborales
    {
        public List<ToDeleteEvent> toDeleteEvent { get; set; } = new List<ToDeleteEvent>();
        public List<EHoras> Horas { get; set; } = new List<EHoras>();
        public long IdClinica { get; set; }
        public long IdDoctor { get; set; }
    }
}
