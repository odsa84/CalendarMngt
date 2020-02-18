using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EClinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioClinica
    {
        ERespuesta Inertar(EInClinica inClinica);

        List<EOutClinica> Consultar();

        List<EOutClinica> ConsultarPorUsuario(string idUsuario);

        EOutClinica ConsultarPorId(long id);
    }
}
