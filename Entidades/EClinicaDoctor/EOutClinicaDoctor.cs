using CalendarMngt.Repositorio.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EClinicaDoctor
{
    public class EOutClinicaDoctor
    {
        public long Id { get; set; }
        public long IdClinica { get; set; }
        public long IdDoctor { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Doctor IdDoctorNavigation { get; set; }
    }
}
