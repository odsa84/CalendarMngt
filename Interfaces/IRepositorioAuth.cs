using CalendarMngt.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Interfaces
{
    public interface IRepositorioAuth
    {
        EOutLogin Login(ELogin model);
    }
}
