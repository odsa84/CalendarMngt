using CalendarMngt.Entidades.ECiudad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioCiudad
    {
        ERespuestaCiudad Insertar(EInCiudad ciudad);

        List<EOutCiudad> Consultar();

        List<EOutCiudad> ConsultarPorNombre(string nombre);

        List<EOutCiudad> ConsultarPorProvincia(long idProvincia);

        EOutCiudad ConsultarPorId(long id);
    }
}
