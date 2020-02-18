using CalendarMngt.Repositorio.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EClinica
{
    public class EInClinica
    {
        public string IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string RazonSocial { get; set; }

        public string InfoGeneral { get; set; }

        public bool Estado { get; set; }
    }
}
