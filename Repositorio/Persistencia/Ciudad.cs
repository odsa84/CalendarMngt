using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Clinica = new HashSet<Clinica>();
        }

        public long Id { get; set; }

        public long IdProvincia { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }

        public virtual ICollection<Clinica> Clinica { get; set; }

        public virtual Provincia IdProvinciaNavigation { get; set; }
    }
}
