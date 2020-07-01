using AutoMapper;
using CalendarMngt.Entidades.ECalendario;
using CalendarMngt.Entidades.ECiudad;
using CalendarMngt.Entidades.ECliente;
using CalendarMngt.Entidades.EClinica;
using CalendarMngt.Entidades.EClinicaDoctor;
using CalendarMngt.Entidades.EDoctor;
using CalendarMngt.Entidades.EEspecialidad;
using CalendarMngt.Entidades.EEstado;
using CalendarMngt.Entidades.EHorasLaborales;
using CalendarMngt.Entidades.EProvincia;
using CalendarMngt.Entidades.ETitulo;
using CalendarMngt.Repositorio.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Configuracion
{
    public class MappProfile : Profile
    {
        public MappProfile()
        {
            //CreateMap<Clase Fuente, Clase Destino>()
            CreateMap<EInClinica, Clinica>().ReverseMap();
            CreateMap<Clinica, EOutClinica>().ReverseMap();

            CreateMap<EInDoctor, Doctor>().ReverseMap();
            CreateMap<Doctor, EOutDoctor>().ReverseMap();

            CreateMap<EInTitulo, Titulo>().ReverseMap();
            CreateMap<Titulo, EOutTitulo>().ReverseMap();

            CreateMap<EInEspecialidad, Especialidad>().ReverseMap();
            CreateMap<Especialidad, EOutEspecialidad>().ReverseMap();

            CreateMap<EInCliente, Cliente>().ReverseMap();
            CreateMap<Cliente, EOutCliente>().ReverseMap();

            CreateMap<EInCalendario, Calendario>().ReverseMap();
            CreateMap<Calendario, EOutCalendario>().ReverseMap();

            CreateMap<EInEstado, Estado>().ReverseMap();
            CreateMap<Estado, EOutEstado>().ReverseMap();

            CreateMap<EInProvincia, Provincia>().ReverseMap();
            CreateMap<Provincia, EOutProvincia>().ReverseMap();

            CreateMap<EInCiudad, Ciudad>().ReverseMap();
            CreateMap<Ciudad, EOutCiudad>().ReverseMap();

            CreateMap<ClinicaDoctor, EOutClinicaDoctor>().ReverseMap();

            CreateMap<EInHoras, HorasLaborales>().ReverseMap();
            CreateMap<HorasLaborales, EOutHoras>().ReverseMap();
        }
    }
}
