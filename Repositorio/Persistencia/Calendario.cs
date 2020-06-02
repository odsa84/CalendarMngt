using System;
using System.Collections.Generic;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class Calendario
    {
        public long Id { get; set; }
        public DateTime InicioFechaHora { get; set; }
        public DateTime FinFechaHora { get; set; }
        public long IdDoctor { get; set; }
        public long IdEstado { get; set; }
        public long IdCliente { get; set; }
        public long IdClinica { get; set; }
        public string Sintomas { get; set; }
        public string Diagnostico { get; set; }
        public string Indicaciones { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Clinica IdClinicaNavigation { get; set; }
    }
}
