using CalendarMngt.Repositorio.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.ECalendario
{
    public class EOutCalendario
    {
        public long Id { get; set; }

        public DateTime InicioFechaHora { get; set; }

        public DateTime FinFechaHora { get; set; }

        public long IdDoctor { get; set; }

        public long IdEstado { get; set; }

        public long IdCliente { get; set; }

        public string Sintomas { get; set; }

        public string Diagnostico { get; set; }

        public string Indicaciones { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public Clinica IdClinicaNavigation { get; set; }
    }
}
