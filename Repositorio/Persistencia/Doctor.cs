using System;
using System.Collections.Generic;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class Doctor
    {
        public Doctor()
        {
            Calendario = new HashSet<Calendario>();
            ClinicaDoctor = new HashSet<ClinicaDoctor>();
            DoctorEspecialidad = new HashSet<DoctorEspecialidad>();
            DoctorTitulo = new HashSet<DoctorTitulo>();
        }

        public long Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string InfoGeneral { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Calendario> Calendario { get; set; }
        public virtual ICollection<ClinicaDoctor> ClinicaDoctor { get; set; }
        public virtual ICollection<DoctorEspecialidad> DoctorEspecialidad { get; set; }
        public virtual ICollection<DoctorTitulo> DoctorTitulo { get; set; }
    }
}
