using System;
using System.Collections.Generic;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class Titulo
    {
        public Titulo()
        {
            DoctorTitulo = new HashSet<DoctorTitulo>();
        }

        public long Id { get; set; }
        public string Titulo1 { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<DoctorTitulo> DoctorTitulo { get; set; }
    }
}
