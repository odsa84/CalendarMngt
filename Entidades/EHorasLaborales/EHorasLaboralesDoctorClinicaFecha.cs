using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EHorasLaborales
{
    public class EHorasLaboralesDoctorClinicaFecha
    {
        public long IdDoctor { get; set; }

        public long IdClinica { get; set; }

        public string Fecha { get; set; }
    }
}
