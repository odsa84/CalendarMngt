using CalendarMngt.Entidades.EEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia.Modelo
{
    internal class OperacionesEstado
    {
        internal ERespuestaEstado OpeInsertar(Estado estado)
        {
            ERespuestaEstado eRespuesta = new ERespuestaEstado();
            using (var est = new cita_doctorContext())
            {
                est.Estado.Add(estado);
                try
                {
                    est.SaveChanges();
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

        internal List<Estado> OpeConsultar()
        {
            List<Estado> Lst;
            using (var estado = new cita_doctorContext())
            {
                var estadoLst = (from est in estado.Estado
                                  .Where(c => (c.Activo == true))
                                  select est);

                Lst = estadoLst.ToList();

                if (Lst.Count() == 0)
                {
                    return new List<Estado>();
                }
            }

            return Lst;
        }

        internal Estado OpeConsultarPorId(long id)
        {
            using (var estado = new cita_doctorContext())
            {
                var estadoLst = (from est in estado.Estado
                                  .Where(est => (est.Id == id) && (est.Activo == true))
                                  select est);

                if (estadoLst.ToList().Count() == 0)
                {
                    return null;
                }

                return estadoLst.ToList()[0];
            }
        }
    }
}
