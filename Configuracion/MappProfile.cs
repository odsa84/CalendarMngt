using AutoMapper;
using CalendarMngt.Entidades.EClinica;
using CalendarMngt.Entidades.EDoctor;
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

        }
    }
}
