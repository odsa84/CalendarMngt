using CalendarMngt.Entidades.EDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.EAuth
{
    public class EOutDoctorLogin
    {
        public string Token { get; set; }

        public DateTime ExpiresIn { get; set; }

        public EOutDoctor Doctor { get; set; }

        public string Tipo { get; set; }
    }
}
