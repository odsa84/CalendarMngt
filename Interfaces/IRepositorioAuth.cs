using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EAuth;
using CalendarMngt.Entidades.ECliente;
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

        EOutClienteLogin LoginCliente(ELogin eLogin);

        ERespuestaCliente ChangePassword(ELogin eLogin);

        ERespuestaCliente ChangePasswordPaciente(EChangePassword eChange);

        EError SendEmail(string toEmail, string bodyEmail);
    }
}
