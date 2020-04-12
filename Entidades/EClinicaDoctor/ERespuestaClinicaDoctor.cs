using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EClinicaDoctor
{
    public class ERespuestaClinicaDoctor
    {
        public ERespuestaClinicaDoctor()
        {
            Error = new EError();
            Doctores = new List<EOutClinicaDoctor>();
        }
        public List<EOutClinicaDoctor> Doctores { get; set; }
        public EError Error { get; set; }
    }
}
