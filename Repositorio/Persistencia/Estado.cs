using System;
using System.Collections.Generic;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class Estado
    {
        public Estado()
        {
            Calendario = new HashSet<Calendario>();
        }

        public long Id { get; set; }
        public string Estado1 { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Calendario> Calendario { get; set; }
    }
}
