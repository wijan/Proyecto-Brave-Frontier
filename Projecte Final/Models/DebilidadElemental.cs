using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class DebilidadElemental
    {
        public int ID { get; set; }
        public List<Elemento> Elementos { get; set; }
        public int Porcentaje { get; set; }
    }
}