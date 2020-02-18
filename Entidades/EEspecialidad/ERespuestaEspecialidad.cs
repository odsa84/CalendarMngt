using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EEspecialidad
{
    public class ERespuestaEspecialidad
    {
        public ERespuestaEspecialidad()
        {
            Especialidades = new List<EOutEspecialidad>();
            Error = new EError();
        }

        public List<EOutEspecialidad> Especialidades { get; set; }

        public EError Error { get; set; }
    }
}
