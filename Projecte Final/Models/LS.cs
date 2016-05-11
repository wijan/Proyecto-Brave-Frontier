using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class LS
    {
        public int ID { get; set; }
        public int Desc { get; set; }
        public virtual List<Personaje> Personajes { get; set; }
    }
}