using CalendarMngt.Entidades.EDoctor;
using CalendarMngt.Entidades.EEspecialidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EDoctorEspecialidad
{
    public class EDoctorEspecialidad
    {
        public EOutDoctor Doctor { get; set; }

        public EOutEspecialidad Especialidad { get; set; }
    }
}
