using System;
using System.Collections.Generic;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class DoctorTitulo
    {
        public long Id { get; set; }
        public long IdDoctor { get; set; }
        public long IdTitulo { get; set; }

        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual Titulo IdTituloNavigation { get; set; }
    }
}
