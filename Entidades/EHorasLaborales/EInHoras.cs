using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EHorasLaborales
{
    public class EInHoras
    {
        public string Id { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Fecha { get; set; }
        public long IdDoctor { get; set; }
        public long IdClinica { get; set; }
        public bool Disponible { get; set; }
    }
}
