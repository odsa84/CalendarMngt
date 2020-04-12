using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.ECiudad
{
    public class ERespuestaCiudad
    {

        public ERespuestaCiudad()
        {
            Ciudades = new List<EOutCiudad>();
            Error = new EError();
        }

        public List<EOutCiudad> Ciudades { get; set; }

        public EError Error { get; set; }
    }
}
