using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioAuth
    {
        EOutLogin Login(ELogin eLogin);

        EOutDoctorLogin LoginDoctor(ELogin eLogin);

        EError SendEmail(string toEmail, string bodyEmail);
    }
}
