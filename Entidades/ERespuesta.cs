using CalendarMngt.Entidades.EClinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades
{
    public class ERespuesta
    {
        public ERespuesta()
        {
            this.Error = new EError();
            this.Clinicas = new List<EOutClinica>();
        }
        public List<EOutClinica> Clinicas { get; set; }
        public EError Error { get; set; }
    }
}
