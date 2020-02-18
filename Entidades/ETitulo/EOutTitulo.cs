using CalendarMngt.Repositorio.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.ETitulo
{
    public class EOutTitulo
    {
        public long Id { get; set; }
        public string Titulo1 { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<DoctorTitulo> DoctorTitulo { get; set; }
    }
}
