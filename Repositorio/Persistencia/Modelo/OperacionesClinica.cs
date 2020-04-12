using AutoMapper;
using CalendarMngt.Entidades;
using CalendarMngt.Entidades.EClinica;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia.Modelo
{
    internal class OperacionesClinica
    {
        private readonly IMapper _mapper;

        public OperacionesClinica(IMapper _mapper)
        {
            this._mapper = _mapper;
        }

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

        internal ERespuesta OpeActualizar(Clinica clinica)
        {
            ERespuesta eRespuesta = new ERespuesta();
            using (var cli = new cita_doctorContext())
            {
                var theClinic = (from cl in cli.Clinica
                                .Where(c => (c.Id == clinica.Id))
                                   select cl).FirstOrDefault();

                theClinic.Nombre = clinica.Nombre;
                theClinic.Telefono = clinica.Telefono;
                theClinic.Email = clinica.Email;
                theClinic.RazonSocial = clinica.RazonSocial;
                theClinic.InfoGeneral = clinica.InfoGeneral;
                theClinic.Direccion = clinica.Direccion;
                theClinic.Referencia = clinica.Referencia;
                theClinic.IdCiudad = clinica.IdCiudad;
                theClinic.IdProvincia = clinica.IdProvincia;
                theClinic.Estado = clinica.Estado;

                try
                {
                    cli.SaveChanges();
                    eRespuesta.Clinicas.Add(_mapper.Map<EOutClinica>(clinica));
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

            eRespuesta.Clinicas.Add(_mapper.Map<EOutClinica>(clinica));

            return eRespuesta;
        }

        internal List<Clinica> OpeConsultar()
        {
            List<Clinica> Lst;
            using (var clinica = new cita_doctorContext())
            {
                var clinicaLst = (from cli in clinica.Clinica
                                  .Include(ciu => ciu.IdCiudadNavigation)
                                  .Include(prov => prov.IdProvinciaNavigation)
                                  .Where(c => (c.Estado == true))
                                  select cli);

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
            using (var clinica = new cita_doctorContext())
            {
                var clinicaLst = (from cli in clinica.Clinica
                                  .Include(ciu => ciu.IdCiudadNavigation)
                                  .Include(prov => prov.IdProvinciaNavigation)
                                  .Where(cli => (cli.IdUsuario == idUsuario) && (cli.Estado == true))
                                  select cli).ToList();

                if (clinicaLst.Count() == 0)
                {
                    return new List<Clinica>();
                }

                return clinicaLst;
            }            
        }

        internal Clinica OpeConsultarPorId(long id)
        {
            using (var clinica = new cita_doctorContext())
            {
                var clinicaLst = (from cli in clinica.Clinica
                                  .Where(cli => (cli.Id == id) && (cli.Estado == true))
                                  select cli);

                if (clinicaLst.ToList().Count() == 0)
                {
                    return null;
                }

                return clinicaLst.ToList()[0];
            }
        }

        internal List<Clinica> OpeConsultaAvanzada(long idCiudad, long idEsp)
        {
            using (var clinica = new cita_doctorContext())
            {
                var clinicaLst = (from cli in clinica.Clinica
                                  .Include(x => x.IdCiudadNavigation)
                                  .Include(x => x.ClinicaDoctor) //Poner en null IdClinicaNavigation
                                  .ThenInclude(x => x.IdDoctorNavigation) //Poner en null ClinicaDoctor
                                  .ThenInclude(x => x.DoctorEspecialidad) //Poner en null IdDoctorNavigation
                                  .ThenInclude(x => x.IdEspecialidadNavigation) //Poner en null DoctorEspecialidad
                                  .Include(x => x.Calendario)
                                  .ThenInclude(x => x.IdEstadoNavigation)
                                  .Where(x => (x.IdCiudadNavigation.Id == idCiudad)
                                    && (x.IdCiudadNavigation.Estado == true)
                                    && (x.ClinicaDoctor.Any(s => s.IdDoctorNavigation.DoctorEspecialidad
                                                                    .Any(de => de.Id == idEsp))
                                    && (x.Estado == true)))
                                  select cli).ToList();                

                /*var clinicList = clinica.Clinica
                            .Where(x => x.ClinicaDoctor.Any(s => s.IdDoctorNavigation.DoctorEspecialidad
                            .Any(de => de.Id == idEsp)) && (cli.IdCiudadNavigation.Id == idCiudad));*/

                if (clinicaLst.Count() == 0)
                {
                    return new List<Clinica>();
                }

                return clinicaLst;
            }
        }        
    }
}
