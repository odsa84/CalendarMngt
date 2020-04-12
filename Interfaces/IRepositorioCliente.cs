using CalendarMngt.Entidades;
using CalendarMngt.Entidades.ECliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioCliente
    {
        ERespuestaCliente Inertar(EInCliente cliente);

        List<EOutCliente> Consultar();

        EOutCliente ConsultarPorId(long id);

        EOutCliente ConsultarPorCedula(string cedula);
    }
}
