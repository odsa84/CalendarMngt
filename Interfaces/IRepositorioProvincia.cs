using CalendarMngt.Entidades.EEstado;
using CalendarMngt.Entidades.EProvincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioProvincia
    {
        ERespuestaProvincia Insertar(EInProvincia ciudad);

        List<EOutProvincia> Consultar();

        List<EOutProvincia> ConsultarPorNombre(string nombre);

        EOutProvincia ConsultarPorId(long id);
    }
}
