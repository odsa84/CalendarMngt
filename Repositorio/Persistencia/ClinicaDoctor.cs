using System;
using System.Collections.Generic;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class ClinicaDoctor
    {
        public long Id { get; set; }
        public long IdClinica { get; set; }
        public long IdDoctor { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Doctor IdDoctorNavigation { get; set; }
    }
}
