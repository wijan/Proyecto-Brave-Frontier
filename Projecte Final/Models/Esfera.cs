using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Esfera:Objeto
    {
        //Esfera
        public int TipoID { get; set; }
        public virtual TipoEsfera TipoEsfera { get; set; }
        public int EfectoID { get; set; }
        public virtual EfectoEsfera Efecto { get; set; }
    }
}