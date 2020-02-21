using CalendarMngt.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia.Modelo
{
    internal class OperacionesDoctor
    {
        internal ERespuestaDoctor OpeInsertar(Doctor doctor)
        {
            ERespuestaDoctor eRespuesta = new ERespuestaDoctor();
            using(var doc = new cita_doctorContext())
            {
                doc.Doctor.Add(doctor);
                try
                {
                    doc.SaveChanges();
                    eRespuesta.Error.Codigo = "00";
                    eRespuesta.Error.Mensaje = "Ok";
                }
                catch (Exception e)
                {
                    eRespuesta.Error.Codigo = "01";
                    eRespuesta.Error.Mensaje = e.Message;

                    return eRespuesta;
                }
            }

            return eRespuesta;
        }

        internal List<Doctor> OpeConsultar()
        {
            using(var doc = new cita_doctorContext())
            {
                var doctorLst = (from doctor in doc.Doctor
                           .Where(d => (d.Estado == true))
                           select doctor).ToList();

                if(doctorLst.Count == 0)
                {
                    return new List<Doctor>();
                }

                return doctorLst;
            }
        }

        internal Doctor OpeConsultarPorId(long id)
        {
            using(var doc = new cita_doctorContext())
            {
                var doctorLst = (from doctor in doc.Doctor
                                  .Where(d => (d.Id == id) && d.Estado == true)
                                  select doctor).ToList();

                if(doctorLst.Count == 0)
                {
                    return null;
                }

                return doctorLst[0];
            }
        }

        internal List<Doctor> OpeConsultarPorClinica(long id)
        {
            using (var doc = new cita_doctorContext())
            {
                var doctorLst = (from cd in doc.ClinicaDoctor
                                 join d in doc.Doctor on cd.IdDoctor equals d.Id
                                 where cd.IdClinicaNavigation.Id == id && cd.IdClinicaNavigation.Estado == true
                                 && d.Estado == true
                                 select d).ToList();
                
                if (doctorLst.Count() == 0)
                {
                    return new List<Doctor>();
                }

                return doctorLst;
            }
        }
    }
}