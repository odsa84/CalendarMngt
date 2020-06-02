using System;
using System.Collections.Generic;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class UltimaHora
    {
        public long Id { get; set; }
        public string Comunicado { get; set; }
        public DateTime? HoraInicio { get; set; }
        public DateTime? HoraFin { get; set; }
        public DateTime FechaCreado { get; set; }
        public bool Estado { get; set; }
    }
}
