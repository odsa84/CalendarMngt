using CalendarMngt.Repositorio.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EClinica
{
    public class EInClinica
    {
        public long Id { get; set; }

        public string IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string RazonSocial { get; set; }

        public string InfoGeneral { get; set; }

        public string Direccion { get; set; }

        public string Referencia { get; set; }

        public long IdCiudad { get; set; }

        public long IdProvincia { get; set; }

        public bool Estado { get; set; }
    }
}
