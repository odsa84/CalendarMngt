using CalendarMngt.Entidades.ECiudad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia.Modelo
{
    internal class OperacionesCiudad
    {
        internal ERespuestaCiudad OpeInsertar(Ciudad ciudad)
        {
            ERespuestaCiudad eRespuesta = new ERespuestaCiudad();
            using (var ciu = new cita_doctorContext())
            {
                ciu.Ciudad.Add(ciudad);
                try
                {
                    ciu.SaveChanges();
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

        internal List<Ciudad> OpeConsultar()
        {
            List<Ciudad> Lst;
            using (var ciudad = new cita_doctorContext())
            {
                var ciudadLst = (from ciu in ciudad.Ciudad
                                  .Where(c => (c.Estado == true))
                                 select ciu);

                Lst = ciudadLst.ToList();

                if (Lst.Count() == 0)
                {
                    return new List<Ciudad>();
                }
            }

            return Lst;
        }

        internal List<Ciudad> OpeConsultarPorNombre(string nombre)
        {
            using (var ciudad = new cita_doctorContext())
            {
                var ciudadLst = (from ciu in ciudad.Ciudad
                                  .Where(ciu => (ciu.Nombre.Equals(nombre)) && (ciu.Estado == true))
                                select ciu).ToList();


                if (ciudadLst.Count() == 0)
                {
                    return new List<Ciudad>();
                }

                return ciudadLst;
            }            
        }

        internal List<Ciudad> OpeConsultarPorProvincia(long idProvincia)
        {
            using (var ciudad = new cita_doctorContext())
            {
                var ciudadLst = (from ciu in ciudad.Ciudad
                                  .Where(ciu => (ciu.IdProvincia == idProvincia) && (ciu.Estado == true))
                                 select ciu).ToList();


                if (ciudadLst.Count() == 0)
                {
                    return new List<Ciudad>();
                }

                return ciudadLst;
            }
        }

        internal Ciudad OpeConsultarPorId(long id)
        {
            using (var ciudad = new cita_doctorContext())
            {
                var ciudadLst = (from ciu in ciudad.Ciudad
                                  .Where(ciu => (ciu.Id == id) && (ciu.Estado == true))
                                 select ciu);

                if (ciudadLst.ToList().Count() == 0)
                {
                    return null;
                }

                return ciudadLst.ToList()[0];
            }
        }
    }
}
