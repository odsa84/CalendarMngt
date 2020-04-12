using CalendarMngt.Entidades.EEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioEstado
    {
        ERespuestaEstado Insertar(EInEstado estado);

        List<EOutEstado> Consultar();

        EOutEstado ConsultarPorId(long id);
    }
}
