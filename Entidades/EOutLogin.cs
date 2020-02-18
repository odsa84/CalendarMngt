using CalendarMngt.Repositorio.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades
{
    public class EOutLogin
    {
        public string Token { get; set; }
        
        public DateTime ExpiresIn { get; set; }

        public ApplicationUser Usuario { get; set; }
    }
}
