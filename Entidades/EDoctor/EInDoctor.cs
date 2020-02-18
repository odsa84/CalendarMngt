using CalendarMngt.Repositorio.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EDoctor
{
    public class EInDoctor
    {
        public long Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string InfoGeneral { get; set; }
        public bool Estado { get; set; }

        public ICollection<Calendario> Calendario { get; set; }
        public ICollection<ClinicaDoctor> ClinicaDoctor { get; set; }
        public ICollection<DoctorEspecialidad> DoctorEspecialidad { get; set; }
        public ICollection<DoctorTitulo> DoctorTitulo { get; set; }
    }
}
