using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EEstado
{
    public class EOutEstado
    {
        public long Id { get; set; }

        public string Estado { get; set; }

        public string Descripcion { get; set; }

        public bool Activo { get; set; }
    }
}
