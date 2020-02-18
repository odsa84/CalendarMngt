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
            List<Doctor> lst;
            using(var doc = new cita_doctorContext())
            {
                var aux = (from doctor in doc.Doctor select doctor);
                lst = aux.ToList();

                if(lst.Count == 0)
                {
                    return new List<Doctor>();
                }
            }

            return lst;
        }

        internal Doctor OpeConsultarPorId(long id)
        {
            using(var doc = new cita_doctorContext())
            {
                var doctorLst = (from doctor in doc.Doctor
                                  .Where(doctor => (doctor.Id == id))
                                  select doctor);
                if(doctorLst.ToList().Count == 0)
                {
                    return null;
                }

                return doctorLst.ToList()[0];
            }
        }
    }
}