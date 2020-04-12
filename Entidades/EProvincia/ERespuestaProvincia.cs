using CalendarMngt.Entidades.EProvincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EEstado
{
    public class ERespuestaProvincia
    {

        public ERespuestaProvincia()
        {
            Provincias = new List<EOutProvincia>();
            Error = new EError();
        }

        public List<EOutProvincia> Provincias { get; set; }

        public EError Error { get; set; }
    }
}
