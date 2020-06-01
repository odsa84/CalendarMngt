using CalendarMngt.Entidades.ECalendario;
using CalendarMngt.Entidades.ECliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioCalendario
    {
        ERespuestaCalendario Inertar(EInCalendario calendario);

        ERespuestaCalendario Actualizar(EInCalendario calendario);

        List<EOutCalendario> Consultar();

        List<EOutCalendario> ConsultarAgendadas();

        List<EOutCliente> ConsultarClientes();

        EOutCalendario ConsultarPorId(long id);

        List<EOutCalendario> ConsultarPorDoctor(long idDoctor);

        List<EOutCalendario> ConsultarPorClinica(long idClinica);

        List<EOutCalendario> ConsultarPorClinicaAgendada(long idClinica);

        List<EOutCalendario> ConsultarPorCliente(long idCliente);

        List<EOutCalendario> ConsultarPorEstado(long idEstado);

        List<EOutCalendario> ConsultarPorFecha(DateTime fecha);
    }
}
