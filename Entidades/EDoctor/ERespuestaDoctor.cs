using CalendarMngt.Entidades.EDoctor;
using System.Collections.Generic;

namespace CalendarMngt.Entidades
{
    public class ERespuestaDoctor
    {
        public ERespuestaDoctor()
        {
            this.Error = new EError();
            this.Doctores = new List<EOutDoctor>();
        }
        public List<EOutDoctor> Doctores { get; set; }
        public EError Error { get; set; }
    }
}
