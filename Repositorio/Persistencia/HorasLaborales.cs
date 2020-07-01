using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class HorasLaborales
    {
        public string Id { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Fecha { get; set; }
        public long IdDoctor { get; set; }
        public long IdClinica { get; set; }

        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual Clinica IdClinicaNavigation { get; set; }
    }
}
