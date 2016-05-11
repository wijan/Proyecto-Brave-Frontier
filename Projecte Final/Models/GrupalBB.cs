using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class GrupalBB
    {
        //Si la habilidad es grupal o individual.
        public int ID { get; set; }
        public String Nombre { get; set; }
        public virtual List<BB> BBGrupal { get; set; }
    }
}