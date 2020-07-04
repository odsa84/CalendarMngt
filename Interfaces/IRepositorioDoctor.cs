using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EClinicaDoctor;
using CalendarMngt.Entidades.EDoctor;
using CalendarMngt.Repositorio.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioDoctor
    {
        ERespuestaDoctor Insertar(EInDoctor inDoctor);

        List<EOutClinicaDoctor> Consultar();

        EOutDoctor ConsultarPorId(long id);

        List<EOutClinicaDoctor> ConsultarPorClinica(long idClinica);

        List<EOutClinicaDoctor> ConsultaAvanzada(long idCiudad, long idEsp);

        List<EOutClinicaDoctor> ConsultaPorCiudadClinicaEspecialidad(long idCiudad, long idClinica, long idEsp);

    }
}
