using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EClinica;
using CalendarMngt.Entidades.EClinicaDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioClinica
    {
        ERespuesta Inertar(EInClinica inClinica);

        ERespuesta Actualizar(EInClinica inClinica);

        List<EOutClinica> Consultar();

        List<EOutClinica> ConsultarPorUsuario(string idUsuario);

        List<EOutClinica> ConsultarPorDoctor(long idDoctor);

        EOutClinica ConsultarPorId(long id);

        List<EOutClinica> ConsultaAvanzada(long idCiudad, long idEsp);

        List<EOutClinica> ConsultaAvanzadaPorCiudad(long idCiudad);

        List<EOutClinica> ConsultaAvanzadaPorEspecialidad(long idEsp);
    }
}
