using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class TipoEsfera
    {
        //Tipo de esfera; stats, crits, heal, def, etc...
        public int ID { get; set; }
        public string Nombre { get; set; }
        public virtual List<Esfera> Esferas { get; set; }
    }
}