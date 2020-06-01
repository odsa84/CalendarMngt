using AutoMapper;
using CalendarMngt.Entidades.ECalendario;
using CalendarMngt.Entidades.ECliente;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia.Modelo
{
    internal class OperacionesCalendario
    {
        private readonly IMapper _mapper;

        public OperacionesCalendario(IMapper _mapper)
        {
            this._mapper = _mapper;
        }

        internal ERespuestaCalendario OpeInsertar(Calendario calendario)
        {
            ERespuestaCalendario eRespuesta = new ERespuestaCalendario();
            using (var cal = new cita_doctorContext())
            {
                cal.Calendario.Add(calendario);
                try
                {
                    cal.SaveChanges();
                    eRespuesta.Calendarios.Add(_mapper.Map<EOutCalendario>(calendario));
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

        internal ERespuestaCalendario OpeActualizar(Calendario calendario)
        {
            ERespuestaCalendario eRespuesta = new ERespuestaCalendario();
            using (var cal = new cita_doctorContext())
            {
                var theCalendar = (from cl in cal.Calendario
                                .Where(c => (c.Id == calendario.Id))
                                 select cl).FirstOrDefault();

                theCalendar.IdDoctor = calendario.IdDoctor;
                theCalendar.IdEstado = calendario.IdEstado;
                theCalendar.Sintomas = calendario.Sintomas;
                theCalendar.Diagnostico = calendario.Diagnostico;
                theCalendar.Indicaciones = calendario.Indicaciones;
                theCalendar.IdDoctor = calendario.IdDoctor;
                theCalendar.IdEstado = calendario.IdEstado;

                try
                {
                    cal.SaveChanges();
                    eRespuesta.Calendarios.Add(_mapper.Map<EOutCalendario>(calendario));
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

            eRespuesta.Calendarios.Add(_mapper.Map<EOutCalendario>(calendario));

            return eRespuesta;
        }

        internal List<Cliente> OpeConsultarClientes()
        {
            List<Cliente> Lst;
            using (var calendario = new cita_doctorContext())
            {
                var calendarioLst = (from cal in calendario.Calendario
                                     .Include(cli => cli.IdClienteNavigation)
                                     select(cal.IdClienteNavigation)).Distinct();

                Lst = calendarioLst.ToList();

                if (Lst.Count() == 0)
                {
                    return new List<Cliente>();
                }
            }

            return Lst;
        }

        internal List<Calendario> OpeConsultar()
        {
            using (var calendario = new cita_doctorContext())
            {
                var calendarioLst = (from cal in calendario.Calendario
                                     .Include(cli => cli.IdClienteNavigation)
                                     .Include(cli => cli.IdClinicaNavigation)
                                     .Include(cli => cli.IdDoctorNavigation)
                                     .Include(cli => cli.IdEstadoNavigation)
                                     select cal).ToList();


                if (calendarioLst.Count() == 0)
                {
                    return new List<Calendario>();
                }

                return calendarioLst;
            }            
        }

        internal List<Calendario> OpeConsultarAgendadas()
        {
            List<Calendario> Lst;
            using (var calendario = new cita_doctorContext())
            {
                var hoy = DateTime.Now;
                var calendarioLst = (from cal in calendario.Calendario
                                     .Where(cal => (cal.IdEstado == 1) && (cal.FinFechaHora >= hoy))
                                     select cal);

                Lst = calendarioLst.ToList();

                if (Lst.Count() == 0)
                {
                    return new List<Calendario>();
                }
            }

            return Lst;
        }

        internal Calendario OpeConsultarPorId(long id)
        {
            using (var calendario = new cita_doctorContext())
            {
                var clienteLst = (from cal in calendario.Calendario
                                  .Include(cli => cli.IdClienteNavigation)
                                  .Include(cli => cli.IdClinicaNavigation)
                                  .Include(cli => cli.IdDoctorNavigation)
                                  .Include(cli => cli.IdEstadoNavigation)
                                  .Where(cal => (cal.Id == id))
                                  select cal);

                if (clienteLst.ToList().Count() == 0)
                {
                    return null;
                }

                return clienteLst.ToList()[0];
            }
        }

        internal List<Calendario> OpeConsultarPorClinica(long idClinica)
        {
            using (var calendario = new cita_doctorContext())
            {
                var calendarioLst = (from cal in calendario.Calendario
                                     .Include(cli => cli.IdClienteNavigation)
                                     .Include(cli => cli.IdClinicaNavigation)
                                     .Include(cli => cli.IdDoctorNavigation)
                                     .Include(cli => cli.IdEstadoNavigation)
                                     .Where(cal => (cal.IdClinica == idClinica))
                                     select cal).ToList();


                if (calendarioLst.Count() == 0)
                {
                    return new List<Calendario>();
                }

                return calendarioLst;
            }            
        }

        internal List<Calendario> OpeConsultarPorClinicaAgendada(long idClinica)
        {
            using (var calendario = new cita_doctorContext())
            {
                var hoy = DateTime.Now;
                var calendarioLst = (from cal in calendario.Calendario
                                     .Include(cli => cli.IdClienteNavigation)
                                     .Include(cli => cli.IdClinicaNavigation)
                                     .Include(cli => cli.IdDoctorNavigation)
                                     .Include(cli => cli.IdEstadoNavigation)
                                     .Where(cal => (cal.IdClinica == idClinica)
                                     && (cal.IdEstado == 1) 
                                     && (cal.FinFechaHora >= hoy))
                                     select cal).ToList();


                if (calendarioLst.Count() == 0)
                {
                    return new List<Calendario>();
                }

                return calendarioLst;
            }
        }

        internal List<Calendario> OpeConsultarPorDoctor(long idDoctor)
        {
            using (var calendario = new cita_doctorContext())
            {
                var calendarioLst = (from cal in calendario.Calendario
                                     .Include(cli => cli.IdClienteNavigation)
                                     .Include(cli => cli.IdClinicaNavigation)
                                     .Include(cli => cli.IdDoctorNavigation)
                                     .Include(cli => cli.IdEstadoNavigation)
                                     .Where(cal => (cal.IdDoctor == idDoctor))
                                     select cal).ToList();


                if (calendarioLst.Count() == 0)
                {
                    return new List<Calendario>();
                }

                return calendarioLst;
            }            
        }

        internal List<Calendario> OpeConsultarPorCliente(long idCliente)
        {
            using (var calendario = new cita_doctorContext())
            {
                var calendarioLst = (from cal in calendario.Calendario
                                     .Include(cli => cli.IdClienteNavigation)
                                     .Include(cli => cli.IdClinicaNavigation)
                                     .Include(cli => cli.IdDoctorNavigation)
                                     .Include(cli => cli.IdEstadoNavigation)
                                     .Where(cal => (cal.IdCliente == idCliente))
                                     select cal).ToList();


                if (calendarioLst.Count() == 0)
                {
                    return new List<Calendario>();
                }

                return calendarioLst;
            }            
        }

        internal List<Calendario> OpeConsultarPorEstado(long idEstado)
        {
            using (var calendario = new cita_doctorContext())
            {
                var calendarioLst = (from cal in calendario.Calendario
                                     .Include(cli => cli.IdClienteNavigation)
                                     .Include(cli => cli.IdClinicaNavigation)
                                     .Include(cli => cli.IdDoctorNavigation)
                                     .Include(cli => cli.IdEstadoNavigation)
                                     .Where(cal => (cal.IdEstado == idEstado))
                                     select cal).ToList();

                if (calendarioLst.Count() == 0)
                {
                    return new List<Calendario>();
                }

                return calendarioLst;
            }            
        }

        internal List<Calendario> OpeConsultarPorFecha(DateTime fecha)
        {
            using (var calendario = new cita_doctorContext())
            {
                var calendarioLst = (from cal in calendario.Calendario
                                     .Include(cli => cli.IdClienteNavigation)
                                     .Include(cli => cli.IdClinicaNavigation)
                                     .Include(cli => cli.IdDoctorNavigation)
                                     .Include(cli => cli.IdEstadoNavigation)
                                     .Where(cal => (cal.InicioFechaHora == fecha))
                                     select cal).ToList();

                if (calendarioLst.Count() == 0)
                {
                    return new List<Calendario>();
                }

                return calendarioLst;
            }            
        }
    }
}
