using CalendarMngt.Entidades.EEspecialidad;
using CalendarMngt.Entidades.ETitulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioEspecialidad
    {
        ERespuestaEspecialidad Insertar(EInEspecialidad inEspecialidad);

        List<EOutEspecialidad> Consultar();

        EOutEspecialidad ConsultarPorId(long id);
    }
}
