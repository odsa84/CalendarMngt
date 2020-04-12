using AutoMapper;
using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EDoctor;
using CalendarMngt.Entidades.EDoctorEspecialidad;
using CalendarMngt.Entidades.EEspecialidad;
using Microsoft.EntityFrameworkCore;
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

        internal List<ClinicaDoctor> OpeConsultar()
        {
            /*using(var doc = new cita_doctorContext())
            {
                var doctorLst = (from doctor in doc.Doctor
                           .Where(d => (d.Estado == true))
                           select doctor).ToList();

                if(doctorLst.Count == 0)
                {
                    return new List<Doctor>();
                }

                return doctorLst;
            }*/

            using (var doc = new cita_doctorContext())
            {
                var doctorLst = (from cd in doc.ClinicaDoctor
                                 .Include(x => x.IdClinicaNavigation)
                                 .Include(x => x.IdDoctorNavigation)
                                 .ThenInclude(x => x.DoctorEspecialidad)
                                 .ThenInclude(x => x.IdEspecialidadNavigation)
                                 .Include(x => x.IdDoctorNavigation)
                                 .ThenInclude(x => x.DoctorTitulo)
                                 .ThenInclude(x => x.IdTituloNavigation)
                                 .Where(c => (c.IdClinicaNavigation.Estado == true)
                                 && (c.IdDoctorNavigation.Estado == true))
                                 select cd).ToList();

                if (doctorLst.Count() == 0)
                {
                    return new List<ClinicaDoctor>();
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

        internal List<ClinicaDoctor> OpeConsultarPorClinica(long id)
        {
            using (var doc = new cita_doctorContext())
            {
                var doctorLst = (from cd in doc.ClinicaDoctor
                                 .Include(x => x.IdClinicaNavigation)
                                 .Include(x => x.IdDoctorNavigation)
                                 .ThenInclude(x => x.DoctorEspecialidad)
                                 .ThenInclude(x => x.IdEspecialidadNavigation)
                                 .Include(x => x.IdDoctorNavigation)
                                 .ThenInclude(x => x.DoctorTitulo)
                                 .ThenInclude(x => x.IdTituloNavigation)                                 
                                 .Where(c => (c.IdClinicaNavigation.Id == id)
                                 && (c.IdClinicaNavigation.Estado == true)
                                 && (c.IdDoctorNavigation.Estado == true))
                                 select cd).ToList();

                if (doctorLst.Count() == 0)
                {
                    return new List<ClinicaDoctor>();
                }

                return doctorLst;
            }
        }

        internal List<ClinicaDoctor> OpeConsultaAvanzada(long idCiudad, long idEsp)
        {
            using (var clinica = new cita_doctorContext())
            {
                var clinicaLst = (from cli in clinica.ClinicaDoctor
                                      .Include(x => x.IdClinicaNavigation)
                                      .ThenInclude(x => x.IdCiudadNavigation)
                                      .Include(x => x.IdClinicaNavigation)
                                      .ThenInclude(x => x.Calendario)
                                      .ThenInclude(x => x.IdEstadoNavigation)
                                      .Include(x => x.IdDoctorNavigation)
                                      .ThenInclude(x => x.DoctorEspecialidad) //Poner en null IdDoctorNavigation
                                      .ThenInclude(x => x.IdEspecialidadNavigation) //Poner en null DoctorEspecialidad
                                      .Where(x => (x.IdClinicaNavigation.IdCiudadNavigation.Id == idCiudad)
                                        && (x.IdClinicaNavigation.IdCiudadNavigation.Estado == true)
                                        && (x.IdClinicaNavigation.Estado == true)
                                        && (x.IdDoctorNavigation.DoctorEspecialidad
                                                                        .Any(de => de.Id == idEsp))
                                        && (x.IdDoctorNavigation.Estado == true))
                                  select cli).ToList();

                if (clinicaLst.Count() == 0)
                {
                    return new List<ClinicaDoctor>();
                }

                return clinicaLst;
            }
        }
    }
}