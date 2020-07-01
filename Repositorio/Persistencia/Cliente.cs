using System;
using System.Collections.Generic;

namespace CalendarMngt.Repositorio.Persistencia
{
    public partial class Cliente
    {
        public Cliente()
        {
            Calendario = new HashSet<Calendario>();
        }

        public long Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }        
        public string Telefono { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Calendario> Calendario { get; set; }
    }
}
