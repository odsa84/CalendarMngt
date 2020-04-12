using CalendarMngt.Entidades.EEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia.Modelo
{
    internal class OperacionesProvincia
    {
        internal ERespuestaProvincia OpeInsertar(Provincia provincia)
        {
            ERespuestaProvincia eRespuesta = new ERespuestaProvincia();
            using (var prov = new cita_doctorContext())
            {
                prov.Provincia.Add(provincia);
                try
                {
                    prov.SaveChanges();
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

        internal List<Provincia> OpeConsultar()
        {
            using (var provincia = new cita_doctorContext())
            {
                var provinciaLst = (from prov in provincia.Provincia
                                  .Where(p => (p.Estado == true))
                                 select prov).ToList();


                if (provinciaLst.Count() == 0)
                {
                    return new List<Provincia>();
                }

                return provinciaLst;
            }            
        }

        internal Provincia OpeConsultarPorId(long id)
        {
            using (var provincia = new cita_doctorContext())
            {
                var provinciaLst = (from prov in provincia.Provincia
                                  .Where(prov => (prov.Id == id) && (prov.Estado == true))
                                 select prov);

                if (provinciaLst.ToList().Count() == 0)
                {
                    return null;
                }

                return provinciaLst.ToList()[0];
            }
        }

        internal List<Provincia> OpeConsultarPorNombre(string nombre)
        {
            using (var provincia = new cita_doctorContext())
            {
                var provinciaLst = (from prov in provincia.Provincia
                                  .Where(prov => (prov.Nombre.Equals(nombre)) && (prov.Estado == true))
                                    select prov).ToList();

                if (provinciaLst.Count() == 0)
                {
                    return new List<Provincia>();
                }

                return provinciaLst;
            }
        }
    }
}
