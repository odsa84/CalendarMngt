using System;
using System.Collections.Generic;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class Clinica
    {
        public Clinica()
        {
            ClinicaDoctor = new HashSet<ClinicaDoctor>();
            Calendario = new HashSet<Calendario>();
            HorasLaborales = new HashSet<HorasLaborales>();
        }

        public long Id { get; set; }
        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string RazonSocial { get; set; }
        public string InfoGeneral { get; set; }
        public string Direccion { get; set; }
        public string Referencia { get; set; }
        public long IdCiudad { get; set; }
        public long IdProvincia { get; set; }        
        public bool Estado { get; set; }

        public virtual Aspnetusers IdUsuarioNavigation { get; set; }
        public virtual Ciudad IdCiudadNavigation { get; set; }
        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual ICollection<ClinicaDoctor> ClinicaDoctor { get; set; }
        public virtual ICollection<Calendario> Calendario { get; set; }
        public virtual ICollection<HorasLaborales> HorasLaborales { get; set; }
    }
}
