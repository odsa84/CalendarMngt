using CalendarMngt.Entidades.ETitulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioTitulo
    {
        ERespuestaTitulo Insertar(EInTitulo inTitulo);

        List<EOutTitulo> Consultar();

        EOutTitulo ConsultarPorId(long id);
    }
}
