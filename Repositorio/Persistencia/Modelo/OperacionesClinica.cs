using CalendarMngt.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia.Modelo
{
    internal class OperacionesClinica
    {
        internal ERespuesta OpeInsertar(Clinica clinica)
        {
            ERespuesta eRespuesta = new ERespuesta();
            using (var cli = new cita_doctorContext())
            {
                cli.Clinica.Add(clinica);
                try
                {
                    cli.SaveChanges();
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

        internal List<Clinica> OpeConsultar()
        {
            List<Clinica> Lst;
            using (var clinica = new cita_doctorContext())
            {
                var clinicaLst = (from cli in clinica.Clinica select cli);

                Lst = clinicaLst.ToList();

                if (Lst.Count() == 0)
                {
                    return new List<Clinica>();
                }
            }

            return Lst;
        }

        internal List<Clinica> OpeConsultarPorUsuario(string idUsuario)
        {
            List<Clinica> Lst;
            using (var clinica = new cita_doctorContext())
            {
                var clinicaLst = (from cli in clinica.Clinica
                                  .Where(cli => (cli.IdUsuario == idUsuario))
                                  select cli);

                Lst = clinicaLst.ToList();

                if (Lst.Count() == 0)
                {
                    return new List<Clinica>();
                }
            }

            return Lst;
        }

        internal Clinica OpeConsultarPorId(long id)
        {
            using (var clinica = new cita_doctorContext())
            {
                var clinicaLst = (from cli in clinica.Clinica
                                  .Where(cli => (cli.Id == id))
                                  select cli);

                if (clinicaLst.ToList().Count() == 0)
                {
                    return null;
                }

                return clinicaLst.ToList()[0];
            }
        }
    }
}
