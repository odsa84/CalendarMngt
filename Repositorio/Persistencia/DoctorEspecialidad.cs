using System;
using System.Collections.Generic;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class DoctorEspecialidad
    {
        public long Id { get; set; }
        public long IdDoctor { get; set; }
        public long IdEspecialidad { get; set; }

        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual Especialidad IdEspecialidadNavigation { get; set; }
    }
}
