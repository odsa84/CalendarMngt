using CalendarMngt.Entidades.EHorasLaborales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioHorasLaborales
    {
        void Insertar(EHorasLaborales eHorasLaborales);

        ERespuestaHorasLaborales ConsultarActualizarDisponibilidad(EInHoras inHoras);

        ERespuestaHorasLaborales ActualizarDisponibilidad(EInHoras inHoras);

        List<EOutHoras> ConsultarPorDoctor(long idDoctor);

        List<EOutHoras> ConsultarPorDoctorClinica(long idDoctor, long idClinica);

        List<EOutHoras> ConsultarPorDoctorClinicaFecha(long idDoctor, long idClinica, string fecha);
    }
}
