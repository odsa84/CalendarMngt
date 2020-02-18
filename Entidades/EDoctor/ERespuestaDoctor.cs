using CalendarMngt.Entidades.EDoctor;
using System.Collections.Generic;

namespace CalendarMngt.Entidades
{
    public class ERespuestaDoctor
    {
        public ERespuestaDoctor()
        {
            Error = new EError();
            Doctores = new List<EOutDoctor>();
        }
        public List<EOutDoctor> Doctores { get; set; }
        public EError Error { get; set; }
    }
}
