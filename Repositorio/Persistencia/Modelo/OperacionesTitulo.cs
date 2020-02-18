using CalendarMngt.Entidades.ETitulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia.Modelo
{
    public class OperacionesTitulo
    {
        internal ERespuestaTitulo OpeInsertar(Titulo titulo)
        {
            ERespuestaTitulo eRespuesta = new ERespuestaTitulo();
            using (var tit = new cita_doctorContext())
            {
                tit.Titulo.Add(titulo);
                try
                {
                    tit.SaveChanges();
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

        internal List<Titulo> OpeConsultar()
        {
            List<Titulo> lst;
            using (var tit = new cita_doctorContext())
            {
                var aux = (from titulo in tit.Titulo select titulo);
                lst = aux.ToList();

                if (lst.Count == 0)
                {
                    return new List<Titulo>();
                }
            }

            return lst;
        }

        internal Titulo OpeConsultarPorId(long id)
        {
            using (var tit = new cita_doctorContext())
            {
                var tituloLst = (from titulo in tit.Titulo
                                  .Where(titulo => (titulo.Id == id))
                                 select titulo);
                if (tituloLst.ToList().Count == 0)
                {
                    return null;
                }

                return tituloLst.ToList()[0];
            }
        }
    }
}
