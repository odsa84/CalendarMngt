using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioDoctor
    {
        ERespuestaDoctor Insertar(EInDoctor inDoctor);

        List<EOutDoctor> Consultar();

        EOutDoctor ConsultarPorId(long id);

        List<EOutDoctor> ConsultarPorClinica(long idClinica);
    }
}
