using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class Provincia
    {
        public Provincia()
        {
            Clinica = new HashSet<Clinica>();
            Ciudad = new HashSet<Ciudad>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Clinica> Clinica { get; set; }

        public virtual ICollection<Ciudad> Ciudad { get; set; }
    }
}
