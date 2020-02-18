using CalendarMngt.Repositorio.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EEspecialidad
{
    public class EOutEspecialidad
    {
        public long Id { get; set; }
        public string Especialidad1 { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<DoctorEspecialidad> DoctorEspecialidad { get; set; }
    }
}
