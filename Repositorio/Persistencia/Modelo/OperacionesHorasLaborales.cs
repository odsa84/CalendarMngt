using AutoMapper;
using CalendarMngt.Entidades.EHorasLaborales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Repositorio.Persistencia.Modelo
{
    public class OperacionesHorasLaborales
    {
        private readonly IMapper _mapper;

        public OperacionesHorasLaborales(IMapper _mapper)
        {
            this._mapper = _mapper;
        }

        public void OpeInsertar(HorasLaborales horasLaborales)
        {
            //ERespuestaHorasLaborales eRespuesta = new ERespuestaHorasLaborales();
            using (var hl = new cita_doctorContext())
            {
                hl.HorasLaborales.Add(horasLaborales);
                try
                {
                    hl.SaveChanges();
                    /*eRespuesta.Doctores.Add(_mapper.Map<EOutDoctor>(doctor));
                    eRespuesta.Error.Codigo = "00";
                    eRespuesta.Error.Mensaje = "Ok";*/
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }

        public List<HorasLaborales> OpeConsultarPorDoctor(long idDoctor)
        {
            using (var hl = new cita_doctorContext())
            {
                var hlList = (from cd in hl.HorasLaborales
                                 .Where(c => (c.IdDoctorNavigation.Id == idDoctor))
                                 select cd).ToList();

                if (hlList.Count() == 0)
                {
                    return new List<HorasLaborales>();
                }

                return hlList;
            }
        }

        public List<HorasLaborales> OpeConsultarPorDoctorClinica(long idDoctor, long idClinica)
        {
            using (var hl = new cita_doctorContext())
            {
                var hlList = (from cd in hl.HorasLaborales
                                 .Where(c => (c.IdDoctorNavigation.Id == idDoctor)
                                 && (c.IdClinicaNavigation.Id == idClinica))
                              select cd).ToList();

                if (hlList.Count() == 0)
                {
                    return new List<HorasLaborales>();
                }

                return hlList;
            }
        }

        public void OpeDelete(List<HorasLaborales> toDelete)
        {
            using (var hl = new cita_doctorContext())
            {
                hl.HorasLaborales.RemoveRange(toDelete);
                try
                {
                    hl.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }
    }
}
