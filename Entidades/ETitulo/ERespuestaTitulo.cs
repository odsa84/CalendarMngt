using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarMngt.Entidades.ETitulo
{
    public class ERespuestaTitulo
    {

        public ERespuestaTitulo()
        {
            Titulos = new List<EOutTitulo>();
            Error = new EError();
        }

        public List<EOutTitulo> Titulos { get; set; }

        public EError Error { get; set; }
    }
}
