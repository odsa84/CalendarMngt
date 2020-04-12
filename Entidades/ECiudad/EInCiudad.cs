using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.ECiudad
{
    public class EInCiudad
    {
        public long Id { get; set; }
        public long IdProvincia { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
