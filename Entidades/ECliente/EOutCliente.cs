﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.ECliente
{
    public class EOutCliente
    {
        public long Id { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Cedula { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public bool Estado { get; set; }
    }
}
