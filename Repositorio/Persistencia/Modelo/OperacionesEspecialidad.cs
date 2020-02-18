using CalendarMngt.Entidades.EEspecialidad;
using CalendarMngt.Entidades.ETitulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia.Modelo
{
    public class OperacionesEspecialidad
    {
        internal ERespuestaEspecialidad OpeInsertar(Especialidad especialidad)
        {
            ERespuestaEspecialidad eRespuesta = new ERespuestaEspecialidad();
            using (var esp = new cita_doctorContext())
            {
                esp.Especialidad.Add(especialidad);
                try
                {
                    esp.SaveChanges();
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

        internal List<Especialidad> OpeConsultar()
        {
            List<Especialidad> lst;
            using (var tit = new cita_doctorContext())
            {
                var aux = (from especialidad in tit.Especialidad select especialidad);
                lst = aux.ToList();

                if (lst.Count == 0)
                {
                    return new List<Especialidad>();
                }
            }

            return lst;
        }

        internal Especialidad OpeConsultarPorId(long id)
        {
            using (var esp = new cita_doctorContext())
            {
                var espLst = (from especialidad in esp.Especialidad
                                  .Where(especialidad => (especialidad.Id == id))
                                 select especialidad);
                if (espLst.ToList().Count == 0)
                {
                    return null;
                }

                return espLst.ToList()[0];
            }
        }
    }
}
