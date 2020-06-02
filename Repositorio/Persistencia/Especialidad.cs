using System;
using System.Collections.Generic;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            DoctorEspecialidad = new HashSet<DoctorEspecialidad>();
        }

        public long Id { get; set; }
        public string Especialidad1 { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<DoctorEspecialidad> DoctorEspecialidad { get; set; }
    }
}
